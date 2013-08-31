/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Gui;

namespace PartialAssociationRules.Domain.Algorithms
{
    /// <summary>
    /// Interface for all available algorithms.
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// Type of the algorithm.
        /// </summary>
        AlgorithmType Type { get; }

        /// <summary>
        /// Construct (partial) association rules.
        /// </summary>
        void Generate();

        InformationSystem InformationSystem { set; get; }

        event NotifyAboutIterationEnd Notify;
        event ReturnGeneratedRules Rules;
        event ReturnPercentOfSeparatedRows SeparatedRows;

        Dictionary<string, int> Weights { get; set; }
    }
}
