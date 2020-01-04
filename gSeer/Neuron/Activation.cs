using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron {
    public class Activation {
        protected virtual float CalcAxon(float x) {
            return 0;
        }
        protected virtual float CalcAxon(float x, float y) {
            return 0;
        }
        protected virtual float CalcDerv(float x) {
            return 0;
        }
        protected virtual float CalcDerv(float x, float y) {
            return 0;
        }
    }
}
