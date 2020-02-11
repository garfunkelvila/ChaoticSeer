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
    public class Neat {
        public static int MAX_NODES;
        public const float WEIGHT_SHIFT_STRENGTH = 0.3f;
        public const float WEIGHT_RANDOM_STRENGTH = 0.1f;
        public const float SURVIVAL_THRESHOLD = 0.02f;
        public const float PROBABILITY_MUTATE_CONNECTION = 0.005f;
        public const float PROBABILITY_MUTATE_NODE = 0.003f;
        public const float PROBABILITY_MUTATE_WEIGHT_SHIFT = 0.025f;
        public const float PROBABILITY_MUTATE_WEIGHT_RANDOM = 0.0f;
        public const float PROBABILITY_MUTATE_TOGGLE = 0.005f;
        #region Properties
        public Dictionary<ConnectionGene, ConnectionGene> Connections { get; }
        public GeneHashSet<NodeGene> Nodes { get; }
        public GeneHashSet<Client> Clients { get; private set; }
        public GeneHashSet<Species> Species { get; private set; }
        ///Protecting Innovation through Speciation
        public float C1 { get; }
        public float C2 { get; }
        public float C3 { get; set; }
        public float CP { get; } = 4f;
        public int InputSize { get; private set; }  //Sensor
        public int OutputSize { get; private set; } //Motor
        public int MaxClients { get; private set; }
        #endregion
        Neat() {
            MAX_NODES = (int)Math.Pow(2, 20);       // 1M max nodes
            Connections = new Dictionary<ConnectionGene, ConnectionGene>();
            Nodes = new GeneHashSet<NodeGene>();
            Clients = new GeneHashSet<Client>();
            Species = new GeneHashSet<Species>();
            C1 = 1;
            C2 = 1;
            C3 = 1;
        }
        public Neat(int inputSize, int outputSize, int clients) : this() {
            Reset(inputSize, outputSize, clients);
        }
        public void Reset(int inputSize, int outputSize, int clients) {
            InputSize = inputSize;
            OutputSize = outputSize;
            MaxClients = clients;

            Connections.Clear();
            Nodes.Clear();
            Clients.Clear();

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
            // Miror to calculator
            for (int i = 0; i < MaxClients; i++) {
                Client c = new Client {
                    //c.Genome = NewEmptyGenome();
                    Genome = new ChaoticSeer(this)
                };
                c.InitializeCalculator();
                Clients.Add(c);
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
        /// <param name="id">Returns the added node</param>
        /// <returns></returns>
        public NodeGene AddNode(int id) {
            if (id <= Nodes.Count) return Nodes[id - 1];
            return AddNode();
        }
        public static ConnectionGene AddConnection(ConnectionGene cG) {
            ConnectionGene c = new ConnectionGene(cG.From, cG.To) {
                Weight = cG.Weight,
                IsEnabled = cG.IsEnabled
            };
            return c;
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
        #region EVOLUTION
        public void Evolve() {
            GenerateSpecies();
            Kill();
            RemoveExtinct();
            Reproduce();
            Mutate();
            Calculate(); ;
        }
        private void GenerateSpecies() {
            foreach (Species item in Species.Data) {
                item.Reset();
            }

            foreach (Client CItem in Clients.Data) {
                if (CItem.Species != null) continue;
                bool hasFound = false;
                foreach (Species SItem in Species.Data) {
                    if (SItem.Put(CItem)) {
                        hasFound = true;
                        break;
                    }
                }

                if (!hasFound) {
                    Species.Add(new Species(CItem));
                }
            }
            foreach (Species item in Species.Data) {
                item.EvalueateScore();
            }
        }
        private void Kill() {
            foreach (Species item in Species.Data) {
                item.Kill(1 - SURVIVAL_THRESHOLD);
            }
        }
        private void RemoveExtinct() {
            for (int i = Species.Count - 1; i > 0; i--) {
                if (Species[i].Clients.Count <= 1) {
                    Species[i].GoExtinct();
                    Species.RemoveAt(i);
                }
            }
        }
        private void Reproduce() {
            RandomSelector<Species> selector = new RandomSelector<Species>();
            foreach (Species s in Species.Data) {
                selector.Add(s, s.Score);
            }
            foreach (Client c in Clients.Data) {
                if (c.Species == null) {
                    Species s = selector.Random();
                    c.Genome = s.Breed();
                    s.ForcePut(c);
                }
            }
        }
        private void Mutate() {
            foreach (Client item in Clients.Data) {
                item.Mutate();
            }
        }
        private void Calculate() {
            foreach (Client item in Clients.Data) {
                item.InitializeCalculator();
            }
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
        #endregion
    }
}
