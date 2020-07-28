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
		internal static List<NodeGene> Neurons { get; private set; } = new List<NodeGene>();

		internal static int AddNodeGene() {
			NodeGene neuron = new NodeGene {
				Innovation = Neurons.Count
			};

			Neurons.Add(neuron);
			return Neurons.Count - 1;
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
				Neurons[index].Type = NeuronTypes.Sensor;
			}
			for (int i = 0; i < Outputs; i++) {
				int index = AddNodeGene();
				Neurons[index].Type = NeuronTypes.Motor;
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

		internal static int NewConnectionGene(NodeGene In, NodeGene Out) {
			ConnectionGene gene = new ConnectionGene {
				In = In,
				Out = Out
			};
			Genes.Add(gene);
			return Genes.IndexOf(gene);
		}
	}
}
