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
    public enum NeuronTypes {
        Sensory = 1,    //Will soon add normalization feature
        Inter = 2,      //BP Related Logistic, or TanH
        Motor = 3       //BP Related Logistic, TanH, or Step
    }
    public class NeuronLayer{
        readonly public Neuron[] neurons;
        readonly public NeuronTypes neuronType;
        readonly public int InputCount;
        /// <summary>
        /// Creates a layer filled with neurons
        /// </summary>
        /// <param name="iCount">Input count</param>
        /// <param name="nCount"></param>
        public NeuronLayer (int iCount, int nCount) {
            neurons = new Neuron[nCount];
            InputCount = iCount;
            for (int i = 0; i < nCount; i++) {
                neurons[i] = new Neuron(iCount);
            }
        }
        /// <summary>
        /// Creates a layer filled with neurons
        /// </summary>
        /// <param name="iCount">Input count</param>
        /// <param name="nCount">Output count</param>
        /// <param name="aF">Activation function for this layer</param>
        public NeuronLayer (int iCount, int nCount,  ActivationFunctions aF = ActivationFunctions.Logistic) {
            neurons = new Neuron[nCount];
            InputCount = iCount;
            for (int i = 0; i < nCount; i++) {
                neurons[i] = new Neuron(iCount, aF);
            }
        }
    }
}
