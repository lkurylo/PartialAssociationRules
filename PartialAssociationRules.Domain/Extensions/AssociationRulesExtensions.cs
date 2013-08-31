/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Data;
using PartialAssociationRules.Domain.Entities;
using System.Linq;

namespace PartialAssociationRules.Domain.Extensions
{
    public static class AssociationRulesExtensions
    {
        private static readonly object locker = new object();

        public static DataTable ConvertToDataTable(this IEnumerable<RuleCount> rules)
        {
            DataTable result = new DataTable();
            DataColumn associationRule = new DataColumn("associationRule");
            associationRule.DataType = typeof(string);
            associationRule.MaxLength = 277;
            result.Columns.Add(associationRule);

            DataColumn support = new DataColumn("support");
            support.DataType = typeof(double);
            result.Columns.Add(support);

            DataColumn confidence = new DataColumn("confidence");
            confidence.DataType = typeof(double);
            result.Columns.Add(confidence);

            DataColumn length = new DataColumn("length");
            length.DataType = typeof(int);
            result.Columns.Add(length);

            DataColumn upperBound = new DataColumn("upperBound");
            upperBound.DataType = typeof(int);
            result.Columns.Add(upperBound);

            DataColumn lowerBound = new DataColumn("lowerBound");
            lowerBound.DataType = typeof(int);
            result.Columns.Add(lowerBound);

            DataColumn theSameRules = new DataColumn("theSameRules");
            theSameRules.DataType = typeof(int);
            result.Columns.Add(theSameRules);

            foreach (var singleRule in rules)
            {
                DataRow row = result.NewRow();
                row["associationRule"] = singleRule.Rule.ToString();
                row["support"] = singleRule.Rule.Support;
                row["confidence"] = singleRule.Rule.Confidence;
                row["length"] = singleRule.Rule.Length;
                row["upperBound"] = singleRule.Rule.UpperBound;
                row["lowerBound"] = singleRule.Rule.LowerBound;
                row["theSameRules"] = singleRule.Count;
                result.Rows.Add(row);
            }

            return result;
        }

        public static Tuple<decimal, decimal> CalculateSupportAndConfidence(this AssociationRule rule,
            IList<Row> rows)
        {
            List<bool> contains;

            int rowsContainsAllConditions = 0;
            int result = 0;
            bool containsDecisionAttr = false;

            foreach (Row singleRow in rows)
            {
                contains = new List<bool>();

                foreach (var singleCondition in rule.Conditions)
                {
                    if (singleRow.Attributes.Contains(singleCondition.Attribute))
                    {
                        contains.Add(true);
                    }
                }

                if (singleRow.Attributes.Contains(rule.Decision.Attribute))
                {
                    containsDecisionAttr = true;
                }

                if (contains.Count == rule.Conditions.Count && containsDecisionAttr == true)
                {
                    result++;
                }

                if (contains.Count == rule.Conditions.Count)
                {
                    rowsContainsAllConditions++;
                }

                containsDecisionAttr = false;
            }

            rule.RowsQuantity = result;
            decimal support = System.Convert.ToDecimal(result * 100) / rows.Count;
            decimal confidence = System.Convert.ToDecimal(result * 100) / rowsContainsAllConditions;

            return new Tuple<decimal, decimal>(support, confidence);
        }

        public static Tuple<int, int> CalculateUpperAndLowerBound(this AssociationRule rule,
            int minimumNumberOfRowsToSeparate, IList<int> deltas)
        {
            int upperBound = rule.Length;

            List<decimal> l = new List<decimal>();
            for (int i = 0; i < deltas.Count; i++)
            {
                int counter = 0;
                for (int j = 1; j <= i; j++)
                {
                    //if (j == 0)
                    //{
                    //    continue;
                    //}
                    //else
                    //{
                    //try
                    //{
                    counter += deltas[j - 1];
                    //}
                    //catch (ArgumentOutOfRangeException)
                    //{
                    //}
                }

                int denominator = deltas[i];

                var iteration = Math.Ceiling(
                    Convert.ToDecimal(minimumNumberOfRowsToSeparate - counter) / denominator);
                l.Add(iteration);
            }

            int lowerBound = Convert.ToInt32(l.Max());

            return new Tuple<int, int>(upperBound, lowerBound);
        }
    }
}
