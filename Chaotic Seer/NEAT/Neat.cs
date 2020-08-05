using Chaotic_Seer.DataStructures;
using Chaotic_Seer.NN;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
				Specie newSpecie = new Specie(genome);
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
			Debug.WriteLine("Mutating...");
			List<Genome> childrens = new List<Genome>();

			foreach (Specie specie in Species) {
				foreach (Genome genome in specie.genomes) {
					genome.Mutate();

					if (Genomes.Count + childrens.Count < Parameters.PopulationSize) {
						#region Reproduce Genomes
						Genome child;

						// Interspecies Mating
						if (Species.Count > 1 && Parameters.InterspeciesMatingRate < Rng.GetFloat()) {
							RandomList<Specie> othersSpecies = new RandomList<Specie>();
							foreach (var _specie in Species) {
								if (specie != _specie)
									othersSpecies.Add(_specie);
							}
							child = genome.MateWith(othersSpecies.Random.genomes.Random);
						}
						else {
							child = genome.MateWith(specie.genomes.Random);
						}
						// THis genome is not initialized
						childrens.Add(child);
						#endregion
					}
				}
			}

			foreach (Genome child in childrens) {
				AddGenomeToPopulation(child);
			}
		}

		public static void Evaluate(TrainingData[] tds) {
			Debug.WriteLine("Evaluating...");
			foreach (Genome genome in Genomes) {
				foreach (TrainingData td in tds) {
					NeuralNetwork.Evaluate(genome, td);
				}
			}
			Debug.WriteLine("Evaluating... Done");
		}

		public static float[] GetOutput(float[] input) {
#if DEBUG
			if (input.Length != Inputs)
				throw new Exception("Input size is not same with neat input size");
#endif
			return NeuralNetwork.GetOutput(Genomes.Random, input);
		}

		public static void Purge() {
			// Thanos - I just realized that i cannot sort genomes

			// Create a function to safely remove a genome
			// Currently removing a genome will not remove it from species
			// This means that species and genomes has seperate copies
			// Genomes should be prioritized and species should only have reference or pointer

			// Loop[ through genomes, check if it is qualified to be deleted
			Thanos();
			ClearBodies();

			static void Thanos() {
				// Sorted genomes fittest on top
				Genome[] _genomes = Genomes.OrderBy(x => x.Fitness).Reverse().ToArray();
				int half = _genomes.Length / 2;

				// Wipe half
				for (int i = half; i < _genomes.Length; i++) {
					_genomes[i].IsAlive = false;
				}
			}

			static void ClearBodies() {
				// It is possible that the representative is selected and it will return null to next iteration

				int i,ii;
				// Remove from population
				i = Genomes.Count();
				do {
					i--;
					if (!Genomes[i].IsAlive)
						Genomes.RemoveAt(i);
				} while (i != 0);

				// Remove genome from Species
				i = Species.Count();
				do {
					i--;
					ii = Species[i].genomes.Count;

					do {
						ii--;

						if (!Species[i].genomes[ii].IsAlive) {
							int identity = Species[i].genomes[ii].Identity;
							Species[i].genomes.RemoveAt(ii);
							
							// If specie has empty genome, delete it and proceed to next specie
							if(Species[i].genomes.Count == 0) {
								Species.RemoveAt(i);
								goto Specie;
							}

							// If representative is dead, select a new one from current specie
							if(Species[i].Representative.Identity == identity) {
								Species[i].Representative = Species[i].genomes.Random;
							}
						}
					} while (ii != 0);
					Specie:;
				} while (i != 0);
			}
		}
	}
}
