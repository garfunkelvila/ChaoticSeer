using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Calculations {
    public class Node : IComparable<Node> {
		Neuron.Activation ActivationFunction;
        public float X { get; set; }
        public float Output { get; set; }
        public List<Connection> Connections { get; set; }
		Node() {
			ActivationFunction = new Neuron.ActivationFunction.Logistic();
			Connections = new List<Connection>();
		}
        public Node(float x ) : this() {
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
		public int CompareTo(Node other) {
			if (X > other.X) return -1;
			if (X < other.X) return 1;
			return 0;
		}
	}
}
