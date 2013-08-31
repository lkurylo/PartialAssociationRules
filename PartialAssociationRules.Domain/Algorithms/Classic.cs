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
    /// <summary>
    /// Classic algorithm for constructing partial association rules.
    /// </summary>
    public class Classic : IAlgorithm
    {
        public InformationSystem InformationSystem { set; get; }
        private IList<Row> separatedRows;

        public AlgorithmType Type
        {
            get { return AlgorithmType.Classic; }
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
                //get all attributes marked as a decision attr.
                List<Attribute> attrs = row.Attributes.Where(x =>
                    InformationSystem.DecisionAttributes[x.Name] == true).Select(x => x).ToList();

                foreach (Attribute decisionAttribute in attrs)
                {
                    Condition decisionAttributeInResult = new Condition(decisionAttribute);
                    IList<Condition> conditions = new List<Condition>();

                    separatedRows = InformationSystem.Rows.GetRowsSeparatedByAttribute(row, decisionAttribute);

                    IList<Row> separatedRowsCopy = separatedRows;
                    int alreadyCovered = 0;
                    List<int> deltas = new List<int>();//{ 0 };
                    while (alreadyCovered < MinimumNumberOfRowsToSeparate)
                    {
                        IList<Subset> subsets = separatedRowsCopy.CreateSubsets(row, decisionAttribute, false);

                        string subsetWithMaxElements = subsets
                             .OrderByDescending(x => x.Count)
                              .Select(x => x.Name)
                              .First();

                        int elementsQuantityInSelectedSubset = subsets.Where(
                                    x => x.Name == subsetWithMaxElements)
                                    .Select(x => x.Count)
                                    .First();

                        deltas.Add(elementsQuantityInSelectedSubset);

                        alreadyCovered += elementsQuantityInSelectedSubset;

                        conditions.Add(new Condition(
                            row.Attributes.Where(x => x.Name == subsetWithMaxElements).First()));

                        separatedRowsCopy = separatedRowsCopy
                            .RemoveElementsFromAlreadyCoveredSubsets(subsets, subsetWithMaxElements);
                    }

                    var rule = new AssociationRule(conditions, decisionAttributeInResult);

                    var supportAndConfidence = rule.CalculateSupportAndConfidence(InformationSystem.Rows);
                    rule.Support = supportAndConfidence.Item1.Round();
                    rule.Confidence = supportAndConfidence.Item2.Round();

                    var upperLowerBound = rule.CalculateUpperAndLowerBound(MinimumNumberOfRowsToSeparate, deltas);
                    rule.UpperBound = upperLowerBound.Item1;
                    rule.LowerBound = upperLowerBound.Item2;

                    result.Add(rule);
                    alreadyCovered = 0;
                    separatedRows = null;
                }
            }

            Rules(result);
        }

        public event Gui.ReturnGeneratedRules Rules;

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
