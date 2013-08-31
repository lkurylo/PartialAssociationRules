/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;

namespace PartialAssociationRules.PresentationLogic.Interfaces
{
    public interface IView<TView, TPresenter>
        where TView : IView<TView, TPresenter>
        where TPresenter : IPresenter<TPresenter, TView>
    {
        void AttachToPresenter(TPresenter presenter, bool requiresInitialState);
        void DetatchFromPresenter();
        //TPresenter Presenter { get; }
    }
}
