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
    public class ClassicWithModificationMultiThreadingOldBackup : IAlgorithm
    {
        public InformationSystem InformationSystem { set; get; }
        private TaskScheduler scheduler;

        public ClassicWithModificationMultiThreadingOldBackup()
        {
            scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        public AlgorithmType Type
        {
            get { return AlgorithmType.ClassicWithModification; }
        }

        public event NotifyAboutIterationEnd Notify;

        public void Generate()
        {
            ConcurrentBag<AssociationRule> result = new ConcurrentBag<AssociationRule>();

            var task = Task.Factory.StartNew(() =>
            {
                int index = 0;
                foreach (Row row in InformationSystem.Rows)
                {
                    var counter = Task.Factory.StartNew(() =>
                    {
                        lock (locker)
                        {
                            Notify(++index);
                            if (index == InformationSystem.Rows.Count)
                            {
                                Rules(result);
                            }
                        }
                    }, CancellationToken.None, TaskCreationOptions.None, scheduler);

                    #region algorithm body

                    IList<Row> separatedRows;

                    List<Attribute> attrs = row.Attributes.Where(x =>
                       InformationSystem.DecisionAttributes[x.Name] == true).Select(x => x).ToList();
                    foreach (Attribute decisionAttribute in attrs)
                    {
                        Condition decisionAttributeInResult = new Condition(decisionAttribute);
                        IList<Condition> conditions = new List<Condition>();

                        separatedRows =
                            InformationSystem.Rows.
                                GetRowsSeparatedByAttribute
                                (row,
                                 decisionAttribute);

                        IList<Row> separatedRowsCopy = separatedRows;
                        int alreadyCovered = 0;
                        int minimumNumberOfRowsToSeparate
                                = System.Convert.ToInt32(System.Math
                                .Ceiling((1 - InformationSystem.Alpha) * separatedRows.Count));

                        while (alreadyCovered < minimumNumberOfRowsToSeparate)
                        {
                            IList<Subset> subsets = separatedRowsCopy.CreateSubsets(row, decisionAttribute, true);

                            string subsetWithMaxElements = subsets
                                        .OrderByDescending(x => x.Quotient)
                                        .Select(x => x.Name)
                                        .First();

                            alreadyCovered += subsets.Where(
                                    x => x.Name == subsetWithMaxElements)
                                    .Select(x => x.Count)
                                    .First();

                            conditions.Add(new Condition(
                                row.Attributes.Where(x => x.Name == subsetWithMaxElements).First()));

                            separatedRowsCopy = separatedRowsCopy
                                .RemoveElementsFromAlreadyCoveredSubsets
                                (subsets, subsetWithMaxElements);
                        }

                        var rule = new AssociationRule(conditions, decisionAttributeInResult);

                        var supportAndConfidence = rule.CalculateSupportAndConfidence(InformationSystem.Rows);
                        rule.Support = supportAndConfidence.Item1.Round();
                        rule.Confidence = supportAndConfidence.Item2.Round();

                        result.Add(rule);
                        alreadyCovered = 0;
                        separatedRows = null;
                    }

                    #endregion
                }

                return result;
            });
        }

        private static readonly object locker = new object();
        public event ReturnGeneratedRules Rules;

        public Dictionary<string, int> Weights
        {
            get;
            set;
        }


        public event ReturnPercentOfSeparatedRows SeparatedRows;
    }
}
