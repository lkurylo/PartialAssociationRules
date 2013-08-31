/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;

namespace PartialAssociationRules.Domain.DataGenerators
{
    /// <summary>
    /// Basic abstract class for all generators.
    /// </summary>
    public abstract class BasicGenerator : IDataGenerator
    {
        /// <summary>
        /// Generator type.
        /// </summary>
        public abstract GeneratorType Type { get; }

        /// <summary>
        /// Number of argument to generate for each object.
        /// </summary>
        public int NumberOfAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Number of objects to generate.
        /// </summary>
        public int NumberOfObjects
        {
            get;
            set;
        }

        /// <summary>
        /// Generate rows for information system.
        /// </summary>
        /// <returns>List of rows.</returns>
        public IList<Entities.Row> Generate()
        {
            List<Entities.Row> result = new List<Entities.Row>(NumberOfObjects);

            for (int i = 0; i < NumberOfObjects; i++)
            {
                Entities.Row row = new Entities.Row();
                row.Name = "r" + (i + 1);

                for (int j = 0; j < NumberOfAttributes; j++)
                {
                    row.Attributes.Add(new Entities.Attribute("a" + (j + 1), RandomValue));
                }

                result.Add(row);
            }

            return result;
        }

        /// <summary>
        /// Return random value from specific range.
        /// </summary>
        protected abstract int RandomValue { get; }
    }
}
