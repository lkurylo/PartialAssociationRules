/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

namespace PartialAssociationRules.Domain.Algorithms
{
    /// <summary>
    /// Represents available algorithms.
    /// </summary>
    public enum AlgorithmType
    {
        /// <summary>
        /// Classic algorithm.
        /// </summary>
        Classic,

        /// <summary>
        /// Modified algorithm.
        /// </summary>
        ClassicWithModification,

        /// <summary>
        /// Algorithm with weights.
        /// </summary>
        ClassicWithWeights,
    }
}
