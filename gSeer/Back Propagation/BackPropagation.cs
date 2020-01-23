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

using gSeer.Neuron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Back_Propagation {
    abstract class BackPropagation {
        protected NeuronLayerGroup nlgBuffer;
        /// Try to polymorph the back propagation for multithreading
        public abstract void outputLayerBP(NeuronLayerGroup nlg, TrainingData tD);
        public abstract void HiddenLayerBP(NeuronLayerGroup nlg);
        public NeuronLayerGroup BackPropagate(NeuronLayerGroup neuronLayerGroup, TrainingData[] trainingData) {
            nlgBuffer = neuronLayerGroup;
            int tDr = Rng.GetRngMinMax(0, trainingData.Length);
            outputLayerBP(neuronLayerGroup, trainingData[tDr]);
            HiddenLayerBP(neuronLayerGroup);
            return this.nlgBuffer;
        }
    }
}
