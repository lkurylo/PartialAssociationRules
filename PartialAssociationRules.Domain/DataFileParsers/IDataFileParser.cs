/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using System.IO;
using PartialAssociationRules.Domain.Entities;

namespace PartialAssociationRules.Domain.DataFileParsers
{
    /// <summary>
    /// Base interface which each data file parser must implement.
    /// </summary>
    public interface IDataFileParser
    {
        /// <summary>
        /// Gets supported file type by this parser.
        /// </summary>
        FileType Type { get; }

        /// <summary>
        /// Parse the file to Row objects.
        /// </summary>
        /// <param name="stream">Stream which contains a file to parse.</param>
        /// <returns>List of parsed rows.</returns>
        IList<Row> Parse(StreamReader stream);
    }
}
