/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using Ninject;
using Ninject.Modules;
using PartialAssociationRules.Domain.Algorithms;
using PartialAssociationRules.Domain.DataFileParsers;
using PartialAssociationRules.Domain.DataGenerators;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Report;
using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
using PartialAssociationRules.PresentationLogic.Model;
using PartialAssociationRules.PresentationLogic.Presenters;
using PartialAssociationRules.PresentationLogic.ViewModels;
using PartialAssociationRules.PresentationViews;

namespace PartialAssociationRules
{
    /// <summary>
    ///Class contains Ninject config for the services.
    /// </summary>
    public class ApplicationAndNinjectConfig : NinjectModule
    {
        /// <summary>
        /// Default contructor.
        /// </summary>
        public ApplicationAndNinjectConfig()
        {
            ApplicationModel.PropertyChanged += NotifyPropertyChangedUtilities.PropertyChanged;
            MainFormViewModel.PropertyChanged += NotifyPropertyChangedUtilities.PropertyChanged;
            InformationSystem.PropertyChanged += NotifyPropertyChangedUtilities.PropertyChanged;
        }

        public override void Load()
        {
            Bind<IServiceLocator>()
               .To<ServiceLocator>()
               .InSingletonScope();

            Bind<IKernel>()
                .ToMethod(x => x.Kernel)
                .InSingletonScope();

            #region generators

            Bind<IDataGenerator>()
                .To<BinaryGenerator>()
                .InSingletonScope()
                .WithMetadata(GeneratorType.Binary.ToString(), null);

            Bind<IDataGenerator>()
                 .To<NumericGenerator>()
                 .InSingletonScope()
                .WithMetadata(GeneratorType.Numeric.ToString(), null);

            Bind<IWeightsGenerator>()
                .To<WeightsGenerator>()
                .InSingletonScope()
                .WithMetadata(GeneratorType.Weights.ToString(), null);

            #endregion

            #region algorithms

            Bind<IAlgorithm>()
                 .To<ClassicMultiThreading>()
                 .InRequestScope()
                .WithMetadata(AlgorithmType.Classic.ToString(), null);

            Bind<IAlgorithm>()
                 .To<ClassicWithModificationMultiThreading>()
                 .InRequestScope()
                .WithMetadata(AlgorithmType.ClassicWithModification.ToString(), null);

            Bind<IAlgorithm>()
                 .To<ClassicWithWeightsMultiThreading>()
                 .InRequestScope()
                .WithMetadata(AlgorithmType.ClassicWithWeights.ToString(), null);

            #endregion

            #region parsers

            Bind<IDataFileParser>()
                 .To<CsvFileParser>()
                 .InRequestScope()
                .WithMetadata(FileType.CSV.ToString(), null);

            Bind<IDataFileParser>()
                 .To<ArffFileParser>()
                 .InRequestScope()
                .WithMetadata(FileType.ARFF.ToString(), null);

            Bind<IDataFileParser>()
                 .To<DataAndNamesFileParser>()
                 .InRequestScope()
                .WithMetadata(FileType.DataAndNames.ToString(), null);

            #endregion

            #region presenters

#if WEB
            Bind<IMainFormViewPresenter>()
               .To<MainFormViewPresenter>()
               .InRequestScope();
#else
            Bind<IMainFormViewPresenter>()
               .To<MainFormViewPresenter>()
               .InSingletonScope();
#endif

            Bind<IPreviewDataViewPresenter>()
              .To<PreviewDataPresenter>()
              .InSingletonScope();

            Bind<ISelectGeneratorViewPresenter>()
              .To<SelectGeneratorViewPresenter>()
              .InSingletonScope();

            Bind<IAboutViewPresenter>()
              .To<AboutViewPresenter>()
              .InSingletonScope();

            Bind<ISettingsViewPresenter>()
              .To<SettingsViewPresenter>()
              .InRequestScope();

            #endregion

            #region reports

            Bind<IReport>()
                .To<TxtReport>()
                .InRequestScope()
                .WithMetadata(ReportType.TXT.ToString(), null);

            Bind<IReport>()
                .To<RsesRulReport>()
                .InRequestScope()
                .WithMetadata(ReportType.RSES.ToString(), null);

            #endregion
        }
    }
}
