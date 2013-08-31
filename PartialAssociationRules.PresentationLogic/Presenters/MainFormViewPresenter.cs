/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using PartialAssociationRules.Domain;
using PartialAssociationRules.Domain.Algorithms;
using PartialAssociationRules.Domain.DataFileParsers;
using PartialAssociationRules.Domain.DataGenerators;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Exceptions;
using PartialAssociationRules.Domain.Extensions;
using PartialAssociationRules.Domain.Gui;
using PartialAssociationRules.Domain.Gui.Upload;
using PartialAssociationRules.Domain.Report;
using PartialAssociationRules.Domain.Utilities;
using PartialAssociationRules.PresentationLogic.Interfaces;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Interfaces.Views;
using PartialAssociationRules.PresentationLogic.Model;
using PartialAssociationRules.PresentationLogic.ViewModels;

namespace PartialAssociationRules.PresentationLogic.Presenters
{
    /// <summary>
    /// Represents presenter objects for the main application form.
    /// </summary>
    public class MainFormViewPresenter : PresenterBase<IMainFormViewPresenter, IMainFormView>, IMainFormViewPresenter
    {
        private MainFormViewModel viewModel;

        /// <summary>
        /// Default contructor.
        /// </summary>
        public MainFormViewPresenter()
        {
            viewModel = new MainFormViewModel();
        }

        /// <summary>
        /// The presenter view model.
        /// </summary>
        public MainFormViewModel ViewModel
        {
            get
            {
                return viewModel;
            }
        }

        /// <summary>
        /// Created dataset from uploaded file.
        /// </summary>
        /// <param name="fileName">Uploaded file name.</param>
        /// <param name="file">Stream which contains uploaed file.</param>
        public void ProcessUploadedFile(string fileName, Stream file)
        {
            if (file == null)
            {
                try
                {
                    file = new FileStream(fileName, FileMode.Open);
                }
                catch (IOException)
                {
                    View.NotifyAboutNoPermissionsToFile();

                    return;
                }
            }

            FileManager manager = null;

            try
            {
                manager = new FileManager(file, fileName);
            }
            catch (PartialAssociationRulesException ex)
            {
                if (ex.Exception == ExceptionsList.UnsuportedFileSelected)
                {
                    View.NotifyAboutUnsupportedFileSelected();
                }

                return;
            }

            IDataFileParser parser =
                Bootstrapper.ServiceLocator.GetService<IDataFileParser>(manager.Type);

            if (ApplicationModel.System != null)
            {
                InformationSystem sys = null;
                try
                {
                    sys = InformationSystem.CreateFromFile(parser, manager);
                }
                catch (PartialAssociationRulesException ex)
                {
                    switch (ex.Exception)
                    {
                        case ExceptionsList.ArgumentCountIncorrect:
                            View.NotifyAboutArgumentCountIncorrect();
                            break;
                        case ExceptionsList.RowsNotParsedCorrectly:
                            View.NotifyAboutRowsNotParsedCorrectly();
                            break;
                        case ExceptionsList.IncorrectNumberOfFilesInArchive:
                            View.NotifyAboutIncorrectNumberOfFilesInArchive();
                            break;
                        case ExceptionsList.IncorrectArchive:
                            View.NotifyAboutIncorrectArchive();
                            break;
                    }

                    return;
                }

                ApplicationModel.System.Rows = sys.Rows;
                View.SetStartupValues();
            }
            else
            {
                //TODO. Find out why I've added this else statement..
                ApplicationModel.System = InformationSystem.CreateFromFile(parser, manager);
            }

            viewModel.DataSetName = manager.FileName;
            viewModel.ObjectsQuantity = ApplicationModel.System.Rows.Count;
            viewModel.AttributesQuantity = ApplicationModel.System.Rows[0].Attributes.Count;

#if WEB
            //Thread.Sleep(2000);
            //   UpdateSummaryUP();
            viewModel.UpdateSummaryUP = true;
#endif
        }

        public string[] AvailableAlgorithms
        {
            get
            {
                AlgorithmsNameType alg = new AlgorithmsNameType();
                return alg.Keys.ToArray();
            }
        }

        /// <summary>
        /// Checks if information system rows are provided.
        /// </summary>
        public bool IsDataAvailable
        {
            get
            {
                return ApplicationModel.System.Rows != null;
            }
        }

