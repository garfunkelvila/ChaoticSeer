using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Genetic_Algorithm;
using gSeer.Data_Structures;
using gSeer.Calculations;
using System.Drawing;

namespace gSeer {
    /// <summary>
    /// Genome
    /// </summary>
    public class ChaoticSeer : Paint {
        public GeneHashSet<ConnectionGene> Connections { get; set; }
        public GeneHashSet<NodeGene> Nodes { get; set; }
        public Neat Neat { get; set; }
		private static Mutation.Mutation _mutation =  new Mutation.MutationST();
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
		public Bitmap GetBitmap() {
			return GenBitmap(this);
		}
        /// <summary>
        /// Calculate the distance between g1 and g2
        /// </summary>
        /// <param name="g2"></param>
        /// <returns></returns>
        public float DistanceTo(ChaoticSeer g2) {
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
        public void MutateConnection() => _mutation.MutateConnection(this);
		public void MutateNode() => _mutation.MutateNode(this);
		public void MutateWeightShift() => _mutation.MutateWeightShift(this);
		public void MutateWeightRandom() => _mutation.MutateWeightRandom(this);
		public void MutateToggleConnection() => _mutation.MutateToggleConnection(this);
		public static ChaoticSeer CrossOver(ChaoticSeer g1, ChaoticSeer g2) => _mutation.CrossOver(g1, g2);
		public ChaoticSeer MutateWith(ChaoticSeer partner) => _mutation.CrossOver(this, partner);
	}
}
