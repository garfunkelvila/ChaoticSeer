using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Neuron {
    internal class Activation {
        public virtual float calcAxon(float x) {
#if DEBUG
            throw new Exception("This method should be overiden");
#endif
            return 0;
        }
        public virtual float calcAxon(float x, float y) {
#if DEBUG
            throw new Exception("This method should be overiden");
#endif
            return 0;
        }
    }
}
