/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class SelectGeneratorPanel : UserControl
    {
        public SelectGeneratorPanel()
        {
            InitializeComponent();
        }
        
        public TextBox ObjectsQuantity
        {
            get { return txtObjQuantity; }
        }

        public TextBox AttributesQuantity
        {
            get { return txtAttrQuantity; }
        }

        public RadioButton BinaryGenerator
        {
            get { return rbtnBinaryGenerator; }
        }

        public RadioButton NumericGenerator
        {
            get { return rbtnNumericGenerator; }
        }

        public Button Generate
        {
            get { return btnGenerate; }
        }

        public Button Cancel
        {
            get { return btnCancel; }
        }
    }
}