        public bool AreRulesAvailable
        {
            get
            {
                if (ApplicationModel.Rules != null && ApplicationModel.Rules.Count() > 0)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Sets controls state for specific selected algorithm. 
        /// </summary>
        /// <param name="algName">Selected algorithm name.</param>
        public void SelectedAlgorithmChanged(string algName)
        {
            AlgorithmsNameType alg = new AlgorithmsNameType();
            switch (alg[algName])
            {
                case Domain.Algorithms.AlgorithmType.Classic:
                case Domain.Algorithms.AlgorithmType.ClassicWithModification:
                    this.View.AlgorithmWithoutWeightsSelected();
                    break;
                case Domain.Algorithms.AlgorithmType.ClassicWithWeights:
                    this.View.AlgorithmWithWeightsSelected();
                    break;
            }

            viewModel.SelectedAlgorithm = algName;
        }

        /// <summary>
        /// Sets controls state when dataset is available.
        /// </summary>
        public void SetControlsStateWhenDataIsAvailable()
        {
            this.View.SetControlsStateWhenDataExists();
        }

        /// <summary>
        /// Sets contrls state when dataset is not available.
        /// </summary>
        public void SetControlsStateWhenDataIsNotAvailable()
        {
            this.View.SetStartupControlsState();
        }

        /// <summary>
        /// Raises when view initial state is required.
        /// </summary>
        /// <param name="view">View object.</param>
        protected override void RefreshView(IMainFormView view)
        {
            //ResetForm();
            ApplicationModel.System = null;
        }

        /// <summary>
        /// Resets form controls to default values.
        /// </summary>
        public void ResetForm()
        {
            ApplicationModel.System = null;
            ApplicationModel.Rules = null;

            View.SetDefaulfAlgorithm();
            View.SetStartupValues();
            View.SetStartupControlsState();
            View.SetWeightsDataSource(null);
            View.RefreshParameters();
        }

        /// <summary>
        /// Retrns SummaryGroupData user control.
        /// </summary>
        public ISummaryGroupData Summary
        {
            get { return this.View.Summary; }
        }

        /// <summary>
        /// Generates the rules by user specific algorithm and updates the progress bar.
        /// </summary>
        public void GenerateRules()
        {
            TimeSpan start = TimeSpan.Zero, stop = TimeSpan.Zero;
            if (ApplicationModel.System.DecisionAttributes.Where(x => x.Value == true).Count() == 0)
            {
                View.NotifyAboutNotMarketAtLeastOneAttributeAsDecision();
                return;
            }

            AlgorithmsNameType alg = new AlgorithmsNameType();
            string selectedAlgorithm = viewModel.SelectedAlgorithm;
            IAlgorithm algorithm = Bootstrapper.ServiceLocator.GetService<IAlgorithm>(alg[selectedAlgorithm]);

            View.SetProgressBarMaxValue(ApplicationModel.System.Rows.Count *
                ApplicationModel.System.DecisionAttributes.Where(x => x.Value == true).Count());

            //update progress bar
            algorithm.Notify += (value) =>
            {
                View.UpdateProgressBar(value);
            };

            //this is for percent of separated rows
            algorithm.SeparatedRows += (value) =>
            {
                ApplicationModel.SeparatedRows = value;
            };

            //set generated rules
            algorithm.Rules += (result) =>
            {
                //Thread.Sleep(20000);
                stop = DateTime.Now.TimeOfDay;
                var group = result.GroupBy(
                       z => z,
                       (rule, count) => new RuleCount
                       {
                           Rule = rule,
                           Count = count.Count()
                       },
                       new AssociationRulesComparer());

                ApplicationModel.Rules = group;

                FilterRules();
                View.SetAlgorithmNameInStatusBar(selectedAlgorithm);
                View.SetAlgorithmRunLengthInStatusBar(stop - start);
            };

            algorithm.InformationSystem = ApplicationModel.System;

            //this is true only for algorithm with weights
            if (ApplicationModel.Weights.Count > 0)
            {
                algorithm.Weights = ApplicationModel.Weights;
            }

            start = DateTime.Now.TimeOfDay;
            algorithm.Generate();
        }

        /// <summary>
        /// Filter rules by a user specific support and confidence level.
        /// </summary>
        public void FilterRules()
        {
            var rules = ApplicationModel.Rules;

            ApplicationModel.FilteredRules = rules.Where(x =>
                                          x.Rule.Support >= ApplicationModel.System.Support &&
                                          x.Rule.Confidence >= ApplicationModel.System.Confidence)
                                          .Select(x => x);
        }

        private DataTable generatedRulesConvertedToDataTable;

        /// <summary>
        /// Sets the result grid with filtered generated rules and updates the rules quantity in the view model.
        /// </summary>
        public void ShowGeneratedRulesAndDistinctGeneratedRowsQuantity()
        {
            if (ApplicationModel.FilteredRules.Count() > 0)
            {
                generatedRulesConvertedToDataTable = ApplicationModel.FilteredRules.ConvertToDataTable();
                View.SetResultDataSource(generatedRulesConvertedToDataTable);
                viewModel.GeneratedRulesQuantity = ApplicationModel.FilteredRules.Sum(x => x.Count);
                viewModel.GenerateDiffrentRulesQuantity = generatedRulesConvertedToDataTable.Rows.Count;
            }
            else
            {
                View.SetResultDataSource(null);
                View.NotifyAboutZeroRulesInResponse();
            }
        }

        /// <summary>
        /// Sets max value for the progress bar.
        /// </summary>
        /// <param name="max"></param>
        public void SetProgressBarMaxValue(int max)
        {
            View.SetProgressBarMaxValue(max);
        }

        /// <summary>
        /// Enables the 'Save report' button.
        /// </summary>
        public void GenerateReportAvailable()
        {
            View.GenerateReportAvailable();
        }

        /// <summary>
        /// Sets the summary details for filtered generated rules.
        /// </summary>
        public void SetSummaryDetails()
        {
            if (ApplicationModel.FilteredRules.Count() > 0)
            {
                decimal averageSupport = ApplicationModel.FilteredRules.Average(x => x.Rule.Support).Round();
                decimal averageConfidence = ApplicationModel.FilteredRules.Average(x => x.Rule.Confidence).Round();
                decimal averageRuleLength =
                    Convert.ToDecimal(ApplicationModel.FilteredRules.Average(x => x.Rule.Length)).Round();
                int minimalRuleLength = ApplicationModel.FilteredRules.Min(x => x.Rule.Length);
                int maximalRuleLength = ApplicationModel.FilteredRules.Max(x => x.Rule.Length);
                decimal minimalSupport = ApplicationModel.FilteredRules.Min(x => x.Rule.Support).Round();
                decimal maximalSupport = ApplicationModel.FilteredRules.Max(x => x.Rule.Support).Round();
                decimal minimalConfidence = ApplicationModel.FilteredRules.Min(x => x.Rule.Confidence).Round();
                decimal maximalConfidence = ApplicationModel.FilteredRules.Max(x => x.Rule.Confidence).Round();
                int minimalUpperBound = ApplicationModel.FilteredRules.Min(x => x.Rule.UpperBound);
                decimal averageUpperBound =
                    Convert.ToDecimal(ApplicationModel.FilteredRules.Average(x => x.Rule.UpperBound)).Round();
                int maximalUpperBound = ApplicationModel.FilteredRules.Max(x => x.Rule.UpperBound);
                int minimalLowerBound = ApplicationModel.FilteredRules.Min(x => x.Rule.LowerBound);
                decimal averageLowerBound =
                    Convert.ToDecimal(ApplicationModel.FilteredRules.Average(x => x.Rule.LowerBound)).Round();
                int maximalLowerBound = ApplicationModel.FilteredRules.Max(x => x.Rule.LowerBound);

                ViewModel.AverageConfidence = averageConfidence;
                ViewModel.AverageSupport = averageSupport;
                ViewModel.AverageRuleLength = averageRuleLength;
                ViewModel.MinimalRuleLength = minimalRuleLength;
                ViewModel.MaximalRuleLength = maximalRuleLength;
                ViewModel.MinimalSupport = minimalSupport;
                ViewModel.MaximalSupport = maximalSupport;
                ViewModel.MinimalConfidence = minimalConfidence;
                ViewModel.MaximalConfidence = maximalConfidence;
                ViewModel.MinimalUpperBound = minimalUpperBound;
                ViewModel.AverageUpperBound = averageUpperBound;
                ViewModel.MaximalUpperBound = maximalUpperBound;
                ViewModel.MinimalLowerBound = minimalLowerBound;
                ViewModel.AverageLowerBound = averageLowerBound;
                ViewModel.MaximalLowerBound = maximalLowerBound;
            }
        }

        /// <summary>
        /// Generates weights for attributes in the current information system.
        /// </summary>
        public void GenerateWeights()
        {
            IWeightsGenerator generator =
                Bootstrapper.ServiceLocator.GetService<IWeightsGenerator>(GeneratorType.Weights);
            generator.MinimalWeight = SettingsManager.Settings.MinimalWeight;
            generator.MaximalWeight = SettingsManager.Settings.MaximalWeight;
            generator.Attributes = ApplicationModel.System.Rows[0].Attributes.Select(x => x.Name).ToList();
            var generatedWeights = generator.Generate();

            ApplicationModel.Weights = generatedWeights;
            DataTable dataSource = generatedWeights.ConvertToDataTable();
            View.SetWeightsDataSource(dataSource);
        }

        /// <summary>
        /// Enables the 'Generate' button.
        /// </summary>
        public void EnableGenerateButton()
        {
            View.EnableGenerateButton();
        }

        /// <summary>
        /// Sets the generated report to the specific file.
        /// </summary>
        /// <param name="fileName">Name of the file to write to.</param>
        public void SaveReportToFile(string fileName)
        {
            //mapping ViewModel to ReportInfo object
            //this is not blow job to doing it manually
            //better solution could be using e.g. AutoMapper for it
            //http://automapper.codeplex.com/
            ReportInfo info = new ReportInfo()
            {
                System = ApplicationModel.System,
                Rules = ApplicationModel.FilteredRules,
                Alpha = ViewModel.Alpha,
                Gamma = ViewModel.Gamma,
                Support = ViewModel.Support,
                Confidence = ViewModel.Confidence,
                SelectedAlgorithm = ViewModel.SelectedAlgorithm,
                DataSetName = ViewModel.DataSetName,
                ObjectsQuantity = ViewModel.ObjectsQuantity,
                AttributesQuantity = ViewModel.AttributesQuantity,
                GeneratedRulesQuantity = ViewModel.GeneratedRulesQuantity,
                GenerateDiffrentRulesQuantity = ViewModel.GenerateDiffrentRulesQuantity,
                AverageSupport = ViewModel.AverageSupport,
                AverageConfidence = ViewModel.AverageConfidence,
                MinimalRuleLength = ViewModel.MinimalRuleLength,
                AverageRuleLength = ViewModel.AverageRuleLength,
                MaximalRuleLength = ViewModel.MaximalRuleLength,
                GeneratedRules = generatedRulesConvertedToDataTable,
                MinimalSupport = ViewModel.MinimalSupport,
                MaximalSupport = ViewModel.MaximalSupport,
                MinimalConfidence = ViewModel.MinimalConfidence,
                MaximalConfidence = ViewModel.MaximalConfidence,
                DecisionAttributes = ApplicationModel.System.DecisionAttributes.Where(x => x.Value == true).Select(x => x.Key).ToList(),
                Weights = ApplicationModel.Weights,
                MinimalLowerBound = ViewModel.MinimalLowerBound,
                AverageLowerBound = ViewModel.AverageLowerBound,
                MaximalLowerBound = ViewModel.MaximalLowerBound,
                MinimalUpperBound = ViewModel.MinimalUpperBound,
                AverageUpperBound = ViewModel.AverageUpperBound,
                MaximalUpperBound = ViewModel.MaximalUpperBound,
                PercentOfSeparatedRows = ApplicationModel.SeparatedRows
            };

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string defaultReportType = Enum.GetNames(typeof(ReportType))[SettingsManager.Settings.DefaultReport];

                IReport report = Bootstrapper.ServiceLocator.GetService<IReport>(
                    (ReportType)Enum.Parse(typeof(ReportType), defaultReportType));

                report.ReportDetails = info;

                writer.Write(report.CreateReport());
                writer.Close();
            }
        }

        /// <summary>
        /// Gets the name for generated report which is a combination of the data set name and current date.
        /// </summary>
        /// <returns></returns>
        public string GetReportName()
        {
            return String.Format("{0} {1} algorytm {2} alpha {3} wsparcie {4}.txt",
                Summary.DataSetName.Replace('.', '_'), DateTime.Now.ToShortDateString(),
                viewModel.SelectedAlgorithm, viewModel.Alpha.ToString().Replace(',', '.'),
                viewModel.Support.ToString().Replace(',', '.'));
        }

        /// <summary>
        /// Sets new weight for the specific attribute.
        /// </summary>
        /// <param name="attribute">The attribute name to change.</param>
        /// <param name="newValue">New value of the weight.</param>
        public void UpdateWeightForAttribute(string attribute, int newValue)
        {
            ApplicationModel.Weights[attribute] = newValue;
        }

        /// <summary>
        /// Opens the instruction in the system specific pdf reader.
        /// </summary>
        public void OpenInstruction()
        {
#if WEB
            string path = HttpRuntime.BinDirectory + "Instruction\\instrukcja.pdf";

            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path);

            if (buffer != null)
            {
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("content-length", buffer.Length.ToString());
                HttpContext.Current.Response.BinaryWrite(buffer);
            }
#else
            //this is I think the simplest solution to open a pdf file without using a 3rd party (commercial) 
            //libraries/controls or Adobe Reader ActiveX which works only with AR. 
            //this solution require only any pdf reader (e.g. foxit reader, acrobat reader etc.) 
            //installed in the system and it must be set to
            //default for pdf files.
            try
            {
                System.Diagnostics.Process.Start("Instruction\\instrukcja.pdf");
            }
            catch (System.IO.FileNotFoundException)
            {
                View.NotifyAboutMissingInstruction();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                View.NotifyAboutMissingDefaultPdfReader();
            }
#endif
        }

