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
    public class TSeer {
        public readonly T.NeuronLayerGroup neuronLayerGroup;
        public T.NeuronLayerGroup NeuronLayerGroups { get; private set; }

        /// <summary>
        /// Create a template based on given seer
        /// </summary>
        /// <param name="seer"></param>
        public TSeer(Seer seer) {
            NeuronLayerGroups = seer.NeuronLayerGroups.GetNeuronLayerGroup;
        }
    }
}
namespace gSeer.T {
    public class Neuron {
        int Dendrites { get; }  /// Neuron input
        public Neuron(int dendritesCount) {
            Dendrites = dendritesCount;
        }
    }
    public class NeuronLayer {
        public Neuron[] Neurons { get; }
        //public NeuronTypes NeuronType { get; }
        public int InputCount { get; }
        public NeuronLayer(int iCount, int nCount) {
            Neurons = new Neuron[nCount];
            InputCount = iCount;
            for (int i = 0; i < nCount; i++) {
                Neurons[i] = new T.Neuron(iCount);
            }
        }
    }
    public class NeuronLayerGroup {
        public readonly NeuronLayer[] neuronLayers;
        public NeuronLayerGroup(NeuronLayer[] neuronLayer) {
            neuronLayers = neuronLayer;
        }
    }
}
