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
            for (int n = 0; n < NeuronLayers[0].neurons.Length; n++) {
                for (int d = 0; d < NeuronLayers[0].neurons[n].Dendrites.Length; d++) {
                    NeuronLayers[0].neurons[n].Dendrites[d] = Inputs[d];
                }
            }
            outputBuffer = new float[NeuronLayers[0].neurons.Length];
            for (int oB = 0; oB < outputBuffer.Length; oB++) {
                outputBuffer[oB] = NeuronLayers[0].neurons[oB].Axon();
            }

            if (NeuronLayers.Length == 1) { //Return if there are no hidden lat
                Prediction = outputBuffer;
                return outputBuffer;
            }

            //Get outputs then feed into next layer
            for (int nL = 1; nL < NeuronLayers.Length; nL++) {
                Parallel.For(0, NeuronLayers[nL].neurons.Length, n => {
                    for (int d = 0; d < NeuronLayers[nL].neurons[n].Dendrites.Length; d++) {
                        NeuronLayers[nL].neurons[n].Dendrites[d] = outputBuffer[d];
                    }
                });
                outputBuffer = new float[NeuronLayers[nL].neurons.Length];
                //--------------------------------------------------------------------------
                for (int oB = 0; oB < outputBuffer.Length; oB++) {
                    outputBuffer[oB] = NeuronLayers[nL].neurons[oB].Axon();
                }
            }
            Prediction = outputBuffer;
            //Add event soon
            return outputBuffer;
        }        
    }
}
