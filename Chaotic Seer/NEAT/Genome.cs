﻿using Chaotic_Seer.DataStructures;
using Chaotic_Seer.NN;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chaotic_Seer.NEAT {
	public class Genome {
		public float Fitness { get; set; }

		internal DataHashSet<ConnectionNeuron> Connections = new DataHashSet<ConnectionNeuron>();
		internal DataHashSet<NodeNeuron> Nodes = new DataHashSet<NodeNeuron>();

		//INeuron[] neurons;
		//int[] inputIndexes = new int[NEAT.Inputs];
		//int[] outputIndexes = new int[NEAT.Outputs];

		public Genome(bool preMutate = false) {
			// Copy the nodes from Neat
			for (int i = 0; i < Neat.Nodes.Count; i++) {
				this.Nodes.Add(new NodeNeuron(Neat.Nodes[i]));
			}

			if (preMutate)
				Mutate();
		}

		public void Mutate() {
			// Select a random connection to split from this Genome and request from neat for the new connection and
			AddNode();
			// Select a random node from this genome, request a connection from neat and add it on this genome
			AddLink();
			// Select a randome node then change its weight based on the pdf code copied from Marl.IO
			ShiftWeight();
			FillNeurons();
						
			void AddNode() {
				// Check if genome has connections
				if (this.Connections.Count == 0) return;

				// Select a random connection to split from Genome
				ConnectionNeuron connection = this.Connections.Random;

				INode nodeIn = connection.In;
				INode nodeOut = connection.Out;

				int NewNodeInnovation = Neat.AddNodeGene();
				NodeGene nodeMid = Neat.Nodes[NewNodeInnovation];
				nodeMid.Type = NeuronTypes.Inter;


				int NewInnovation1 = Neat.NewConnectionGene(nodeIn, nodeMid);
				ConnectionNeuron conIn = new ConnectionNeuron {
					In = nodeIn,
					Out = nodeMid,
					Weight = 1,
					Innovation = NewInnovation1
				};
				this.Connections.Add(conIn);

				int NewInnovation2 = Neat.NewConnectionGene(nodeMid, nodeOut);
				ConnectionNeuron conOut = new ConnectionNeuron {
					In = nodeMid,
					Out = nodeOut,
					Weight = connection.Weight,
					Innovation = NewInnovation2
				};

				this.Connections.Add(conOut);
				this.Connections.Remove(connection);  // Equivalent to disabling the connection
			}
			void AddLink() {
				INode Neuron1 = this.Nodes.Random;
				INode Neuron2 = this.Nodes.Random;

				// Check if both neurons are input
				if ((Neuron1.Type == NeuronTypes.Sensor &&
					Neuron2.Type == NeuronTypes.Sensor) ||
					(Neuron1.Type == NeuronTypes.Motor &&
					Neuron2.Type == NeuronTypes.Motor)) {
					return;
				}
				// Swap positions if output neuron is a sensor
				if (Neuron2.Type == NeuronTypes.Sensor) {
					INode temp = Neuron1;
					Neuron1 = Neuron2;
					Neuron2 = temp;
				}

				int NewInnovation = Neat.NewConnectionGene(Neuron1, Neuron2);

				ConnectionNeuron newConnection = new ConnectionNeuron {
					In = Neuron1,
					Out = Neuron2,
					Innovation = NewInnovation
				};

				this.Connections.Add(newConnection);
			}
			void ShiftWeight() {
				float MaxRange = Parameters.WeightMutationRange;
				float PerturbChange = Parameters.WeightMutationProbability;
				for (int i = 0; i < this.Connections.Count; i++) {
					int connectionIndex = Rng.GetInt(Connections.Count);
					if (Rng.GetFloat() < PerturbChange) {
						Connections[connectionIndex].Weight +=
							(Rng.GetFloat() * MaxRange * 2) - MaxRange;
					}
					else {
						Connections[connectionIndex].Weight =
							(Rng.GetFloat() * 4) - 2;
					}
				}
			}
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
			foreach (ConnectionNeuron connection in g1.Connections) {
				g1Connections.Add(new ConnectionGene(connection));
			}

			foreach (ConnectionNeuron connection in g2.Connections) {
				g2Connections.Add(new ConnectionGene(connection));
			}


			float de = excess();
			float dd = disjoint();
			float dw = weights();
			return (de + dd + dw) < Parameters.ct;

			float excess() {
				int counter = Math.Abs(g1.Connections.Count - g2.Connections.Count);
				return (Parameters.c1 * counter) / 1;
			}
			float disjoint() {
				int disjoints = 0;

				// Match
				for (int i = 0; i < g1.Connections.Count; i++) {
					if (g2Connections.Contains(g1Connections[i])) {
						disjoints++;
					}
				}

				for (int i = 0; i < g2.Connections.Count; i++) {
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

						float g1W = g1.Connections[g1i].Weight;
						float g2W = g2.Connections[g2i].Weight;
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
