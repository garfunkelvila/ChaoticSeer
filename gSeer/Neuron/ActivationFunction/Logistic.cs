using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron.ActivationFunction {
    class Logistic : Activation {
        /// <summary>
        /// Returns logistic function
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returns logistic function</returns>
        public override float calcAxon(float x) {
            return (float)(1 / (1 + Math.Exp(-x)));
        }
    }
    class LogisticPrime : Activation {
        /// <summary>
        /// Returnes derivative of Logistic
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes derivative of Logistic</returns>
        public override float calcAxon(float x) {
            //Not sure if this is correct
            float _logistic = new Logistic().calcAxon(x);
            return _logistic * (1 - _logistic);
        }
    }
}
