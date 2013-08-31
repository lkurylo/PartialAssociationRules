/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Data;
using PartialAssociationRules.Domain.Entities;
using System.Collections.Generic;

namespace PartialAssociationRules.Domain.Report
{
    public class ReportInfo
    {
        public InformationSystem System { set; get; }

        public decimal Alpha
        {
            get;
            set;
        }

        public decimal Gamma
        {
            get;
            set;
        }

        public decimal Support
        {
            get;
            set;
        }

        public decimal Confidence
        {
            get;
            set;
        }

        public string SelectedAlgorithm
        {
            get;
            set;
        }

        public string DataSetName
        {
            get;
            set;
        }

        public int ObjectsQuantity
        {
            get;
            set;
        }

        public int AttributesQuantity
        {
            get;
            set;
        }

        public int GeneratedRulesQuantity
        {
            get;
            set;
        }

        public int GenerateDiffrentRulesQuantity
        {
            get;
            set;
        }

        public decimal AverageSupport
        {
            get;
            set;
        }

        public decimal AverageConfidence
        {
            get;
            set;
        }

        public int MinimalRuleLength
        {
            get;
            set;
        }

        public decimal AverageRuleLength
        {
            get;
            set;
        }

        public int MaximalRuleLength
        {
            get;
            set;
        }

        public decimal MinimalSupport
        {
            set;
            get;
        }

        public decimal MaximalSupport
        {
            set;
            get;
        }

        public decimal MinimalConfidence
        {
            set;
            get;
        }

        public decimal MaximalConfidence
        {
            set;
            get;
        }

        public DataTable GeneratedRules
        {
            set;
            get;
        }

        public System.Collections.Generic.List<string> DecisionAttributes { get; set; }

        public global::System.Collections.Generic.IEnumerable<RuleCount> Rules { get; set; }

        public global::System.Collections.Generic.Dictionary<string, int> Weights { get; set; }

        public int MinimalUpperBound { get; set; }

        public decimal AverageUpperBound { get; set; }

        public int MinimalLowerBound { get; set; }

        public int MaximalUpperBound { get; set; }

        public decimal AverageLowerBound { get; set; }

        public int MaximalLowerBound { get; set; }

        public IEnumerable<AlgorithmProgressExecution> PercentOfSeparatedRows { get; set; }
    }
}
