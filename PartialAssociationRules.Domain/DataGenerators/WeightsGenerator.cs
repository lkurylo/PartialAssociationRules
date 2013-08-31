/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;

namespace PartialAssociationRules.Domain.DataGenerators
{
    public class WeightsGenerator : IWeightsGenerator
    {
        private Random randomizer;
        public WeightsGenerator()
        {
            randomizer = new Random(DateTime.Now.Millisecond);
        }

        public Dictionary<string, int> Generate()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var singleAttr in Attributes)
            {
                result[singleAttr] = GetWeight();
            }

            return result;
        }

        private int GetWeight()
        {
            return randomizer.Next(MinimalWeight, MaximalWeight + 1);
        }

        public GeneratorType Type
        {
            get { return GeneratorType.Weights; }
        }

        public IList<string> Attributes
        {
            set;
            get;
        }

        public int MinimalWeight
        {
            get;
            set;
        }

        public int MaximalWeight
        {
            get;
            set;
        }
    }
}
