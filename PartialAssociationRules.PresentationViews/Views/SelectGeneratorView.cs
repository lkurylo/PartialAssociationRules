/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Windows.Forms;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class SelectGeneratorView : Form, ISelectGeneratorView, IDisposable
    {
        private ISelectGeneratorViewPresenter presenter;
        public ISelectGeneratorViewPresenter Presenter
        {
            get { return presenter; }
        }

        public SelectGeneratorView()
        {
            InitializeComponent();

            presenter = Bootstrapper.ServiceLocator.GetService<ISelectGeneratorViewPresenter>();
            this.AttachToPresenter(presenter, true);
        }

        private void SelectGeneratorView_Load(object sender, System.EventArgs e)
        {
            selectGeneratorPanel1.BinaryGenerator.Checked = true;

            selectGeneratorPanel1.Generate.Click += (x, y) =>
            {
                Presenter.ViewModel.NumberOfObjects = Convert.ToInt32(selectGeneratorPanel1.ObjectsQuantity.Text);
                Presenter.ViewModel.NumberOfAttributes = Convert.ToInt32(selectGeneratorPanel1.AttributesQuantity.Text);
                Presenter.ViewModel.UseBinaryGenerator = selectGeneratorPanel1.BinaryGenerator.Checked;

                presenter.GenerateNewDataSet();
                this.Close();
            };

            selectGeneratorPanel1.Cancel.Click += (x, y) =>
            {
                this.Close();
            };
        }

        public void AttachToPresenter(ISelectGeneratorViewPresenter presenter, bool requiresInitialState)
        {
            if (presenter == null)
                throw new ArgumentNullException("presenter");

            DetatchFromPresenter();

            this.presenter = presenter;

            presenter.ConnectView(this, requiresInitialState);
        }

        public void DetatchFromPresenter()
        {
            lock (this)
            {
                if (presenter != null)
                {
                    presenter.DisconnectView(this);
                    presenter = null;
                }
            }
        }

        public void SetStartupControlsState()
        {
            selectGeneratorPanel1.ObjectsQuantity.Focus();
        }

        public void SetStartupValues()
        {
            selectGeneratorPanel1.AttributesQuantity.Text = Presenter.GetDefaultAttributesQuantity(); 
            selectGeneratorPanel1.ObjectsQuantity.Text = Presenter.GetDefaultObjectsQuantity(); 
        }

        void IDisposable.Dispose()
        {
            DetatchFromPresenter();
        }
    }
}
