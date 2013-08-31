/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Interfaces.Views;
using System;

namespace PartialAssociationRules.PresentationLogic.Interfaces
{
    public interface IMainFormView : IView<IMainFormView, IMainFormViewPresenter>
    {
        void SetControlsStateWhenDataExists();
        void SetStartupControlsState();
        void SetStartupValues();
        void AlgorithmWithoutWeightsSelected();
        void AlgorithmWithWeightsSelected();
        ISummaryGroupData Summary { get; }
        void SetResultDataSource(System.Data.DataTable dataSource);
        void SetProgressBarMaxValue(int max);
        void UpdateProgressBar(int value);
        void GenerateReportAvailable();
        void SetWeightsDataSource(System.Data.DataTable dataSource);
        void SetDefaulfAlgorithm();
        void EnableGenerateButton();
        void NotifyAboutUnsupportedFileSelected();
        void NotifyAboutArgumentCountIncorrect();
        void NotifyAboutNoPermissionsToFile();
        void NotifyAboutRowsNotParsedCorrectly();
        void NotifyAboutIncorrectNumberOfFilesInArchive();
        void NotifyAboutIncorrectArchive();
        void NotifyAboutMissingInstruction();
        void NotifyAboutZeroRulesInResponse();
        void RefreshParameters();
        void NotifyAboutMissingDefaultPdfReader();

        void NotifyAboutNotMarketAtLeastOneAttributeAsDecision();
#if WEB
        void UpdateSummaryUP();
#endif

        void SetAlgorithmNameInStatusBar(string selectedAlgorithm);
        void SetAlgorithmRunLengthInStatusBar(TimeSpan runLength);
    }
}
