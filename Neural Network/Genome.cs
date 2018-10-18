using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    class Genome {
        public delegate void DecisionHandler (double[] motors);
        public event DecisionHandler Decision;
        public Genome (int sensoryCount, int motorCount) {

        }
    }
}
