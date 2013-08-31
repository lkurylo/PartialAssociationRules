using System;

namespace PartialAssociationRules.Domain.Extensions
{
    public enum TemplateElements
    {
        date,
        selectedAlgorithm,
        datasetName,
        objectsQuantity,
        attributesQuantity,
        alpha,
        support,
        confidence,
        gamma,
        informationSystem,
        weights,
        rules,
        generatedRulesQuantity,
        generatedDiffrentRulesQuantity,
        minimalRuleLength,
        averageRuleLength,
        maximalRuleLength,
        minimalSupport,
        averageSupport, 
        maximalSupport,
        minimalConfidence,
        averageConfidence,
        maximalConfidence,
        decisionAttributes,
        minimalUpperBound,
        averageUpperBound,
        maximalUpperBound,
        minimalLowerBound,
        averageLowerBound,
        maximalLowerBound,
        percentOfSeparatedRows
    }

    public static class StringExtensions
    {
        public static string Replace(this string str, TemplateElements elem, string newValue)
        {
            string x=String.Format("#{{{0}}}", elem.ToString());
            return str.Replace(x, newValue);
        }
    }
}
