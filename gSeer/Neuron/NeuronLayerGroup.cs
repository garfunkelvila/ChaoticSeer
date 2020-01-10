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

namespace gSeer.Neuron {
    public class NeuronLayerGroup{
        readonly public NeuronLayer[] NeuronLayers;
        public float[] Prediction { get; set; }
        #region Constructors
        /// <summary>
        /// Holds an array of Neuron layers and their connections
        /// </summary>
        /// <param name="nLayers">Neuron Layers</param>
        public NeuronLayerGroup (NeuronLayer[] nLayers) {
            NeuronLayers = nLayers;
        }
        #endregion
        /// <summary>
        /// Returns the prediction and also put it into its property
        /// </summary>
        /// <param name="Inputs">Input data</param>
        /// <returns>Returns the prediction of the group</returns>
        public float[] Predict (float[] Inputs) {
            float[] outputBuffer;
            // Feed the inputs to the input layer
            for (int n = 0; n < NeuronLayers[0].neurons.Length; n++) {
                for (int d = 0; d < NeuronLayers[0].neurons[n].Dendrites.Length; d++) {
                    NeuronLayers[0].neurons[n].Dendrites[d] = Inputs[d];
                }
            }
            // Cache the prediction for the input layer
            outputBuffer = new float[NeuronLayers[0].neurons.Length];
            for (int oB = 0; oB < outputBuffer.Length; oB++) {
                outputBuffer[oB] = NeuronLayers[0].neurons[oB].Axon();
            }

            // Return if it is just a single layer
            if (NeuronLayers.Length == 1) { 
                Prediction = outputBuffer;
                return outputBuffer;
            }
            // Loop through each next layer
            for (int nL = 1; nL < NeuronLayers.Length; nL++) {
                // Feed the current layer the prediction of last layer
                for (int n = 0; n < NeuronLayers[nL].neurons.Length; n++) {
                    for (int d = 0; d < NeuronLayers[nL].neurons[n].Dendrites.Length; d++) {
                        NeuronLayers[nL].neurons[n].Dendrites[d] = NeuronLayers[nL - 1].neurons[d].Prediction;
                    }
                }
                // Cache the prediction for the input layer
                for (int oB = 0; oB < NeuronLayers[nL].neurons.Length; oB++) {
                    NeuronLayers[nL].neurons[oB].Axon();
                }
            }
            outputBuffer = new float[NeuronLayers[NeuronLayers.Length - 1].neurons.Length];
            for (int n = 0; n < NeuronLayers[NeuronLayers.Length - 1].neurons.Length; n++) {
                outputBuffer[n] = NeuronLayers[NeuronLayers.Length - 1].neurons[n].Prediction;
            }
            Prediction = outputBuffer;
            //Add event soon
            return outputBuffer;
        }        
    }
}
