/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class DefaultParametersGroup : UserControl
    {
        public DefaultParametersGroup()
        {
            InitializeComponent();
        }

        public NumericUpDown Alpha
        {
            get
            {
                return nudAlphaDefault;
            }
        }

        public NumericUpDown Gamma
        {
            get
            {
                return nudGammaDefault;
            }
        }

        public NumericUpDown Support
        {
            get
            {
                return nudSupportDefault;
            }
        }

        public NumericUpDown Confidence
        {
            get
            {
                return nudConfidenceDefault;
            }
        }
    }
}
