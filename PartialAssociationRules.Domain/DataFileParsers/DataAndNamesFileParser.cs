/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Exceptions;
using PartialAssociationRules.Domain.Utilities;

namespace PartialAssociationRules.Domain.DataFileParsers
{
    public class DataAndNamesFileParser : DataFileParser
    {
        /// <summary>
        /// Supported delimiters in data and names files.
        /// </summary>
        private readonly char[] supportedDelimiters = { ',' };

        public override FileType Type
        {
            get { return FileType.DataAndNames; }
        }

        public override IList<Entities.Row> Parse(StreamReader stream)
        {
            List<Entities.Row> result = new List<Entities.Row>();

            if (!ZipUtilities.IsCorrectZipArchive(stream.BaseStream))
            {
                throw new PartialAssociationRulesException(ExceptionsList.IncorrectArchive);
            }

            StreamReader header = ZipUtilities.ExtractFileWithColumnNames(stream.BaseStream);
            header.BaseStream.Seek(0, SeekOrigin.Begin);

            Regex getPointSeven = new Regex(@"(?<file>^7.[\s\w:,-\[\]\(\)\{\}]+)"
                , RegexOptions.Multiline | RegexOptions.IgnoreCase);
            string file = getPointSeven.Match(header.ReadToEnd()).Groups["file"].Value;

            int ind = SettingsManager.Settings.DefaultRegexIndex;
            var selectedRegex =
                SettingsManager.Settings.RegexForNamesHeader.Split(new string[] { ";;;" }, StringSplitOptions.None)[ind];

            Regex linesWithAttributes = new Regex(selectedRegex,
                //@"((^[\t ]+\d+\.\s+)(?<data>[^\s:]+))|((^[\t ]+\s+)(?<data>[^\s:]+))",//RegexForHeader,
            RegexOptions.Multiline | RegexOptions.IgnoreCase);

            var linesWithAttributesMatched = linesWithAttributes.Matches(file);

            List<string> attrNames = new List<string>();

            foreach (Match singleMatch in linesWithAttributesMatched)
            {
                string attr = singleMatch.Groups["data"].Value;
                attrNames.Add(attr);
            }

            StreamReader data = ZipUtilities.ExtractFileWithData(stream.BaseStream);
            data.BaseStream.Seek(0, SeekOrigin.Begin);

            string line;
            int rowNumber = 1;
            while ((line = data.ReadLine()) != null)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    Row row = new Row();
                    row.Name = ("r" + rowNumber++);
                    int index = 0;

                    foreach (string s in line.Split(supportedDelimiters))
                    {
                        try
                        {
                            row.Attributes.Add(new Entities.Attribute(attrNames[index++], s));
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            //Occurs when in one line is more values than in the first line with attributes names
                            //then rethrow an app specific exception
                            stream.Close();
                            throw new PartialAssociationRulesException(ExceptionsList.ArgumentCountIncorrect);
                        }
                    }

                    result.Add(row);
                    index = 0;
                }
            }

            stream.Close();
            Verify(result);
            return result;
        }
    }
}
