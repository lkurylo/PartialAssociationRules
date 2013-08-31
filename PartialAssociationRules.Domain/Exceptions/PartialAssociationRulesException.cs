/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;

namespace PartialAssociationRules.Domain.Exceptions
{
    public class PartialAssociationRulesException : Exception
    {
        public ExceptionsList Exception
        {
            get;
            set;
        }

        public PartialAssociationRulesException(ExceptionsList exc)
            : base(exc.ToString())
        {
            Exception = exc;
        }
    }
}
