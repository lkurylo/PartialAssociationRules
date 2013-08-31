/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Extensions;
using PartialAssociationRules.Domain.Gui;

namespace PartialAssociationRules.Domain.Algorithms
{
    public class ClassicWithModification : IAlgorithm
    {
        public InformationSystem InformationSystem { set; get; }
        private IList<Row> separatedRows;

        //public IEnumerable<RuleCount> Generate()
        //{
        //    int associationsRulesToGenerate = InformationSystem.Rows.Count * InformationSystem.Rows[0].Attributes.Count;
        //    IList<AssociationRule> result = new List<AssociationRule>(associationsRulesToGenerate);

        //    foreach (Row row in InformationSystem.Rows)
        //    {
        //        IList<Condition> conditions = new List<Condition>();

        //        foreach (Attribute decisionAttribute in row.Attributes) //each attribute is treated as a decision attribute
        //        {
        //            Condition decisionAttributeInResult = new Condition(decisionAttribute);

        //            separatedRows = InformationSystem.Rows.GetRowsSeparatedByAttribute(row, decisionAttribute);

        //            IList<Row> separatedRowsCopy = separatedRows;
        //            int alreadyCovered = 0;
        //            while (alreadyCovered < MinimumNumberOfRowsToSeparate)
        //            {
        //                IList<Subset> subsets = separatedRowsCopy.CreateSubsets(row, decisionAttribute);

        //                string subsetWithMaxElements = subsets
        //                     .OrderByDescending(x => x.Count)
        //                      .Select(x => x.Name)
        //                      .First();

        //                alreadyCovered += subsets.Where(x => x.Name == subsetWithMaxElements).Select(x => x.Count).First();
        //                conditions.Add(new Condition(
        //                    row.Attributes.Where(x => x.Name == subsetWithMaxElements).First()));

        //                separatedRowsCopy = separatedRowsCopy
        //                    .RemoveElementsFromAlreadyCoveredSubsets(subsets, subsetWithMaxElements);
        //            }

        //            result.Add(new AssociationRule(conditions, decisionAttributeInResult));
        //            alreadyCovered = 0;
        //        }
        //    }

        //    var distinctRules =
        //                       result.GroupBy(
        //                       x => x,
        //                      (rule, count) => new RuleCount
        //                      {
        //                          Rule = rule,
        //                          Count = count.Count()
        //                      },
        //                       new AssociationRulesComparer());

        //    return distinctRules;
        //}

        public AlgorithmType Type
        {
            get { return AlgorithmType.ClassicWithModification; }
        }

        private int MinimumNumberOfRowsToSeparate
        {
            get
            {
                return System.Convert.ToInt32(System.Math.Ceiling((1 - InformationSystem.Alpha) * separatedRows.Count));
            }
        }

        public event NotifyAboutIterationEnd Notify;

        public void Generate()
        {
            ConcurrentBag<AssociationRule> result = new ConcurrentBag<AssociationRule>();

            foreach (Row row in InformationSystem.Rows)
            {
                List<Attribute> attrs = row.Attributes.Where(x =>
                       InformationSystem.DecisionAttributes[x.Name] == true).Select(x => x).ToList();
                foreach (Attribute decisionAttribute in attrs)
                {
                    Condition decisionAttributeInResult = new Condition(decisionAttribute);
                    IList<Condition> conditions = new List<Condition>();

                    separatedRows = InformationSystem.Rows.GetRowsSeparatedByAttribute(row, decisionAttribute);

                    IList<Row> separatedRowsCopy = separatedRows;
                    int alreadyCovered = 0;
                    while (alreadyCovered < MinimumNumberOfRowsToSeparate)
                    {
                        IList<Subset> subsets = separatedRowsCopy.CreateSubsets(row, decisionAttribute, true);

                        string subsetWithMaxElements = subsets
                             .OrderByDescending(x => x.Quotient)
                              .Select(x => x.Name)
                              .First();

                        alreadyCovered += subsets.Where(x => x.Name == subsetWithMaxElements)
                            .Select(x => x.Count).First();
                        conditions.Add(new Condition(
                            row.Attributes.Where(x => x.Name == subsetWithMaxElements).First()));

                        separatedRowsCopy = separatedRowsCopy
                            .RemoveElementsFromAlreadyCoveredSubsets(subsets, subsetWithMaxElements);
                    }

                    var rule = new AssociationRule(conditions, decisionAttributeInResult);

                    var supportAndConfidence = rule.CalculateSupportAndConfidence(InformationSystem.Rows);
                    rule.Support = supportAndConfidence.Item1.Round();
                    rule.Confidence = supportAndConfidence.Item2.Round();

                    result.Add(rule);
                    alreadyCovered = 0;
                    separatedRows = null;
                }
            }

            Rules(result);
        }

        public event ReturnGeneratedRules Rules;

        public Dictionary<string, int> Weights
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }


        public event ReturnPercentOfSeparatedRows SeparatedRows;
    }
}
