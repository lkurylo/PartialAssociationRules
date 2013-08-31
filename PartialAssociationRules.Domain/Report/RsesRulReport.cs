/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PartialAssociationRules.Domain.Entities;

namespace PartialAssociationRules.Domain.Report
{
    public class RsesRulReport : IReport
    {
        public string CreateReport()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(String.Format("RULE_SET {0}", ReportDetails.DataSetName));
            result.AppendLine(String.Format("ATTRIBUTES {0}", ReportDetails.System.Rows[0].Attributes.Count));

            if (ReportDetails.DecisionAttributes.Count == 1)
            {
                ReportDetails.System.Rows[0].Attributes.ToList().ForEach(x =>
                {
                    if (x.Name != ReportDetails.DecisionAttributes[0])
                    {
                        result.AppendLine(String.Format(" {0} symbolic", x.Name));
                    }
                });

                result.AppendLine(String.Format(" {0} symbolic", ReportDetails.DecisionAttributes[0]));
            }
            else
            {
                ReportDetails.System.Rows[0].Attributes.ToList().ForEach(x =>
                {
                    result.AppendLine(String.Format(" {0} symbolic", x.Name));
                });
            }

            List<object> allValues = new List<object>();

            ReportDetails.System.Rows.ToList()
                .ForEach(z => z.Attributes.ToList()
                    .ForEach(x =>
            {
                if (ReportDetails.DecisionAttributes.Contains(x.Name))
                {
                    allValues.Add((x.Value));
                }
            }));

            List<string> distinctValues=new List<string>();
            allValues.Distinct().ToList().ForEach(x => distinctValues.Add(Convert.ToString(x)));

            result.AppendLine(String.Format("DECISION_VALUES {0}", distinctValues.Count));

            foreach (string singleValue in distinctValues)
            {
                result.AppendLine(singleValue);
            }

            result.AppendLine(String.Format("RULES {0}", ReportDetails.Rules.Count()));

            foreach (RuleCount singleRule in ReportDetails.Rules)
            {
                result.AppendLine(singleRule.Rule.ToRsesRulString());
            }

            return result.ToString();
        }

        public ReportType Type
        {
            get { return ReportType.RSES; }
        }

        public ReportInfo ReportDetails
        {
            get;
            set;
        }
    }
}
