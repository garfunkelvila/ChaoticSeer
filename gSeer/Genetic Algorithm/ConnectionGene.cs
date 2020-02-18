using gSeer.Data_Structures;
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
        public int ReplaceIndex { get; set; }
        public override int InnovationNumber { get; set; }
        public ConnectionGene(bool isEnabled = true) {
            IsEnabled = isEnabled;
        }
        public ConnectionGene(NodeGene from, NodeGene to) : this() {
            From = from;
            To = to;
        }
        public override bool Equals(object obj) {
            if (!GetType().Equals(obj.GetType())) return false;
            ConnectionGene cg = (ConnectionGene)obj;
            return (From.Equals(cg.From) && To.Equals(cg.To));
        }
        public override int GetHashCode() {
            return From.InnovationNumber * NeatCNS.MAX_NODES + To.InnovationNumber;
        }
    }
}
