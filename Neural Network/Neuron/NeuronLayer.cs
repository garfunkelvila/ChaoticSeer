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
    //ISSUE when constructed in a Threading.Parallel.For it keeps giving -1 for weight or +1, not sure if its this fault or Nueron,
    //or it is because of activation not using static methods
    public enum NeuronTypes {
        Sensory = 1,    //Will soon add normalization feature
        Inter = 2,      //BP Related Logistic, or TanH
        Motor = 3       //BP Related Logistic, TanH, or Step
    }
    /// <summary>
    /// Neuron layer or Layer group (non-existing yet) should accept one or many double and poop one or many double
    /// </summary>
    public class NeuronLayer{
        readonly public Neuron[] neurons;
        readonly public NeuronTypes neuronType;
        readonly public int InputCount; //Used by BackPropagation
        public double[] Axons;

        /// <summary>
        /// Creates a layer filled with neurons
        /// </summary>
        /// <param name="nCount">Neuron count</param>
        /// <param name="iCount">Input count</param>
        public NeuronLayer (int iCount, int nCount) {
            neurons = new Neuron[nCount];
            InputCount = iCount;
            for (int i = 0; i < nCount; i++) {
                neurons[i] = new Neuron(iCount);
            }
        }
        public NeuronLayer (int iCount, int nCount,  NeuronTypes nType = NeuronTypes.Inter) {
            neurons = new Neuron[nCount];
            InputCount = iCount;
            for (int i = 0; i < nCount; i++) {
                neurons[i] = new Neuron(iCount);
            }
        }
        public NeuronLayer (int iCount, int nCount,  ActivationFunctions aF = ActivationFunctions.Logistic) {
            neurons = new Neuron[nCount];
            InputCount = iCount;
            for (int i = 0; i < nCount; i++) {
                neurons[i] = new Neuron(iCount, aF);
            }
        }
        /// <summary>
        /// This is to prevent recalculating of prediction
        /// </summary>
        /// <returns>Returns the prediction of the neurons</returns>
        public void CopyAxon() {
            double[] rBuffer = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++) {
                rBuffer[i] = neurons[i].Prediction;
            }
            Axons = rBuffer;
        }
    }
}
