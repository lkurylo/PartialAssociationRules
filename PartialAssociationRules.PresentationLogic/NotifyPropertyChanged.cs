/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Model;
using System.Web;

namespace PartialAssociationRules.PresentationViews
{
    /// <summary>
    /// Contains PropertyChanged event handler.
    /// </summary>
    public static class NotifyPropertyChangedUtilities
    {
        /// <summary>
        /// Represnts property changed forms controls.
        /// </summary>
        private enum PropertiesToHandle
        {
            System,
            Rows,
            FilteredRules,
            Weights,
            Alpha,
            Gamma,
            Support,
            Confidence,
            SelectedAlgorithm,
            DataSetName,
            ObjectsQuantity,
            AttributesQuantity,
            GeneratedRulesQuantity,
            GenerateDiffrentRulesQuantity,
            AverageSupport,
            AverageConfidence,
            AverageRuleLength,
            MinimalRuleLength,
            MaximalRuleLength,
            MinimalSupport,
            MaximalSupport,
            MinimalConfidence,
            MaximalConfidence,
            MinimalUpperBound,
            AverageUpperBound,
            MaximalUpperBound,
            MinimalLowerBound,
            AverageLowerBound,
            MaximalLowerBound
#if WEB
, UpdateSummaryUP
#endif
        }

        private static IMainFormViewPresenter presenter;
        private static IMainFormViewPresenter Presenter
        {
            get
            {
#if WEB
                return HttpContext.Current.Session["presenter"] as IMainFormViewPresenter;
#else
                if (presenter == null)
                {
                    presenter = Bootstrapper.ServiceLocator.GetService<IMainFormViewPresenter>();
                }

                return presenter;
#endif
            }
        }

        /// <summary>
        /// PropertyChanged event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            PropertiesToHandle property;

            try
            {
                Enum.TryParse<PropertiesToHandle>(e.PropertyName, true, out property);
            }
            catch (ArgumentException)
            {
                return;
            }

            switch (property)
            {
                case PropertiesToHandle.Rows:
                case PropertiesToHandle.System:
                    bool isNull = ApplicationModel.System == null && ApplicationModel.System.Rows == null;

                    if (!isNull)
                    {
#if !WEB
                        Presenter.SetControlsStateWhenDataIsAvailable();
#endif
                        Presenter.MarkDecisionAttributes();
                    }
                    else
                    {
                        Presenter.SetControlsStateWhenDataIsNotAvailable();
                    }

                    break;
                case PropertiesToHandle.FilteredRules:
                    Presenter.ShowGeneratedRulesAndDistinctGeneratedRowsQuantity();
                    Presenter.GenerateReportAvailable();
                    Presenter.SetSummaryDetails();
                    break;
                case PropertiesToHandle.Weights:
                    Presenter.EnableGenerateButton();
                    break;
                case PropertiesToHandle.Alpha:
                    ApplicationModel.System.Alpha = Presenter.ViewModel.Alpha;
                    break;
                case PropertiesToHandle.Gamma:
                    ApplicationModel.System.Gamma = Presenter.ViewModel.Gamma;
                    break;
                case PropertiesToHandle.Support:
                    ApplicationModel.System.Support = Presenter.ViewModel.Support;
                    break;
                case PropertiesToHandle.Confidence:
                    ApplicationModel.System.Confidence = Presenter.ViewModel.Confidence;
                    break;
                case PropertiesToHandle.SelectedAlgorithm:
                    break;
                case PropertiesToHandle.DataSetName:
                    Presenter.Summary.DataSetName = Presenter.ViewModel.DataSetName;
                    break;
                case PropertiesToHandle.ObjectsQuantity:
                    Presenter.Summary.ObjectsQuantity = Presenter.ViewModel.ObjectsQuantity;
                    //  Presenter.SetProgressBarMaxValue(Presenter.ViewModel.ObjectsQuantity);
                    break;
                case PropertiesToHandle.AttributesQuantity:
                    Presenter.Summary.AttributesQuantity = Presenter.ViewModel.AttributesQuantity;
                    break;
                case PropertiesToHandle.GeneratedRulesQuantity:
                    Presenter.Summary.GeneratedRulesQuantity = Presenter.ViewModel.GeneratedRulesQuantity;
                    break;
                case PropertiesToHandle.GenerateDiffrentRulesQuantity:
                    Presenter.Summary.GenerateDiffrentRulesQuantity = Presenter.ViewModel.GenerateDiffrentRulesQuantity;
                    break;
                case PropertiesToHandle.AverageSupport:
                    Presenter.Summary.AverageSupport = Presenter.ViewModel.AverageSupport;
                    break;
                case PropertiesToHandle.AverageConfidence:
                    Presenter.Summary.AverageConfidence = Presenter.ViewModel.AverageConfidence;
                    break;
                case PropertiesToHandle.AverageRuleLength:
                    Presenter.Summary.AverageRuleLength = Presenter.ViewModel.AverageRuleLength;
                    break;
                case PropertiesToHandle.MinimalRuleLength:
                    Presenter.Summary.MinimalRuleLength = Presenter.ViewModel.MinimalRuleLength;
                    break;
                case PropertiesToHandle.MaximalRuleLength:
                    Presenter.Summary.MaximalRuleLength = Presenter.ViewModel.MaximalRuleLength;
                    break;
                case PropertiesToHandle.MinimalSupport:
                    Presenter.Summary.MinimalSupport = Presenter.ViewModel.MinimalSupport;
                    break;
                case PropertiesToHandle.MaximalSupport:
                    Presenter.Summary.MaximalSupport = Presenter.ViewModel.MaximalSupport;
                    break;
                case PropertiesToHandle.MinimalConfidence:
                    Presenter.Summary.MinimalConfidence = Presenter.ViewModel.MinimalConfidence;
                    break;
                case PropertiesToHandle.MaximalConfidence:
                    Presenter.Summary.MaximalConfidence = Presenter.ViewModel.MaximalConfidence;
                    break;
                case PropertiesToHandle.MinimalLowerBound:
                    Presenter.Summary.MinimalLowerBound = Presenter.ViewModel.MinimalLowerBound;
                    break;
                case PropertiesToHandle.AverageLowerBound:
                    Presenter.Summary.AverageLowerBound = Presenter.ViewModel.AverageLowerBound;
                    break;
                case PropertiesToHandle.MaximalLowerBound:
                    Presenter.Summary.MaximalLowerBound = Presenter.ViewModel.MaximalLowerBound;
                    break;
                case PropertiesToHandle.MinimalUpperBound:
                    Presenter.Summary.MinimalUpperBound = Presenter.ViewModel.MinimalUpperBound;
                    break;
                case PropertiesToHandle.AverageUpperBound:
                    Presenter.Summary.AverageUpperBound = Presenter.ViewModel.AverageUpperBound;
                    break;
                case PropertiesToHandle.MaximalUpperBound:
                    Presenter.Summary.MaximalUpperBound = Presenter.ViewModel.MaximalUpperBound;
                    break;
#if WEB
                case PropertiesToHandle.UpdateSummaryUP:
                    Presenter.UpdateSummaryUP();
                    break;
#endif
            }
        }
    }
}
