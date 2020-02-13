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
    public class CalcConnection {
        public CalcNode From { get; set; }
        public CalcNode To { get; set; }
        public float Weight { get; set; }
        public bool IsEnabled { get; set; } = true;
        public CalcConnection(CalcNode from, CalcNode to) {
            From = from;
            To = to;
        }
    }
}
