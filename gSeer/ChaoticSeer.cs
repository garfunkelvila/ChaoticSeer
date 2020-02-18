using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Genetic_Algorithm;
using gSeer.Data_Structures;
using System.Drawing;

namespace gSeer {
    /// <summary>
    /// Genome
	/// Attemp for seer to calculate for itself
    /// </summary>
    public class ChaoticSeer : IComparable<ChaoticSeer> {
		public int Identity { get; set; }
        public GeneHashSet<ConnectionGene> Connections { get; set; }
        public GeneHashSet<NodeGene> Nodes { get; set; }
		public float Fitness { get; set; }
		public int Age { get; set; }
		public NeatCNS Cns { get; private set; }
		/// Percentage of this genome to survive
		public readonly float SURVIVAL_THRESHOLD;// Narual selection dying
		public readonly int AGE_THRESHOLD;         // Natural dying

		public readonly int REPRODUCE_START_THRESHOLD;	// Age when reproduction is allowd
		public readonly int REPRODUCE_END_THRESHOLD;	// Age when reproduction is stopped
		public readonly int EVOLVE_START_THRESHOLD;		// Age when to start evolving
		public readonly int EVOLVE_END_THRESHOLD;		// Age when to stop evolving

		private static Mutation.Mutation _mutation;
		private static Forward_Propagation.ForwardPropagation _FPropagation;

		/// <summary>
		/// Create a Genome without neat template.
		/// 
		/// </summary>
		private ChaoticSeer() {
			SURVIVAL_THRESHOLD = 0.02f;
			AGE_THRESHOLD = 60; //Replace with random that averages to 60
			REPRODUCE_START_THRESHOLD = 12; // Replace with random that averages to 15
			REPRODUCE_END_THRESHOLD = 50; // Replace with random that averages to 45
			EVOLVE_START_THRESHOLD = 0;
			EVOLVE_END_THRESHOLD = 40;	// replace with random that averages to 45

			Connections = new GeneHashSet<ConnectionGene>();
            Nodes = new GeneHashSet<NodeGene>();
			_mutation = new Mutation.MutationST();
			Fitness = 0;
			Age = 0;
		}
        /// <summary>
        /// Create an emptygenome with only nodes wihtout connections based on a Neat
        /// </summary>
        /// <param name="Cns"></param>
        public ChaoticSeer(NeatCNS neat) : this() {
            Cns = neat;
            for (int i = 0; i < Cns.InputSize + Cns.OutputSize; i++) {
                Nodes.Add(Cns.AddNode(i + 1));
            }
        }
		public float[] GetPrediction(params float[] input) {
			_FPropagation = new Forward_Propagation.FPropagateST(this);
			return _FPropagation.Output(input);
		}
		public Bitmap GetBitmap() => Paint.GenBitmap(this);
        /// <summary>
        /// Calculate the gene distance between g1 and g2
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
            return (Cns.C1 * disjoint / N) + (Cns.C2 * excess / N) + (Cns.C3 * weightDiff);
        }
        public void Mutate() {
            if (NeatCNS.PROBABILITY_MUTATE_CONNECTION > Util.GetRngF())
                MutateConnection();
            if (NeatCNS.PROBABILITY_MUTATE_NODE > Util.GetRngF())
                MutateNode();
            if (NeatCNS.PROBABILITY_MUTATE_TOGGLE > Util.GetRngF())
                MutateToggleConnection();
            if (NeatCNS.PROBABILITY_MUTATE_WEIGHT_SHIFT > Util.GetRngF())
                MutateWeightShift();
            if (NeatCNS.PROBABILITY_MUTATE_WEIGHT_RANDOM > Util.GetRngF())
                MutateWeightRandom();
		}
        public void MutateConnection() => _mutation.MutateConnection(this);
		public void MutateNode() => _mutation.MutateNode(this);
		public void MutateWeightShift() => _mutation.MutateWeightShift(this);
		public void MutateWeightRandom() => _mutation.MutateWeightRandom(this);
		public void MutateToggleConnection() => _mutation.MutateToggleConnection(this);
		public ChaoticSeer MateWith(ChaoticSeer partner) => _mutation.CrossOver(this, partner);
		/// <summary>
		/// Larger score move first to the array
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(ChaoticSeer other) {
			if (Fitness > other.Fitness) return -1;
			if (Fitness < other.Fitness) return 1;
			return 0;
		}
	}
}
