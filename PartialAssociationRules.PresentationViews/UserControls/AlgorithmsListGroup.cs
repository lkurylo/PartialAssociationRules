/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class AlgorithmsListGroup : UserControl
    {
        public AlgorithmsListGroup()
        {
            InitializeComponent();
        }

        public Button Generate{
            get
            {
                return btnGenerate;
            }
        }

        public Button GenerateWeights{
            get
            {
                return btnGenerateWeights;
            }
        }

        public Button Reset{
            get
            {
                return btnReset;
            }
        }

        public Button SaveReport{
            get
            {
                return btnSaveReport;
            }
        }

        public ComboBox Algorithms
        {
            get { return cbAlgorithms; }
        }

        public ProgressBar GenerateRulesProgress
        {
            get { return pbGenerateRulesProgress; }
        }

        public DataGridView Weights
        {
            get
            {
                return dgvWeights;
            }
        }

        public BindingSource BindingSource
        {
            get
            {
                return bindingSource1;
            }
        }

        public SaveFileDialog SaveFileDialog
        {
            get
            {
                return saveFileDialog1;
            }
        }
    }
}
