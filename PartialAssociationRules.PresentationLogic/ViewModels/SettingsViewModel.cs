/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.Domain;

namespace PartialAssociationRules.PresentationLogic.ViewModels
{
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {
            Alpha = SettingsManager.Settings.Alpha;
            Gamma = SettingsManager.Settings.Gamma;
            Support = SettingsManager.Settings.Support;
            Confidence = SettingsManager.Settings.Confidence;
            DefaultAlgorithm = SettingsManager.Settings.DefaultAlgorithm;
            ObjectsQuantity = SettingsManager.Settings.ObjectsQuantity;
            AttributesQuantity = SettingsManager.Settings.AttributesQuantity;
            TrimDataSet = SettingsManager.Settings.TrimDataSet;
            DefaultFilesCatalog = SettingsManager.Settings.DefaultFilesCatalog;
            DefaultGenerator = SettingsManager.Settings.DefaultGenerator;
            MaximalWeight = SettingsManager.Settings.MaximalWeight;
            MinimalWeight = SettingsManager.Settings.MinimalWeight;
            DefaultReportType = SettingsManager.Settings.DefaultReport;
            InsertInfSysInReport = SettingsManager.Settings.InsertInfSysInReport;
            PercentageOfSeparatedRows = SettingsManager.Settings.PercentageOfSeparatedRows;
            RegexForNamesHeader = SettingsManager.Settings.RegexForNamesHeader;
            DefaultRegex = SettingsManager.Settings.DefaultRegexIndex;
        }

        public decimal Alpha { set; get; }
        public decimal Gamma { set; get; }
        public decimal Support { set; get; }
        public decimal Confidence { set; get; }

        public int DefaultAlgorithm { set; get; }
        public int MaximalWeight { get; set; }
        public int MinimalWeight { get; set; }

        public bool TrimDataSet { set; get; }
        public string DefaultFilesCatalog { get; set; }

        public int DefaultGenerator { get; set; }
        public int ObjectsQuantity { set; get; }
        public int AttributesQuantity { set; get; }

        public int DefaultReportType { get; set; }
        public bool InsertInfSysInReport { get; set; }
        public string RegexForNamesHeader { get; set; }

        public int DefaultRegex { get; set; }

        public bool PercentageOfSeparatedRows { get; set; }
    }
}
