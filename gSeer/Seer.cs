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
using gSeer.Back_Propagation;
using gSeer.Neuron;

namespace gSeer {
    public class Seer : Genetics {
        public float Fitness { get; set; }
        public NeuronLayerGroup NeuronLayerGroups { get; private set; }     /// I made it like this in preperation for CNS
        readonly BackPropagation _BackPropagation;

        /// <summary>
        /// This seer creates a fully connected network. If you want to create a custom one, you may want to use Neuron, NeuronLayer and NeuronLayergroup to create what you want
        /// </summary>
        /// <param name="inputCount"></param>
        /// <param name="outputCount"></param>
        /// <param name="numLayers"></param>
        /// <param name="mtBP">Use multi threading for back propagation?</param>
        public Seer (int inputCount, int outputCount, int numLayers = 1, bool mtBP = false) {
            _BackPropagation = SetThreadingMode(mtBP);

            NeuronLayer[] nL = new NeuronLayer[numLayers];
            /// If single layer
            if (numLayers == 1) {
                nL[0] = new NeuronLayer(inputCount, outputCount);
                NeuronLayerGroups = new NeuronLayerGroup(nL);
                return;
            }
            /// If multilayer
            int hn = (int)Math.Ceiling(outputCount * 1.1d); /// 1.1d to make the hidden layer a bit fat
            nL[0] = new NeuronLayer(inputCount, hn);        /// Add the first one
            for (int nli = 1; nli < numLayers - 1; nli++) { /// Skip the last
                nL[nli] = new NeuronLayer(hn, hn);
            }
            nL[numLayers - 1] = new NeuronLayer(hn, outputCount);   /// Add the last
            NeuronLayerGroups = new NeuronLayerGroup(nL);     /// add the layers to the group
        }
        /// <summary>
        /// This one should only be used on mutations
        /// </summary>
        /// <param name="neuronLayerGroup"></param>
        public Seer (NeuronLayerGroup neuronLayerGroup, bool mtBP = false) {
            NeuronLayerGroups = neuronLayerGroup;
        }
        public Seer (TSeer tseer, bool mtBP = false) {
			_BackPropagation = SetThreadingMode(mtBP);
			NeuronLayerGroups = new NeuronLayerGroup(tseer.neuronLayerGroup);
		}
        public float[] Predict (float[] Sensories) {
            return NeuronLayerGroups.Predict(Sensories);
            /// This thing is supposed to raise an event when finished. But instead, I just return the value xD
            /// Will add event feature soon
        }

        public void Train (TrainingData[] td, int iteration) {
            for (int i = 0; i < iteration; i++) {
                NeuronLayerGroups = _BackPropagation.BackPropagate(NeuronLayerGroups, td);
            }
        }

        public float[] GetError () {
            float[] _rBuffer = new float[NeuronLayerGroups.NeuronLayers[NeuronLayerGroups.NeuronLayers.Length - 1].Neurons.Length];
            for (int n = 0; n < NeuronLayerGroups.NeuronLayers[NeuronLayerGroups.NeuronLayers.Length - 1].Neurons.Length; n++) {
                _rBuffer[n] = NeuronLayerGroups.NeuronLayers[NeuronLayerGroups.NeuronLayers.Length - 1].Neurons[n].Error;
            }
            return _rBuffer;
        }

        /// <summary>
        /// This will be used for seer mutation
        /// </summary>
        /// <param name="seer"></param>
        /// <returns></returns>
        public Seer MutateWith (Seer seer) {
            return new Seer(Mutate(this.NeuronLayerGroups, seer.NeuronLayerGroups));
        }
        /// <summary>
        /// Relocate this thing somewhere else
        /// </summary>
        /// <param name="isMultiThreaded"></param>
        /// <returns></returns>
        private BackPropagation SetThreadingMode(bool isMultiThreaded = false) {
            if (isMultiThreaded)
                return new BpMultiThread();
            else
                return new BpSingleThread();
        }
    }
}
