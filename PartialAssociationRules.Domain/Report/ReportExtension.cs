/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;

namespace PartialAssociationRules.Domain.Report
{
    public class ReportExtensions : Dictionary<ReportType, ReportExtensionsList>
    {
        public ReportExtensions()
        {
            string[] types = Enum.GetNames(typeof(ReportType));

            foreach (string singleType in types)
            {
                switch ((ReportType)Enum.Parse(typeof(ReportType), singleType))
                {
                    case ReportType.RSES:
                        this.Add(ReportType.RSES, ReportExtensionsList.RUL);
                        break;
                    case ReportType.TXT:
                        this.Add(ReportType.TXT, ReportExtensionsList.TXT);
                        break;
                }
            }
        }

        public IEnumerable<string> ReportTypes
        {
            get
            {
                foreach (var key in this)
                {
                    yield return key.Key.ToString();
                }
            }
        }

        public ReportExtensionsList this[string reportType]
        {
            get
            {
                return this[(ReportType)Enum.Parse(typeof(ReportType), reportType)];
            }
        }
    }
}
