/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class ResultGrid : UserControl
    {
        public ResultGrid()
        {
            InitializeComponent();
        }

        public DataGridView ResultDataGridView
        {
            get
            {
                return dgvResult;
            }
        }

        public BindingSource BindingSource
        {
            get
            {
                return bindingSource1;
            }
        }
    }
}
