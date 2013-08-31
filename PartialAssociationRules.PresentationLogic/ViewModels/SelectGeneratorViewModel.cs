/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialAssociationRules.PresentationLogic.ViewModels
{
    public class SelectGeneratorViewModel
    {
        public int NumberOfObjects
        {
            set;
            get;
        }

        public int NumberOfAttributes
        {
            set;
            get;
        }

        public bool UseBinaryGenerator
        {
            set;
            get;
        }
    }
}
