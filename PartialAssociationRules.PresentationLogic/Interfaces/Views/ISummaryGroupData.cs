/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using PartialAssociationRules.PresentationLogic.Interfaces.Presenters;
namespace PartialAssociationRules.PresentationLogic.Interfaces.Views
{
    public interface ISummaryGroupData
    {
        //IMainFormViewPresenter Presenter { set; get; }
        string DataSetName { set; get; }
        int ObjectsQuantity { set; get; }
        int AttributesQuantity { set; get; }
        int GeneratedRulesQuantity { set; get; }
        int GenerateDiffrentRulesQuantity { set; get; }
        decimal AverageSupport { set; get; }
        decimal AverageConfidence { set; get; }
        int MinimalRuleLength { set; get; }
        decimal AverageRuleLength { set; get; }
        int MaximalRuleLength { set; get; }
        decimal MinimalSupport { get; set; }
        decimal MaximalSupport { get; set; }
        decimal MinimalConfidence { get; set; }
        decimal MaximalConfidence { get; set; }
        int MinimalUpperBound { get; set; }
        decimal AverageUpperBound { get; set; }
        int MaximalUpperBound { get; set; }
        int MinimalLowerBound { get; set; }
        decimal AverageLowerBound { get; set; }
        int MaximalLowerBound { get; set; }
    }
}
