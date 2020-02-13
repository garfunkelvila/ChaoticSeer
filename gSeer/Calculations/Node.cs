using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Calculations {
    public class CalcNode : IComparable<CalcNode> {
		Neuron.Activation ActivationFunction;
        public float X { get; set; }
        public float Output { get; set; }
        public List<CalcConnection> Connections { get; set; }
		CalcNode() {
			ActivationFunction = new Neuron.ActivationFunction.Logistic();
			Connections = new List<CalcConnection>();
		}
        public CalcNode(float x ) : this() {
            X = x;
        }
		public void Calculate() {
            float s = 0f;
            for (int i = 0; i < Connections.Count; i++) {
                if (Connections[i].IsEnabled) {
                    s += Connections[i].Weight * Connections[i].From.Output;
                }
            }
            Output = ActivationFunction.GetAxon(s);
        }
		/// <summary>
		/// Compare position left to right
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(CalcNode other) {
			if (X > other.X) return -1;
			if (X < other.X) return 1;
			return 0;
		}
	}
}
