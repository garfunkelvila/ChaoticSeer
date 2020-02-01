using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Genetic_Algorithm {
    public abstract class Gene {
        /// <summary>
        /// Whenever a new gene appears (through structural mutation), a global
        /// innovation number is incremented and assigned to that gene.The
        /// innovation numbers thus represent a chronology of every gene in the
        /// system.
        /// </summary>
        public abstract int InnovationNumber { get; set; }
    }
}
