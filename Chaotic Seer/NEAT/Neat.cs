using Chaotic_Seer.DataStructures;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chaotic_Seer.NEAT {
	public static class Neat {
		public static int Inputs = 2;
		public static int Outputs = 1;

		public static DataHashSet<Genome> Genomes { get; private set; } = new DataHashSet<Genome>();  // Entire Population
		public static RandomList<Specie> Species { get; private set; } = new RandomList<Specie>();
		internal static DataHashSet<ConnectionGene> Genes { get; private set; } = new DataHashSet<ConnectionGene>();
		internal static List<NodeGene> Nodes { get; private set; } = new List<NodeGene>();

		internal static int AddNodeGene() {
			NodeGene neuron = new NodeGene {
				Innovation = Nodes.Count
			};

			Nodes.Add(neuron);
			return Nodes.Count - 1;
		}

		internal static void AddGenomeToPopulation(Genome genome) {
			Genomes.Add(genome);

			bool foundSpecies = false;
			foreach (Specie specie in Species) {
				if (!foundSpecies && genome.Equals(specie.Representative)) {
					specie.AddGenome(genome);
					foundSpecies = true;
				}
			}

			if (!foundSpecies) {
				Specie newSpecie = new Specie();
				newSpecie.AddGenome(genome);
				newSpecie.Representative = genome;
				Species.Add(newSpecie);
			}
		}

		public static void Initialize() {
			Debug.WriteLine("Initializing NEAT");

			// ================================================================
			for (int i = 0; i < Inputs; i++) {
				int index = AddNodeGene();
				Nodes[index].Type = NeuronTypes.Sensor;
			}
			for (int i = 0; i < Outputs; i++) {
				int index = AddNodeGene();
				Nodes[index].Type = NeuronTypes.Motor;
			}
			Debug.WriteLine("NEAT IO Neurons Initialized");

			// ================================================================
			int Population = (int)(Parameters.PopulationSize * 0.8f);
			for (int i = 0; i < Population; i++) {
				Genome g = new Genome(true);
				AddGenomeToPopulation(g);
			}

			// ================================================================
			Debug.WriteLine(Genomes.Count + " Genomes initialized");
			Debug.WriteLine(Species.Count + " Species detected");

		}

		internal static int NewConnectionGene(INode In, INode Out) {
			ConnectionGene gene = new ConnectionGene {
				In = In,
				Out = Out
			};
			Genes.Add(gene);
			return Genes.IndexOf(gene);
		}

		public static void Mutate() {
			List<Genome> childrens = new List<Genome>();

			foreach (Specie specie in Species) {
				foreach (Genome genome in specie.genomes) {
					// Give rng for matinge

					genome.Mutate();

					//if (Genomes.Count + childrens.Count < Parameters.PopulationSize) {
					//	#region Reproduce Genomes
					//	Genome child;

					//	if (Species.Count > 1 && Parameters.InterspeciesMatingRate < Rng.GetFloat()) {
					//		RandomList<Specie> othersSpecies = new RandomList<Specie>();
					//		foreach (var _specie in Species) {
					//			if (specie != _specie)
					//				othersSpecies.Add(_specie);
					//		}
					//		child = genome.MateWith(othersSpecies.Random.genomes.Random);
					//	}
					//	else {
					//		child = genome.MateWith(specie.genomes.Random);
					//	}
					//	// THis genome is not initialized
					//	//childrens.Add(child);
					//	#endregion
					//}
				}
			}

			foreach (Genome child in childrens) {
				// AddToPopulation(child);
			}
		}
	}
}
