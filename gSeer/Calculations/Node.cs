using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Calculations {
    public class Node : IComparable<Node> {
        public float X { get; set; }
        public float Output { get; set; }
        public List<Connection> Connections { get; set; } = new List<Connection>();
        public int CompareTo(Node other) {
            if (X > other.X) return 1;
            if (X < other.X) return -1;
            return 0;
        }
        public Node(float x ) {
            X = x;
        }

        public void Calculate() {
            float s = 0f;
            for (int i = 0; i < Connections.Count; i++) {
                if (Connections[i].IsEnabled) {
                    s += Connections[i].Weight * Connections[i].From.Output;
                }
                
            }
            Output = ActivationFunction(s);
        }
        private float ActivationFunction(float x) {
            return (float)(1 / (1 + Math.Exp(-x)));
        }
    }
}
