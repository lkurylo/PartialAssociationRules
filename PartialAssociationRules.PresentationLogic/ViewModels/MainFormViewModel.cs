/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.ComponentModel;
using System.Collections.Generic;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.PresentationLogic.Model;

namespace PartialAssociationRules.PresentationLogic.ViewModels
{
    /// <summary>
    /// Represents view model for main application form.
    /// </summary>
    public class MainFormViewModel
    {
        /// <summary>
        /// Gets or sets the alpha value.
        /// </summary>
        public decimal Alpha
        {
            set
            {
                alpha = value;
                NotifyPropertyChanged("Alpha");
            }
            get
            {
                return alpha;
            }
        }

        /// <summary>
        /// Gets or sets the gamma value.
        /// </summary>
        public decimal Gamma
        {
            set
            {
                gamma = value;
                NotifyPropertyChanged("Gamma");
            }
            get
            {
                return gamma;
            }
        }

        /// <summary>
        /// Gets or sets the support value.
        /// </summary>
        public decimal Support
        {
            set
            {
                support = value;
                NotifyPropertyChanged("Support");
            }
            get
            {
                return support;
            }
        }

        /// <summary>
        /// Gets or sets the confidence value.
        /// </summary>
        public decimal Confidence
        {
            set
            {
                confidence = value;
                NotifyPropertyChanged("Confidence");
            }
            get
            {
                return confidence;
            }
        }

        /// <summary>
        /// Gets or sets the selected algorithm value.
        /// </summary>
        public string SelectedAlgorithm
        {
            set
            {
                selectedAlgorithm = value;
                NotifyPropertyChanged("SelectedAlgorithm");
            }
            get
            {
                return selectedAlgorithm;
            }
        }

        /// <summary>
        /// Gets or sets the dataset name value.
        /// </summary>
        public string DataSetName
        {
            set
            {
                dataSetName = value;
                NotifyPropertyChanged("DataSetName");
            }
            get
            {
                return dataSetName;
            }
        }

        /// <summary>
        /// Gets or sets the objects quantity value.
        /// </summary>
        public int ObjectsQuantity
        {
            set
            {
                objectsQuantity = value;
                NotifyPropertyChanged("ObjectsQuantity");
            }
            get
            {
                return objectsQuantity;
            }
        }

        /// <summary>
        /// Gets or sets the attributes quantity value.
        /// </summary>
        public int AttributesQuantity
        {
            set
            {
                attributesQuantity = value;
                NotifyPropertyChanged("AttributesQuantity");
            }
            get
            {
                return attributesQuantity;
            }
        }

        /// <summary>
        /// Gets or sets the generated rules quantity value.
        /// </summary>
        public int GeneratedRulesQuantity
        {
            set
            {
                generatedRulesQuantity = value;
                NotifyPropertyChanged("GeneratedRulesQuantity");
            }
            get
            {
                return generatedRulesQuantity;
            }
        }

        /// <summary>
        /// Gets or sets the alpha value.
        /// </summary>
        public int GenerateDiffrentRulesQuantity
        {
            set
            {
                generateDiffrentRulesQuantity = value;
                NotifyPropertyChanged("GenerateDiffrentRulesQuantity");
            }
            get
            {
                return generateDiffrentRulesQuantity;
            }
        }

        /// <summary>
        /// Gets or sets the average support value.
        /// </summary>
        public decimal AverageSupport
        {
            set
            {
                averageSupport = value;
                NotifyPropertyChanged("AverageSupport");
            }
            get
            {
                return averageSupport;
            }
        }

        /// <summary>
        /// Gets or sets the average confidence value.
        /// </summary>
        public decimal AverageConfidence
        {
            set
            {
                averageConfidence = value;
                NotifyPropertyChanged("AverageConfidence");
            }
            get
            {
                return averageConfidence;
            }
        }

        /// <summary>
        /// Gets or sets the minimal rule length value.
        /// </summary>
        public int MinimalRuleLength
        {
            set
            {
                minimalRuleLength = value;
                NotifyPropertyChanged("MinimalRuleLength");
            }
            get
            {
                return minimalRuleLength;
            }
        }

