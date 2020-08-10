//  ChaoticSeer, a C# Artificial Neural Network Library
//  Copyright (C) 2020  Garfunkel Vila
//  
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 3 of the License, or any later version.
//  
//  This library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library. If not,
//  see<https://www.gnu.org/licenses/>.

using Chaotic_Seer.DataStructures;
using Chaotic_Seer.NN;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chaotic_Seer.NEAT {
	public class Genome {
		public float Fitness { get; set; }
		public int Age { get; private set; } = 0;
		public int Identity { get; set; } = Rng.GetInt(2147483647); // Now it seems it needs to be unique per specie
		public bool IsAlive { get; set; } = true; // Used for purging

		internal DataHashSet<ConnectionNeuron> Connections = new DataHashSet<ConnectionNeuron>();
		
		/// Crap, so i just mande two copies of this thing, what i want is those three are pointers to this one
		internal DataHashSet<INode> AllNeurons = new DataHashSet<INode>();
		internal DataHashSet<SensorNeuron> SensorNeurons = new DataHashSet<SensorNeuron>();
		internal DataHashSet<InterNeuron> InterNeuron = new DataHashSet<InterNeuron>();
		internal DataHashSet<MotorNeuron> MotorNeurons = new DataHashSet<MotorNeuron>();

		//INeuron[] neurons;
		//int[] inputIndexes = new int[NEAT.Inputs];
		//int[] outputIndexes = new int[NEAT.Outputs];

		internal Genome() {
			/// Copy the input and output nodes from neat
			for (int i = 0; i < Neat.Inputs; i++) {
				SensorNeurons.Add(new SensorNeuron(Neat.Nodes[i]));
			}
			for (int i = Neat.Inputs; i < Neat.Inputs + Neat.Outputs; i++) {
				MotorNeurons.Add(new MotorNeuron(Neat.Nodes[i]));
			}
		}
		internal Genome(DataHashSet<ConnectionGene> Connections) {
			/// Copy the input and output nodes from neat
			for (int i = 0; i < Neat.Inputs; i++) {
				SensorNeuron _new = new SensorNeuron(Neat.Nodes[i]);
				SensorNeurons.Add(_new);
				AllNeurons.Add(_new);
			}
			for (int i = Neat.Inputs; i < Neat.Inputs + Neat.Outputs; i++) {
				MotorNeuron _new = new MotorNeuron(Neat.Nodes[i]);
				MotorNeurons.Add(_new);
				AllNeurons.Add(_new);
			}

			/// Grab the connectons from neat, its innovation is their neat index
			for (int i = 0; i < Connections.Count; i++) {
				this.Connections.Add(new ConnectionNeuron(Connections[i], i));
			}
		}

		public void Mutate() {
			if(++Age >= Parameters.MaximumStagnation) {
				IsAlive = false;
				return;
			}
			/// Select a random connection to split from this Genome and request from neat for the new connection and
			AddNode();
			/// Select a random node from this genome, request a connection from neat and add it on this genome
			AddLink();
			/// Select a randome node then change its weight based on the pdf code copied from Marl.IO
			ShiftWeight();
						
			void AddNode() {
				// Check if genome has connections
				if (this.Connections.Count == 0) return;
				if (this.InterNeuron.Count >= Parameters.MaxNodes) return;

				// Select a random connection to split from this Genome
				ConnectionNeuron connection = Connections.Random;

				INode nodeIn = connection.In;
				INode nodeOut = connection.Out;

				int NewNodeInnovation = Neat.AddNodeGene();
				InterNeuron nodeMid = new InterNeuron(Neat.Nodes[NewNodeInnovation]);

				int NewInnovation1 = Neat.NewConnectionGene(nodeIn, nodeMid);
				ConnectionNeuron conIn = new ConnectionNeuron {
					In = nodeIn,
					Out = nodeMid,
					Weight = 1,
					Innovation = NewInnovation1
				};
				

				int NewInnovation2 = Neat.NewConnectionGene(nodeMid, nodeOut);
				ConnectionNeuron conOut = new ConnectionNeuron {
					In = nodeMid,
					Out = nodeOut,
					Weight = connection.Weight,
					Innovation = NewInnovation2
				};

				this.Connections.Add(conIn);
				this.InterNeuron.Add(nodeMid);
				this.Connections.Add(conOut);
				this.Connections.Remove(connection);  /// Equivalent to disabling the connection
			}
			void AddLink() {
				INode Neuron1 = AllNeurons.Random;
				INode Neuron2 = AllNeurons.Random;

				/// Prevent output to output or input to input
				if ((Neuron1.Type == NeuronTypes.Sensor && Neuron2.Type == NeuronTypes.Sensor) ||
					(Neuron1.Type == NeuronTypes.Motor && Neuron2.Type == NeuronTypes.Motor)) {
					return;
				}
				/// Swap positions if output neuron is a sensor
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

		[Obsolete("Mating is incomplete")]
		public Genome MateWith(Genome genome) {
			Genome g1 = this;
			Genome g2 = genome;
			// TODO: Averaging of weights
			// TODO: Same Fitness
			
			Genome child = new Genome();
			DataHashSet<ConnectionGene> g2Connections = new DataHashSet<ConnectionGene>();

			SwapCheck();
			LoadG2Connections();
			SameFitness();
			Crossover();

			return child;

			void SwapCheck() {
				// Make sure g1 is the higher fitness genome
				if (g2.Fitness > g1.Fitness) {
					Genome temp = g1;
					g1 = g2;
					g2 = temp;
				}
			}

			void LoadG2Connections() {
				foreach (ConnectionNeuron item in g2.Connections) {
					g2Connections.Add(new ConnectionGene(item));
				}
			}

			void SameFitness() {
				// UNTESTED
				if (g1.Fitness != g2.Fitness)
					return;
				// Basically this part is crossover for same fitness
				// This might kill the child because there is a 50/50 chance that a link wont be inherited
				// This thing also has too much rng
				DataHashSet<ConnectionNeuron> newConnections = new DataHashSet<ConnectionNeuron>();

				foreach (ConnectionNeuron item in g1.Connections) {
					newConnections.Add(new ConnectionNeuron(item));
				}

				foreach (ConnectionNeuron item in newConnections) {
					ConnectionNeuron con1 = new ConnectionNeuron(item);
					ConnectionNeuron con2 = null;
					if (newConnections.Contains(con1)) {
						con2 = newConnections[newConnections.IndexOf(con1)];
					}

					// If match, disjoint and excess is inherit randomly
					// else inherit from more fit
					if (con2 != null && Rng.GetBool()) {
						if (Rng.GetBool())
							child.Connections.Add(con2);
					}
					else {
						if (Rng.GetBool())
							child.Connections.Add(con1);
					}
				}
			}

			void Crossover() {
				for (int i = 0; i < g1.Connections.Count; i++) {
					int g1i = i;
					//int g2i = -1;   // -1 Represents null
					ConnectionGene g1Con = new ConnectionGene(g1.Connections[i]);

					// If g2 has same connection on g1
					// Assign the same connection on g2
					if (g2Connections.Contains(g1Con)) {
						int g2i = g2Connections.IndexOf(g1Con);
						child.Connections.Add(new ConnectionNeuron(g2.Connections[g2i]));
					}
					else {
						child.Connections.Add(new ConnectionNeuron(g1.Connections[g1i]));
					}

					//if (g2i >= 0 && Rng.GetRngB()) {
					//	child.Genes.Add(new ConnectionGeneW(g1.Genes[g1i]));
					//}
					//else {
					//	child.Genes.Add(new ConnectionGeneW(g2.Genes[g2i]));
					//}
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
			// I think it should return its identity
			return Identity;
		}
	}
}
