/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Extensions;
using PartialAssociationRules.Domain.Gui;

namespace PartialAssociationRules.Domain.Algorithms
{
    public class ClassicWithWeightsMultiThreading : IAlgorithm
    {
        public InformationSystem InformationSystem { set; get; }

        public AlgorithmType Type
        {
            get { return AlgorithmType.ClassicWithWeights; }
        }

        public event NotifyAboutIterationEnd Notify;

        private TaskScheduler guiScheduler;

        public ClassicWithWeightsMultiThreading()
        {
            guiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private static readonly object locker = new object();

        public void Generate()
        {
            ConcurrentBag<AssociationRule> result = new ConcurrentBag<AssociationRule>();
            ConcurrentBag<AlgorithmProgressExecution> algExecution = new ConcurrentBag<AlgorithmProgressExecution>();
            ConcurrentBag<Task> tasks = new ConcurrentBag<Task>();
            int index = 0;

            foreach (Row singleRow in InformationSystem.Rows)
            {
                decimal gamma = InformationSystem.Gamma;
                decimal alpha = InformationSystem.Alpha;

                List<Attribute> attrs = singleRow.Attributes.Where(x =>
                InformationSystem.DecisionAttributes[x.Name] == true).Select(x => x).ToList();
                foreach (Attribute decisionAttribute in attrs)
                {
                    var localCopy = System.Tuple.Create<Row, Attribute>(singleRow, decisionAttribute);
                    Task<AssociationRule> task = Task.Factory.StartNew<AssociationRule>((variables) =>
                {
                    var decAttr = ((System.Tuple<Row, Attribute>)variables).Item2;
                    var row = ((System.Tuple<Row, Attribute>)variables).Item1;

                    #region algorithm body

                    IList<Row> separatedRows;
                    Condition decisionAttributeInResult = new Condition(decAttr);
                    //List<int> deltas = new List<int>();
                    IList<Condition> conditions = new List<Condition>();

                    separatedRows = InformationSystem.Rows.GetRowsSeparatedByAttribute(row, decAttr);

                    decimal M = System.Math.Ceiling(separatedRows.Count() * (1 - alpha));
                    decimal N = System.Math.Ceiling(separatedRows.Count() * (1 - gamma));

                    IList<Row> separatedRowsCopy = separatedRows;
                    int alreadyCovered = 0;

                    AlgorithmProgressExecution progress = new AlgorithmProgressExecution()
                    {
                        DecisionAttribute = decAttr
                    };

                    while (alreadyCovered < M)
                    {
                        AlgorithmIteration iteration = new AlgorithmIteration()
                        {
                            IterationNumber = progress.Iterations.Count() + 1,
                            ObjectsToCover = separatedRowsCopy.Count
                        };

                        IList<Subset> subsets = separatedRowsCopy.CreateSubsets(row, decAttr, false);

                        //here we must calculate for each subset its quotient: w(fj)/min(|U(T,r,d,fj)\D|,N-|D|)
                        //where D is output set, empty at the beginning
                        Dictionary<Subset, decimal> quotients = new Dictionary<Subset, decimal>();
                        subsets.Where(x => x.Count > 0).ToList().ForEach(subset =>
                        {
                            quotients[subset] =
                           System.Convert.ToDecimal(Weights.Where(x => x.Key == subset.Name)
                           .Select(x => x.Value).First()) /
                                System.Math.Min(subset.Rows.Count, N - alreadyCovered);
                        });

                        string subsetWithMinimumQuotient = quotients
                             .OrderBy(x => x.Value)
                              .Select(x => x.Key)
                              .First()
                              .Name;

                        var elementsQuantityInSelectedSubset= subsets.Where(x => x.Name == subsetWithMinimumQuotient)
                            .Select(x => x.Count).First();

                        alreadyCovered += elementsQuantityInSelectedSubset;
                        //int elementsQuantityInSelectedSubset = subsets.Where(
                        //      x => x.Name == subsetWithMinimumQuotient)
                        //      .Select(x => x.Count)
                        //      .First();
                        iteration.ObjectsCovered = elementsQuantityInSelectedSubset;
                        //deltas.Add(elementsQuantityInSelectedSubset);

                        //alreadyCovered += elementsQuantityInSelectedSubset;

                        conditions.Add(new Condition(
                            row.Attributes.Where(x => x.Name == subsetWithMinimumQuotient).First()));

                        separatedRowsCopy = separatedRowsCopy
                            .RemoveElementsFromAlreadyCoveredSubsets(subsets, subsetWithMinimumQuotient);

                        progress.Iterations.Add(iteration);
                    }

                    var rule = new AssociationRule(conditions, decisionAttributeInResult);

                    var supportAndConfidence = rule.CalculateSupportAndConfidence(InformationSystem.Rows);
                    rule.Support = supportAndConfidence.Item1.Round();
                    rule.Confidence = supportAndConfidence.Item2.Round();

                    //var upperLowerBound = rule.CalculateUpperAndLowerBound(System.Convert.ToInt32(M), deltas);
                    rule.UpperBound = -1;// upperLowerBound.Item1;
                    rule.LowerBound = -1;//upperLowerBound.Item2;

                    algExecution.Add(progress);

                    #endregion

                    return rule;
                }, localCopy, CancellationToken.None, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
                    task.ContinueWith(x =>
                     {
                         if (x.Status == TaskStatus.RanToCompletion)
                         {
                             lock (locker)
                             {
                                 result.Add(((Task<AssociationRule>)x).Result);
                                 Notify(++index);
                             }
                         }
                     }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, guiScheduler);

                    tasks.Add(task);
                }
            }

            var finish = Task.Factory.ContinueWhenAll(tasks.ToArray(), x =>
            {
                SeparatedRows(algExecution);
                Rules(result);
            }, CancellationToken.None, TaskContinuationOptions.None, guiScheduler);
        }

        public event ReturnGeneratedRules Rules;

        public Dictionary<string, int> Weights
        {
            get;
            set;
        }


        public event ReturnPercentOfSeparatedRows SeparatedRows;
    }
}
