using Chaotic_Seer.DataStructures;
using Chaotic_Seer.NEAT;
using Chaotic_Seer.Util;
using Seer.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Chaotic_Seer.NN {
	/// <summary>
	/// Use this for calculator
	/// </summary>
	static class NeuralNetwork {
		//static internal DataHashSet<ConnectionNeuron> Connections = new DataHashSet<ConnectionNeuron>();
		//static internal DataHashSet<NodeNeuron> Nodes = new DataHashSet<NodeNeuron>();
		static ActivationFunction af = new Logistic();

		/// <summary>
		/// Calculate output and return output
		/// </summary>
		/// <param name="genome"></param>
		public static float[] GetOutput(Genome genome, TrainingData td) {
			float[] pred = new float[Neat.Outputs];
			ConnectionNeuron[] connections = genome.Connections.ToArray();
			NodeNeuron[] neurons = genome.Nodes.ToArray();

			List<NodeNeuron> calculatedNeurons = new List<NodeNeuron>();

			DataHashSet<ConnectionNeuron> nextConnection = new DataHashSet<ConnectionNeuron>();
			DataHashSet<NodeNeuron> nextNeurons = new DataHashSet<NodeNeuron>();

			// Load the input neurons and prepare the next neurons
			LoadInput();
			// Calculate hidden neurons and load next neurons
			CalculateHidden();
			// Calculate the output neurons
			CalculateOutput();

			void LoadInput() {
				for (int i = 0; i < Neat.Inputs; i++) {
					neurons[i].Axon = td.Input[i];
					calculatedNeurons.Add(neurons[i]);

					// This could possibly the slowest process, Loop through all connections and then select it
					foreach (ConnectionNeuron connection in connections) {
						if (connection.In.Equals(neurons[i])) { // This could possibly the slowest process
							nextConnection.Add(connection);
							nextNeurons.Add((NodeNeuron)connection.Out);
						}
					}
				}
			}
			void CalculateHidden() {
				do {
					for (int i = 0; i < nextNeurons.Count; i++) {
						// Skip the output for now
						if (nextNeurons[i].Type == NeuronTypes.Motor) {
							nextNeurons.Remove(nextNeurons[i]);
							continue;
						}

						if (calculatedNeurons.Contains(nextNeurons[i])) {
							nextNeurons.Remove(nextNeurons[i]);
							continue;
						}

						float netAxon = 0;

						foreach (ConnectionNeuron connection in nextConnection) {
							if (connection.Out.Equals(nextNeurons[i])) {
								NodeNeuron temp = (NodeNeuron)connection.In;
								netAxon += temp.Axon * connection.Weight;
							}
						}

						//TODO: Add the next connections and neurons
						nextNeurons[i].Axon = af.GetAxon(netAxon);
						calculatedNeurons.Add(nextNeurons[i]);
					}
				} while (nextNeurons.Count() > 0);
			}
			void CalculateOutput() {
				for (int i = Neat.Inputs; i < Neat.Outputs + Neat.Inputs; i++) {
					float netAxon = 0;
					// This could possibly the slowest process, Loop through all connections and then select it
					foreach (ConnectionNeuron connection in connections) {
						if (connection.Out.Equals(neurons[i])) {
							NodeNeuron temp = (NodeNeuron)connection.In;
							netAxon += temp.Axon * connection.Weight;
						}
					}
					neurons[i].Axon = af.GetAxon(netAxon);
					pred[i - Neat.Inputs] = neurons[i].Axon;
					calculatedNeurons.Add(neurons[i]);
				}
			}
			
			// Debug.WriteLine("PRED: " + neurons[2].Axon);
			return pred;
		}

		/// <summary>
		/// Calculate output and evaluate fitness
		/// </summary>
		/// <param name="genome"></param>
		public static void Evaluate(Genome genome, TrainingData td) {
			float[] answer;
			float _fitness = 0;
			answer = GetOutput(genome, td);
            for (int i = 0; i < td.Output.Length; i++) {
				_fitness += Rng.FloatingAnd(answer[i], td.Output[i]);
			}
			genome.Fitness = _fitness;
			//Debug.WriteLine("Fit: " + _fitness);
		}
	}
}
