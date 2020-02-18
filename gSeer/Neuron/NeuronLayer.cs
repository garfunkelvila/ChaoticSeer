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

using gSeer.ActivationFunctions;
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
    public class NeuronLayer {
        public Neuron[] Neurons { get; }
        public NeuronTypes NeuronType { get; }
        public int InputCount { get; }
        /// <summary>
        /// Creates a layer filled with neurons
        /// </summary>
        /// <param name="iCount">Input count</param>
        /// <param name="nCount">Output count</param>
        /// <param name="aF">Activation function for this layer</param>
        public NeuronLayer(int iCount, int nCount, Activation aF = null) {
            Neurons = new Neuron[nCount];
            InputCount = iCount;
            for (int i = 0; i < nCount; i++) {
                Neurons[i] = new Neuron(iCount, aF);
            }
        }
		/// <summary>
		/// Create a NeuronLayer based on template
		/// </summary>
		/// <param name="neuronLayer"></param>
		public NeuronLayer (T.NeuronLayer neuronLayer) {
			int nCount = neuronLayer.Neurons.Length;
			int iCount = neuronLayer.InputCount;

			Neurons = new Neuron[nCount];
			InputCount = iCount;
			for (int i = 0; i < nCount; i++) {
				//Need to check if AF is passed correctly
				Neurons[i] = new Neuron(neuronLayer.Neurons[i], neuronLayer.Neurons[i]._activationFunction);
			}
		}

        public T.NeuronLayer GetTNeuronLayer {
            get {
                return new T.NeuronLayer(InputCount,Neurons.Length);
            }
        }
    }
}
