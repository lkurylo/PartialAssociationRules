/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Data;
using System.IO;
using System.Text;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Extensions;
using PartialAssociationRules.Domain.Gui;

namespace PartialAssociationRules.Domain.Report
{
    public class TxtReport : IReport
    {
        public string CreateReport()
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            //this is a hack for win xp
            //only God and people from M$ knows why in xp current directory is set to the Report subdirectory
            //and not to the directory where the executable file is
            //in win 7 is ok
            int index = currentDirectory.LastIndexOf("\\Reports");
            if (index >= 0)
            {
                currentDirectory = currentDirectory.Remove(index);
            }

            StreamReader template = new StreamReader(currentDirectory + "\\Reports\\Templates\\txtReportTemplate.txt", Encoding.UTF8);

            string templateBody = template.ReadToEnd();

            string result = templateBody
                    .Replace(TemplateElements.alpha, Convert.ToString(ReportDetails.Alpha))
                    .Replace(TemplateElements.attributesQuantity, Convert.ToString(ReportDetails.AttributesQuantity))
                    .Replace(TemplateElements.averageConfidence, Convert.ToString(ReportDetails.AverageConfidence))
                    .Replace(TemplateElements.averageRuleLength, Convert.ToString(ReportDetails.AverageRuleLength))
                    .Replace(TemplateElements.averageSupport, Convert.ToString(ReportDetails.AverageSupport))
                    .Replace(TemplateElements.confidence, Convert.ToString(ReportDetails.Confidence))
                    .Replace(TemplateElements.datasetName, ReportDetails.DataSetName)
                    .Replace(TemplateElements.date, System.DateTime.Now.ToString())
                    .Replace(TemplateElements.generatedDiffrentRulesQuantity,
                    Convert.ToString(ReportDetails.GenerateDiffrentRulesQuantity))
                    .Replace(TemplateElements.generatedRulesQuantity,
                    Convert.ToString(ReportDetails.GeneratedRulesQuantity))
                    .Replace(TemplateElements.maximalConfidence, Convert.ToString(ReportDetails.MaximalConfidence))
                    .Replace(TemplateElements.maximalRuleLength,
                Convert.ToString(ReportDetails.MaximalRuleLength))
                     .Replace(TemplateElements.maximalSupport,
                Convert.ToString(ReportDetails.MaximalSupport))
                    .Replace(TemplateElements.minimalConfidence, Convert.ToString(ReportDetails.MinimalConfidence))
                    .Replace(TemplateElements.minimalRuleLength, Convert.ToString(ReportDetails.MinimalRuleLength))
                    .Replace(TemplateElements.minimalSupport, Convert.ToString(ReportDetails.MinimalSupport))
                    .Replace(TemplateElements.objectsQuantity, Convert.ToString(ReportDetails.ObjectsQuantity))
                    .Replace(TemplateElements.selectedAlgorithm, ReportDetails.SelectedAlgorithm)
                    .Replace(TemplateElements.support, Convert.ToString(ReportDetails.Support))
                    .Replace(TemplateElements.minimalUpperBound, Convert.ToString(ReportDetails.MinimalUpperBound))
                    .Replace(TemplateElements.averageUpperBound, Convert.ToString(ReportDetails.AverageUpperBound))
                    .Replace(TemplateElements.maximalUpperBound, Convert.ToString(ReportDetails.MaximalUpperBound))
                    .Replace(TemplateElements.minimalLowerBound, Convert.ToString(ReportDetails.MinimalLowerBound))
                    .Replace(TemplateElements.averageLowerBound, Convert.ToString(ReportDetails.AverageLowerBound))
                    .Replace(TemplateElements.maximalLowerBound, Convert.ToString(ReportDetails.MaximalLowerBound))
                    ;

            AlgorithmsNameType algorithms = new AlgorithmsNameType();
            if (algorithms[ReportDetails.SelectedAlgorithm] == Algorithms.AlgorithmType.ClassicWithWeights)
            {
                result = result
                    .Replace(TemplateElements.gamma, Convert.ToString(ReportDetails.Gamma))
                    .Replace(TemplateElements.weights, ConvertWeightsToString());
            }
            else
            {
                result = result
                    .Replace(TemplateElements.gamma, "nie zdefiniowano")
                    .Replace(TemplateElements.weights, "nie zdefiniowano");
            }

            if (SettingsManager.Settings.InsertInfSysInReport)
            {
                result = result
                    .Replace(TemplateElements.informationSystem, ConvertInformationSystemToString());
            }
            else
            {
                result = result
                    .Replace(TemplateElements.informationSystem, "nie zdefiniowano");
            }

            if (SettingsManager.Settings.PercentageOfSeparatedRows)
            {
                result = result
             .Replace(TemplateElements.percentOfSeparatedRows, ConvertPercentageOfSeparatedRowsToString());
            }
            else
            {
                result = result
             .Replace(TemplateElements.percentOfSeparatedRows, "nie zdefiniowano");
            }

            StringBuilder rules = new StringBuilder();
            foreach (var row in ReportDetails.GeneratedRules.Rows)
            {
                var objects = ((DataRow)row).ItemArray;

                rules.AppendLine(
                    System.String.Format("Reguła asocjacyjna: {0}, wsparcie[%]: {1}, zaufanie[%]: {2}, długość reguły: {3}, liczba powtórzeń: {4}, górna granica: {5}, dolna granica: {6}",
                    objects[0], objects[1], objects[2], objects[3], objects[6], objects[4], objects[5]));
            }

            result = result
                .Replace(TemplateElements.rules, rules.ToString());

            StringBuilder attributes = new StringBuilder();
            foreach (string singleAttr in ReportDetails.DecisionAttributes)
            {
                attributes.AppendLine(singleAttr);
            }

            result = result
                .Replace(TemplateElements.decisionAttributes, attributes.ToString());

            return result;
        }

        public ReportType Type
        {
            get { return ReportType.TXT; }
        }

        private string ConvertInformationSystemToString()
        {
            StringBuilder result = new StringBuilder();
            StringBuilder row;

            var data = ReportDetails.System.Rows;

            result.Append("Nr |");
            foreach (Entities.Attribute singleAttribute in data[0].Attributes) //add attributes names
            {
                result.Append(String.Format(" {0} |", singleAttribute.Name));
            }

            foreach (Row singleRow in ReportDetails.System.Rows) //add data from each row
            {
                row = new StringBuilder();
                row.AppendLine("");
                row.Append(singleRow.Name + " |");

                foreach (Entities.Attribute singleAttribute in singleRow.Attributes)
                {
                    row.Append(String.Format(" {0} |", singleAttribute.Value));
                }

                result.Append(row);
            }

            return result.ToString();
        }

        private string ConvertWeightsToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Atrybut | Wartość");

            var weights = ReportDetails.Weights;
            foreach (var singleWeight in weights)
            {
                result.AppendLine(String.Format("{0} | {1}", singleWeight.Key, singleWeight.Value));
            }

            return result.ToString();
        }

        private string ConvertPercentageOfSeparatedRowsToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Atrybut decyzyjny | Nr iteracji | Procentowe pokrycie");
            foreach (var singleRow in ReportDetails.PercentOfSeparatedRows)
            {
                foreach (var singleIteration in singleRow.Iterations)
                {
                    result.AppendLine(String.Format("{0} | {1} | {2}", singleRow.DecisionAttribute.Name, singleIteration.IterationNumber, singleIteration.PercentageCover));
                }
            }

            return result.ToString();
        }

        public ReportInfo ReportDetails
        {
            get;
            set;
        }
    }
}
