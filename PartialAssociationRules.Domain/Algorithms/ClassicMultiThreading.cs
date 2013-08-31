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
    /// <summary>
    /// Classic algorithm for constructing partial association rules.
    /// </summary>
    public class ClassicMultiThreading : IAlgorithm
    {
        public InformationSystem InformationSystem { set; get; }
        private TaskScheduler guiScheduler;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ClassicMultiThreading()
        {
            guiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        /// <summary>
        /// Construct (partial) association rules.
        /// </summary>
        public void Generate()
        {
            ConcurrentBag<AssociationRule> result = new ConcurrentBag<AssociationRule>();

            ConcurrentBag<Task> tasks = new ConcurrentBag<Task>();
            ConcurrentBag<AlgorithmProgressExecution> algExecution = new ConcurrentBag<AlgorithmProgressExecution>();
            int index = 0;
            foreach (Row singleRow in InformationSystem.Rows)
            {
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

                        IList<Row> separatedRows = null;
                        Condition decisionAttributeInResult = new Condition(decAttr);
                        IList<Condition> conditions = new List<Condition>();

                        separatedRows =
                            InformationSystem.Rows.GetRowsSeparatedByAttribute(row, decAttr);

                        IList<Row> separatedRowsCopy = separatedRows;
                        int alreadyCovered = 0;
                        List<int> deltas = new List<int>();
                        int minimumNumberOfRowsToSeparate
                                = System.Convert.ToInt32(System.Math
                                .Ceiling((1 - InformationSystem.Alpha) * separatedRows.Count));

                        AlgorithmProgressExecution progress = new AlgorithmProgressExecution()
                        {
                            DecisionAttribute = decAttr
                        };

                        while (alreadyCovered < minimumNumberOfRowsToSeparate)
                        {
                            AlgorithmIteration iteration = new AlgorithmIteration()
                            {
                                IterationNumber = progress.Iterations.Count() + 1,
                                ObjectsToCover = separatedRowsCopy.Count
                            };

                            IList<Subset> subsets = separatedRowsCopy.CreateSubsets(row, decAttr, false);

                            string subsetWithMaxElements = subsets
                                        .OrderByDescending(x => x.Count)
                                        .Select(x => x.Name)
                                        .First();

                            int elementsQuantityInSelectedSubset = subsets.Where(
                                    x => x.Name == subsetWithMaxElements)
                                    .Select(x => x.Count)
                                    .First();

                            iteration.ObjectsCovered = elementsQuantityInSelectedSubset;
                            deltas.Add(elementsQuantityInSelectedSubset);

                            alreadyCovered += elementsQuantityInSelectedSubset;

                            conditions.Add(new Condition(row.Attributes
                                .Where(x => x.Name == subsetWithMaxElements).First()));

                            separatedRowsCopy = separatedRowsCopy
                                .RemoveElementsFromAlreadyCoveredSubsets
                                (subsets, subsetWithMaxElements);

                            progress.Iterations.Add(iteration);
                        }

                        var rule = new AssociationRule(conditions, decisionAttributeInResult);

                        var supportAndConfidence = rule.CalculateSupportAndConfidence(InformationSystem.Rows);
                        rule.Support = supportAndConfidence.Item1.Round();
                        rule.Confidence = supportAndConfidence.Item2.Round();

                        var upperLowerBound = rule.CalculateUpperAndLowerBound(minimumNumberOfRowsToSeparate, deltas);
                        rule.UpperBound = upperLowerBound.Item1;
                        rule.LowerBound = upperLowerBound.Item2;

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

        /// <summary>
        /// Type of the algorithm.
        /// </summary>
        public AlgorithmType Type
        {
            get { return AlgorithmType.Classic; }
        }

        public event NotifyAboutIterationEnd Notify;
        public event ReturnGeneratedRules Rules;
        private static readonly object locker = new object();

        public Dictionary<string, int> Weights
        {
            get;
            set;
        }


        public event ReturnPercentOfSeparatedRows SeparatedRows;
    }
}
