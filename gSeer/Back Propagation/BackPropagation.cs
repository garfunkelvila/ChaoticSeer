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
    public class BackPropagation : Activation {
        // Gradient Descent
        // Learning_Rate = 0.05
        // Prediction = I * W + B
        // Error = Correct - Prediction
        // W += Error * I * Learning_Rate
        // B += Error * Learning_Rate

        //Output layer will soon changed into Motor layer, Because of CNS
        NeuronLayerGroup nlgBuffer; //This one is the thing being returned. SHould only consist of updated weights and biases

        /// <summary>
        /// Learning thingy
        /// </summary>
        /// <param name="neuronLayerGroup"></param>
        /// <param name="trainingData"></param>
        /// <returns>Returned the back propagated NeuronLayerGroup</returns>
        public NeuronLayerGroup BackPropagate (NeuronLayerGroup neuronLayerGroup, TrainingData[] trainingData) {
            nlgBuffer = neuronLayerGroup;
            int tDr = r.Next(0, trainingData.Length);
            outputLayerBP(neuronLayerGroup, trainingData[tDr]);
            hiddenLayerBP(neuronLayerGroup);
            return this.nlgBuffer;
        }
        /// <summary>
        /// Back propagates the output layer
        /// </summary>
        /// <param name="nlg">Input NeuronLayerGroup</param>
        /// <param name="tD">Training data</param>
        void outputLayerBP (NeuronLayerGroup nlg, TrainingData tD) {
            int nLengh = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons.Length;
            Neuron[] _cNeurons = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons;        //Singe this is one thing, just cache the layer. I think neurons will be faster
            Neuron[] _bNeurons = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons;

            nlg.Predict(tD.Input);  // Propagation forward through the network to generate the output value(s)

            // Calculation of the cost (error term). Output cost for each output
            for (int n = 0; n < nLengh; n++) {
                _cNeurons[n].Error = tD.Target[n] - _cNeurons[n].Prediction;
            }

            //WEIGHT UPDATE FOR OUTPUT BUFFER LAYER
            for (int n = 0; n < _cNeurons.Length; n++) {
                float lr = _cNeurons[n].LearningRate;
                float d_Cost = 0;
                
                d_Cost = _cNeurons[n].Error * _cNeurons[n].AxonPrime();
                _bNeurons[n].Bias += lr * d_Cost;

                for (int w = 0; w < _cNeurons[n].Weights.Length; w++) { //Weight loop
                    d_Cost = _cNeurons[n].Error * _cNeurons[n].AxonPrime();
                    _bNeurons[n].Weights[w] += lr * d_Cost * _cNeurons[n].Dendrites[w];
                }
            }
            // COPY TO BUFFER
            for (int n = 0; n < _cNeurons.Length; n++) {
                nlgBuffer.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons[n].Bias = _bNeurons[n].Bias;
                nlgBuffer.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons[n].Weights = _bNeurons[n].Weights;
            }            
        }
        /// <summary>
        /// Backpropagates the hidden layer
        /// </summary>
        /// <param name="nlg">Input NeuronLayerGroup</param>
        void hiddenLayerBP(NeuronLayerGroup nlg) {
            for (int nl = nlg.NeuronLayers.Length - 2; nl >= 0; nl--) {  //Start from second to last
                int nLengh = nlg.NeuronLayers[nl].neurons.Length;
                Neuron[] _cNeurons = nlg.NeuronLayers[nl].neurons;
                Neuron[] _bNeurons = nlg.NeuronLayers[nl].neurons;


                // Calculation of the cost (error term). Hidden cost.
                for (int n = 0; n < nLengh; n++) { //Current Layer Neuron loop
                    float sumBuffer = 0;
                    Neuron[] _oNeurons = nlg.NeuronLayers[nl + 1].neurons;


                    for (int en = 0; en < _oNeurons.Length; en++) {  // Last layer error loop
                        sumBuffer += _oNeurons[en].Weights[n] * _oNeurons[en].Error;    //Error of output layer * connected weight
                    }
                    _cNeurons[n].Error = sumBuffer;  //Give the error to current layer
                }

                // WEIGHT UPDATE
                for (int n = 0; n < nLengh; n++) {
                    float nLearningRate = _cNeurons[n].LearningRate;
                    float d_Cost = 0;

                    d_Cost = _cNeurons[n].Error * _cNeurons[n].AxonPrime();
                    _cNeurons[n].Bias += nLearningRate * d_Cost;

                    for (int w = 0; w < _cNeurons[n].Weights.Length; w++) { //Weight loop
                        d_Cost = _cNeurons[n].Error * _cNeurons[n].AxonPrime();
                        _bNeurons[n].Weights[w] += nLearningRate * d_Cost * _cNeurons[n].Dendrites[w];
                    }
                }
                // COPY TO BUFFER
                for (int n = 0; n < _cNeurons.Length; n++) {
                    nlgBuffer.NeuronLayers[nl].neurons[n].Bias = _bNeurons[n].Bias;
                    nlgBuffer.NeuronLayers[nl].neurons[n].Weights = _bNeurons[n].Weights;
                }
            }
        }
    }
}
