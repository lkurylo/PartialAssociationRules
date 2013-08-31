/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Concurrent;
using PartialAssociationRules.Domain.Entities;

namespace PartialAssociationRules.Domain.Gui
{
    public delegate void NotifyAboutIterationEnd(int iteration);
    public delegate void ReturnGeneratedRules(ConcurrentBag<AssociationRule> result);
    public delegate void ReturnPercentOfSeparatedRows(ConcurrentBag<AlgorithmProgressExecution> result);
}
