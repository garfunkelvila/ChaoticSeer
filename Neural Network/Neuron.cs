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
        public double[] Dendrites;
        public double[] Weights;
        public double Bias;
        public double cAxon; //Used by BackPropagation
        readonly public ActivationFunctions ActivationFunction;
        public Neuron (
                int dendritesCount,
                ActivationFunctions af = ActivationFunctions.TanH) {
            Dendrites = new double[dendritesCount];
            Weights = new double[dendritesCount];
            for (int i = 0; i < dendritesCount; i++)
                Weights[i] = r.NextDouble() * 1 - 1;
            Bias = r.NextDouble() * 2 - 1;
            ActivationFunction = af;
        }
        public double Axon () {
            double buffer = 0;
            for (int i = 0; i < Dendrites.Length; i++) {
                buffer += Dendrites[i] * Weights[i];
            }
            buffer += Bias;
            return calcAxon(buffer, ActivationFunction);
        }
    }
}
