/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using System.Data;

namespace PartialAssociationRules.Domain.Extensions
{
    public static class DictionaryExtensions
    {
        public static DataTable ConvertToDataTable(this Dictionary<string, int> dict)
        {
            DataTable result = new DataTable();
            DataColumn attrName = new DataColumn("attrName");
            attrName.DataType = typeof(string);
            result.Columns.Add(attrName);

            DataColumn attrWeight = new DataColumn("attrWeight");
            attrWeight.DataType = typeof(int);
            result.Columns.Add(attrWeight);

            foreach (var singleKey in dict.Keys)
            {
                DataRow row = result.NewRow();
                row["attrName"] = singleKey;
                row["attrWeight"] = dict[singleKey];
                result.Rows.Add(row);
            }

            return result;
        }
    }
}
