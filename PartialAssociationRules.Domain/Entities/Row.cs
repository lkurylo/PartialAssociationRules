/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using System.Text;

namespace PartialAssociationRules.Domain.Entities
{
    /// <summary>
    /// Represents one row from information system.
    /// </summary>
    public class Row
    {
        public string Name { set; get; }

        /// <summary>
        /// List of attributes for current row.
        /// </summary>
        public IList<Attribute> Attributes { set; get; }

        /// <summary>
        /// Defaut constructor.
        /// </summary>
        public Row()
        {
            Attributes = new List<Attribute>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Row p = obj as Row;
            if ((System.Object)p == null) //cast to object because if the == operator is overrided too we can have an exception
            {                                             //http://weblogs.asp.net/tgraham/archive/2004/03/23/94870.aspx#5430744       
                return false;
            }

            return (Name == p.Name) && (Attributes == p.Attributes);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Attributes.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var attr in Attributes)
            {
                result.AppendFormat("{0},{1};", attr.Name, attr.Value);
            }

            return result.ToString().TrimEnd(';');
        }
    }
}
