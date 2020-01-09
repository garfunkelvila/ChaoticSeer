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

        public float GetAxon(float x) {
            return CalcAxon(x);
        }
        public float GetAxon(float x, float y) {
            return CalcAxon(x, y);
        }
        public float GetDerv(float x) {
            return GetAxon(x);
        }
        public float GetDerv(float x, float y) {
            return GetAxon(x, y);
        }
    }
}
