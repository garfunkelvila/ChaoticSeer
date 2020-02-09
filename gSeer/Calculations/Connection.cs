using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Calculations;

namespace gSeer.Calculations {
    /// <summary>
    /// Might merge this to the ConnectionGene
    /// </summary>
    public class Connection {
        public Node From { get; set; }
        public Node To { get; set; }
        public float Weight { get; set; }
        public bool IsEnabled { get; set; } = true;
        public Connection(Node from, Node to) {
            From = from;
            To = to;
        }
    }
}
