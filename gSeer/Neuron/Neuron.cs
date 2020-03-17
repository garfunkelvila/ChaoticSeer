//  ChaoticSeer, a C# Artificial Neural Network Library
//  Copyright (C) 2020  Garfunkel Vila
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
using gSeer.ActivationFunctions;

namespace gSeer.Neuron {
    public class Neuron {
        public Activation ActivationFunction { get; }
        public float LearningRate { get; }
        public float[] Dendrites { get; set; }
        public float[] Weights { get; set; }
        public float Bias { get; set; }
        public float Prediction { get; private set; }
        public float NetPrediction { get; set; }
        public float Error { get; set; }
        /// <summary>
        /// Creates an instance of neuron. Currently BP only supports Logistic.
        /// </summary>
        /// <param name="dendritesCount">Input count</param>
        /// <param name="aF">Activation function to use</param>
        public Neuron (int dendritesCount, Activation aF = null) {
            Dendrites = new float[dendritesCount];
            Weights = new float[dendritesCount];
            for (int i = 0; i < dendritesCount; i++)
                Weights[i] = (float) Rng.GetRng() * -0.1f; //Will change range dependent into AF
            Bias = 1; //(float) rng.getRng();

            ActivationFunction = aF ?? new Logistic();
            LearningRate = (float)Rng.GetRng() * 0.05f;
        }
		/// <summary>
		/// Create a neuron based on a template
		/// </summary>
		/// <param name="neuron"></param>
		public Neuron (T.Neuron neuron, Activation aF = null) {
			int dendritesCount = neuron.Dendrites;

			Dendrites = new float[dendritesCount];
			Weights = new float[dendritesCount];
			for (int i = 0; i < dendritesCount; i++)
				Weights[i] = (float)Rng.GetRng() * -0.1f; /// Will change range dependent into AF
			Bias = 1; //(float) rng.getRng();

			ActivationFunction = aF ?? new Logistic();
			LearningRate = (float)Rng.GetRng() * 0.05f;
		}

        /// <summary>
        /// Returns the prediction of the neuron and also put it into its property
        /// </summary>
        /// <returns>Returns the prediction of the neuron</returns>
        public float Axon() {
            NetPrediction = 0;
            for (int i = 0; i < Dendrites.Length; i++) {
                NetPrediction += Dendrites[i] * Weights[i];
            }
            NetPrediction += Bias;

            Prediction = ActivationFunction.GetAxon(NetPrediction);// CalcAxon(netPrediction);
            return Prediction;
        }
        /// <summary>
        /// Attemp to move here teh back propagation so it will always use the same derivatives
        /// </summary>
        /// <returns></returns>
        public float AxonPrime() {
            return ActivationFunction.GetDerv(NetPrediction);
        }

        public T.Neuron GetTNeuron {
            get {
                return new T.Neuron(Dendrites.Length);
            }
        }
    }
}
