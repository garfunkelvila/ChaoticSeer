using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron.ActivationFunction {
    class ReLU : Activation {
        /// <summary>
        /// Retuns a rectified linear unit
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="trigger">The starting point</param>
        /// <returns>Rectified linerar unit</returns>
        protected override float CalcAxon(float x, float trigger = 0.5f) {
            return x > trigger ? x : 0;
        }
    }
}
