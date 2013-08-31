/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Windows.Forms;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class AboutView : Form, IAboutView, IDisposable
    {
        private IAboutViewPresenter presenter;
        public IAboutViewPresenter Presenter
        {
            get
            {
                return presenter;
            }
        }

        public AboutView()
        {
            InitializeComponent();
            
            presenter = Bootstrapper.ServiceLocator.GetService<IAboutViewPresenter>();
            this.AttachToPresenter(presenter, false);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void ShowForm()
        //{
        //    this.ShowDialog();
        //}

        public void AttachToPresenter(IAboutViewPresenter presenter, bool requiresInitialState)
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

        void IDisposable.Dispose()
        {
            DetatchFromPresenter();
        }
    }
}
