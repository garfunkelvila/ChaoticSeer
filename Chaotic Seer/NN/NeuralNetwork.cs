using Chaotic_Seer.DataStructures;
using Chaotic_Seer.NEAT;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
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
		public static void GetOutput(Genome genome) {
		}

		/// <summary>
		/// Calculate output and evaluate fitness
		/// </summary>
		/// <param name="genome"></param>
		public static void Evaluate(Genome genome, TrainingData td) {
			ConnectionNeuron[] connections = genome.Connections.ToArray();
			NodeNeuron[] neurons = genome.Nodes.ToArray();

			List<NodeNeuron> calculatedNeurons = new List<NodeNeuron>();
			List<ConnectionNeuron> calculatedConnections = new List<ConnectionNeuron>();
			
			DataHashSet<ConnectionNeuron> nextConnection = new DataHashSet<ConnectionNeuron>();
			DataHashSet<NodeNeuron> nextNeurons = new DataHashSet<NodeNeuron>();

			// Load the input neurons and prepare the next neurons
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

			genome.Fitness = Rng.GetInt(100);
		}
	}
}
