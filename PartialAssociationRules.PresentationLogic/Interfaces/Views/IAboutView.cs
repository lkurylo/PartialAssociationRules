/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;

namespace PartialAssociationRules.PresentationLogic.Interfaces
{
    public interface IAboutView : IView<IAboutView, IAboutViewPresenter>
    {
    }
}
