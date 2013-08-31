/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

namespace PartialAssociationRules.Domain.Report
{
    public interface IReport
    {
        string CreateReport();
        ReportType Type { get; }
        ReportInfo ReportDetails { get; set; }
    }
}