        public string GetDefaultDirectoryContainsDataSourceFiles()
        {
            return String.Format("{0}\\{1}", System.IO.Directory.GetCurrentDirectory(), SettingsManager.Settings.DefaultFilesCatalog);
        }

        public string GetDefaultDirectoryToSaveReports()
        {
            return String.Format("{0}\\{1}", System.IO.Directory.GetCurrentDirectory(), "Reports");
        }

        public void MarkDecisionAttributes()
        {
            if (ApplicationModel.System.Rows != null)
            {
                IEnumerable<string> attrs = ApplicationModel.System.Rows[0].Attributes.Select(x => x.Name);
                Dictionary<string, bool> attributes =
                    new Dictionary<string, bool>(attrs.Count());

                attrs.ToList().ForEach(x =>
                {
                    attributes[x] = true;
                });

                ApplicationModel.System.DecisionAttributes = attributes;
            }
        }

        public decimal GetDefaultAlpha()
        {
            return SettingsManager.Settings.Alpha;
        }

        public decimal GetDefaultGamma()
        {
            return SettingsManager.Settings.Gamma;
        }

        public decimal GetDefaultConfidence()
        {
            return SettingsManager.Settings.Confidence;
        }

        public decimal GetDefaultSupport()
        {
            return SettingsManager.Settings.Support;
        }

