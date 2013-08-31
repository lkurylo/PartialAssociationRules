/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Linq;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;

namespace PartialAssociationRules.PresentationLogic.Presenters
{
    public class AboutViewPresenter : PresenterBase<IAboutViewPresenter, IAboutView>, IAboutViewPresenter
    {
        protected override void RefreshView(IAboutView viewInstance)
        {        
        }
    }
}
