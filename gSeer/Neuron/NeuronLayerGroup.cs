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
            for (int n = 0; n < NeuronLayers[0].Neurons.Length; n++) {
                for (int d = 0; d < NeuronLayers[0].Neurons[n].Dendrites.Length; d++) {
                    NeuronLayers[0].Neurons[n].Dendrites[d] = Inputs[d];
                }
            }
            // Cache the prediction for the input layer
            outputBuffer = new float[NeuronLayers[0].Neurons.Length];
            for (int oB = 0; oB < outputBuffer.Length; oB++) {
                outputBuffer[oB] = NeuronLayers[0].Neurons[oB].Axon();
            }

            // Return if it is just a single layer
            if (NeuronLayers.Length == 1) { 
                Prediction = outputBuffer;
                return outputBuffer;
            }
            // Loop through each next layer
            for (int nL = 1; nL < NeuronLayers.Length; nL++) {
                // Feed the current layer the prediction of last layer
                for (int n = 0; n < NeuronLayers[nL].Neurons.Length; n++) {
                    for (int d = 0; d < NeuronLayers[nL].Neurons[n].Dendrites.Length; d++) {
                        NeuronLayers[nL].Neurons[n].Dendrites[d] = NeuronLayers[nL - 1].Neurons[d].Prediction;
                    }
                }
                // Cache the prediction for the input layer
                for (int oB = 0; oB < NeuronLayers[nL].Neurons.Length; oB++) {
                    NeuronLayers[nL].Neurons[oB].Axon();
                }
            }
            outputBuffer = new float[NeuronLayers[NeuronLayers.Length - 1].Neurons.Length];
            for (int n = 0; n < NeuronLayers[NeuronLayers.Length - 1].Neurons.Length; n++) {
                outputBuffer[n] = NeuronLayers[NeuronLayers.Length - 1].Neurons[n].Prediction;
            }
            Prediction = outputBuffer;
            //Add event soon
            return outputBuffer;
        } 
        
        public T.NeuronLayerGroup GetNeuronLayerGroup {
            get {
                T.NeuronLayer[] _neuronLayerGroup = new T.NeuronLayer[NeuronLayers.Length];
                for (int i = 0; i < NeuronLayers.Length; i++) {
                    _neuronLayerGroup[i] = NeuronLayers[i].GetNeuronLayer;
                }
                return new T.NeuronLayerGroup(_neuronLayerGroup);
            }
        }
    }
}
