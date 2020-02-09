using gSeer.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Genetic_Algorithm {
    /// <summary>
    /// X,Y handles recursion
    /// </summary>
    public class NodeGene : Gene {
        /// <summary>
        /// Used for drawing and comparing the position of node
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Used for drawing and comparing the position of node
        /// </summary>
        public float Y { get; set; }
        public override int InnovationNumber { get; set; }
        //Transfer from Neat
        public NodeGene(int innovationNumber) {
            InnovationNumber = innovationNumber;
        }
        public override bool Equals(Object obj) {
            // Attemp not to use equals that is overriden
            if (!GetType().Equals(obj.GetType())) return false;
            return InnovationNumber == ((NodeGene) obj).InnovationNumber;
        }
        public override int GetHashCode() {
            return InnovationNumber;
        }
    }
}
