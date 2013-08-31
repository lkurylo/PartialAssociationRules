/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialAssociationRules.Domain.Entities
{
    public class Subset
    {
        public Subset()
        {
            Rows = new List<string>();
        }

        public int Count
        {
            get
            {
                return Rows.Count();
            }
        }

        public string Name
        {
            set;
            get;
        }

        /// <summary>
        /// This is quotient !=d/(=d+1) for all rows where d is decision of current processed row.
        /// </summary>
        public decimal Quotient
        {
            set;
            get;
        }

        public IList<string> Rows
        {
            set;
            get;
        }
    }
}
