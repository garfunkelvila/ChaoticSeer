using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron {
    public class Activation {
        readonly public static Random r = new Random();
        public virtual float CalcAxon(float x) {
            return 0;
        }
        public virtual float CalcAxon(float x, float y) {
            return 0;
        }
        public virtual float CalcDerv(float x) {
            return 0;
        }
        public virtual float CalcDerv(float x, float y) {
            return 0;
        }
    }
}
