/* Copyright 2011 Łukasz Kuryło (lszk86@gmail.com)
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PartialAssociationRules.Domain.Entities;
using PartialAssociationRules.Domain.Extensions;
using PartialAssociationRules.Domain.Gui;
using PartialAssociationRules.Domain.Utilities;

namespace PartialAssociationRules.Domain.Algorithms
{
    /// <summary>
    /// Classic algorithm for constructing partial association rules.
    /// </summary>
    public class ClassicMultiThreading : IAlgorithm
    {
        public InformationSystem InformationSystem { set; get; }
        //private SynchronizationContext contex;
        public TaskScheduler Scheduler { get; set; }

        public Barrier Barrier { set; get; }
        //private Barrier barrier = new Barrier(1, (b) =>
        //                                                    {
        //                                                        P(++index);
        //                                                    });
        public ClassicMultiThreading()
        {
            Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //contex = SynchronizationContext.Current;
            //options = new ParallelOptions();
            //options.TaskScheduler = scheduler;
        }

        /// <summary>
        /// Construct (partial) association rules.
        /// </summary>
        public IEnumerable<RuleCount> Generate()
        {
            int index = 0;

            //TaskScheduler sch = TaskScheduler.Current;

            List<ConcurrentBag<AssociationRule>> result2 =
                  new List<ConcurrentBag<AssociationRule>>();

            ConcurrentBag<AssociationRule> result =
                  new ConcurrentBag<AssociationRule>();
            //   Parallel.ForEach(InformationSystem.Rows, (row) =>       //    
            Task[] tasks = new Task[InformationSystem.Rows.Count ];
            //    foreach (Row row in InformationSystem.Rows)
            //   {
            for (int i = 0; i < InformationSystem.Rows.Count; i++)
            {
                tasks[i] = new Task((n) =>
                                                                      {
                                                                          #region body
                                                                          IList<Row> separatedRows;
                                                                          var row = InformationSystem.Rows[i];
                                                                          ConcurrentBag<AssociationRule> result3 = new ConcurrentBag<AssociationRule>();
                                                                          foreach (Attribute decisionAttribute in row.Attributes)
                                                                          //each attribute is treated as a decision attribute
                                                                          {
                                                                              Condition
                                                                                  decisionAttributeInResult
                                                                                      =
                                                                                      new Condition(
                                                                                          decisionAttribute);
                                                                              IList<Condition> conditions =
                                                                                  new List<Condition>();

                                                                              separatedRows =
                                                                                  InformationSystem.Rows.GetRowsSeparatedByAttribute(row, decisionAttribute);

                                                                              IList<Row> separatedRowsCopy = separatedRows;
                                                                              int alreadyCovered = 0;
                                                                              int minimumNumberOfRowsToSeparate
                                                                                      = System.Convert.ToInt32(
                                                                                      System.Math.Ceiling((1 - InformationSystem.Alpha) * separatedRows.Count));

                                                                              while (alreadyCovered < minimumNumberOfRowsToSeparate)
                                                                              {
                                                                                  IList<Subset> subsets =
                                                                                      separatedRowsCopy.CreateSubsets(row, decisionAttribute);

                                                                                  string
                                                                                      subsetWithMaxElements = subsets.OrderByDescending(x => x.Count)
                                                                                              .Select(x => x.Name)
                                                                                              .First();

                                                                                  alreadyCovered +=
                                                                                      subsets.Where(
                                                                                          x =>
                                                                                          x.Name ==
                                                                                          subsetWithMaxElements)
                                                                                          .Select(
                                                                                              x => x.Count)
                                                                                          .First();
                                                                                  conditions.Add(new Condition
                                                                                                     (
                                                                                                     row.Attributes.Where(x => x
                                                                                                                 .Name ==
                                                                                                             subsetWithMaxElements)
                                                                                                         .First
                                                                                                         ()));

                                                                                  separatedRowsCopy = separatedRowsCopy
                                                                                      .RemoveElementsFromAlreadyCoveredSubsets
                                                                                      (subsets,
                                                                                          subsetWithMaxElements);
                                                                              }
                                                                              var rule = new AssociationRule(
                                                                                          conditions,
                                                                                          decisionAttributeInResult);

                                                                              rule.Support = decimal.Round(
                                                                             rule.CalculateSupport(
                                                                                  InformationSystem.Rows), 2);

                                                                              rule.Confidence = decimal.Round(
                                                                              rule.CalculateConfidence(
                                                                                  InformationSystem.Rows), 2);
                                                                              result.Add(rule);
                                                                              //  result3.Add(rule);
                                                                              //   );
                                                                              alreadyCovered = 0;
                                                                              separatedRows = null;

                                                                          }
                                                                          //  
                                                                          #endregion
                                                                      }, CancellationToken.None, TaskCreationOptions.LongRunning);

                tasks[i].ContinueWith((p) =>
               {
                   int o;
                   lock (locker)
                   {
                        o = ++index;
                   }
                       Notify(o);
                   
               }

, CancellationToken.None, TaskContinuationOptions.None, Scheduler);

                tasks[i].Start();
                tasks[i].Wait();
            }

            // Task.WaitAll(tasks);
            var group = result.GroupBy(
                z => z,
                (rule, count) => new RuleCount
                                     {
                                         Rule = rule,
                                         Count = count.Count()
                                     },
                new AssociationRulesComparer());

            return group;
        }

        //    return
        //        rules.Result.Where(x =>
        //                           x.Rule.Support >= InformationSystem.Support * 100 &&
        //                           x.Rule.Confidence * 100 >=
        //                           InformationSystem.Confidence).Select(x => x);
        //});

        /// <summary>
        /// Type of the algorithm.
        /// </summary>
        public AlgorithmType Type
        {
            get { return AlgorithmType.Classic; }
        }

        public event NotifyAboutIterationEnd Notify;
        private static readonly object locker = new object();
        //private readonly object locker = new object();
    }
}
