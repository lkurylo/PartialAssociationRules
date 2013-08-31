/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

namespace PartialAssociationRules.Domain.Entities
{
    /// <summary>
    /// Class represents attribute from information system.
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// Default contructor.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        /// <param name="value">Attribute value.</param>
        public Attribute(string name, object value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Returns the attribute name.
        /// </summary>
        public string Name { private set; get; }

        /// <summary>
        /// Returns the attribute value.
        /// </summary>
        public object Value { private set; get; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Attribute p = obj as Attribute;
            if ((System.Object)p == null) //cast to object because if the == operator 
                                            //is overrided too we can have an exception
            {                                             //http://weblogs.asp.net/tgraham/archive/2004/03/23/94870.aspx#5430744       
                return false;
            }

            return (Name.Equals(p.Name)) && (Value.Equals(p.Value));
        }
        
        public bool Equals(Attribute obj)
        {
            if ((System.Object)obj == null)
            {
                return false;
            }

            return (Name.Equals(obj.Name)) && (Value.Equals(obj.Value));
        }

        public bool EqualsByValue(Attribute obj)
        {
            if ((System.Object)obj == null)
            {
                return false;
            }

            bool result = (Value.Equals(obj.Value));
            return result;
        }

        public bool EqualsByName(Attribute obj)
        {
            if ((System.Object)obj == null)
            {
                return false;
            }

            return (Name.Equals(obj.Name));
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Value.GetHashCode();
        }
    }
}
