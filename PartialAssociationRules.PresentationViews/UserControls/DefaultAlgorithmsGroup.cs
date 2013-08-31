/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class DefaultAlgorithmsGroup : UserControl
    {
        public DefaultAlgorithmsGroup()
        {
            InitializeComponent();
        }

        public TextBox MinimalWeight
        {
            get
            {
                return txtMinWeightDefault;
            }
        }

        public TextBox MaximalWeight
        {
            get
            {
                return txtMaxWeightDefault;
            }
        }

        public ComboBox Algorithm
        {
            get
            {
                return cbAlgorithmDefault; 
            }
        }
    }
}
