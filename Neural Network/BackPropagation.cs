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
//THIS THING IS FROM A YOUTUBE CHANNEL
//https://www.youtube.com/watch?v=tIeHLnjs5U8&t
//I did not use the one on Kodigo
namespace Neural_Network {
    class BackPropagation : Activations {
        //Inputs: NeuronLayerGroup
        //Output: Update NLG it directly

        NeuronLayerGroup nlg;

        TrainingData[] Targets;
        TrainingData Target;

        double learning_rate = 0.2;
        int TrainIteration = 50000;

        double[] Costs (double[] Preditions) {
            //Using only 1 target with multiple values
            double[] _rBuffer = new double[Target.Targets.Length];
            for (int i = 0; i < Target.Targets.Length; i++) {
                _rBuffer[i] = Math.Pow(Preditions[i] - Target.Targets[i], 2);
            }
            return _rBuffer;
        }
        //Dericative of Cost with respect to Prediction
        double[] d_CostPred (double[] Preditions) {
            double[] _rBuffer = new double[Preditions.Length];
            for (int i = 0; i < Preditions.Length; i++) {
                _rBuffer[i] = 2 * (Preditions[i] - Target.Targets[i]);
            }
            return _rBuffer;
        }

        double d_Pred () {
            return 0;
        }

        //I don't know what to call this function
        //L3.weights[i] * L2.Axons[i] + L3.Biases[i]
        double[] d_Layer (int LayerIndex) {
            double[] _rBuffer = new double[nlg.NeuronLayers[LayerIndex].InputCount];

            //Single neuron for now
            //Axon should be the last value -- I think this will result to re calculation of axon from forward propagation
            for (int i = 0; i < _rBuffer.Length; i++) {
                _rBuffer[i] = 
                    nlg.NeuronLayers[LayerIndex].neurons[0].Weights[i] * 
                    nlg.NeuronLayers[LayerIndex - 1].neurons[0].cAxon *
                    nlg.NeuronLayers[LayerIndex].neurons[0].Bias;
            }

            return _rBuffer;
        }
        //Weight * Previews Activation + Bias
        

    }
}
