/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class DefaultGeneratorsGroup : UserControl
    {
        public DefaultGeneratorsGroup()
        {
            InitializeComponent();
        }

        public ComboBox DefaultGenerator
        {
            get
            {
                return cbDefaultGenerator;
            }
        }

        public TextBox ObjectsQuantityDefault
        {
            get
            {
                return txtObjectsQuantityDefault;
            }
        }

        public TextBox AttributesQuantityDefault
        {
            get
            {
                return txtAttributesQuantityDefault;
            }
        }
    }
}
