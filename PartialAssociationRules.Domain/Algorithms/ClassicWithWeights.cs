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
    public class ClassicWithWeights : IAlgorithm
    {
        public InformationSystem InformationSystem { set; get; }
        private IList<Row> separatedRows;

        public AlgorithmType Type
        {
            get { return AlgorithmType.ClassicWithWeights; }
        }

        public event NotifyAboutIterationEnd Notify;

        public void Generate()
        {
            decimal gamma = InformationSystem.Gamma;
            decimal alpha = InformationSystem.Alpha;

            ConcurrentBag<AssociationRule> result = new ConcurrentBag<AssociationRule>();

            foreach (Row row in InformationSystem.Rows)
            {
                List<Attribute> attrs = row.Attributes.Where(x =>
                       InformationSystem.DecisionAttributes[x.Name] == true).Select(x => x).ToList();
                foreach (Attribute decisionAttribute in attrs)// row.Attributes)
                {
                    Condition decisionAttributeInResult = new Condition(decisionAttribute);
                    IList<Condition> conditions = new List<Condition>();

                    separatedRows = InformationSystem.Rows.GetRowsSeparatedByAttribute(row, decisionAttribute);

                    decimal M = System.Math.Ceiling(separatedRows.Count() * (1 - alpha));
                    decimal N = System.Math.Ceiling(separatedRows.Count() * (1 - gamma));

                    IList<Row> separatedRowsCopy = separatedRows;
                    int alreadyCovered = 0;
                    while (alreadyCovered < M)
                    {
                        IList<Subset> subsets = separatedRowsCopy.CreateSubsets(row, decisionAttribute, false);

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

                        alreadyCovered += subsets.Where(x => x.Name == subsetWithMinimumQuotient)
                            .Select(x => x.Count).First();
                        conditions.Add(new Condition(
                            row.Attributes.Where(x => x.Name == subsetWithMinimumQuotient).First()));

                        separatedRowsCopy = separatedRowsCopy
                            .RemoveElementsFromAlreadyCoveredSubsets(subsets, subsetWithMinimumQuotient);
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
            get;
            set;
        }


        public event ReturnPercentOfSeparatedRows SeparatedRows;
    }
}
