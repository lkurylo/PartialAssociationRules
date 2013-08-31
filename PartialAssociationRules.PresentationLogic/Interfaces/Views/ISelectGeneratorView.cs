/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;

namespace PartialAssociationRules.PresentationLogic.Interfaces
{
    public interface ISelectGeneratorView : IView<ISelectGeneratorView, ISelectGeneratorViewPresenter>
    {
        void SetStartupControlsState();
        void SetStartupValues();
    }
}
