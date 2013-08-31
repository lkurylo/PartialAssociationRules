using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialAssociationRules.Domain.Entities
{
    public class AlgorithmProgressExecution
    {
        public AlgorithmProgressExecution()
        {
            Iterations = new List<AlgorithmIteration>();
        }

        public Attribute DecisionAttribute { set; get; }
        public IList<AlgorithmIteration> Iterations { set; get; }
    }
}
