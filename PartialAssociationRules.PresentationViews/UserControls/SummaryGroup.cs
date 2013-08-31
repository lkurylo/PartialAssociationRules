/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Windows.Forms;
using PartialAssociationRules.PresentationLogic.Interfaces.Views;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class SummaryGroup : UserControl, ISummaryGroupData
    {
        public SummaryGroup()
        {
            InitializeComponent();
        }

        public string DataSetName
        {
            get
            {
                return lblDataSetName.Text;
            }
            set
            {
                lblDataSetName.Text = value;
            }
        }

        public int ObjectsQuantity
        {
            get
            {
                return Convert.ToInt32(lblObjectsQuantity.Text);
            }
            set
            {
                lblObjectsQuantity.Text = Convert.ToString(value);
            }
        }

        public int AttributesQuantity
        {
            get
            {
                return Convert.ToInt32(lblAttributesQuantity.Text);
            }
            set
            {
                lblAttributesQuantity.Text = Convert.ToString(value);
            }
        }

        public int GeneratedRulesQuantity
        {
            get
            {
                return Convert.ToInt32(lblGeneratedRulesQuantity.Text);
            }
            set
            {
                lblGeneratedRulesQuantity.Text = Convert.ToString(value);
            }
        }

        public int GenerateDiffrentRulesQuantity
        {
            get
            {
                return Convert.ToInt32(lblGenerateDiffrentRulesQuantity.Text);
            }
            set
            {
                lblGenerateDiffrentRulesQuantity.Text = Convert.ToString(value);
            }
        }

        public decimal AverageSupport
        {
            get
            {
                return Convert.ToDecimal(lblAverageSupport.Text);
            }
            set
            {
                lblAverageSupport.Text = Convert.ToString(value);
            }
        }

        public decimal AverageConfidence
        {
            get
            {
                return Convert.ToDecimal(lblAverageConfidence.Text);
            }
            set
            {
                lblAverageConfidence.Text = Convert.ToString(value);
            }
        }

        public int MinimalRuleLength
        {
            get
            {
                return Convert.ToInt32(lblMinimalRuleLength.Text);
            }
            set
            {
                lblMinimalRuleLength.Text = Convert.ToString(value);
            }
        }

        public int MinimalUpperBound
        {
            get
            {
                return Convert.ToInt32(lblMinimalUpperBound.Text);
            }
            set
            {
                lblMinimalUpperBound.Text = Convert.ToString(value);
            }
        }

        public decimal AverageUpperBound
        {
            get
            {
                return Convert.ToInt32(lblAverageUpperBound.Text);
            }
            set
            {
                lblAverageUpperBound.Text = Convert.ToString(value);
            }
        }

        public int MaximalUpperBound
        {
            get
            {
                return Convert.ToInt32(lblMaximalUpperBound.Text);
            }
            set
            {
                lblMaximalUpperBound.Text = Convert.ToString(value);
            }
        }

        public int MinimalLowerBound
        {
            get
            {
                return Convert.ToInt32(lblMinimalLowerBound.Text);
            }
            set
            {
                lblMinimalLowerBound.Text = Convert.ToString(value);
            }
        }

        public decimal AverageLowerBound
        {
            get
            {
                return Convert.ToInt32(lblAverageLowerBound.Text);
            }
            set
            {
                lblAverageLowerBound.Text = Convert.ToString(value);
            }
        }

        public int MaximalLowerBound
        {
            get
            {
                return Convert.ToInt32(lblMaximalLowerBound.Text);
            }
            set
            {
                lblMaximalLowerBound.Text = Convert.ToString(value);
            }
        }

        public decimal AverageRuleLength
        {
            get
            {
                return Convert.ToDecimal(lblAverageRuleLength.Text);
            }
            set
            {
                lblAverageRuleLength.Text = Convert.ToString(value);
            }
        }

        public int MaximalRuleLength
        {
            get
            {
                return Convert.ToInt32(lblMaximalRuleLength.Text);
            }
            set
            {
                lblMaximalRuleLength.Text = Convert.ToString(value);
            }
        }

        public decimal MinimalSupport
        {
            get
            {
                return Convert.ToDecimal(lblMinimalSupport.Text);
            }
            set
            {
                lblMinimalSupport.Text = Convert.ToString(value);
            }
        }

        public decimal MaximalSupport
        {
            get
            {
                return Convert.ToDecimal(lblMaximalSupport.Text);
            }
            set
            {
                lblMaximalSupport.Text = Convert.ToString(value);
            }
        }

        public decimal MinimalConfidence
        {
            get
            {
                return Convert.ToDecimal(lblMinimalConfidence.Text);
            }
            set
            {
                lblMinimalConfidence.Text = Convert.ToString(value);
            }
        }

        public decimal MaximalConfidence
        {
            get
            {
                return Convert.ToDecimal(lblMaximalConfidence.Text);
            }
            set
            {
                lblMaximalConfidence.Text = Convert.ToString(value);
            }
        }
    }
}
