/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Interfaces.Views;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class SettingsView : Form, ISettingsView, IDisposable
    {
        private ISettingsViewPresenter presenter;
        public SettingsView()
        {
            InitializeComponent();

            presenter = Bootstrapper.ServiceLocator.GetService<ISettingsViewPresenter>();
            this.AttachToPresenter(presenter, true);
        }

        public void AttachToPresenter(ISettingsViewPresenter presenter, bool requiresInitialState)
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

        public ISettingsViewPresenter Presenter
        {
            get { return presenter; }
        }

        new void Dispose()
        {
            DetatchFromPresenter();
        }

        public void InitializeControlsEvents()
        {
            this.btnSettingsCancel.Click += (x, y) =>
            {
                this.Close();
            };

            this.btnSettingsSaveNew.Click += (x, y) =>
            {
                //if (MessageBoxView.Show("Aby wprowadzone zmiany odniosły skutek, należy zrestartować aplikację.", "Zapisz",
                //       MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                //{
                Presenter.SetNewDefaultValues();
                this.Close();
                //}
            };

            this.btnSetDefault.Click += (x, y) =>
            {
                Presenter.RestoreDefaultSettings();
                this.Close();
            };
        }

        private void defaultParametersGroup1_Load(object sender, EventArgs e)
        {
            defaultParametersGroup1.Alpha.ValueChanged += (x, y) =>
            {
                Presenter.ViewModel.Alpha = ((NumericUpDown)x).Value;
                defaultParametersGroup1.Gamma.Maximum = defaultParametersGroup1.Alpha.Value;
            };

            defaultParametersGroup1.Gamma.ValueChanged += (x, y) =>
            {
                Presenter.ViewModel.Gamma = ((NumericUpDown)x).Value;
            };

            defaultParametersGroup1.Support.ValueChanged += (x, y) =>
            {
                Presenter.ViewModel.Support = ((NumericUpDown)x).Value;
            };

            defaultParametersGroup1.Confidence.ValueChanged += (x, y) =>
            {
                Presenter.ViewModel.Confidence = ((NumericUpDown)x).Value;
            };

            defaultParametersGroup1.Alpha.Value = Presenter.ViewModel.Alpha;
            defaultParametersGroup1.Gamma.Value = Presenter.ViewModel.Gamma;
            defaultParametersGroup1.Support.Value = Presenter.ViewModel.Support;
            defaultParametersGroup1.Confidence.Value = Presenter.ViewModel.Confidence;
        }

        private void defaultAlgorithmsGroup1_Load(object sender, EventArgs e)
        {
            string[] algorithms = Presenter.AvailableAlgorithms;
            defaultAlgorithmsGroup1.Algorithm.Items.Clear();
            defaultAlgorithmsGroup1.Algorithm.Items.AddRange(algorithms);

            defaultAlgorithmsGroup1.Algorithm.SelectedIndex = Presenter.ViewModel.DefaultAlgorithm;
            defaultAlgorithmsGroup1.MinimalWeight.Text = Presenter.ViewModel.MinimalWeight.ToString();
            defaultAlgorithmsGroup1.MaximalWeight.Text = Presenter.ViewModel.MaximalWeight.ToString();

            defaultAlgorithmsGroup1.Algorithm.SelectedIndexChanged += (x, y) =>
            {
                Presenter.ViewModel.DefaultAlgorithm = ((ComboBox)x).SelectedIndex;
            };

            defaultAlgorithmsGroup1.MinimalWeight.TextChanged += (x, y) =>
            {
                Presenter.ViewModel.MinimalWeight = Convert.ToInt32(((TextBox)x).Text);
            };

            defaultAlgorithmsGroup1.MaximalWeight.TextChanged += (x, y) =>
            {
                Presenter.ViewModel.MaximalWeight = Convert.ToInt32(((TextBox)x).Text);
            };
        }

        private void defaultParsersGroup1_Load(object sender, EventArgs e)
        {
            defaultParsersGroup1.TrimDataSet.Checked = Presenter.ViewModel.TrimDataSet;
            defaultParsersGroup1.DefaultFilesCatalog.Text = Presenter.ViewModel.DefaultFilesCatalog;

            string[] regexs = Presenter.ViewModel.RegexForNamesHeader.Split(new string[] { ";;;" },
                StringSplitOptions.RemoveEmptyEntries);
            string[] regexsAfterCleaning = new string[regexs.Count()];
            int i = 0;
            regexs.ToList().ForEach(x =>
            {
                regexsAfterCleaning[i++] = x;
            });

            defaultParsersGroup1.RegexsList.Items.AddRange(regexsAfterCleaning);

            defaultParsersGroup1.DefaultFilesCatalog.TextChanged += (x, y) =>
            {
                Presenter.ViewModel.DefaultFilesCatalog = ((TextBox)x).Text;
            };

            defaultParsersGroup1.TrimDataSet.CheckedChanged += (x, y) =>
            {
                Presenter.ViewModel.TrimDataSet = ((CheckBox)x).Checked;
            };

            defaultParsersGroup1.Menu.Opening += (x, y) =>
            {
                var selectedIndex = defaultParsersGroup1.RegexsList.SelectedIndex;
                if (selectedIndex == -1)
                {
                    foreach (var singleItem in defaultParsersGroup1.Menu.Items)
                    {
                        ((ToolStripItem)singleItem).Enabled = false;
                    }
                }
                else
                {
                    foreach (var singleItem in defaultParsersGroup1.Menu.Items)
                    {
                        ((ToolStripItem)singleItem).Enabled = true;
                    }
                }
            };

            defaultParsersGroup1.DeleteSelected.Click += (x, y) =>
            {
                var selectedIndex = defaultParsersGroup1.RegexsList.SelectedIndex;
                if (selectedIndex != -1)
                {
                    if (selectedIndex == Presenter.ViewModel.DefaultRegex)
                    {
                        Presenter.ViewModel.DefaultRegex = 0;
                        defaultParsersGroup1.RegexsList.Refresh();
                    }

                    defaultParsersGroup1.RegexsList.Items.RemoveAt(selectedIndex);

                    UpdateRegexList();
                }
            };

            defaultParsersGroup1.AddRegexForNamesFilesButton.Enabled = false;

            defaultParsersGroup1.AddRegexForNamesFilesTextBox.TextChanged += (x, y) =>
            {
                if (String.IsNullOrEmpty(defaultParsersGroup1.AddRegexForNamesFilesTextBox.Text))
                {
                    defaultParsersGroup1.AddRegexForNamesFilesButton.Enabled = false;
                }
                else
                {
                    defaultParsersGroup1.AddRegexForNamesFilesButton.Enabled = true;
                }
            };

            defaultParsersGroup1.AddRegexForNamesFilesButton.Click += (x, y) =>
            {
                string newItem = defaultParsersGroup1.AddRegexForNamesFilesTextBox.Text;
                defaultParsersGroup1.AddRegexForNamesFilesTextBox.Text = "";
                defaultParsersGroup1.RegexsList.Items.Add(newItem);

                UpdateRegexList();
            };

            defaultParsersGroup1.SetDefault.Click += (x, y) =>
            {
                var selectedIndex = defaultParsersGroup1.RegexsList.SelectedIndex;
                if (selectedIndex != -1)
                {
                    Presenter.ViewModel.DefaultRegex = selectedIndex;
                    //Presenter.SaveDefaultRegexIndex();//TODO dodac te zmienna do configa bo teraz tego nie ma
                    defaultParsersGroup1.RegexsList.Refresh();
                }
            };

            defaultParsersGroup1.RegexsList.DrawItem += (x, y) =>
            {
                bool selected = ((y.State & DrawItemState.Selected) == DrawItemState.Selected);

                int index = y.Index;
                if (index >= 0 && index < defaultParsersGroup1.RegexsList.Items.Count)
                {
                    string text = defaultParsersGroup1.RegexsList.Items[index].ToString();
                    Graphics g = y.Graphics;

                    Color color;
                    if (index == Presenter.ViewModel.DefaultRegex)
                    {
                        color = Color.Orange;
                    }
                    else
                    {
                        color = Color.White;
                    }

                    g.FillRectangle(new SolidBrush(color), y.Bounds);

                    if (selected)
                    {
                        color = Color.FromKnownColor(KnownColor.Highlight);
                    }

                    g.FillRectangle(new SolidBrush(color), y.Bounds);

                    // Print text
                    g.DrawString(text, y.Font, Brushes.Black,
                        defaultParsersGroup1.RegexsList.GetItemRectangle(index).Location);
                }

                y.DrawFocusRectangle();
            };

            defaultParsersGroup1.Copy.Click += (x, y) =>
            {
                var selectedIndex = defaultParsersGroup1.RegexsList.SelectedIndex;
                if (selectedIndex != -1)
                {
                    Clipboard.SetDataObject(defaultParsersGroup1.RegexsList.Items[selectedIndex], true);
                }
            };
        }

        private void defaultGeneratorsGroup1_Load(object sender, EventArgs e)
        {
            defaultGeneratorsGroup1.DefaultGenerator.SelectedIndex = Presenter.ViewModel.DefaultGenerator;

            defaultGeneratorsGroup1.ObjectsQuantityDefault.Text = Presenter.ViewModel.ObjectsQuantity.ToString();
            defaultGeneratorsGroup1.AttributesQuantityDefault.Text = Presenter.ViewModel.AttributesQuantity.ToString();

            defaultGeneratorsGroup1.DefaultGenerator.SelectedIndexChanged += (x, y) =>
            {
                Presenter.ViewModel.DefaultGenerator = ((ComboBox)x).SelectedIndex;
            };

            defaultGeneratorsGroup1.ObjectsQuantityDefault.TextChanged += (x, y) =>
            {
                Presenter.ViewModel.ObjectsQuantity = Convert.ToInt32(((TextBox)x).Text);
            };

            defaultGeneratorsGroup1.AttributesQuantityDefault.TextChanged += (x, y) =>
            {
                Presenter.ViewModel.AttributesQuantity = Convert.ToInt32(((TextBox)x).Text);
            };
        }

        private void defaultReportsGroup1_Load(object sender, EventArgs e)
        {
            defaultReportsGroup1.DefaultReportType.Items.AddRange(Presenter.GetAvilableReportTypes());

            defaultReportsGroup1.DefaultReportType.SelectedIndex = Presenter.ViewModel.DefaultReportType;

            defaultReportsGroup1.DefaultReportType.SelectedIndexChanged += (x, y) =>
            {
                Presenter.ViewModel.DefaultReportType = Convert.ToInt32(((ComboBox)x).SelectedIndex);
            };

            defaultReportsGroup1.InfSysInTXTReport.Checked = Presenter.ViewModel.InsertInfSysInReport;

            defaultReportsGroup1.InfSysInTXTReport.CheckedChanged += (x, y) =>
            {
                Presenter.ViewModel.InsertInfSysInReport = defaultReportsGroup1.InfSysInTXTReport.Checked;
            };

            defaultReportsGroup1.PercentageOfSeparatedRows.Checked = Presenter.ViewModel.PercentageOfSeparatedRows;

            defaultReportsGroup1.PercentageOfSeparatedRows.CheckedChanged += (x, y) =>
            {
                Presenter.ViewModel.PercentageOfSeparatedRows = defaultReportsGroup1.PercentageOfSeparatedRows.Checked;
            };
        }

        private void UpdateRegexList()
        {
            StringBuilder result = new StringBuilder();
            foreach (var singleItem in defaultParsersGroup1.RegexsList.Items)
            {
                result.AppendFormat("{0};;;", (string)singleItem);
            }

            Presenter.ViewModel.RegexForNamesHeader = result.ToString().TrimEnd(';');
        }
    }
}
