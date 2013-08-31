/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.Domain.Entities;

namespace PartialAssociationRules.Domain.Utilities
{
    public class AssociationRulesComparer : System.Collections.Generic.IEqualityComparer<AssociationRule>
    {
        public bool Equals(AssociationRule x, AssociationRule y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(AssociationRule obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
