/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using System.Data;
using System.Linq;
using PartialAssociationRules.Domain.Entities;

namespace PartialAssociationRules.Domain.Extensions
{
    public static class InformationSystemExtensions
    {
        public static IList<Row> GetRowsSeparatedByAttribute(this IList<Row> rows, Row currentParserRow, Entities.Attribute decisionAttribute)
        {
            List<Candidate> candidates = new List<Candidate>();
            Candidate candidate = null;

            foreach (Row singleRow in rows)
            {
                if (singleRow.Name != currentParserRow.Name)
                {
                    candidate = new Candidate();
                    candidate.Row = singleRow;

                    for (int i = 0; i < currentParserRow.Attributes.Count; i++)
                    {
                        if (singleRow.Attributes[i].EqualsByName(decisionAttribute)) //we've found our decision attribute
                        {
                            if (!singleRow.Attributes[i].EqualsByValue(decisionAttribute))
                            {
                                candidate.IsDifferentOnDecision = true;
                                continue;
                            }
                        }

                        if (singleRow.Attributes[i].EqualsByName(currentParserRow.Attributes[i])) //check other attributes
                        {
                            if (singleRow.Attributes[i].EqualsByValue(currentParserRow.Attributes[i]) == false)
                            {
                                candidate.DifferentOnAttributes++;
                            }
                        }
                    }

                    candidates.Add(candidate);
                }
            }

            return candidates
                .Where(x => x.IsDifferentOnDecision == true && x.DifferentOnAttributes > 0)
                .Select(x => x.Row)
                .ToList();
        }

        public static IList<Subset> CreateSubsets(this IList<Row> rows, Row currentParserRow,
            Entities.Attribute decisionAttribute, bool calculate)
        {
            IList<Subset> result = new List<Subset>(currentParserRow.Attributes.Count);

            foreach (Attribute singleAttr in currentParserRow.Attributes)
            {
                if (!singleAttr.EqualsByName(decisionAttribute))
                {
                    result.Add(new Subset()
                    {
                        Name = singleAttr.Name
                    });
                }
            }

            foreach (Row singleRow in rows)
            {
                for (int i = 0; i < singleRow.Attributes.Count; i++)
                {
                    if (singleRow.Attributes[i].EqualsByName(currentParserRow.Attributes[i])
                        && !singleRow.Attributes[i].EqualsByName(decisionAttribute))
                    {
                        if (!singleRow.Attributes[i].EqualsByValue(currentParserRow.Attributes[i]))
                        {
                            result.Where(x => x.Name == singleRow.Attributes[i].Name).First().Rows.Add(singleRow.Name);
                        }
                    }
                }
            }

            if (calculate)
            {
                foreach (Subset singleSubset in result)
                {
                    int diffrentOnDecision = singleSubset.Rows.Count();
                    int equalOnDecision = 1;

                    foreach (Row singleRow in rows)
                    {
                        if (singleRow.Name != currentParserRow.Name) //should be always true
                        {
                            foreach (Attribute singleAttr in singleRow.Attributes)
                            {
                                if (singleAttr.EqualsByName(decisionAttribute))
                                {
                                    if (singleAttr.EqualsByValue(decisionAttribute))
                                    {
                                        equalOnDecision++;
                                    }

                                    break;
                                }
                            }
                        }
                    }

                    result.Where(x => x.Name == singleSubset.Name).First().Quotient =
                        System.Convert.ToDecimal(diffrentOnDecision) / equalOnDecision;
                }
            }

            return result;
        }

        public static IList<Row> RemoveElementsFromAlreadyCoveredSubsets(this IList<Row> rows,
            IList<Subset> subsets, string subsetWithMaxElements)
        {
            List<string> rowsFromSubsetWithMaxElements = subsets
              .Where(x => x.Name == subsetWithMaxElements).First().Rows.ToList();

            List<Row> result = new List<Row>();//rows.Count - rowsFromSubsetWithMaxElements.Count);

            rows.ToList().ForEach(x =>
            {
                if (!rowsFromSubsetWithMaxElements.Contains(x.Name))
                {
                    result.Add(x);
                }
            });

            return result;
        }

        public static DataTable ConvertDataSetToDataTable(this IList<Row> rows)
        {
            DataTable result = new DataTable();

            for (int i = 0; i < rows[0].Attributes.Count; i++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = rows[0].Attributes[i].Name;
                result.Columns.Add(column);
            }

            foreach (Row singleRow in rows)
            {
                var row = result.NewRow();

                foreach (Entities.Attribute singleAttribute in singleRow.Attributes)
                {
                    row[singleAttribute.Name] = singleAttribute.Value;
                }

                result.Rows.Add(row);
            }

            return result;
        }
    }
}
