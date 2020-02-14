using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Data_Structures;
using gSeer.Genetic_Algorithm;

namespace gSeer.Forward_Propagation {
	public abstract class ForwardPropagation {
		public abstract List<CalcNode> InputNodes { get; set; }
		public abstract List<CalcNode> HiddenNodes { get; set; }
		public abstract List<CalcNode> OutputNodes { get; set; }
		public abstract float[] Output(params float[] input);
	}
}
