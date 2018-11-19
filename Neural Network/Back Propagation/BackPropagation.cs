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
    public class BackPropagation : Activations {
        //Output layer will soon changed into Motor layer, Because of CNS
        NeuronLayerGroup nlgBuffer; //This one is the thing being returned

        /// <summary>
        /// Learning thingy
        /// </summary>
        /// <param name="neuronLayerGroup"></param>
        /// <param name="trainingData"></param>
        /// <returns>Returned the back propagated NeuronLayerGroup</returns>
        public NeuronLayerGroup BackPropagate (NeuronLayerGroup neuronLayerGroup, TrainingData[] trainingData) {
            //TODO: Test all training data once
            nlgBuffer = neuronLayerGroup;
            int tDr = r.Next(0, trainingData.Length);
            outputLayerBP(neuronLayerGroup, trainingData[tDr]);
            //hiddenLayerBP(neuronLayerGroup);

            return this.nlgBuffer;
        }
        void outputLayerBP (NeuronLayerGroup nlg, TrainingData tD) {
            NeuronLayer neuronLayer = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1];        //Singe this is one thing, just cache the layer. I think neurons will be faster
            NeuronLayer bufferNeuronLayer = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1];

            nlg.Predict(tD.Input);  // Propagation forward through the network to generate the output value(s)

            // Calculation of the cost (error term)
            for (int n = 0; n < neuronLayer.neurons.Length; n++) {
                neuronLayer.neurons[n].Error = neuronLayer.neurons[n].Prediction - tD.Target[n];
            }
            //WEIGHT UPDATE FOR OUTPUT LAYER

            Parallel.For(0, neuronLayer.neurons.Length, n => {
                float lr = neuronLayer.neurons[n].LearningRate;
                float d_Cost;

                d_Cost = neuronLayer.neurons[n].Error * LogisticPrime(neuronLayer.neurons[n].netPrediction);
                bufferNeuronLayer.neurons[n].Bias += lr * d_Cost;

                for (int w = 0; w < neuronLayer.neurons[n].Weights.Length; w++) { //Weight loop
                    d_Cost = neuronLayer.neurons[n].Error * LogisticPrime(neuronLayer.neurons[n].netPrediction) * neuronLayer.neurons[n].Dendrites[w];
                    bufferNeuronLayer.neurons[n].Weights[w] += lr * d_Cost;
                }
            });
            nlgBuffer.NeuronLayers[nlg.NeuronLayers.Length- 1] = bufferNeuronLayer;
        }
        void hiddenLayerBP(NeuronLayerGroup nlg) {
            // nl   Neuron Layer Index
            // el   Last Layer Error
            // en   Last Layer Neuron Error
            for (int nl = nlg.NeuronLayers.Length - 2; nl > 0; nl--) {  //Start from second to last
                // Calculation of the cost (error term)
                for (int n = 0; n < nlg.NeuronLayers[nl].neurons.Length; n++) { //Current Layer Neuron loop
                    float sumBuffer = 0;
                    int el = nl + 1;

                    // (w1 / (w1 + w2)) + e
                    for (int en = 0; en < nlg.NeuronLayers[el].neurons.Length; en++) {  //Error Neurons. this thing gives the error value
                        //Error of output layer * connected weight
                        sumBuffer += nlg.NeuronLayers[el].neurons[en].Weights[n] * nlg.NeuronLayers[el].neurons[en].Error;
                    }
                    nlg.NeuronLayers[nl].neurons[n].Error = sumBuffer;
                }

                //WEIGHT UPDATE - There is somethign wrong in here
                for (int n = 0; n < nlg.NeuronLayers[nl].neurons.Length; n++) {
                    float nLearningRate = nlgBuffer.NeuronLayers[nl].neurons[n].LearningRate;
                    //float nCost;
                    float d_Cost;

                    //Multiply error from current layer to output? I am not sue if that is how chain rule works
                    /*for (int i = nl + 1; i < nlg.NeuronLayers.Length; i++) {
                        nCost = nlg.NeuronLayers[nl].neurons[n].Error;
                    }*/

                    //d_Cost = nlg.NeuronLayers[nl].neurons[n].Error * LogisticPrime(nlg.NeuronLayers[nl].neurons[n].netPrediction) * nlg.NeuronLayers[nl].neurons[n].Bias;
                    d_Cost = nlg.NeuronLayers[nl].neurons[n].Error * nlg.NeuronLayers[nl].neurons[n].Bias;
                    nlgBuffer.NeuronLayers[nl].neurons[n].Bias -= nlg.NeuronLayers[nl].neurons[n].LearningRate * d_Cost;

                    for (int w = 0; w < nlg.NeuronLayers[nl].neurons[n].Weights.Length; w++) { //Weight loop

                        //d_Cost = nlg.NeuronLayers[nl].neurons[n].Error * LogisticPrime(nlg.NeuronLayers[nl].neurons[n].netPrediction) * nlg.NeuronLayers[nl].neurons[n].Dendrites[w];
                        d_Cost = nlg.NeuronLayers[nl].neurons[n].Error * nlg.NeuronLayers[nl].neurons[n].Dendrites[w];

                        nlgBuffer.NeuronLayers[nl].neurons[n].Weights[w] -= nlg.NeuronLayers[nl].neurons[n].LearningRate * d_Cost;

                    }
                }
                //Parallel.For(0, nlg.NeuronLayers[nl].neurons.Length, n => { //Neuron loop
                    
                //});
            }
        }
    }
}
