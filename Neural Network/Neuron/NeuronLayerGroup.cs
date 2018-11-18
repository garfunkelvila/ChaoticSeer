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
        public float[] Prediction;
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

            //Get outputs then feed into next layer
            for (int nL = 1; nL < NeuronLayers.Length; nL++) {
                //My first time xD this thing is slow for low count
                //https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallel.for?view=netframework-4.7.2#System_Threading_Tasks_Parallel_For_System_Int32_System_Int32_System_Action_System_Int32__
                Parallel.For(0, NeuronLayers[nL].neurons.Length, n => {
                    for (int d = 0; d < NeuronLayers[nL].neurons[n].Dendrites.Length; d++) {
                        NeuronLayers[nL].neurons[n].Dendrites[d] = outputBuffer[d];
                    }
                });
                outputBuffer = new float[NeuronLayers[nL].neurons.Length];
                //--------------------------------------------------------------------------
                Parallel.For(0, outputBuffer.Length, oB => {
                    outputBuffer[oB] = NeuronLayers[nL].neurons[oB].Axon();
                });
            }
            Prediction = outputBuffer;
            Parallel.ForEach(NeuronLayers, nl => {
                nl.CopyAxon();  //This one puts the axons into field
            });

            //Add event soon
            return outputBuffer;
        }
        /*public override int GetHashCode () {
            //Will be used to check if nlg have the same with other
        }*/
    }
}
