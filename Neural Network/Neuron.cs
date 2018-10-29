using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    public class Neuron : Activations {
        public double[] Dendrites;
        public double[] Weights;
        public double Bias;
        public ActivationFunctions ActivationFunction;
        public Neuron (
                int dendritesCount,
                ActivationFunctions af = ActivationFunctions.TanH) {
            Dendrites = new double[dendritesCount];
            Weights = new double[dendritesCount];
            for (int i = 0; i < dendritesCount; i++)
                Weights[i] = r.NextDouble() * 2 - 1;
            Bias = r.NextDouble() * 2 - 1;
            ActivationFunction = af;
        }
        public double Axon () {
            double buffer = 0;
            for (int i = 0; i < Dendrites.Length; i++) {
                buffer += Dendrites[i] * Weights[i];
            }
            buffer += Bias;
            return Sigmoid(buffer);
        }
    }
}
