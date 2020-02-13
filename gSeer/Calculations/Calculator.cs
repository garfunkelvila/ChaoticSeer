using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Data_Structures;
using gSeer.Genetic_Algorithm;

namespace gSeer.Calculations {
    /// <summary>
    /// This thing calculates the values for the genes
    /// </summary>
    public class Calculator {
        public List<Node> InputNodes { get; private set; } = new List<Node>();
        public List<Node> HiddenNodes { get; private set; }  = new List<Node>();
        public List<Node> OutputNodes { get; private set; }  = new List<Node>();
        public Calculator(ChaoticSeer seer) {
            GeneHashSet<NodeGene> _nodes = seer.Nodes;
            GeneHashSet<ConnectionGene> _cons = seer.Connections;
            Dictionary<int, Node> _nodeHashMap = new Dictionary<int, Node>();
            foreach (NodeGene item in _nodes.Data) {
                Node node = new Node(item.X);
                _nodeHashMap.Add(item.InnovationNumber, node);

                if(item.X < 0.1) {
                    InputNodes.Add(node);
                }
                else if(item.X >= 0.9) {
                    OutputNodes.Add(node);
                }
                else {
                    HiddenNodes.Add(node);
                }
            }
			//Node inherits comparable so it should use the sort correctly
			//HiddenNodes.Sort(delegate (Node n1, Node n2) {
			//	//https://stackoverflow.com/questions/3163922/sort-a-custom-class-listt
			//	return n1.CompareTo(n2);
			//});
			HiddenNodes.Sort();
            foreach (ConnectionGene item in _cons.Data) {
                NodeGene from = item.From;
                NodeGene to = item.To;

                Node node_from = _nodeHashMap[from.InnovationNumber];
                Node node_to = _nodeHashMap[to.InnovationNumber];

				Connection con = new Connection(node_from, node_to) {
					Weight = item.Weight,
					IsEnabled = item.IsEnabled
				};

				node_to.Connections.Add(con);
            }
        }
        public float[] Calculate( params float[] input) {
            if (input.Length != InputNodes.Count) throw new NotSupportedException();
            //Initialze input nodes
            for (int i = 0; i < InputNodes.Count; i++) {
                InputNodes[i].Output = input[i];
            }
            //Calculate hidden nodes
            foreach (Node item in HiddenNodes) {
                item.Calculate();
            }
            float[] output = new float[OutputNodes.Count];
            //calculate ouput nodes
            for (int i = 0; i < OutputNodes.Count; i++) {
                OutputNodes[i].Calculate();
                output[i] = OutputNodes[i].Output;
            }
            return output;
        }
    }
}
