using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Genetic_Algorithm {
    public class ConnectionGene : Gene {
        public NodeGene From { get; set; }
        public NodeGene To { get; set; }
        public float Weight { get; set; }
        public bool IsEnabled { get; set; }

        public override int InnovationNumber { get; set; }
        public ConnectionGene(bool isEnabled = true) {
            IsEnabled = isEnabled;
        }
    }
}
