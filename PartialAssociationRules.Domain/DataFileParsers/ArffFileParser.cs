/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PartialAssociationRules.Domain.DataFileParsers
{
    /// <summary>
    /// Default parser for arff files.
    /// </summary>
    public class ArffFileParser : DataFileParser
    {
        /// <summary>
        /// Supported delimiters in arff files.
        /// </summary>
        private readonly char[] supportedDelimiters = { ',' };

        /// <summary>
        /// Supported file type by this parser.
        /// </summary>
        public override FileType Type
        {
            get
            {
                return FileType.ARFF;
            }
        }

        /// <summary>
        /// Parse the file to Row objects.
        /// </summary>
        /// <param name="stream">Stream which contains a file to parse.</param>
        /// <returns>List of parsed rows.</returns>
        public override IList<Entities.Row> Parse(System.IO.StreamReader stream)
        {
            List<Entities.Row> result = new List<Entities.Row>();
            Regex attributes = new Regex(@"(@attribute )([\w\d._'-]+)([\s\{\}, \d\w]+)", RegexOptions.IgnoreCase);
            Regex data = new Regex("(@data)([\\d\\w, \r\n.'\"-]+)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            //get the entire file
            string file = stream.ReadToEnd();

            MatchCollection matchedAttributes = attributes.Matches(file);
            string[] attributesNames = new string[matchedAttributes.Count];
            int index = 0;

            foreach (Match m in matchedAttributes)
            {
                attributesNames[index++] = m.Groups[2].Value.Trim('\'');
            }

            index = 1;
            data.Match(file)
                .Groups[2]
                .Value
                .Split(new string[] { "\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(x =>
                {
                  //  x = x;
                    Entities.Row row = new Entities.Row()
                    {
                        Name = ("r" + index++)
                    };

                    int attrIndex = 0;

                    x.Split(supportedDelimiters)
                        .ToList()
                        .ForEach(i =>
                    {
                        row.Attributes.Add(new Entities.Attribute(attributesNames[attrIndex++], i.Trim('\'', '\"')));
                    });

                    result.Add(row);
                });

            Verify(result);
            return result;
        }
    }
}
