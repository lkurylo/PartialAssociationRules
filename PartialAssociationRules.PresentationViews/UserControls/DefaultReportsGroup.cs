/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class DefaultReportsGroup : UserControl
    {
        public DefaultReportsGroup()
        {
            InitializeComponent();
        }

        public ComboBox DefaultReportType
        {
            get
            {
                return cbDefaultReportType;
            }
        }

        public CheckBox InfSysInTXTReport
        {
            get
            {
                return ckSystemInReport;
            }
        }

        public CheckBox PercentageOfSeparatedRows
        {
            get
            {
                return ckIncludePercentageOfSeparatedRows;
            }
        }
    }
}
