using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron {
    public abstract class Activation {
        protected abstract float CalcAxon(float x);
        protected abstract float CalcAxon(float x, float y);
        protected abstract float CalcDerv(float x);
        protected abstract float CalcDerv(float x, float y);
    }
}
