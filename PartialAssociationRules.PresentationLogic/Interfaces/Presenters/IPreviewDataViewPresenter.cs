/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;

namespace PartialAssociationRules.PresentationLogic.Interfaces.Presenters
{
    public interface IPreviewDataViewPresenter : IPresenter<IPreviewDataViewPresenter, IPreviewDataView>
    {
        Dictionary<string, bool> GetDecisionAttributes();
        void UpdateDecisionAttribute(string attribute, bool isChecked);
    }
}
