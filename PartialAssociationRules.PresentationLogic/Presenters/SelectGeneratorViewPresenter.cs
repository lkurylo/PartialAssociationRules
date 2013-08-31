/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Web;
using System.Web.Profile;
using PartialAssociationRules.Domain;
using PartialAssociationRules.Domain.DataGenerators;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Model;
using PartialAssociationRules.PresentationLogic.ViewModels;

namespace PartialAssociationRules.PresentationLogic.Presenters
{
    public class SelectGeneratorViewPresenter :
        PresenterBase<ISelectGeneratorViewPresenter, ISelectGeneratorView>, ISelectGeneratorViewPresenter
    {
        public SelectGeneratorViewModel ViewModel
        {
            get
            {
                return viewModel;
            }
        }

        public SelectGeneratorViewPresenter()
        {
            viewModel = new SelectGeneratorViewModel();
        }

        private SelectGeneratorViewModel viewModel;

        public void GenerateNewDataSet()
        {
            IDataGenerator dataGenerator = Bootstrapper.ServiceLocator.GetService<IDataGenerator>(viewModel.UseBinaryGenerator ?
                      GeneratorType.Binary :
                      GeneratorType.Numeric);

            // ProfileManager.Provider.GetPropertyValues
            if (ApplicationModel.System != null)
            {
                var sys = InformationSystem.CreateFromGenerator(dataGenerator,
                viewModel.NumberOfAttributes, viewModel.NumberOfObjects);
                ApplicationModel.System.Rows = sys.Rows;
            }
            else
            {
                ApplicationModel.System = InformationSystem.CreateFromGenerator(dataGenerator,
                viewModel.NumberOfAttributes, viewModel.NumberOfObjects);
            }

            IMainFormViewPresenter mainForm;
#if WEB
            mainForm = HttpContext.Current.Session["presenter"] as IMainFormViewPresenter;
#else
             mainForm = Bootstrapper.ServiceLocator.GetService<IMainFormViewPresenter>();
#endif
            mainForm.ViewModel.DataSetName = "zbiór wygenerowany";
            mainForm.ViewModel.AttributesQuantity = ViewModel.NumberOfAttributes;
            mainForm.ViewModel.ObjectsQuantity = ViewModel.NumberOfObjects;
        }

        protected override void RefreshView(ISelectGeneratorView view)
        {
            view.SetStartupValues();
            view.SetStartupControlsState();
        }

        public string GetDefaultAttributesQuantity()
        {
            return SettingsManager.Settings.AttributesQuantity.ToString();
        }

        public string GetDefaultObjectsQuantity()
        {
            return SettingsManager.Settings.ObjectsQuantity.ToString();
        }
    }
}
