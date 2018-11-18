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
    class BackPropagation : Activations {
        //Output layer will soon changed into Motor layer, Because of CNS

        NeuronLayerGroup nlgBuffer; //This one is the thing being returned
        public double outputError (TrainingData trainingData, NeuronLayerGroup nlg) {
            double _rBuffer = 0;
            for (int i = 0; i < trainingData.Target.Length; i++) {
                _rBuffer += Math.Pow(trainingData.Target[i] - nlg.Prediction[i], 2);
            }
            return _rBuffer;
        }
        public double outputError (TrainingData[] trainingData, NeuronLayerGroup nlg) {
            double _rBuffer = 0;
            for (int td = 0; td < trainingData.Length; td++) {
                for (int i = 0; i < trainingData[td].Target.Length; i++) {
                    _rBuffer += Math.Pow(trainingData[td].Target[i] - nlg.Prediction[i], 2);
                }
            }
            return _rBuffer / trainingData.Count();
        }
        public NeuronLayerGroup BackPropagate (NeuronLayerGroup neuronLayerGroup, TrainingData[] trainingData) {
            outputLayerBP(neuronLayerGroup, trainingData);
            hiddenLayerBP(neuronLayerGroup);
            return this.nlgBuffer;
        }
        void outputLayerBP (NeuronLayerGroup nlg, TrainingData[] tD) {
            NeuronLayer neuronLayer = nlg.NeuronLayers[nlg.NeuronLayers.Length];        //Singe this is one thing, just cache the layer. I think neurons will be faster
            NeuronLayer bufferNeuronLayer = nlg.NeuronLayers[nlg.NeuronLayers.Length];
            //ERROR CALCULATION FOR OUTPUT LAYER
            for (int n = 0; n < neuronLayer.neurons.Length; n++) {
                float tdTotal = 0;
                for (int t = 0; t < tD.Length; t++) {
                    //Some square it, some don't, I don't get it. Maybe cost is being squared? I'll check some more forumlas and derivatives
                    tdTotal = (float) Math.Pow(neuronLayer.neurons[n].Prediction - tD[t].Target[n], 2);
                }
                neuronLayer.neurons[n].Error = tdTotal / tD.Length;    //Maybe precalculating all average is better
            }
            //WEIGHT UPDATE FOR OUTPUT LAYER
            for (int n = 0; n < neuronLayer.neurons.Length; n++) { //Neuron loop
                float nLearningRate = neuronLayer.neurons[n].LearningRate;
                float d_Cost = neuronLayer.neurons[n].Error * LogisticPrime(neuronLayer.neurons[n].netPrediction) * neuronLayer.neurons[n].Bias;
                bufferNeuronLayer.neurons[n].Bias -= nLearningRate * d_Cost;

                for (int w = 0; w < neuronLayer.neurons[n].Weights.Length; w++) { //Weight loop
                    d_Cost = neuronLayer.neurons[n].Error * LogisticPrime(neuronLayer.neurons[n].netPrediction) * neuronLayer.neurons[n].Dendrites[w];
                    bufferNeuronLayer.neurons[n].Weights[w] -= nLearningRate * d_Cost;
                }
            }
            nlgBuffer.NeuronLayers[nlg.NeuronLayers.Length] = bufferNeuronLayer;
        }
        void hiddenLayerBP(NeuronLayerGroup nlg) {
            for (int nl = nlg.NeuronLayers.Length - 1; nl > 0; nl--) {  //Start from second to last
                //ERROR CALCULATION FOR CURRENT LAYER
                for (int n = 0; n < nlg.NeuronLayers[nl].neurons.Length; n++) { //Current Layer Neuron loop
                    float sumBuffer = 0;
                    int el = nl + 1;

                    for (int en = 0; en < nlg.NeuronLayers[el].neurons.Length; en++) {  //Error Neurons. this thing gives the error value
                        sumBuffer += nlg.NeuronLayers[el].neurons[en].Weights[n] * nlg.NeuronLayers[el].neurons[en].Error;
                    }
                    nlg.NeuronLayers[nl].neurons[n].Error = sumBuffer;
                }

                //WEIGHT UPDATE
                Parallel.For(0, nlg.NeuronLayers[nl].neurons.Length, n => { //Neuron loop
                    float nLearningRate = nlgBuffer.NeuronLayers[nl].neurons[n].LearningRate;
                    float nCost;
                    float d_Cost;

                    //Multiply error from current layer to output? I am not sue if that is how chain rule works
                    for (int i = nl + 1; i < nlg.NeuronLayers.Length; i++) {
                        nCost = nlg.NeuronLayers[nl].neurons[n].Error;
                    }

                    d_Cost = nlg.NeuronLayers[nl].neurons[n].Error * LogisticPrime(nlg.NeuronLayers[nl].neurons[n].netPrediction) * nlg.NeuronLayers[nl].neurons[n].Bias;

                    nlgBuffer.NeuronLayers[nl].neurons[n].Bias -= nlg.NeuronLayers[nl].neurons[n].LearningRate * d_Cost;

                    for (int w = 0; w < nlg.NeuronLayers[nl].neurons[n].Weights.Length; w++) { //Weight loop

                        d_Cost = nlg.NeuronLayers[nl].neurons[n].Error * LogisticPrime(nlg.NeuronLayers[nl].neurons[n].netPrediction) * nlg.NeuronLayers[nl].neurons[n].Dendrites[w];

                        nlgBuffer.NeuronLayers[nl].neurons[n].Weights[w] -= nlg.NeuronLayers[nl].neurons[n].LearningRate * d_Cost;

                    }
                });
            }
            nlg = nlgBuffer;
            nlgBuffer = null;
        }
    }
}
