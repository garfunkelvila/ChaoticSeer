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
    public class Neuron : Activations{
        public float[] Dendrites;
        public float[] Weights;
        public float Bias;
        public float Prediction;               //Used by BackPropagation
        public float netPrediction;            //Used by BackPropagation. They always call it z, I currently don't know why xD
        public float Error;                    //I think sooner i need to shadow copy most of these variables, instead of keepeng them here in neuron
        readonly public ActivationFunctions ActivationFunction; //I assume that when this thing is readonly, affected scripts will skip jump instructions except the one with random
        readonly public float LearningRate;    // This is for mutation too
        public Neuron (int dendritesCount,
                ActivationFunctions af = ActivationFunctions.Logistic) {
            Dendrites = new float[dendritesCount];
            Weights = new float[dendritesCount];
            for (int i = 0; i < dendritesCount; i++)
                Weights[i] = (float) r.NextDouble() * 2 - 1; //Will change range dependent into AF
            Bias = 1; //(float) r.NextDouble();
            ActivationFunction = af;
            LearningRate = (float) r.NextDouble();
        }
        public float Axon () {
            netPrediction = 0;
            for (int i = 0; i < Dendrites.Length; i++) {
                netPrediction += Dendrites[i] * Weights[i];
            }
            netPrediction += Bias;
            return calcAxon(netPrediction, ActivationFunction);
        }
    }
}