        /// <summary>
        /// Gets or sets the average rule length value.
        /// </summary>
        public decimal AverageRuleLength
        {
            set
            {
                averageRuleLength = value;
                NotifyPropertyChanged("AverageRuleLength");
            }
            get
            {
                return averageRuleLength;
            }
        }

        /// <summary>
        /// Gets or sets the maximal rule length value.
        /// </summary>
        public int MaximalRuleLength
        {
            set
            {
                maximalRuleLength = value;
                NotifyPropertyChanged("MaximalRuleLength");
            }
            get
            {
                return maximalRuleLength;
            }
        }

        public decimal MinimalSupport
        {
            set
            {
                minimalSupport = value;
                NotifyPropertyChanged("MinimalSupport");
            }
            get
            {
                return minimalSupport;
            }
        }

        public decimal MaximalSupport
        {
            set
            {
                maximalSupport = value;
                NotifyPropertyChanged("MaximalSupport");
            }
            get
            {
                return maximalSupport;
            }
        }

        public decimal MinimalConfidence
        {
            set
            {
                minimalConfidence = value;
                NotifyPropertyChanged("MinimalConfidence");
            }
            get
            {
                return minimalConfidence;
            }
        }

        public decimal MaximalConfidence
        {
            set
            {
                maximalConfidence = value;
                NotifyPropertyChanged("MaximalConfidence");
            }
            get
            {
                return maximalConfidence;
            }
        }

        public int MinimalUpperBound
        {
            get
            {
                return minimalUpperBound;
            }
            set
            {
                minimalUpperBound = value;
                NotifyPropertyChanged("MinimalUpperBound");
            }
        }

        public decimal AverageUpperBound
        {
            get
            {
                return averageUpperBound;
            }
            set
            {
                averageUpperBound = value;
                NotifyPropertyChanged("AverageUpperBound");
            }
        }

        public int MaximalUpperBound
        {
            get
            {
                return maximalUpperBound;
            }
            set
            {
                maximalUpperBound = value;
                NotifyPropertyChanged("MaximalUpperBound");
            }
        }

        public int MinimalLowerBound
        {
            get
            {
                return minimalLowerBound;
            }
            set
            {
                minimalLowerBound = value;
                NotifyPropertyChanged("MinimalLowerBound");
            }
        }

        public decimal AverageLowerBound
        {
            get
            {
                return averageLowerBound;
            }
            set
            {
                averageLowerBound = value;
                NotifyPropertyChanged("AverageLowerBound");
            }
        }

        public int MaximalLowerBound
        {
            get
            {
                return maximalLowerBound;
            }
            set
            {
                maximalLowerBound = value;
                NotifyPropertyChanged("MaximalLowerBound");
            }
        }

#if WEB
        private bool summaryUpdatePanel;
        public bool UpdateSummaryUP
        {
            set
            {
                summaryUpdatePanel = value;
                if (summaryUpdatePanel)
                {
                    NotifyPropertyChanged("UpdateSummaryUP");
                }
            }
            get
            {
                return summaryUpdatePanel;
            }
        }
#endif

        /// <summary>
        /// Raises when specific property has change.
        /// </summary>
        public static event PropertyChangedEventHandler PropertyChanged;

        private decimal gamma;
        private decimal alpha;
        private decimal support;
        private decimal confidence;
        private string selectedAlgorithm;
        private string dataSetName;
        private int objectsQuantity;
        private int attributesQuantity;
        private int generatedRulesQuantity;
        private int generateDiffrentRulesQuantity;
        private decimal averageConfidence;
        private decimal averageSupport;
        private int minimalRuleLength;
        private decimal averageRuleLength;
        private int maximalRuleLength;
        private decimal minimalSupport;
        private decimal maximalSupport;
        private decimal minimalConfidence;
        private decimal maximalConfidence;
        private int minimalUpperBound;
        private decimal averageUpperBound;
        private int maximalUpperBound;
        private int maximalLowerBound;
        private int minimalLowerBound;
        private decimal averageLowerBound;

        /// <summary>
        /// Notify when specific property value as change.
        /// </summary>
        /// <param name="property"></param>
        private static void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(null, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainFormViewModel()
        {
            //DataSetName = "-";
        }
    }
}
