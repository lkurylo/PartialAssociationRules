/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class ParametersGroup : UserControl
    {
        public ParametersGroup()
        {
            InitializeComponent();
        }

        public NumericUpDown Alpha
        {
            get
            {
                return nudAlpha;
            }
        }

        public NumericUpDown Gamma
        {
            get
            {
                return nudGamma;
            }
        }

        public NumericUpDown Support
        {
            get
            {
                return nudSupport;
            }
        }

        public NumericUpDown Confidence
        {
            get
            {
                return nudConfidence;
            }
        }
    }
}
