using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    //LayerGroup should be able to connect with a layer group with same output:input
    //
    class LayerGroup {
        public delegate void OutputHandler (double[] motors);
        public event OutputHandler Decision;
        #region Constructors
        /// <summary>
        /// Holds an array of Neuron layers.
        /// </summary>
        /// <param name="nLayers"></param>
        public LayerGroup (NeuronLayer[] nLayers) {
            NeuronLayers = nLayers;
        }
        /// <summary>
        /// Holds a Neuron layer.
        /// </summary>
        /// <param name="nLayers"></param>
        public LayerGroup (NeuronLayer nLayer) {
            NeuronLayer = nLayer;
        }
        #endregion
        public NeuronLayer[] NeuronLayers { get; set; }
        public NeuronLayer NeuronLayer { get; set; }
        public double[] Inputs { get; set; }
        public double[] Outputs { get; set; }
    }
}
