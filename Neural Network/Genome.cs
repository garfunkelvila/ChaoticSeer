using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    /// <summary>
    /// This setups the Layers
    /// </summary>
    class Genome {
        public delegate void DecisionHandler (double[] motors);
        public event DecisionHandler Decision;



        public Genome (int sensoryCount, int motorCount) {
            NeuronLayer nL = new NeuronLayer(8, sensoryCount);
            LayerGroup lg = new LayerGroup(nL);
        }
        public void Sensory () {
            
        }
    }
}
