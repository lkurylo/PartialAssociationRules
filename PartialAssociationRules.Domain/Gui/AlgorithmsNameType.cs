/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using PartialAssociationRules.Domain.Algorithms;

namespace PartialAssociationRules.Domain.Gui
{
    /// <summary>
    /// Helper class which contains algorithms names and types as a key-value dictionary.
    /// </summary>
    public class AlgorithmsNameType
    {
        private static Dictionary<string, AlgorithmType> dict;

        /// <summary>
        /// Defaut constructor.
        /// </summary>
        public AlgorithmsNameType()
        {
            if (dict == null)
            {
                dict = new Dictionary<string, AlgorithmType>();

                dict["klasyczny"] = AlgorithmType.Classic;
                dict["zmodyfikowany"] = AlgorithmType.ClassicWithModification;
                dict["z wagami"] = AlgorithmType.ClassicWithWeights;
            }
        }

        /// <summary>
        /// Gets algorithm type for specific algorithm name.
        /// </summary>
        /// <param name="key">The key from the dictionary.</param>
        /// <returns>Algorithm type for specific algorithm name. </returns>
        public AlgorithmType this[string key]
        {
            get
            {
                return dict[key];
            }
        }

        /// <summary>
        /// Gets a list of all keys.
        /// </summary>
        public IEnumerable<string> Keys
        {
            get
            {
                foreach (var elem in dict)
                {
                    yield return elem.Key;
                }
            }
        }
    }
}
