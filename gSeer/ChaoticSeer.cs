using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Genetic_Algorithm;
using gSeer.Data_Structures;
using gSeer.Calculations;
namespace gSeer {
    /// <summary>
    /// Genome
    /// </summary>
    public class ChaoticSeer {
        public GeneHashSet<ConnectionGene> Connections { get; set; }
        public GeneHashSet<NodeGene> Nodes { get; set; }
        public Neat Neat { get; set; }
        /// Percentage of this species allowed to reproduce
        public const float SURVIVAL_THRESHOLD = 0.02f;
        /// <summary>
        /// Create a Genome without neat template
        /// </summary>
        public ChaoticSeer() {
            Connections = new GeneHashSet<ConnectionGene>();
            Nodes = new GeneHashSet<NodeGene>();
        }
        /// <summary>
        /// Create an emptygenome with only nodes wihtout connections based on a Neat
        /// </summary>
        /// <param name="neat"></param>
        public ChaoticSeer(Neat neat) : this() {
            Neat = neat;
            for (int i = 0; i < neat.InputSize + neat.OutputSize; i++) {
                Nodes.Add(neat.AddNode(i + 1));
            }
        }
        /// <summary>
        /// Calculate the distance between g1 and g2
        /// </summary>
        /// <param name="g2"></param>
        /// <returns></returns>
        public float Distance(ChaoticSeer g2) {
            // g1 genome must have highest innovation number
            #region Cache
            ChaoticSeer g1_this = this;

            // Get the last innovation number
            int highestInnovationGene1 = g1_this.Connections.Count == 0 ? 
                0 : g1_this.Connections[g1_this.Connections.Count - 1].InnovationNumber;
            int highestInnovationGene2 = g1_this.Connections.Count == 0 ? 
                0 : g2.Connections[g2.Connections.Count - 1].InnovationNumber;

            int indexG1 = 0;
            int indexG2 = 0;

            int disjoint = 0;
            int simmilar = 0;
            float weightDiff = 0;

            #endregion
            if (highestInnovationGene1 < highestInnovationGene2) {
                // ensure g1 have the highest inovation number
                ChaoticSeer g = g1_this;
                g1_this = g2;
                g2 = g;
            }

            /// Loop through all connections
            while (indexG1 < g1_this.Connections.Count && indexG2 < g2.Connections.Count) {
                ConnectionGene cg1 = g1_this.Connections[indexG1];
                ConnectionGene cg2 = g1_this.Connections[indexG2];

                int in1 = cg1.InnovationNumber;
                int in2 = cg2.InnovationNumber;

                if (in1 == in2) {
                    /// Simmilar gene
                    simmilar++;
                    weightDiff += Math.Abs(cg1.Weight - cg2.Weight);    //Clampt to be always positive
                    indexG1++;
                    indexG2++;
                }
                else if (in1 > in2) {
                    /// disjoint/skip gene of b
                    disjoint++;
                    indexG2++;
                }
                else {
                    /// disjoint/skip gene of a
                    disjoint++;
                    indexG1++;
                }
            }

            int excess = g1_this.Connections.Count - indexG2;    // Required to order genes because of this one
            weightDiff /= simmilar;     // Divide difference with the ammount of same connections. I also saw on others creation

            // Protecting Innovation through Speciation phd04.38
            float N = Math.Max(g1_this.Connections.Count, g2.Connections.Count);
            if (N < 20) {
                N = 1;  //Clamp to 1
            }
            // Protecting Innovation through Speciation phd04.38
            return (Neat.C1 * disjoint / N) + (Neat.C2 * excess / N) + (Neat.C3 * weightDiff);
        }
        /// <summary>
        /// Creates a new genome.
        /// current g1 should have the higher score
        /// take all the genes of g1
        /// if there is a genome in g1 that is also in g2, choose randomly
        /// do not take disjoint genes of g2
        /// take excess genes of g1 if they exist
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        public static ChaoticSeer CrossOver(ChaoticSeer g1, ChaoticSeer g2) {
            Neat neat = g1.Neat;
            //Genome _genomeBuffer = neat.NewEmptyGenome();
            ChaoticSeer _genomeBuffer = new ChaoticSeer();

            int indexG1 = 0;
            int indexG2 = 0;

            //Handle not connectec genes
            while (indexG1 < g1.Connections.Count && indexG2 < g2.Connections.Count) {
                ConnectionGene gene1 = g1.Connections[indexG1];
                ConnectionGene gene2 = g2.Connections[indexG2];

                int in1 = gene1.InnovationNumber;
                int in2 = gene2.InnovationNumber;

                if (in1 == in2) {
                    // basically if they are thesame, just select either of them randomly
                    if (Util.GetRngF() > 0.5f)
                        _genomeBuffer.Connections.Add(neat.Connections[gene1]);
                    else
                        _genomeBuffer.Connections.Add(neat.Connections[gene2]);

                    indexG1++;
                    indexG2++;
                }
                else if (in1 > in2) {
                    //genome.Connections.Add(neat.Connections[gene2]);
                    //disjoint/skip gene of b
                    indexG2++;
                }
                else {
                    //disjoint/skip gene of a
                    _genomeBuffer.Connections.Add(neat.Connections[gene1]);
                    indexG1++;
                }
            }
            // Add the connections
            while (indexG1 < g1.Connections.Count) {
                ConnectionGene gene1 = g1.Connections[indexG1];
                _genomeBuffer.Connections.Add(neat.Connections[gene1]);
                indexG1++;
            }
            // Add the nodes
            foreach (ConnectionGene c in _genomeBuffer.Connections) {
                _genomeBuffer.Nodes.Add(c.From);
                _genomeBuffer.Nodes.Add(c.To);
            }

            return _genomeBuffer;
        }
        public void Mutate() {
            if (Neat.PROBABILITY_MUTATE_CONNECTION > Util.GetRngF())
                MutateConnection();
            if (Neat.PROBABILITY_MUTATE_NODE > Util.GetRngF())
                MutateNode();
            if (Neat.PROBABILITY_MUTATE_TOGGLE > Util.GetRngF())
                MutateToggleConnection();
            if (Neat.PROBABILITY_MUTATE_WEIGHT_SHIFT > Util.GetRngF())
                MutateWeightShift();
            if (Neat.PROBABILITY_MUTATE_WEIGHT_RANDOM > Util.GetRngF())
                MutateWeightRandom();
        }
        /// <summary>
        /// Check existing link first
        /// </summary>
        public void MutateConnection() {
            for (int i = 0; i < 100; i++) {
                NodeGene a = Nodes.Random;
                NodeGene b = Nodes.Random;

                if (a == null || b == null) continue;   //skip if empty
                if (a.X == b.X)  continue;              //skip if thesame

                // Create connection for the new seed
                ConnectionGene con;
                if (a.X < b.X)
                    con = new ConnectionGene(a, b);
                else
                    con = new ConnectionGene(b, a);

                if (Connections.Contains(con)) {
                    //skip if newly generated connection already exist
                    continue;
                }

                con = Neat.AddConnection(con.From, con.To);
                con.Weight = (Util.GetRngF() * 2 - 1) * Neat.WEIGHT_RANDOM_STRENGTH;

                //Attempt to ensure that the data is sorted by its InnovaitonNumber
                for (int cI = 0; i < Connections.Count; i++) {
                    int innovation = Connections[cI].InnovationNumber;
                    if (con.InnovationNumber < innovation) {
                        //Insert it right next
                        Connections.Insert(cI, con);
                        return;
                    }
                }
                Connections.Add(con);
                return;
            }
        }
        /// <summary>
        /// Add node
        /// </summary>
        public void MutateNode() {
            ConnectionGene con = Connections.Random;
            if (con == null) return;

            NodeGene from = con.From;
            NodeGene middle;
            NodeGene to = con.To;

            int replaceIndex = Neat.GetReplaceIndex(from, to);

            if(replaceIndex == 0) {
                middle = Neat.AddNode();
                middle.X = (from.X + to.X) / 2;
                middle.Y = (from.Y + to.Y) / 2 + (float)(Util.GetRngF() * 0.1 - 0.05);
                Neat.SetReplaceIndex(from, to, middle.InnovationNumber);
            }
            else {
                middle = Neat.AddNode(replaceIndex);
            }

            //NodeGene middle = Neat.AddNode();
            //middle.X = (from.X + to.X) / 2; //Divide by to to get the center
            //middle.Y = (from.Y + to.Y) / 2; //Divide by to to get the center

            ConnectionGene con1 = Neat.AddConnection(from, middle);
            ConnectionGene con2 = Neat.AddConnection(middle, to);


            con1.Weight = 1;
            con2.Weight = con.Weight;
            con2.IsEnabled = con.IsEnabled;

            Connections.Remove(con);
            Connections.Add(con1);
            Connections.Add(con2);

            Nodes.Add(middle);

        }
        /// <summary>
        /// Shift weight based on shift strength
        /// </summary>
        public void MutateWeightShift() {
            ConnectionGene con = Connections.Random;
            if (con != null) {
                con.Weight += (Util.GetRngF() * 2 - 1) * Neat.WEIGHT_SHIFT_STRENGTH;
            }
        }
        /// <summary>
        /// Shift weight based on random strength
        /// </summary>
        public void MutateWeightRandom() {
            ConnectionGene con = Connections.Random;
            if (con != null) {
                con.Weight = (Util.GetRngF() * 2 - 1) * Neat.WEIGHT_RANDOM_STRENGTH;
            }
        }
        public void MutateToggleConnection() {
            ConnectionGene con = Connections.Random;
            if (con != null) {
                con.IsEnabled = con.IsEnabled;
            }
        }
    }
}
