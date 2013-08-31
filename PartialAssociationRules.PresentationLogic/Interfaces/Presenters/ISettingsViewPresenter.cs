/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.PresentationLogic.Interfaces.Views;
using PartialAssociationRules.PresentationLogic.ViewModels;

namespace PartialAssociationRules.PresentationLogic.Interfaces.Presenters
{
    public interface ISettingsViewPresenter : IPresenter<ISettingsViewPresenter, ISettingsView>
    {
        SettingsViewModel ViewModel { get; }
        void SetNewDefaultValues();
        string[] AvailableAlgorithms { get; }
        void SaveDefaultRegexIndex();
        void RestoreDefaultSettings();
        string[] GetAvilableReportTypes();
    }
}
