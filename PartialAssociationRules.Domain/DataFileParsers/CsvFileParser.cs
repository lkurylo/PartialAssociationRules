/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Exceptions;

namespace PartialAssociationRules.Domain.DataFileParsers
{
    /// <summary>
    /// Default parser for csv/txt files.
    /// </summary>
    public class CsvFileParser : DataFileParser
    {
        /// <summary>
        /// Supported delimiters in csv/txt files.
        /// </summary>
        private readonly char[] supportedDelimiters = { ',', ';' };

        /// <summary>
        /// Supported file type by this parser.
        /// </summary>
        public override FileType Type
        {
            get { return FileType.CSV; }
        }

        /// <summary>
        /// Parse the file to Row objects.
        /// </summary>
        /// <param name="stream">Stream which contains a file to parse.</param>
        /// <returns>List of parsed rows.</returns>
        public override IList<Entities.Row> Parse(System.IO.StreamReader stream)
        {
            List<Row> result = new List<Row>();

            string line;
            int rowNumber = 0;
            Dictionary<int, string> attrNames = new Dictionary<int, string>();

            //first line should contains attribute names
            if ((line = stream.ReadLine()) != null)
            {
                int index = 0;
                foreach (string s in line.Split(supportedDelimiters))
                {
                    attrNames.Add(index++, s);
                }
            }

            //rest lines
            while ((line = stream.ReadLine()) != null)
            {
                Row row = new Row();
                int index = 0;

                foreach (string s in line.Split(supportedDelimiters))
                {
                    try
                    {
                        row.Attributes.Add(new Entities.Attribute(attrNames[index++], s));
                    }
                    catch (KeyNotFoundException)
                    {
                        //Occurs when in one line is more values than in the first line with attributes names
                        //then rethrow an app specific exception
                        stream.Close();
                        throw new PartialAssociationRulesException(ExceptionsList.ArgumentCountIncorrect);
                    }
                }

                row.Name = "r" + (++rowNumber);
                result.Add(row);
                index = 0;
            }

            stream.Close();
            Verify(result);
            return result;
        }
    }
}
