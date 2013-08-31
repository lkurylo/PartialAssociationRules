/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using System.Linq;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;

namespace PartialAssociationRules.PresentationLogic.Presenters
{
    public abstract class PresenterBase<TPresenter, TView> :
         IPresenter<TPresenter, TView>
        where TView : IView<TView, TPresenter>
        where TPresenter : IPresenter<TPresenter, TView>
    {
        private TView view;

        protected abstract void RefreshView(TView view);

        public void ConnectView(TView view, bool requiresState)
        {
            this.view = view;

            if (requiresState)
                RefreshView(view);
        }

        public void DisconnectView(TView view)
        {
            this.view = default(TView);
        }

        protected TView View
        {
            get
            {
                return view;
            }
        }
    }
}
