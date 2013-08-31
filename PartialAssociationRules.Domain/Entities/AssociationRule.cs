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
    public class AssociationRule
    {
        public IList<Condition> Conditions { private set; get; }
        public Condition Decision { private set; get; }

        public int Length
        {
            get
            {
                return Conditions.Count;
            }
        }

        public decimal Support { get; set; }

        public decimal Confidence { get; set; }

        public int UpperBound { get; set; }

        public int LowerBound { get; set; }

        //public AlgorithmProgressExecution AlgorithmExecution { set; get; }

        /// <summary>
        /// Gets how many rows from the information system supports the rule.
        /// X->Y: (X u Y)
        /// </summary>
        public int RowsQuantity { set; get; }

        public AssociationRule(IList<Condition> conditions, Condition decision)
        {
            Conditions = conditions;
            Decision = decision;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Conditions
                .ToList()
                .ForEach(z =>
            {
                result.Append(z.ToString() + " & ");
            });

            return String.Format("{0} -> {1}", result.ToString().TrimEnd(' ', '&'), Decision.ToString());
        }

        public string ToRsesRulString()
        {
            StringBuilder result = new StringBuilder();

            Conditions
                .ToList()
                .ForEach(z =>
                {
                    result.Append("(" + z.ToString() + ")&");
                });

            return String.Format("{0}=>({1}={2}[{3}]) {3}",
                result.ToString().TrimEnd(' ', '&'), Decision.Attribute.Name, Decision.Attribute.Value, this.RowsQuantity);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            AssociationRule p = obj as AssociationRule;
            if ((System.Object)p == null)
            {
                return false;
            }

            return Equals(p);
        }

        public bool Equals(AssociationRule obj)
        {
            if (Conditions.Count != obj.Conditions.Count)
            {
                return false;
            }

            if (!Decision.Attribute.Equals(obj.Decision.Attribute))
            {
                return false;
            }

            bool result = true;

            for (int i = 0; i < Conditions.Count; i++)
            {
                if (result == true)
                {
                    if (!Conditions[i].Attribute.Equals(obj.Conditions[i].Attribute))
                    {
                        result = false;
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
