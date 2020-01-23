//  gSeer, a C# Artificial Neural Network Library
//  Copyright (C) 2018  Garfunkel Vila
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Neuron;

namespace gSeer.Genetic_Algorithm {
	class MutationMT : Genetics {
		public override NeuronLayer Mutate(NeuronLayer neuronLayerX, NeuronLayer neuronLayerY, float mutationBias = 0.5F) {
			CheckNeuronLayerScheme(neuronLayerX, neuronLayerY);
			Parallel.For(0, neuronLayerX.Neurons.Length, new ParallelOptions { MaxDegreeOfParallelism = Util.Cores }, n => {
				neuronLayerX.Neurons[n].Bias =
					(neuronLayerX.Neurons[n].Bias * mutationBias) +
					(neuronLayerY.Neurons[n].Bias * Util.GetRngF());
				for (int w = 0; w < neuronLayerX.Neurons[n].Weights.Length; w++) {
					neuronLayerX.Neurons[n].Weights[w] =
						(neuronLayerX.Neurons[n].Weights[w] * mutationBias) +
						(neuronLayerY.Neurons[n].Weights[w] * Util.GetRngF());
				}
			});
			return neuronLayerX;
		}

		public override NeuronLayerGroup Mutate(NeuronLayerGroup[] neuronLayerGroup, float mutationBias = 0.01F) {
			CheckNeuronLayerGroupScheme(neuronLayerGroup);
			Parallel.For(0, neuronLayerGroup.Length, new ParallelOptions { MaxDegreeOfParallelism = Util.Cores }, nlG => {
				for (int nL = 0; nL < neuronLayerGroup[nlG].NeuronLayers.Length; nL++) {
					for (int n = 0; n < neuronLayerGroup[nlG].NeuronLayers[nL].Neurons.Length; n++) {
						neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Bias =
							(neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Bias * mutationBias) +
							(neuronLayerGroup[nlG].NeuronLayers[nL].Neurons[n].Bias * Util.GetRngF());
						for (int w = 0; w < neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Weights.Length; w++) {
							neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Weights[w] =
								(neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Weights[w] * mutationBias) +
								(neuronLayerGroup[nlG].NeuronLayers[nL].Neurons[n].Weights[w] * Util.GetRngF());
						}
					}
				}
			});
			return neuronLayerGroup[0];
		}

		public override NeuronLayerGroup Mutate(NeuronLayerGroup neuronLayerGroupX, NeuronLayerGroup neuronLayerGroupY, float mutationBias = 0.5F) {
			CheckNeuronLayerGroupScheme(neuronLayerGroupX, neuronLayerGroupY);
			/// TODO: Allow mutation for unequal neuron, also add warning
			Parallel.For(0, neuronLayerGroupX.NeuronLayers.Length, new ParallelOptions { MaxDegreeOfParallelism = Util.Cores }, nL => {
				for (int n = 0; n < neuronLayerGroupX.NeuronLayers[nL].Neurons.Length; n++) {
					/// I might use polymorphism here for the mutation algorithm
					neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Bias =
						(neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Bias * mutationBias) +
						(neuronLayerGroupY.NeuronLayers[nL].Neurons[n].Bias * Util.GetRngF());
					for (int w = 0; w < neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Weights.Length; w++) {
						neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Weights[w] =
							(neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Weights[w] * mutationBias) +
							(neuronLayerGroupY.NeuronLayers[nL].Neurons[n].Weights[w] * Util.GetRngF());
					}
				}
			});
			return neuronLayerGroupX;
		}
	}
}
