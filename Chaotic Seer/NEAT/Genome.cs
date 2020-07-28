using Chaotic_Seer.DataStructures;
using Chaotic_Seer.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.NEAT {
    public class Genome {
		public float Fitness { get; set; }

		internal DataHashSet<ConnectionNeuron> Genes = new DataHashSet<ConnectionNeuron>();
		internal DataHashSet<NodeGene> Nodes = new DataHashSet<NodeGene>();   // Should be a collections of neurons copied from neat

		//INeuron[] neurons;
		//int[] inputIndexes = new int[NEAT.Inputs];
		//int[] outputIndexes = new int[NEAT.Outputs];

		public Genome() {
		}

		public Genome(bool preMutate) {
		}

		/// <summary>
		/// Use speciation to compare
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj) {
			if (!GetType().Equals(obj.GetType())) return false;
			Genome g1 = this;
			Genome g2 = obj as Genome;

			Genome[] genomes = new Genome[2];
			genomes[0] = g1;
			genomes[1] = g2;

			DataHashSet<ConnectionGene> g1Connections = new DataHashSet<ConnectionGene>();
			DataHashSet<ConnectionGene> g2Connections = new DataHashSet<ConnectionGene>();
			// Make a local copy
			foreach (ConnectionNeuron connection in g1.Genes) {
				g1Connections.Add(new ConnectionGene(connection));
			}

			foreach (ConnectionNeuron connection in g2.Genes) {
				g2Connections.Add(new ConnectionGene(connection));
			}


			float de = excess();
			float dd = disjoint();
			float dw = weights();
			return (de + dd + dw) < Parameters.ct;

			float excess() {
				int counter = Math.Abs(g1.Genes.Count - g2.Genes.Count);
				return (Parameters.c1 * counter) / 1;
			}
			float disjoint() {
				int disjoints = 0;

				// Match
				for (int i = 0; i < g1.Genes.Count; i++) {
					if (g2Connections.Contains(g1Connections[i])) {
						disjoints++;
					}
				}

				for (int i = 0; i < g2.Genes.Count; i++) {
					if (g1Connections.Contains(g2Connections[i])) {
						disjoints++;
					}
				}

				return (Parameters.c2 * disjoints) / 1;
			}
			float weights() {
				int counter = 0;
				float gaw = 0;  // Gross average weight
				for (int g2i = 0; g2i < g2Connections.Count; g2i++) {
					// TODO: Check because since the Seer.Connection gene has weight. contains will return false
					// It should use the one on neat, as it has only from, to and innovation

					if (g1Connections.Contains(g2Connections[g2i])) {
						int g1i = g1Connections.IndexOf(g2Connections[g2i]);
						counter++;

						float g1W = g1.Genes[g1i].Weight;
						float g2W = g2.Genes[g2i].Weight;
						gaw += Math.Abs(g1W + g2W);
					}
				}

				if (counter == 0)
					return 0;

				return Parameters.c3 * (gaw / counter);
			}
		}

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
