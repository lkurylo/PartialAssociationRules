/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using System.ComponentModel;

namespace PartialAssociationRules.PresentationLogic.Model
{
    public static class ApplicationModel
    {
        private static InformationSystem system;
        public static InformationSystem System
        {
            set
            {
                system = value;
                NotifyPropertyChanged("System");
            }
            get
            {
                if (system == null)
                {
                    system = new InformationSystem();
                }

                return system;
            }
        }

        private static Dictionary<string, int> weights;
        public static Dictionary<string, int> Weights
        {
            set
            {
                weights = value;
                NotifyPropertyChanged("Weights");
            }
            get
            {
                if (weights == null)
                {
                    weights = new Dictionary<string, int>();
                }

                return weights;
            }
        }

        private static IEnumerable<RuleCount> filteredRules;
        public static IEnumerable<RuleCount> FilteredRules
        {
            set
            {
                filteredRules = value;
                NotifyPropertyChanged("FilteredRules");
            }
            get
            {
                if (filteredRules == null)
                {
                    filteredRules = new List<RuleCount>();
                }

                return filteredRules;
            }
        }

        public static event PropertyChangedEventHandler PropertyChanged;

        private static void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(null, new PropertyChangedEventArgs(property));
            }
        }

        public static IEnumerable<RuleCount> Rules { get; set; }

        public static IEnumerable<AlgorithmProgressExecution> SeparatedRows
        {
            set;
            get;
        }
    }
}
