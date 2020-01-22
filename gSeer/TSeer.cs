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
        public T.NeuronLayerGroup neuronLayerGroup;
        public TSeer(Seer seer) {
            
        }
    }
}
namespace gSeer.T {
    public class Neuron {
        readonly int Dendrites;
    }
    public class NeuronLayer {
        public readonly Neuron[] neurons;
        public NeuronLayer(Neuron[] neuron) {
            neurons = neuron;
        }
    }
    public class NeuronLayerGroup {
        public readonly NeuronLayer[] neuronLayers;
        public NeuronLayerGroup(NeuronLayer[] neuronLayer) {
            neuronLayers = neuronLayer;
        }
    }
}
