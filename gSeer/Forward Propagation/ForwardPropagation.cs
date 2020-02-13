using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Data_Structures;
using gSeer.Genetic_Algorithm;

namespace gSeer.Forward_Propagation {
	public abstract class ForwardPropagation {
		public List<CalcNode> InputNodes { get; private set; } = new List<CalcNode>();
		public List<CalcNode> HiddenNodes { get; private set; } = new List<CalcNode>();
		public List<CalcNode> OutputNodes { get; private set; } = new List<CalcNode>();
		public abstract float[] Output(params float[] input);
	}
}
