using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron.ActivationFunction {
    class TanH : Activation {
        /// <summary>
        /// Returnes hyperbolic tangent
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes hyperbolic tangent</returns>
        public override float CalcAxon(float x) {
            return (float)Math.Tanh(x);
        }
        /// <summary>
        /// Returnes derivative of HyperbolicTangent
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes derivative of HyperbolicTangent</returns>
        public override float AxonDerv(float x) {
            return (float)(1 / (Math.Cosh(x) * Math.Cosh(x)));
        }
    }
}
