/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class PreviewGroup : UserControl
    {
        public PreviewGroup()
        {
            InitializeComponent();
        }

        public CheckedListBox DecisionAttributesList
        {
            get
            {
                return cblDecisionAttributes;
            }
        }

        public DataGridView PreviewGrid
        {
            get
            {
                return dgvPreviewData;
            }
        }

        public CheckBox SelectAll
        {
            get
            {
                return cbSelectAll;
            }
        }
    }
}
