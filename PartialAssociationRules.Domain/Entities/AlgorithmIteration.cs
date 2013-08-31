using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PartialAssociationRules.Domain.Extensions;

namespace PartialAssociationRules.Domain.Entities
{
    public class AlgorithmIteration
    {
        public AlgorithmIteration()
        {
            IterationNumber = 0;
        }

        public int IterationNumber { set; get; }
        public int ObjectsToCover { set; private get; }
        public int ObjectsCovered { set; private get; }
        public decimal PercentageCover
        {
            get
            {
                return ((ObjectsCovered * 100) / Convert.ToDecimal(ObjectsToCover)).Round();
            }
        }
    }
}
