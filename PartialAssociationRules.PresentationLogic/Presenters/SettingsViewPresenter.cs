/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Linq;
using PartialAssociationRules.Domain;
using PartialAssociationRules.Domain.Gui;
using PartialAssociationRules.Domain.Report;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Interfaces.Views;
using PartialAssociationRules.PresentationLogic.ViewModels;

namespace PartialAssociationRules.PresentationLogic.Presenters
{
    /// <summary>
    /// Default presenter for SettingsView form.
    /// </summary>
    public class SettingsViewPresenter : PresenterBase<ISettingsViewPresenter, ISettingsView>, ISettingsViewPresenter
    {
        private SettingsViewModel viewModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SettingsViewPresenter()
        {
            viewModel = new SettingsViewModel();
        }

        protected override void RefreshView(ISettingsView view)
        {
            view.InitializeControlsEvents();
        }

        /// <summary>
        /// Default view model for SettingsView form.
        /// </summary>
        public SettingsViewModel ViewModel
        {
            get { return viewModel; }
        }

        /// <summary>
        /// Sets new user definied values to the config file changed in the SettingsView form.
        /// </summary>
        public void SetNewDefaultValues()
        {
            SettingsManager.Settings.Alpha = viewModel.Alpha;
            SettingsManager.Settings.Gamma = viewModel.Gamma;
            SettingsManager.Settings.Support = viewModel.Support;
            SettingsManager.Settings.Confidence = viewModel.Confidence;

            SettingsManager.Settings.DefaultAlgorithm = viewModel.DefaultAlgorithm;
            SettingsManager.Settings.MinimalWeight = viewModel.MinimalWeight;
            SettingsManager.Settings.MaximalWeight = viewModel.MaximalWeight;

            SettingsManager.Settings.TrimDataSet = viewModel.TrimDataSet;
            SettingsManager.Settings.DefaultFilesCatalog = viewModel.DefaultFilesCatalog;

            SettingsManager.Settings.AttributesQuantity = viewModel.AttributesQuantity;
            SettingsManager.Settings.ObjectsQuantity = viewModel.ObjectsQuantity;
            SettingsManager.Settings.DefaultGenerator = viewModel.DefaultGenerator;

            SettingsManager.Settings.DefaultReport = viewModel.DefaultReportType;
            SettingsManager.Settings.InsertInfSysInReport = viewModel.InsertInfSysInReport;
            SettingsManager.Settings.PercentageOfSeparatedRows = viewModel.PercentageOfSeparatedRows;

            SettingsManager.Settings.RegexForNamesHeader = viewModel.RegexForNamesHeader;
            SettingsManager.Settings.DefaultRegexIndex = viewModel.DefaultRegex;

            SettingsManager.Settings.Save();
        }

        /// <summary>
        /// Gets available algorithms as a array of string.
        /// </summary>
        public string[] AvailableAlgorithms
        {
            get
            {
                AlgorithmsNameType alg = new AlgorithmsNameType();
                return alg.Keys.ToArray();
            }
        }

        public void SaveDefaultRegexIndex()
        {
            SettingsManager.Settings.DefaultRegexIndex = viewModel.DefaultRegex;

            SettingsManager.Settings.Save();
        }

        public void RestoreDefaultSettings()
        {
            SettingsManager.Settings.Reset();
        }

        public string[] GetAvilableReportTypes()
        {
            ReportExtensions reports = new ReportExtensions();
            return reports.ReportTypes.ToArray();
        }
    }
}
