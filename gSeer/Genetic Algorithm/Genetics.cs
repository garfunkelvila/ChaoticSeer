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

namespace gSeer {
    /// <summary>
    /// This class contains method for mutations and maybe others
    /// I did not expect this thing to get this messy. I havent tested this thing
    /// Codes are based on CodeBullet's tutoral, with my customizations
    /// </summary>
    public class Genetics {
        static Random r = new Random();
        #region Mutate
        #region NeuronLayer
        //--------------------------------------------------------------------------------
        //Neuron Layer
        //--------------------------------------------------------------------------------
        /// <summary>
        /// Mutuate the layer. First layer is the dominant layer. The default rate is 10%.
        /// </summary>
        /// <param name="neuronLayer">Layers to mutate</param>
        /// <param name="mutationRate"></param>
        /// <returns>Returns the result of the mutation as a NeuronLayer</returns>
        public NeuronLayer Mutate (NeuronLayer[] neuronLayer, float mutationRate = 0.01f) {
            #region CHECKING
#if DEBUG //Just checking thing even we know we just duplicate the template programatically
            bool notMatch = false;
            //Check if solo
            if (neuronLayer.Length == 1) throw new Exception("neuronLayer Cant be solo, use clone instead");
            
            foreach (NeuronLayer nL in neuronLayer) {
                //Check if neuron count per layer match don't math
                if (nL.neurons.Length != neuronLayer[0].neurons.Length) {
                    notMatch = true;
                    break;
                }
                //Check if dendrites on current neuronLayer matches to each neuron dendrites in the first layer
                foreach (Neuron n2 in nL.neurons) {
                    foreach (Neuron n in neuronLayer[0].neurons) {
                        if(n2.Dendrites.Length != n.Dendrites.Length) {
                            notMatch = true;
                            break;
                        }
                    }
                    if (notMatch) break;
                }
            }
            if (notMatch == true) throw new Exception("Layout doesn't match");
#endif
            #endregion
            Parallel.For(0, neuronLayer.Length, nL => {
                for (int n = 0; n < neuronLayer[nL].neurons.Length; n++) {
                    //Mutate bias
                    if (r.NextDouble() < mutationRate)
                        neuronLayer[0].neurons[n].Bias = neuronLayer[nL].neurons[n].Bias;
                    //Mutate weights
                    for (int w = 0; w < neuronLayer[0].neurons[n].Weights.Length; w++) {
                        if (r.NextDouble() < mutationRate)
                            neuronLayer[0].neurons[n].Weights[w] = neuronLayer[nL].neurons[n].Weights[w];
                    }
                }
            });
            return neuronLayer[0];
        }
        /// <summary>
        /// Mutate two layers
        /// </summary>
        /// <param name="neuronLayerX">First</param>
        /// <param name="neuronLayerY">Second</param>
        /// <param name="mutationRate">Rate of mutation</param>
        /// <returns>Returns the result of the mutation as a NeuronLayer</returns>
        public NeuronLayer Mutate (NeuronLayer neuronLayerX, NeuronLayer neuronLayerY, float mutationRate = 0.5f) {
            #region CHECKING
#if DEBUG 
            //Check if X and Y have thesame layout.
            //Lazyness kicked in, I will just make a mutation that supports unequal layout sooner
            if (neuronLayerX.neurons.Length != neuronLayerY.neurons.Length) throw new Exception("X and Y Should have thesame number of neurons.");
            //TODO: Allow mutation for unequal neuron
#endif
            #endregion
            Parallel.For(0, neuronLayerX.neurons.Length, new ParallelOptions { MaxDegreeOfParallelism = 16 }, n => {
                //Mutate bias
                if (r.NextDouble() < mutationRate)
                    neuronLayerX.neurons[n].Bias = neuronLayerY.neurons[n].Bias;
                //Mutate weights
                for (int w = 0; w < neuronLayerX.neurons[n].Weights.Length; w++) {
                    if (r.NextDouble() < mutationRate)
                        neuronLayerX.neurons[n].Weights[w] = neuronLayerY.neurons[n].Weights[w];
                }
            });
            return neuronLayerX;
        }
        #endregion
        #region LayerGroup
        //--------------------------------------------------------------------------------
        //Neuron Layer Group
        //--------------------------------------------------------------------------------
        public NeuronLayerGroup Mutate (NeuronLayerGroup[] neuronLayerGroup, float mutationRate = 0.01f) {
            #region CHECKING
#if DEBUG
            if (neuronLayerGroup.Length == 1) throw new Exception("Cant be solo, use clone instead");
#endif
            #endregion
            Parallel.For(0, neuronLayerGroup.Length, new ParallelOptions { MaxDegreeOfParallelism = 2 }, nlG => {
                for (int nL = 0; nL < neuronLayerGroup[nlG].NeuronLayers.Length; nL++) {
                    for (int n = 0; n < neuronLayerGroup[nlG].NeuronLayers[nL].neurons.Length; n++) {
                        if (r.NextDouble() < mutationRate)
                            neuronLayerGroup[0].NeuronLayers[nL].neurons[n].Bias = neuronLayerGroup[nlG].NeuronLayers[nL].neurons[n].Bias;
                        for (int w = 0; w < neuronLayerGroup[0].NeuronLayers[nL].neurons[n].Weights.Length; w++) {
                            neuronLayerGroup[0].NeuronLayers[nL].neurons[n].Weights[w] = neuronLayerGroup[nlG].NeuronLayers[nL].neurons[n].Weights[w];
                        }
                    }
                }
            });
            return neuronLayerGroup[0];
        }
        public NeuronLayerGroup Mutate (NeuronLayerGroup neuronLayerGroupX, NeuronLayerGroup neuronLayerGroupY, float mutationRate = 0.5f) {
#if DEBUG
            //if (neuronLayerGroupX.NeuronLayers.neurons.Length != neuronLayerY.neurons.Length) throw new Exception("X and Y Should have thesame number of neurons.");
            //TODO: Allow mutation for unequal neuron
#endif
            Parallel.For(0, neuronLayerGroupX.NeuronLayers.Length, new ParallelOptions { MaxDegreeOfParallelism = 2 }, nL => {
                for (int n = 0; n < neuronLayerGroupX.NeuronLayers[nL].neurons.Length; n++) {
                    if (r.NextDouble() < mutationRate) {
                        if (r.NextDouble() < mutationRate)
                            neuronLayerGroupX.NeuronLayers[nL].neurons[n].Bias = neuronLayerGroupY.NeuronLayers[nL].neurons[n].Bias;
                        for (int w = 0; w < neuronLayerGroupX.NeuronLayers[nL].neurons[n].Weights.Length; w++) {
                            neuronLayerGroupX.NeuronLayers[nL].neurons[n].Weights[w] = neuronLayerGroupY.NeuronLayers[nL].neurons[n].Weights[w];
                        }
                    }
                }
            });
            return neuronLayerGroupX;
        }
        #endregion
        #endregion
        #region Clone
        public NeuronLayer Clone (NeuronLayer neuronLayer) {
            //Literally just return itself, ensure that this is by value
            return neuronLayer;
        }
        public NeuronLayerGroup Clone (NeuronLayerGroup neuronLayerGroup) {
            //Literally just return itself, ensure that this is by value
            return neuronLayerGroup;
        }
        #endregion
        public void Epoch () {
            //TODO
        }
    }
}
