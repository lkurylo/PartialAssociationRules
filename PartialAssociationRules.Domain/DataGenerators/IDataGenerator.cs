/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using PartialAssociationRules.Domain.Entities;

namespace PartialAssociationRules.Domain.DataGenerators
{
    /// <summary>
    /// Basic interface for all data generators.
    /// </summary>
    public interface IDataGenerator
    {
        /// <summary>
        /// Generator type.
        /// </summary>
        GeneratorType Type { get; }

        /// <summary>
        /// Number of argument to generate for each object.
        /// </summary>
        int NumberOfAttributes { set; get; }

        /// <summary>
        /// Number of objects to generate.
        /// </summary>
        int NumberOfObjects { set; get; }

        /// <summary>
        /// Generate information system rows.
        /// </summary>
        /// <returns>List of rows.</returns>
        IList<Row> Generate();
    }
}
