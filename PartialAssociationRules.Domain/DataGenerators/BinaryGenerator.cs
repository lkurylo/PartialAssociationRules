/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using PartialAssociationRules.Domain.Entities;

namespace PartialAssociationRules.Domain.DataGenerators
{
    /// <summary>
    /// Implementation of binary data generator.
    /// </summary>
    public class BinaryGenerator : BasicGenerator
    {
        private System.Random rand = null;

        /// <summary>
        /// Generator type.
        /// </summary>
        public override GeneratorType Type
        {
            get
            {
                return GeneratorType.Binary;
            }
        }

        /// <summary>
        /// Return random value from range [0,1].
        /// </summary>
        protected override int RandomValue
        {
            get
            {
                if (rand == null)
                    rand = new System.Random(System.DateTime.Now.Millisecond);

                return rand.Next(0, 2);
            }
        }
    }
}
