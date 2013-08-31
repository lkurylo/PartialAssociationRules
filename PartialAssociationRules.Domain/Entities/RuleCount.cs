/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

namespace PartialAssociationRules.Domain.Entities
{
    public class RuleCount
    {
        public AssociationRule Rule { set; get; }
        public int Count { set; get; }
    }
}
