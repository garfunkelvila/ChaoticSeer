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
using Chaotic_Seer.NEAT;
using Chaotic_Seer.Util;
using Seer.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Chaotic_Seer.NN {
	/// <summary>
	/// Use this for calculator
	/// </summary>
	static class NeuralNetwork {
		//static internal DataHashSet<ConnectionNeuron> Connections = new DataHashSet<ConnectionNeuron>();
		//static internal DataHashSet<NodeNeuron> Nodes = new DataHashSet<NodeNeuron>();

		/// <summary>
		/// Calculate output and return output
		/// </summary>
		/// <param name="genome"></param>
		public static float[] GetOutput(Genome genome, float[] inputs) {
			float[] pred = new float[Neat.Outputs];
			//ConnectionNeuron[] connections = genome.Connections.ToArray();
			/// ==========
			SensorNeuron[] sensorNeurons = new SensorNeuron[Neat.Inputs];
			InterNeuron[] hiddenNeurons = genome.InterNeuron.ToArray();
			/// ==========

			List<INode> calculatedNeurons = new List<INode>();

			DataHashSet<ConnectionNeuron> nextConnection = new DataHashSet<ConnectionNeuron>();
			DataHashSet<INode> nextNeurons = new DataHashSet<INode>(); // Buffer for virtual layer

			/// Load the input neurons and prepare the next neurons
			LoadInput();
			/// Calculate hidden neurons and load next neurons
			CalculateHidden();
			/// Calculate the output neurons
			CalculateOutput();

			// TODO: make connections a list so loop can be shorter each iterations
			// I think this will be faster even list is slower than array

			void LoadInput() {
				for (int i = 0; i < Neat.Inputs; i++) {
					genome.SensorNeurons[i].Axon = inputs[i];
					calculatedNeurons.Add(genome.SensorNeurons[i]);

					/// This could possibly the slowest process, Loop through all connections and then select it
					foreach (ConnectionNeuron connection in genome.Connections) {
						/// Find the connection with the current input neuron
						if (connection.In.Innovation == genome.SensorNeurons[i].Innovation) {
							nextConnection.Add(connection);
							nextNeurons.Add(connection.Out);
						}
					}
				}

				Debug.WriteLine(nextNeurons.Count());
			}
			void CalculateHidden() {
				if (genome.InterNeuron.Count == 0)
					return;
				/// Loop though layers
				do {
					/// Loop through neurons
					for (int i = 0; i < nextNeurons.Count; i++) {
						/// Skip the output
						if (nextNeurons[i].Type == NeuronTypes.Motor) {
							nextNeurons.RemoveAt(i);
							continue;
						}

						/// Skip if neuron is already calculated
						// I think i should also delete connection pointing to this one
						if (calculatedNeurons.Contains(nextNeurons[i])) {
							nextNeurons.Remove(nextNeurons[i]);
							continue;
						}

						InterNeuron thisNeuron = (InterNeuron)nextNeurons[i];
						float netAxon = 0;

						foreach (ConnectionNeuron connection in nextConnection) {
							if (connection.Out.Equals(nextNeurons[i])) {
								if (connection.In.GetType().Name == "InterNeuron") {
									InterNeuron temp = (InterNeuron)connection.In;
									netAxon += temp.Axon * connection.Weight;
								}
								else {
									SensorNeuron temp = (SensorNeuron)connection.In;
									netAxon += temp.Axon * connection.Weight;
								}
							}
						}
						//TODO: Add the next connections and neurons
						thisNeuron.NetAxon = netAxon;
						calculatedNeurons.Add(nextNeurons[i]);
					}
				} while (nextNeurons.Count() > 0);
			}
			void CalculateOutput() {
				for (int i = 0; i < genome.MotorNeurons.Count; i++) {
					float netAxon = 0;
					// This could possibly the slowest process, Loop through all connections and then select it
					foreach (ConnectionNeuron connection in genome.Connections) {
						if (connection.Out.Equals(genome.MotorNeurons[i])) {

							// This may not always be InterNeuron,
							// It can also be a sensor neuron
							if (connection.In.GetType().Name == "InterNeuron") {
								InterNeuron temp = (InterNeuron)connection.In;
								netAxon += temp.Axon * connection.Weight;
							}
							else {
								SensorNeuron temp = (SensorNeuron)connection.In;
								netAxon += temp.Axon * connection.Weight;
							}
						}
					}
					genome.MotorNeurons[i].NetAxon = netAxon;
					pred[i] = genome.MotorNeurons[i].Axon;
					calculatedNeurons.Add(genome.MotorNeurons[i]);
				}
			}
			
			// Debug.WriteLine("PRED: " + neurons[2].Axon);
			return pred;
		}

		/// <summary>
		/// Calculate output and evaluate fitness
		/// </summary>
		/// <param name="genome"></param>
		public static void Evaluate(Genome genome, TrainingData[] tds) {
			float[] answer;
			float _fitness = 0;

			foreach (TrainingData td in tds) {
				answer = GetOutput(genome, td.Inputs);
				for (int i = 0; i < td.Outputs.Length; i++) {
					_fitness += Rng.FloatingAnd(answer[i], td.Outputs[i]);
				}
			}
			genome.Fitness = _fitness;
			//Debug.WriteLine("Fit: " + _fitness);
		}
	}
}