/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using System.IO;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Exceptions;

namespace PartialAssociationRules.Domain.DataFileParsers
{
    /// <summary>
    /// Base class which each data file parser must implement.
    /// </summary>
    public abstract class DataFileParser : IDataFileParser
    {
        public abstract FileType Type { get; }

        /// <summary>
        /// Parse the file to Row objects.
        /// </summary>
        /// <param name="stream">Stream which contains a file to parse.</param>
        /// <returns>List of parsed rows.</returns>
        public abstract IList<Row> Parse(StreamReader stream);

        /// <summary>
        /// Verify if the parsed file contains the same number of attributes in each line.
        /// </summary>
        /// <param name="rows">List of generated rows.</param>
        protected void Verify(List<Row> rows)
        {
            bool result = true;
            int numberOfAttributes;

            try
            {
                numberOfAttributes = rows[0].Attributes.Count;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw new PartialAssociationRulesException(ExceptionsList.RowsNotParsedCorrectly);
            }

            for (int i = 1; i < rows.Count; i++)
            {
                if (rows[i].Attributes.Count != numberOfAttributes)
                {
                    result = false;
                    break;
                }
            }

            if (!result)
            {
                throw new PartialAssociationRulesException(ExceptionsList.ArgumentCountIncorrect);
            }
        }
    }
}
