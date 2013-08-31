/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.PresentationLogic.ViewModels;

namespace PartialAssociationRules.PresentationLogic.Interfaces.Presenters
{
    public interface ISelectGeneratorViewPresenter : IPresenter<ISelectGeneratorViewPresenter, ISelectGeneratorView>
    {
        SelectGeneratorViewModel ViewModel { get; }
        void GenerateNewDataSet();

        string GetDefaultAttributesQuantity();

        string GetDefaultObjectsQuantity();
    }
}
