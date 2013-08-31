/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using System.Linq;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class PreviewDataView : Form, IPreviewDataView, IDisposable
    {
        private IPreviewDataViewPresenter presenter;
        public IPreviewDataViewPresenter Presenter
        {
            get
            {
                return presenter;
            }
        }

        public PreviewDataView()
        {
            InitializeComponent();

            presenter = Bootstrapper.ServiceLocator.GetService<IPreviewDataViewPresenter>();
            this.AttachToPresenter(presenter, true);
        }

        public void AttachToPresenter(PresentationLogic.Interfaces.Presenters.IPreviewDataViewPresenter presenter, 
            bool requiresInitialState)
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
                if (Presenter != null)
                {
                    Presenter.DisconnectView(this);
                    presenter = null;
                }
            }
        }

        new void Dispose()
        {
            DetatchFromPresenter();
        }

        public void SetDataSource(DataTable source)
        {
            previewGroup1.PreviewGrid.DataSource = source;
        }

        private void previewGroup1_Load(object sender, EventArgs e)
        {
            //populate the control with data
            Dictionary<string, bool> attrs = Presenter.GetDecisionAttributes();
            foreach (string key in attrs.Keys)
            {
                previewGroup1.DecisionAttributesList.Items.Add(key, attrs[key]);
            }

            //fires when user change item checked state
            //it's important to add this event after the control is populated
            previewGroup1.DecisionAttributesList.ItemCheck += (x, y) =>
            {
                int index = y.Index;
                CheckState state = y.NewValue;
                bool isChecked = false;
                switch (state)
                {
                    case CheckState.Checked:
                    case CheckState.Indeterminate:
                        isChecked = true;
                        break;
                    case CheckState.Unchecked:
                        isChecked = false;
                        break;
                }

                string attribute = previewGroup1.DecisionAttributesList.GetItemText(previewGroup1.DecisionAttributesList.Items[index]);

                Presenter.UpdateDecisionAttribute(attribute, isChecked);
            };

            previewGroup1.SelectAll.Checked = true;
            previewGroup1.SelectAll.CheckedChanged += (x, y) =>
            {
                bool isChecked = previewGroup1.SelectAll.Checked;
                if (isChecked)
                {
                    for (int i = 0; i < previewGroup1.DecisionAttributesList.Items.Count; i++)
                    {
                        previewGroup1.DecisionAttributesList.SetItemCheckState(i, CheckState.Checked);
                    }
                }
                else
                {
                    for (int i = 0; i < previewGroup1.DecisionAttributesList.Items.Count; i++)
                    {
                        previewGroup1.DecisionAttributesList.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            };
        }
    }
}
