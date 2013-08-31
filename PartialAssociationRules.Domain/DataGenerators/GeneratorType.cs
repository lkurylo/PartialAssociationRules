/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

namespace PartialAssociationRules.Domain.DataGenerators
{
    /// <summary>
    /// Represents available generators.
    /// </summary>
    public enum GeneratorType
    {
        /// <summary>
        /// Binary generator.
        /// </summary>
        Binary,

        /// <summary>
        /// Numeric generator.
        /// </summary>
        Numeric,

        /// <summary>
        /// Generator for weights.
        /// </summary>
        Weights
    }
}
