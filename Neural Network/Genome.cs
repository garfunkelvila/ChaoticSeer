using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Neural_Network {
    /// <summary>
    /// This setups the Layers
    /// This thing setups the layers and groups etc, I think this should be in CNS class (non-existing yet)
    /// </summary>
    class Genome {
        public delegate void DecisionHandler (double[] motors);
        public event DecisionHandler Decision;

        LayerGroup lg;

        public Genome (int sensoryCount, int motorCount) {
            //NeuronLayer nL = new NeuronLayer(16, sensoryCount);
            //lg = new LayerGroup(nL);
        }
        public void Sensory (double[] inputs) {
            lg.Inputs = inputs;
        }
    }
}
