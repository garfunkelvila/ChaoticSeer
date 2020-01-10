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
    class BpMultiThread : BackPropagation {
        public override void HiddenLayerBP(NeuronLayerGroup nlg) {
            for (int nl = nlg.NeuronLayers.Length - 2; nl >= 0; nl--) {  //Start from second to last
                int nLengh = nlg.NeuronLayers[nl].neurons.Length;
                Neuron.Neuron[] _cNeurons = nlg.NeuronLayers[nl].neurons;
                Neuron.Neuron[] _bNeurons = nlg.NeuronLayers[nl].neurons;

                /// Calculation of the cost (error term). Hidden cost.
                Parallel.For(0,nLengh, n=> {
                    float sumBuffer = 0;
                    Neuron.Neuron[] _oNeurons = nlg.NeuronLayers[nl + 1].neurons;

                    for (int en = 0; en < _oNeurons.Length; en++) {  // Last layer error loop
                        sumBuffer += _oNeurons[en].Weights[n] * _oNeurons[en].Error;    //Error of output layer * connected weight
                    }
                    _cNeurons[n].Error = sumBuffer;  //Give the error to the neurons on current layer
                });

                // WEIGHT UPDATE
                Parallel.For(0, nLengh, n => {
                    float nLearningRate = _cNeurons[n].LearningRate;
                    float d_Cost = 0;

                    d_Cost = _cNeurons[n].Error * _cNeurons[n].AxonPrime();
                    _cNeurons[n].Bias += nLearningRate * d_Cost;

                    for (int w = 0; w < _cNeurons[n].Weights.Length; w++) { //Weight loop
                        d_Cost = _cNeurons[n].Error * _cNeurons[n].AxonPrime();
                        _bNeurons[n].Weights[w] += nLearningRate * d_Cost * _cNeurons[n].Dendrites[w];
                    }
                });

                // COPY TO BUFFER
                for (int n = 0; n < _cNeurons.Length; n++) {
                    nlgBuffer.NeuronLayers[nl].neurons[n].Bias = _bNeurons[n].Bias;
                    nlgBuffer.NeuronLayers[nl].neurons[n].Weights = _bNeurons[n].Weights;
                }
            }
        }

        public override void outputLayerBP(NeuronLayerGroup nlg, TrainingData tD) {
            int nLengh = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons.Length;
            Neuron.Neuron[] _cNeurons = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons;        //Singe this is one thing, just cache the layer. I think neurons will be faster
            Neuron.Neuron[] _bNeurons = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons;

            nlg.Predict(tD.Input);  // Propagation forward through the network to generate the output value(s)

            /// Calculation of the cost (error term). Output cost for each output
            Parallel.For(0, nLengh, n => {
                _cNeurons[n].Error = tD.Target[n] - _cNeurons[n].Prediction;
            });

            /// WEIGHT UPDATE FOR OUTPUT BUFFER LAYER
            Parallel.For(0, nLengh, n => {
                float lr = _cNeurons[n].LearningRate;
                float d_Cost = 0;

                d_Cost = _cNeurons[n].Error * _cNeurons[n].AxonPrime();
                _bNeurons[n].Bias += lr * d_Cost;

                for (int w = 0; w < _cNeurons[n].Weights.Length; w++) { //Weight loop
                    d_Cost = _cNeurons[n].Error * _cNeurons[n].AxonPrime();
                    _bNeurons[n].Weights[w] += lr * d_Cost * _cNeurons[n].Dendrites[w];
                }
            });
            /// COPY TO BUFFER
            for (int n = 0; n < _cNeurons.Length; n++) {
                nlgBuffer.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons[n].Bias = _bNeurons[n].Bias;
                nlgBuffer.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons[n].Weights = _bNeurons[n].Weights;
            }
        }
    }
}
