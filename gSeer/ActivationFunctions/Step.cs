using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.ActivationFunctions {
    public class Step : Activation {
        /// <summary>
        /// Returns a Step or 0 and 1
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="trigger">Threshold</param>
        /// <returns>Either 0 or 1</returns>
        protected override float CalcAxon(float x, float trigger = 0.5f) {
            return x > trigger ? 1 : 0;
        }

        protected override float CalcAxon(float x) {
            throw new NotImplementedException();
        }

        protected override float CalcDerv(float x) {
            throw new NotImplementedException();
        }

        protected override float CalcDerv(float x, float y) {
            throw new NotImplementedException();
        }
    }
}