        public int GetDefaultAlgorithm()
        {
            return SettingsManager.Settings.DefaultAlgorithm;
        }

        public string GetDefaultReportExtension()
        {
            ReportExtensions extensions = new ReportExtensions();

            string extension = Enum.GetNames(typeof(ReportType))[SettingsManager.Settings.DefaultReport];
            var result = extensions[extension];

            return result.ToString().ToLower();
        }

#if WEB
        public void UpdateSummaryUP()
        {
            View.UpdateSummaryUP();
        }

        /// <summary>
        /// Gets dumped information system as a html table.
        /// </summary>
        /// <returns>String containing dumped information system.</returns>
        public string GetDumpedInformationSystem()
        {
            StringBuilder header = new StringBuilder();
            StringBuilder body = new StringBuilder();
            StringBuilder result = new StringBuilder();

            //ApplicationModel.System.Rows.Select(x => x.Attributes[0].Name).ToList().ForEach(x =>
            //{
            //    header.AppendFormat("<th>{0}</th>", x);
            //});
            bool parsedFirstRow = false;
            foreach (var singleRow in ApplicationModel.System.Rows)
            {
                body.Append("<tr>");

                singleRow.ToString().Split(';').ToList().ForEach(x =>
                {
                    var attrNameValue = x.Split(',');
                    if (parsedFirstRow == false)
                        header.AppendFormat("<th>{0}</th>", attrNameValue[0]);
                    body.AppendFormat("<td>{0}</td>", attrNameValue[1]);
                });

                parsedFirstRow = true;
                body.Append("</tr>");
            }

            result.AppendFormat("<table id=\"previewDataTable\"><thead><tr>{0}</tr></thead><tbody>{1}</tbody></table>",
                header.ToString(), body.ToString());
            return result.ToString();
        }
#endif
    }
}
