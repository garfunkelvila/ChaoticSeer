using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    class Neuron : Activations {
        public Neuron (
                int dendritesCount,
                ActivationFunctions af = ActivationFunctions.Sigmoid) {
            Dendrites = new double[dendritesCount];
            Weights = new double[dendritesCount];
            for (int i = 0; i < dendritesCount; i++)
                Weights[i] = r.NextDouble();
            Bias = r.Next(0, Dendrites.Length);
            ActivationFunction = af;
        }
        /// <summary>
        /// This thing is the pred part
        /// pred = sigmoid(z)
        /// z = (weight_1 * input_1) + (weight_2 * input_2) + (weight_3 * input_3) .......... and so on
        /// </summary>
        /// <returns>Returns the prediction</returns>
        public double Axon () {
#if DEBUG
#endif
            double buffer = 0;
            for (int i = 0; i < Dendrites.Length; i++) {
                buffer += Dendrites[i] * Weights[i];
            }
            buffer += Bias;
            return calcAxon(buffer, ActivationFunction);
        }
#region Properties
        public double[] Dendrites {get; set; }
        public double[] Weights { get; set; }
        public double Bias { get; set; }
        public ActivationFunctions ActivationFunction { get; }
#endregion
    }
}
