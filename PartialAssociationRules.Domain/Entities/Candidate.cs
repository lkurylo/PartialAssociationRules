/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.Domain.Entities;

namespace PartialAssociationRules.Domain.Entities
{
    public class Candidate
    {
        public Candidate()
        {
            IsDifferentOnDecision = false;
            Row = null;
            DifferentOnAttributes = 0;
        }

        public bool IsDifferentOnDecision
        {
            set;
            get;
        }

        public Row Row
        {
            set;
            get;
        }

        public int DifferentOnAttributes
        {
            set;
            get;
        }
    }
}
