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
using Chaotic_Seer.NN;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;

/// I might polymorph this, getOutput and evaluate
namespace Chaotic_Seer.BackPropagation {
	internal static class BackPropagation {
		public static void BackPropagate(Genome genome, TrainingData[] tds) {
			float[] pred = new float[Neat.Outputs];

			SensorNeuron[] sensorNeurons = genome.SensorNeurons.ToArray();
			InterNeuron[] interNeurons = genome.InterNeuron.ToArray();
			MotorNeuron[] motorNeurons = genome.MotorNeurons.ToArray();

			List<INode> loadedNeurons = new List<INode>();

			/// Attemp the other one, get all connections, find the one pointing the neuron as input
			// DataHashSet<ConnectionNeuron> nextConnection = new DataHashSet<ConnectionNeuron>();
			
			DataHashSet<INode> nextNeurons = new DataHashSet<INode>();

			List<NeuronLayer> neuronLayers = new List<NeuronLayer>(); // This is a copy, modifications here don't affect genome

			int tdSelected = 0;
			TrainingData td = tds[tdSelected];
			int layerCounter = 1;

			/// Load Outputs
			LoadInput(td);
			LoadHidden();
			LoadOutput();

			CalculateCost();

			OutputLayerBackPropagaiton();
			HiddenLayerBackPropagation();


			

			#region FeedForward
			void LoadInput(TrainingData td) {
				NeuronLayer InputLayer = new NeuronLayer();
				for (int i = 0; i < sensorNeurons.Length; i++) {
					sensorNeurons[i].NetAxon = td.Inputs[i];
					loadedNeurons.Add(sensorNeurons[i]);
					InputLayer.neurons.Add(new BpNeuron(sensorNeurons[i]));

					// This could possibly the slowest process, Loop through all connections and then selects it
					foreach (ConnectionNeuron connection in genome.Connections) {
						if (connection.In.Innovation == sensorNeurons[i].Innovation) {
							if(connection.Out.Type == NeuronTypes.Inter) {
								nextNeurons.Add((InterNeuron)connection.Out);
							}
							else {
								nextNeurons.Add((MotorNeuron)connection.Out);
							}							
						}
					}
				}
				neuronLayers.Add(InputLayer);
			}
			void LoadHidden() {
				DataHashSet<INode> aBuffer;				// Current loop
				DataHashSet<INode> bBuffer = nextNeurons;	// Next
				if (genome.InterNeuron.Count == 0)
					return;
				do {
					aBuffer = bBuffer;
					bBuffer = new DataHashSet<INode>();

                    NeuronLayer HiddenLayer = new NeuronLayer();
					for (int i = 0; i < aBuffer.Count; i++) {
						/// Skip the output for now
						if (aBuffer[i].Type == NeuronTypes.Motor) {
							continue;
						}
						/// Skip already loaded neurons
						if (loadedNeurons.Contains(aBuffer[i])) {
							continue;
						}

						InterNeuron thisNeuron = (InterNeuron)aBuffer[i];
						float netAxon = 0;

						foreach (ConnectionNeuron connection in genome.Connections) {
							/// Find the connection with nextneuron as its input
							if (aBuffer[i].Innovation == connection.In.Innovation) {
								/// THis connection is what we need to match
								if (connection.In.Type == NeuronTypes.Inter) {
									InterNeuron temp = (InterNeuron)connection.In;
									netAxon += temp.Axon * connection.Weight;
								}
								else if (connection.In.Type == NeuronTypes.Motor) {
									MotorNeuron temp = (MotorNeuron)connection.In;
									netAxon += temp.Axon * connection.Weight;
								}
								else {
									SensorNeuron temp = (SensorNeuron)connection.In;
									netAxon += temp.Axon * connection.Weight;
								}

								if (connection.Out.Type == NeuronTypes.Inter) {
									InterNeuron temp = (InterNeuron)connection.Out;
									bBuffer.Add(temp);
								}
							}
						}

						//TODO: Add the next connections and neurons
						thisNeuron.NetAxon = netAxon;
						loadedNeurons.Add(aBuffer[i]); /// Use nextNeuron to preserve original object type
						switch (aBuffer[i].Type) {
							/*case NeuronTypes.Sensor:
								HiddenLayer.neurons.Add(new BpNeuron((SensorNeuron)nextNeurons[i]));
								break;*/
							case NeuronTypes.Inter:
								HiddenLayer.neurons.Add(new BpNeuron((InterNeuron)aBuffer[i]));
								break;
							case NeuronTypes.Motor:
								HiddenLayer.neurons.Add(new BpNeuron((MotorNeuron)aBuffer[i]));
								break;
							default:
								throw new Exception("Queued neurons is not a valid BP neuron?");
						}
					}

					// Skip if added no neurons
					if (HiddenLayer.neurons.Count > 0) {
						neuronLayers.Add(HiddenLayer);
						layerCounter++;
					}						
				} while (bBuffer.Count() > 0);
			}
			void LoadOutput() {
				NeuronLayer OutputLayer = new NeuronLayer();
				for (int i = 0; i < genome.MotorNeurons.Count; i++) {
					float netAxon = 0;
					// This could possibly the slowest process, Loop through all connections and then select it
					foreach (ConnectionNeuron connection in genome.Connections) {
						if (connection.Out.Innovation == genome.MotorNeurons[i].Innovation) {
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
					motorNeurons[i].NetAxon = netAxon;	// NetAxon property also calculates the axon
					pred[i] = motorNeurons[i].Axon;
					loadedNeurons.Add(motorNeurons[i]);
					OutputLayer.neurons.Add(new BpNeuron(motorNeurons[i]));
				}
				neuronLayers.Add(OutputLayer);
			}
			#endregion
			
			void CalculateCost() {
				BpNeuron[] neurons = neuronLayers[neuronLayers.Count - 1].neurons.ToArray();
				td.Cost = 0;
				for (int i = 0; i < neurons.Length; i++) {
					td.Cost += (float)Math.Pow(pred[i] - td.Target[i], 2);
				}
				td.Cost /= neurons.Length;
			}

			/// Error propagation
			void OutputLayerBackPropagaiton() {
				BpNeuron[] neurons = neuronLayers[neuronLayers.Count - 1].neurons.ToArray();
				/// Update weights for each connections
				for (int i = 0; i < neurons.Length; i++) {
					/// No bias used for this version
					foreach (ConnectionNeuron gConnection in genome.Connections) {
						if(gConnection.Out.Innovation == neurons[i].Innovation) {
							float a = 2 * (neurons[i].Axon - td.Target[i]);
							float b = neurons[i].AxonPrime;
							float c = dendrite(gConnection.In);

							gConnection.Weight -= Parameters.LearningRate * (a * b * c);
						}
						break;
						float dendrite(INode node) {
							switch (node.Type) {
								case NeuronTypes.Sensor:
									return ((SensorNeuron)gConnection.In).Axon;
								case NeuronTypes.Inter:
									return ((InterNeuron)gConnection.In).Axon;
								default:
									throw new Exception("Unsuported neuron");
							}
						}
					}
				}
			}

			void HiddenLayerBackPropagation() {
				/// Loop through layers backward
				for (int layer = neuronLayers.Count - 2; layer >= 0; layer--) {
					BpNeuron[] neurons = neuronLayers[layer].neurons.ToArray();

					/// Loop through neurons
					for (int i = 0; i < neurons.Length; i++) {
						/// Loop through connections finding the neuron as input
						foreach (ConnectionNeuron gConnection in genome.Connections) {
							if (gConnection.Out.Innovation == neurons[i].Innovation) {
								float a = 0;
								float b = neurons[i].AxonPrime;
								float c = dendrite(gConnection.In);

								gConnection.Weight -= Parameters.LearningRate * (b * c);
							}
							break;
							float dendrite(INode node) {
								switch (node.Type) {
									case NeuronTypes.Sensor:
										return ((SensorNeuron)gConnection.In).Axon;
									case NeuronTypes.Inter:
										return ((InterNeuron)gConnection.In).Axon;
									default:
										throw new Exception("Unsuported neuron");
								}
							}
						}
					}
				}
			}
		}
	}	
}
