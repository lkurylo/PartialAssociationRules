/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using PartialAssociationRules.Domain.Extensions;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Model;

namespace PartialAssociationRules.PresentationLogic.Presenters
{
    public class PreviewDataPresenter : PresenterBase<IPreviewDataViewPresenter, IPreviewDataView>, IPreviewDataViewPresenter
    {
        protected override void RefreshView(IPreviewDataView view)
        {
#if !WEB
            var rows = ApplicationModel.System.Rows.ConvertDataSetToDataTable();
            view.SetDataSource(rows);
#endif
        }

        public Dictionary<string, bool> GetDecisionAttributes()
        {
            return ApplicationModel.System.DecisionAttributes;
        }

        public void UpdateDecisionAttribute(string attribute, bool isChecked)
        {
            ApplicationModel.System.DecisionAttributes[attribute] = isChecked;
        }
    }
}
