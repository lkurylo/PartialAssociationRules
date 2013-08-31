/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Windows.Forms;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Interfaces.Views;
using PartialAssociationRules.PresentationViews.Views;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    /// <summary>
    /// Represents main application windows form.
    /// </summary>
    public partial class MainFormView : Form, IMainFormView
    {
        private IMainFormViewPresenter presenter;

        /// <summary>
        /// Presenter 
        /// </summary>
        public IMainFormViewPresenter Presenter
        {
            get
            {
                return presenter;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainFormView()
        {
            InitializeComponent();

            presenter = Bootstrapper.ServiceLocator.GetService<IMainFormViewPresenter>();
            this.AttachToPresenter(Presenter, true);
        }

        /// <summary>
        /// Load event for DataSourceGroup user control.
        /// </summary>
        /// <param name="sender">Object with send this event.</param>
        /// <param name="e">Event object.</param>
        private void dataSourceGroup1_Load(object sender, EventArgs e)
        {
            var self = (DataSourceGroup)sender;

            self.LoadFile.Click += (x, y) =>
            {
                dataSourceGroup1.OpenFile.ShowDialog();
            };

            self.GenerateSet.Click += (x, y) =>
            {
                using (
                    SelectGeneratorView view = new SelectGeneratorView())
                {
                    view.ShowDialog();
                }
            };

            self.PreviewData.Click += (x, y) =>
            {
                using (
               PreviewDataView view = new PreviewDataView())
                {
                    view.ShowDialog();
                }
            };

            self.OpenFile.InitialDirectory = Presenter.GetDefaultDirectoryContainsDataSourceFiles();

            self.OpenFile.FileOk += (x, y) =>
            {
                var fileDialog = (OpenFileDialog)x;

                Presenter.ProcessUploadedFile(fileDialog.FileName, fileDialog.OpenFile());
            };

            self.LoadFile.DragEnter += (x, y) =>
            {
                y.Effect = DragDropEffects.Copy;
            };

            self.LoadFile.DragDrop += (x, y) =>
            {
                string[] file = y.Data.GetData(DataFormats.FileDrop) as string[];

                Presenter.ProcessUploadedFile(file[0], null);
            };
        }

        /// <summary>
        /// Load event for ParametersGroup user control.
        /// </summary>
        /// <param name="sender">Object with send this event.</param>
        /// <param name="e">Event object.</param>
        private void parametersGroup1_Load(object sender, EventArgs e)
        {
            var self = (ParametersGroup)sender;

            self.Alpha.ValueChanged += (x, y) =>
            {
                Presenter.ViewModel.Alpha = self.Alpha.Value;
                self.Gamma.Maximum = self.Alpha.Value;
            };

            self.Gamma.ValueChanged += (x, y) =>
            {
                Presenter.ViewModel.Gamma = self.Gamma.Value;
            };

            self.Support.ValueChanged += (x, y) =>
            {
                Presenter.ViewModel.Support = self.Support.Value;

                if (Presenter.AreRulesAvailable)
                {
                    Presenter.FilterRules();
                }
            };

            self.Confidence.ValueChanged += (x, y) =>
            {
                Presenter.ViewModel.Confidence = self.Confidence.Value;

                if (Presenter.AreRulesAvailable)
                {
                    Presenter.FilterRules();
                }
            };

            self.Alpha.Value = Presenter.GetDefaultAlpha();
            self.Gamma.Value = Presenter.GetDefaultGamma();
            self.Support.Value = Presenter.GetDefaultSupport();
            self.Confidence.Value = Presenter.GetDefaultConfidence();
        }

        /// <summary>
        /// Load event for AlgorithmsListGroup user control.
        /// </summary>
        /// <param name="sender">Object with send this event.</param>
        /// <param name="e">Event object.</param>
        private void algorithmsListGroup1_Load(object sender, EventArgs e)
        {
            var self = (AlgorithmsListGroup)sender;

            self.Algorithms.SelectedValueChanged += (x, y) =>
            {
                ComboBox combo = (ComboBox)x;
                presenter.SelectedAlgorithmChanged((string)combo.SelectedItem);
            };

            string[] algorithms = presenter.AvailableAlgorithms;
            self.Algorithms.Items.Clear();
            self.Algorithms.Items.AddRange(algorithms);
            self.Algorithms.SelectedIndex = Presenter.GetDefaultAlgorithm();

            self.SaveFileDialog.InitialDirectory = Presenter.GetDefaultDirectoryToSaveReports();
            self.SaveFileDialog.DefaultExt = Presenter.GetDefaultReportExtension();

            self.SaveReport.Click += (x, y) =>
            {
                self.SaveFileDialog.FileName = Presenter.GetReportName();
                self.SaveFileDialog.ShowDialog();
            };

            self.SaveFileDialog.FileOk += (x, y) =>
            {
                var fileDialog = (SaveFileDialog)x;

                Presenter.SaveReportToFile(fileDialog.FileName);
            };

            self.Reset.Click += (x, y) =>
            {
                presenter.ResetForm();
            };

            self.Generate.Click += (x, y) =>
            {
                Presenter.GenerateRules();
            };

            self.GenerateWeights.Click += (x, y) =>
            {
                Presenter.GenerateWeights();
            };

            self.GenerateRulesProgress.Minimum = 0;

            self.Weights.Columns[0].DataPropertyName = "attrName";
            self.Weights.Columns[1].DataPropertyName = "attrWeight";

            self.Weights.CellEndEdit += (x, y) =>
            {
                if (y.ColumnIndex == 1)
                {
                    DataGridViewRow row = self.Weights.Rows[y.RowIndex];
                    string attribute = Convert.ToString(row.Cells["attribute"].Value);
                    int newValue = Convert.ToInt32(row.Cells["weight"].Value);

                    Presenter.UpdateWeightForAttribute(attribute, newValue);
                }
            };
        }

        public void SetProgressBarMaxValue(int max)
        {
            algorithmsListGroup1.GenerateRulesProgress.Maximum = max;
        }

        /// <summary>
        /// Sets default controls values on application start.
        /// </summary>
        public void SetStartupValues()
        {
            summaryGroup1.DataSetName = "-";
            summaryGroup1.ObjectsQuantity = default(int);
            summaryGroup1.AttributesQuantity = default(int);
            summaryGroup1.GeneratedRulesQuantity = default(int);
            summaryGroup1.GenerateDiffrentRulesQuantity = default(int);
            summaryGroup1.AverageSupport = default(decimal);
            summaryGroup1.AverageConfidence = default(decimal);
            summaryGroup1.MinimalRuleLength = default(int);
            summaryGroup1.AverageRuleLength = default(decimal);
            summaryGroup1.MaximalRuleLength = default(int);
            summaryGroup1.MinimalConfidence = default(decimal);
            summaryGroup1.MinimalSupport = default(decimal);
            summaryGroup1.MaximalConfidence = default(decimal);
            summaryGroup1.MaximalSupport = default(decimal);
            summaryGroup1.MinimalUpperBound = default(int);
            summaryGroup1.AverageUpperBound = default(decimal);
            summaryGroup1.MaximalUpperBound = default(int);
            summaryGroup1.MinimalLowerBound = default(int);
            summaryGroup1.AverageLowerBound = default(decimal);
            summaryGroup1.MaximalLowerBound = default(int);
            AlgorithmNameStatusBar = "-";
            AlgorithmRunLengthStatusBar = "-";
        }

        /// <summary>
        /// Load event for MainFormView.
        /// </summary>
        /// <param name="sender">Object with send this event.</param>
        /// <param name="e">Event object.</param>
        private void MainFormView_Load(object sender, EventArgs e)
        {
            presenter = Bootstrapper.ServiceLocator.GetService<IMainFormViewPresenter>();

            Settings.Click += (x, y) =>
            {
                using (
             SettingsView view = new SettingsView())
                {
                    view.ShowDialog();
                }
            };

            ShowInstruction.Click += (x, y) =>
            {
                Presenter.OpenInstruction();
            };

            About.Click += (x, y) =>
            {
                using (
             AboutView view = new AboutView())
                {
                    view.ShowDialog();
                }
            };

            Close.Click += (x, y) =>
            {
                if (MessageBoxView.Show("Zamknąć aplikację? Wszystkie wykonane obliczenia zostaną utracone.", "Zamknij",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Close();
                }
            };

            SetDefaulfAlgorithm();
            SetStartupValues();
            SetStartupControlsState();
            SetWeightsDataSource(null);
        }

        #region controls states

        /// <summary>
        /// Sets default controls states on application start.
        /// </summary>
        public void SetStartupControlsState()
        {
            dataSourceGroup1.PreviewData.Enabled = false;
            //parametersGroup1.Gamma.Enabled = false;
            //   algorithmsListGroup1.GenerateWeights.Enabled = false;
            //  algorithmsListGroup1.Weights.Enabled = false;
            algorithmsListGroup1.Generate.Enabled = false;
            algorithmsListGroup1.SaveReport.Enabled = false;
            algorithmsListGroup1.GenerateRulesProgress.Value = 0;
            resultGrid1.ResultDataGridView.DataSource = null;
        }

        /// <summary>
        /// Sets controls states when data set is available.
        /// </summary>
        public void SetControlsStateWhenDataExists()
        {
            dataSourceGroup1.PreviewData.Enabled = true;
            if (algorithmsListGroup1.Algorithms.SelectedIndex != 2)
                algorithmsListGroup1.Generate.Enabled = true;
            else
            {
                algorithmsListGroup1.Weights.Enabled = true;
                algorithmsListGroup1.GenerateWeights.Enabled = true;
            }

            //if some rules are already generated, erase them from gui
            if (resultGrid1.ResultDataGridView.DataSource != null)
            {
                resultGrid1.ResultDataGridView.DataSource = null;

                algorithmsListGroup1.GenerateRulesProgress.Value = 0;

                summaryGroup1.GeneratedRulesQuantity = default(int);
                summaryGroup1.GenerateDiffrentRulesQuantity = default(int);
                summaryGroup1.AverageSupport = default(decimal);
                summaryGroup1.AverageConfidence = default(decimal);
                summaryGroup1.MinimalRuleLength = default(int);
                summaryGroup1.AverageRuleLength = default(decimal);
                summaryGroup1.MaximalRuleLength = default(int);
            }

            if (algorithmsListGroup1.Weights.DataSource != null)
            {
                algorithmsListGroup1.Weights.DataSource = null;
            }
        }

        /// <summary>
        /// Sets controls states when algorithm with weights is selected.
        /// </summary>
        public void AlgorithmWithWeightsSelected()
        {
            parametersGroup1.Gamma.Enabled = true;
            if (Presenter.IsDataAvailable)
            {
                algorithmsListGroup1.GenerateWeights.Enabled = true;
                algorithmsListGroup1.Weights.Enabled = true;
                algorithmsListGroup1.Generate.Enabled = false;
            }
        }

        /// <summary>
        /// Sets controls states when algorithm without weights is selected.
        /// </summary>
        public void AlgorithmWithoutWeightsSelected()
        {
            parametersGroup1.Gamma.Enabled = false;
            algorithmsListGroup1.GenerateWeights.Enabled = false;
            algorithmsListGroup1.Weights.Enabled = false;
            algorithmsListGroup1.Weights.DataSource = null;
        }

        public void GenerateReportAvailable()
        {
            algorithmsListGroup1.SaveReport.Enabled = true;
        }

        #endregion

        /// <summary>
        /// Attach current view to specific presenter.
        /// </summary>
        /// <param name="presenter">Presenter object to attach for this view.</param>
        /// <param name="requiresInitialState">Indicates that view require initial state.</param>
        public void AttachToPresenter(IMainFormViewPresenter presenter, bool requiresInitialState)
        {
            if (presenter == null)
                throw new ArgumentNullException("presenter");

            DetatchFromPresenter();

            this.presenter = presenter;

            presenter.ConnectView(this, requiresInitialState);
        }

        /// <summary>
        /// Detach current view from his current presenter.
        /// </summary>
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

        /// <summary>
        /// Returns the SummaryGroupData user control.
        /// </summary>
        public ISummaryGroupData Summary
        {
            get { return summaryGroup1; }
        }

        public void SetResultDataSource(System.Data.DataTable dataSource)
        {
            resultGrid1.BindingSource.DataSource = dataSource;
            resultGrid1.ResultDataGridView.DataSource = resultGrid1.BindingSource;
        }

        private void resultGrid1_Load(object sender, EventArgs e)
        {
            var self = (ResultGrid)sender;

            self.ResultDataGridView.Columns[0].DataPropertyName = "associationRule";
            self.ResultDataGridView.Columns[1].DataPropertyName = "support";
            self.ResultDataGridView.Columns[2].DataPropertyName = "confidence";
            self.ResultDataGridView.Columns[3].DataPropertyName = "length";
            self.ResultDataGridView.Columns[4].DataPropertyName = "upperBound";
            self.ResultDataGridView.Columns[5].DataPropertyName = "lowerBound";
            self.ResultDataGridView.Columns[6].DataPropertyName = "theSameRules";
        }

        public void UpdateProgressBar(int value)
        {
            algorithmsListGroup1.GenerateRulesProgress.Value = value;
        }

        public void SetWeightsDataSource(System.Data.DataTable dataSource)
        {
            algorithmsListGroup1.BindingSource.DataSource = dataSource;
            algorithmsListGroup1.Weights.DataSource = algorithmsListGroup1.BindingSource;
        }

        public void SetDefaulfAlgorithm()
        {
            if (algorithmsListGroup1.Algorithms.Items.Count > 0)
            {
                algorithmsListGroup1.Algorithms.SelectedIndex = Presenter.GetDefaultAlgorithm();
                if (algorithmsListGroup1.Algorithms.SelectedIndex == 2)
                {
                    algorithmsListGroup1.GenerateWeights.Enabled = false;
                    parametersGroup1.Gamma.Enabled = true;
                }
            }
        }

        public void EnableGenerateButton()
        {
            algorithmsListGroup1.Generate.Enabled = true;
        }

        public void NotifyAboutUnsupportedFileSelected()
        {
            MessageBoxView.Show("Załadowny format pliku nie jest obsługiwany. Listę wspieranych formatów można znaleźć w instrukcji obsługi.",
                "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void NotifyAboutArgumentCountIncorrect()
        {
            MessageBoxView.Show("Liczba atrybutów w poszczególnych wierszach musi być identyczna.",
                 "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void NotifyAboutNoPermissionsToFile()
        {
            MessageBoxView.Show("Brak uprawnień do pliku lub jest on obecnie wykorzystywany przez inny proces.",
                 "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void NotifyAboutRowsNotParsedCorrectly()
        {
            MessageBoxView.Show("Błąd przy parsowaniu wierszy z danymi. Poprawny format zapisu zbiorów danych dla poszczególnych formatów plików można znaleźć w instrukcji.",
                 "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void NotifyAboutIncorrectNumberOfFilesInArchive()
        {
            MessageBoxView.Show("Nieprawidłowa liczba plików w archiwum. Poprawny opis zawartości archiwum można znaleźć w instrukcji.",
                 "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void NotifyAboutIncorrectArchive()
        {
            MessageBoxView.Show("Archiwum jest uszkodzone.",
                  "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void NotifyAboutMissingInstruction()
        {
            MessageBoxView.Show("Plik z instrukcją nie został znaleziony.",
                "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void NotifyAboutZeroRulesInResponse()
        {
            MessageBoxView.Show("Dla wprowadzonych wartości parametrów algorytm nie zwrócił żadnego wyniku.",
               "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void NotifyAboutMissingDefaultPdfReader()
        {
            MessageBoxView.Show("W systemie nie zdefiniowano domyślnego programu do odczyty plików pdf.",
                 "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void NotifyAboutNotMarketAtLeastOneAttributeAsDecision()
        {
            MessageBoxView.Show("W systemie nie ustawiono ani jednego atrybutu decyzyjnego.",
                 "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string AlgorithmNameStatusBar
        {
            get
            {
                return tsslAlgorithmName.Text;
            }
            set
            {
                tsslAlgorithmName.Text = value;
            }
        }

        private string AlgorithmRunLengthStatusBar
        {
            get
            {
                return tsslAlgorithmRunLength.Text;
            }
            set
            {
                tsslAlgorithmRunLength.Text = value;
            }
        }

        public void SetAlgorithmNameInStatusBar(string selectedAlgorithm)
        {
            AlgorithmNameStatusBar = selectedAlgorithm;
        }

        public void SetAlgorithmRunLengthInStatusBar(TimeSpan runLength)
        {
            string result = String.Format("{0} godzin {1} minut {2} sekund {3} milisekund",
                runLength.Hours, runLength.Minutes, runLength.Seconds, runLength.Milliseconds);

            AlgorithmRunLengthStatusBar = result;
        }

        public void RefreshParameters()
        {
            parametersGroup1.Alpha.Value = 0;
            parametersGroup1.Gamma.Value = 0;
            parametersGroup1.Support.Value = 0;
            parametersGroup1.Confidence.Value = 0;

            parametersGroup1.Alpha.Value = Presenter.GetDefaultAlpha();
            parametersGroup1.Gamma.Value = Presenter.GetDefaultGamma();
            parametersGroup1.Support.Value = Presenter.GetDefaultSupport();
            parametersGroup1.Confidence.Value = Presenter.GetDefaultConfidence();
        }
    }
}
