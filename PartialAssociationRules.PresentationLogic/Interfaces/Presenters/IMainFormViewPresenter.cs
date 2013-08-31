/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.IO;
using PartialAssociationRules.PresentationLogic.Interfaces.Views;
using PartialAssociationRules.PresentationLogic.ViewModels;
using System.Collections;

namespace PartialAssociationRules.PresentationLogic.Interfaces.Presenters
{
    public interface IMainFormViewPresenter : IPresenter<IMainFormViewPresenter, IMainFormView>
    {
        MainFormViewModel ViewModel { get; }
        void ProcessUploadedFile(string fileName, Stream file);
        void SelectedAlgorithmChanged(string algName);
        void SetControlsStateWhenDataIsAvailable();
        void SetControlsStateWhenDataIsNotAvailable();
        void ResetForm();
        ISummaryGroupData Summary { get; }
        void GenerateRules();
        string[] AvailableAlgorithms { get; }
        void ShowGeneratedRulesAndDistinctGeneratedRowsQuantity();
        void SetProgressBarMaxValue(int max);
        void GenerateReportAvailable();
        void SetSummaryDetails();
        void GenerateWeights();
        bool IsDataAvailable { get; }
        void EnableGenerateButton();
        void SaveReportToFile(string fileName);
        string GetReportName();
        void UpdateWeightForAttribute(string attribute, int newValue);
        void OpenInstruction();
        string GetDefaultDirectoryToSaveReports();
        string GetDefaultDirectoryContainsDataSourceFiles();
        void MarkDecisionAttributes();
        decimal GetDefaultAlpha();
        decimal GetDefaultGamma();
        decimal GetDefaultConfidence();
        decimal GetDefaultSupport();
        int GetDefaultAlgorithm();
        string GetDefaultReportExtension();
        void FilterRules();
        bool AreRulesAvailable { get; }
#if WEB
        void UpdateSummaryUP();
        string GetDumpedInformationSystem();
#endif
    }
}
