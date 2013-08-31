/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;

namespace PartialAssociationRules.PresentationLogic.Interfaces.Views
{
    public interface ISettingsView : IView<ISettingsView, ISettingsViewPresenter>
    {
        void InitializeControlsEvents();
    }
}
