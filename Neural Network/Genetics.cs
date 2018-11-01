﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
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
                    if (r.NextDouble() < mutationRate) {
                        neuronLayer[0].neurons[n].Dendrites = neuronLayer[nL].neurons[n].Dendrites;
                        neuronLayer[0].neurons[n].Bias = neuronLayer[nL].neurons[n].Bias;
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
            Parallel.For(0, neuronLayerX.neurons.Length, n => {
                if (r.NextDouble() < mutationRate) {
                    neuronLayerX.neurons[n].Dendrites = neuronLayerY.neurons[n].Dendrites;
                    neuronLayerX.neurons[n].Bias = neuronLayerY.neurons[n].Bias;
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
#if DEBUG
            if (neuronLayerGroup.Length == 1) throw new Exception("Cant be solo, use clone instead");
#endif
            Parallel.For(0, neuronLayerGroup.Length, nlG => {
                for (int nL = 0; nL < neuronLayerGroup[nlG].NeuronLayers.Length; nL++) {
                    for (int n = 0; n < neuronLayerGroup[nlG].NeuronLayers[nL].neurons.Length; n++) {
                        neuronLayerGroup[0].NeuronLayers[nL].neurons[n].Dendrites = neuronLayerGroup[nlG].NeuronLayers[nL].neurons[n].Dendrites;
                        neuronLayerGroup[0].NeuronLayers[nL].neurons[n].Bias = neuronLayerGroup[nlG].NeuronLayers[nL].neurons[n].Bias;
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
            Parallel.For(0, neuronLayerGroupX.NeuronLayers.Length, nL => {
                for (int n = 0; n < neuronLayerGroupX.NeuronLayers[nL].neurons.Length; n++) {
                    if (r.NextDouble() < mutationRate) {
                        neuronLayerGroupX.NeuronLayers[nL].neurons[n].Dendrites = neuronLayerGroupY.NeuronLayers[nL].neurons[n].Dendrites;
                        neuronLayerGroupX.NeuronLayers[nL].neurons[n].Bias = neuronLayerGroupY.NeuronLayers[nL].neurons[n].Bias;
                    }
                }
            });
            return neuronLayerGroupX;
        }
        #endregion
        #endregion
        #region Clone
        public void Clone (NeuronLayer neuronLayer) {
            
        }
        public void Clone (NeuronLayerGroup neuronLayerGroup) {
            
        }
        #endregion
    }
}
