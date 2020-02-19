using gSeer.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Genetic_Algorithm {
    /// <summary>
    /// Equivalent to NEAT on PDF and works of others
    /// Especially https://github.com/Luecx/NEAT. I just inserted some C#
    /// specifics and other .net optimizations
    /// </summary>
    public class NeatCNS {
        public static int MAX_NODES;
        public const float WEIGHT_SHIFT_STRENGTH = 0.3f;
        public const float WEIGHT_RANDOM_STRENGTH = 0.1f;
        public const float SURVIVAL_THRESHOLD = 0.02f;
        public const float PROBABILITY_MUTATE_CONNECTION = 0.0025f;
        public const float PROBABILITY_MUTATE_NODE = 0.0025f;
        public const float PROBABILITY_MUTATE_WEIGHT_SHIFT = 0.75f;
        public const float PROBABILITY_MUTATE_WEIGHT_RANDOM = 0.001f;
        public const float PROBABILITY_MUTATE_TOGGLE = 0.005f;
        #region Properties
        public Dictionary<ConnectionGene, ConnectionGene> Connections { get; }
        public GeneHashSet<NodeGene> Nodes { get; }
        ///Protecting Innovation through Speciation
        public float C1 { get; }
        public float C2 { get; }
        public float C3 { get; set; }
        public float CP { get; } = 4f;
        public int InputSize { get; private set; }  //Sensor
        public int OutputSize { get; private set; } //Motor
        #endregion
        NeatCNS() {
            //MAX_NODES = (int)Math.Pow(2, 20);       // 1M max nodes
            MAX_NODES = 5;
            Connections = new Dictionary<ConnectionGene, ConnectionGene>();
            Nodes = new GeneHashSet<NodeGene>();
            C1 = 1;
            C2 = 1;
            C3 = 1;
        }
		public NeatCNS(int inputSize, int outputSize) : this() {
			Reset(inputSize, outputSize);
		}
		public void Reset(int inputSize, int outputSize) {
			InputSize = inputSize;
			OutputSize = outputSize;

			Connections.Clear();
			Nodes.Clear();

			// Directly access property of the newly addded node to list
			for (int i = 0; i < inputSize; i++) {
				NodeGene n = AddNode();
				n.X = 0.1f; // Used for drawing

				float _testa = i + 1;
				float _testb = inputSize + 1;
				float _testc = _testa / _testb;
				//n.Y = _testc;
				n.Y = i + 1 / inputSize + 1;
			}
			for (int i = 0; i < outputSize; i++) {
				NodeGene n = AddNode();
				n.X = 0.9f; // Used for drawing
				n.Y = i + 1 / outputSize + 1;
			}

		}
		/// <summary>
		/// Add a new node to the nervous system
		/// </summary>
		/// <returns>Returns the added node</returns>
		public NodeGene AddNode() {
            NodeGene n = new NodeGene(Nodes.Count + 1);
            Nodes.Add(n);
            return n;
        }
		/// <summary>
		/// Add a new node to the nervous system
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns the added node</returns>
		public NodeGene AddNode(int id) {
            if (id <= Nodes.Count) return Nodes[id - 1];
            return AddNode();
        }
        public ConnectionGene AddConnection(NodeGene node1, NodeGene node2) {
            /// Check if the current connection exists on the current genome
            ConnectionGene connectionGene = new ConnectionGene(node1, node2);
            if (Connections.ContainsKey(connectionGene)) {
                connectionGene.InnovationNumber = Connections[connectionGene].InnovationNumber;
            }
            else {
                connectionGene.InnovationNumber = Connections.Count + 1;
                Connections.Add(connectionGene, connectionGene);
            }
            return connectionGene;
        }
		public void SetReplaceIndex(NodeGene node1, NodeGene node2, int index) {
			Connections[new ConnectionGene(node1, node2)].ReplaceIndex = index;
		}
		public int GetReplaceIndex(NodeGene node1, NodeGene node2) {
			ConnectionGene con = new ConnectionGene(node1, node2);
			ConnectionGene data = Connections[con];
			if (data == null) return 0;
			return data.ReplaceIndex;
		}
	}
}
