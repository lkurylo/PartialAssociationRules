/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;

namespace PartialAssociationRules.Domain.DataGenerators
{
    public interface IWeightsGenerator
    {
        Dictionary<string,int> Generate();

        GeneratorType Type { get; }

        IList<string> Attributes { set; get; }

        int MinimalWeight { set; get; }

        int MaximalWeight { set; get; }
    }
}
