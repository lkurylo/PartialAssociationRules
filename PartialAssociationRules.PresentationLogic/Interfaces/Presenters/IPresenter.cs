/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialAssociationRules.PresentationLogic.Interfaces.Presenters
{
    public interface IPresenter<TPresenter, TView>
        where TPresenter : IPresenter<TPresenter, TView>
        where TView : IView<TView, TPresenter>
    {
        void ConnectView(TView view, bool requiresState);
        void DisconnectView(TView view);
    }
}
