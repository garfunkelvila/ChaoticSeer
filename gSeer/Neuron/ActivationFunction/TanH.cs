using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron.ActivationFunction {
    public class TanH : Activation {
        /// <summary>
        /// Returnes hyperbolic tangent
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes hyperbolic tangent</returns>
        protected override float CalcAxon(float x) {
            return (float)Math.Tanh(x);
        }

        protected override float CalcAxon(float x, float y) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returnes derivative of HyperbolicTangent
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes derivative of HyperbolicTangent</returns>
        protected override float CalcDerv(float x) {
            return (float)(1 / (Math.Cosh(x) * Math.Cosh(x)));
        }

        protected override float CalcDerv(float x, float y) {
            throw new NotImplementedException();
        }
    }
}
