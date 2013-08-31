/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class DataSourceGroup : UserControl
    {
        public DataSourceGroup()
        {
            InitializeComponent();
        }

        public Button LoadFile
        {
            get
            {
                return btnLoadFile;
            }
        }

        public Button GenerateSet
        {
            get
            {
                return btnGenerateSet;
            }
        }

        public Button PreviewData
        {
            get
            {
                return btnPreviewData;
            }
        }

        public OpenFileDialog OpenFile
        {
            get
            {
                return openFileDialog1;
            }
        }
    }
}
