//  Copyright (C) 2018  Garfunkel Vila
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    public class NeuronLayerGroup{
        readonly public NeuronLayer[] NeuronLayers;
        public float[] Prediction { get; set; }
        #region Constructors
        /// <summary>
        /// Holds an array of Neuron layers.
        /// </summary>
        /// <param name="nLayers"></param>
        public NeuronLayerGroup (NeuronLayer[] nLayers) {
            NeuronLayers = nLayers;
        }
        #endregion
        public float[] Predict (float[] Inputs) {
            float[] outputBuffer;

            // Feed the input to the input layer
            for (int n = 0; n < NeuronLayers[0].neurons.Length; n++) {
                for (int d = 0; d < NeuronLayers[0].neurons[n].Dendrites.Length; d++) {
                    NeuronLayers[0].neurons[n].Dendrites[d] = Inputs[d];
                }
            }
            
            // Fill the prediction for the input layer
            outputBuffer = new float[NeuronLayers[0].neurons.Length];
            for (int oB = 0; oB < outputBuffer.Length; oB++) {
                outputBuffer[oB] = NeuronLayers[0].neurons[oB].Axon();
            }

            // Return if there are no other layer
            if (NeuronLayers.Length == 1) { 
                Prediction = outputBuffer;
                return outputBuffer;
            }

            
            for (int nL = 1; nL < NeuronLayers.Length; nL++) {
                // Feed the current layer the prediction of last layer
                for (int n = 0; n < NeuronLayers[nL].neurons.Length; n++) {
                    for (int d = 0; d < NeuronLayers[nL].neurons[n].Dendrites.Length; d++) {
                        NeuronLayers[nL].neurons[n].Dendrites[d] = NeuronLayers[nL - 1].neurons[d].Prediction;
                    }

                }

                // Fill prediction of current layer
                //--------------------------------------------------------------------------
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
