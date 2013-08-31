/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;

namespace PartialAssociationRules.Domain.Entities
{
    public class Condition
    {
        public Condition(Attribute attribute)
        {
            Attribute = attribute;
        }

        public Attribute Attribute { private set; get; }

        public override string ToString()
        {
            return String.Format("{0}={1}", Attribute.Name, Attribute.Value); //Value);
        }
    }
}
