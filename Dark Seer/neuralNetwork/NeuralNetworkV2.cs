using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Seer.neuralNetwork {
    //https://en.wikipedia.org/wiki/Artificial_neuron
    class Neuron {
        private static Random r = new Random();
        public enum ActivationFunction {
            BinaryStep = 0,
            Logistic = 1
        }
        double[] Dendrites { get; set; } //Input
        public double Axon() {
            double total = 0;
            float threshold;
            int i;
            
            return 0;
        } //Output
        public ActivationFunction Activation { get; set; }
        public Neuron (double[] dendrites) {
            Activation = ActivationFunction.Logistic;
            Dendrites = dendrites;
        }
        public double outputTest (double[] inputs) {
            double bias = 0;
            double total = 0;
            int i = 0;
            for (; i < inputs.Length; i++) {
                total += inputs[i];
            }
            switch (Activation) {
                case ActivationFunction.BinaryStep:
                    return bias < total ? 1 : 0;
                case ActivationFunction.Logistic:
                    return 1 / (1 + Math.Exp(-total / bias));
                default:
                    throw new Exception("An error occured");
            }
        }
    }
    class TLU {
        double threshold;
        double[] weights;
        
        
        double fire (double[] inputs) {
            int T = 0;
            for (int i = 0; i < inputs.Length; i++) {

            }
            return 0;
        }
    }
}
