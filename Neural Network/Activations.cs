using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    enum ActivationFunctions {
        Any = 0,
        Sigmoid = 1,
        ReLu = 2,
        Step = 3
    }
    abstract class Activations {
        public Random r = new Random();
        public double Sigmoid (double x) {
            return (1 / (1 + Math.Exp(-x)));
        }
        public virtual double Sigmoid (double x, double steepnes = 0.5, double maxValue = 1, double midPoint = 0.5f) {
#if DEBUG
            if (steepnes < 0) throw new Exception("Steepness cant be negative");
            if (maxValue < midPoint) throw new Exception("maxValue is lower than midPoint");
            if (midPoint < 0.5f) throw new Exception("midPoint just dont");
#endif
            return (maxValue / (1 + Math.Exp(-steepnes * (x - midPoint))));
        }
        /// <summary>
        /// This ReLU starts at 0.5
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double ReLU (double x) {
            return x > 0.5d ? x : 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Step (double x) {
            return x > 0.5d ? 1 : 0;
        }
        /// <summary>
        /// This one adds randomness.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="ActivationFunction"></param>
        /// <returns></returns>
        public double calcAxon (double x, ActivationFunctions ActivationFunction) {
            switch (ActivationFunction) {
                case ActivationFunctions.Any:
                    int af = r.Next(1, 3);
                    switch (af) {
                        case 1: return Sigmoid(x);
                        case 2: return ReLU(x);
                        case 3: return Step(x);
#if DEBUG 
                        default: throw new Exception("Please add the new AF here");
#endif

                    }
                case ActivationFunctions.Sigmoid: return Sigmoid(x);
                case ActivationFunctions.ReLu: return ReLU(x);
#if DEBUG
                default: throw new Exception("Activation function selection error occured");
#endif
            }
        }
    }

}
