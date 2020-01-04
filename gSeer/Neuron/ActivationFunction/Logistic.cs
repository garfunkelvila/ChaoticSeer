using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron.ActivationFunction {
    public class Logistic : Activation {
        /// <summary>
        /// Returns logistic function
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returns logistic function</returns>
        protected override float CalcAxon(float x) {
            return (float)(1 / (1 + Math.Exp(-x)));
        }
        /// <summary>
        /// Returnes derivative of Logistic
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes derivative of Logistic</returns>
        protected override float CalcDerv(float x) {
            //Not sure if this is correct
            float _logistic = new Logistic().CalcAxon(x);
            return _logistic * (1 - _logistic);
        }
    }
}
