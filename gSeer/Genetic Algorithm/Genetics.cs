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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron {
    /// <summary>
    /// This class contains method for mutations and maybe others.
    /// I did not expect this thing to get this messy. I havent tested this thing.
    /// Codes are based on CodeBullet's tutoral, with my customizations.
    /// 
    /// Formula: (wX * mBias) + (wY * rng).
    /// </summary>
    public abstract class Genetics {
        /// <summary>
        /// Use this to mutate two layers
        /// </summary>
        /// <param name="neuronLayerX">First</param>
        /// <param name="neuronLayerY">Second</param>
        /// <param name="mutationBias">Rate of mutation</param>
        /// <returns>Returns the result of the mutation as a NeuronLayer</returns>
        protected NeuronLayer Mutate (NeuronLayer neuronLayerX, NeuronLayer neuronLayerY, float mutationBias = 0.5f) {
            CheckNeuronLayerScheme(neuronLayerX, neuronLayerY);

            Parallel.For(0, neuronLayerX.Neurons.Length, new ParallelOptions { MaxDegreeOfParallelism = 16 }, n => {
                neuronLayerX.Neurons[n].Bias =
                    (neuronLayerX.Neurons[n].Bias * mutationBias) +
                    (neuronLayerY.Neurons[n].Bias * rng.GetRngF());
                for (int w = 0; w < neuronLayerX.Neurons[n].Weights.Length; w++) {
                    neuronLayerX.Neurons[n].Weights[w] =
                        (neuronLayerX.Neurons[n].Weights[w] * mutationBias) +
                        (neuronLayerY.Neurons[n].Weights[w] * rng.GetRngF());
                }
            });
            return neuronLayerX;
        }
        /// <summary>
        /// Use this to mutate using neuron layer groups from different species where the first one is the dominante gene
        /// </summary>
        /// <param name="neuronLayerGroup"></param>
        /// <param name="mutationBias"></param>
        /// <returns></returns>
        protected NeuronLayerGroup Mutate (NeuronLayerGroup[] neuronLayerGroup, float mutationBias = 0.01f) {
            CheckNeuronLayerGroupScheme(neuronLayerGroup);
            Parallel.For(0, neuronLayerGroup.Length, new ParallelOptions { MaxDegreeOfParallelism = 2 }, nlG => {
                for (int nL = 0; nL < neuronLayerGroup[nlG].NeuronLayers.Length; nL++) {
                    for (int n = 0; n < neuronLayerGroup[nlG].NeuronLayers[nL].Neurons.Length; n++) {
                        neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Bias =
                            (neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Bias * mutationBias) +
                            (neuronLayerGroup[nlG].NeuronLayers[nL].Neurons[n].Bias * rng.GetRngF());
                        for (int w = 0; w < neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Weights.Length; w++) {
                            neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Weights[w] =
                                (neuronLayerGroup[0].NeuronLayers[nL].Neurons[n].Weights[w] * mutationBias) + 
                                (neuronLayerGroup[nlG].NeuronLayers[nL].Neurons[n].Weights[w] * rng.GetRngF());
                        }
                    }
                }
            });
            return neuronLayerGroup[0];
        }
        protected NeuronLayerGroup Mutate (NeuronLayerGroup neuronLayerGroupX, NeuronLayerGroup neuronLayerGroupY, float mutationBias = 0.5f) {
            CheckNeuronLayerGroupScheme(neuronLayerGroupX, neuronLayerGroupY);
            /// TODO: Allow mutation for unequal neuron, also add warning
            Parallel.For(0, neuronLayerGroupX.NeuronLayers.Length, new ParallelOptions { MaxDegreeOfParallelism = 2 }, nL => {
                for (int n = 0; n < neuronLayerGroupX.NeuronLayers[nL].Neurons.Length; n++) {
                    /// I might use polymorphism here for the mutation algorithm
                    neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Bias =
                        (neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Bias * mutationBias) +
                        (neuronLayerGroupY.NeuronLayers[nL].Neurons[n].Bias * rng.GetRngF());
                    for (int w = 0; w < neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Weights.Length; w++) {
                        neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Weights[w] =
                            (neuronLayerGroupX.NeuronLayers[nL].Neurons[n].Weights[w] * mutationBias) +
                            (neuronLayerGroupY.NeuronLayers[nL].Neurons[n].Weights[w] * rng.GetRngF());
                    }
                }
            });
            return neuronLayerGroupX;
        }

        /// Debug Functions
        [Conditional("DEBUG")]
        private void CheckNeuronLayerGroupScheme(NeuronLayerGroup neuronLayerGroupX, NeuronLayerGroup neuronLayerGroupY) {
            /// Check if layers match
            if (neuronLayerGroupX.NeuronLayers.Length != neuronLayerGroupY.NeuronLayers.Length)
                throw new Exception("X and Y Should have the same number of layers.");
            /// Match the number of neurons per layer
            for (int i = 0; i < neuronLayerGroupX.NeuronLayers.Length; i++) {
                if (neuronLayerGroupX.NeuronLayers[i].Neurons.Length != neuronLayerGroupY.NeuronLayers[i].Neurons.Length)
                    throw new Exception("X and Y Should have the same number of layers.");
            }
        }
        [Conditional("DEBUG")]
        private void CheckNeuronLayerScheme(NeuronLayer neuronLayerX, NeuronLayer neuronLayerY) {
            if (neuronLayerX.Neurons.Length != neuronLayerY.Neurons.Length) throw new Exception("X and Y Should have thesame number of neurons.");
        }
        [Conditional("DEBUG")]
        private void CheckNeuronLayerGroupScheme(NeuronLayerGroup[] neuronLayerGroup) {
            if (neuronLayerGroup.Length == 1) throw new Exception("Cant be solo, use clone instead");
        }
    }
}