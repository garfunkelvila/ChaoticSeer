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
        bool isSingle;

        public NeuronLayer[] NeuronLayers;
        public NeuronLayer NeuronLayer;
        public double[] Inputs;
        public double[] Outputs;

        #region Constructors
        /// <summary>
        /// Holds an array of Neuron layers.
        /// </summary>
        /// <param name="nLayers"></param>
        public LayerGroup (NeuronLayer[] nLayers) {
            isSingle = false;
            NeuronLayers = nLayers;
        }
        /// <summary>
        /// Holds a Neuron layer.
        /// </summary>
        /// <param name="nLayers"></param>
        public LayerGroup (NeuronLayer nLayer) {
            isSingle = true;
            NeuronLayer = nLayer;
        }
        #endregion
        public void Decide () {
            double[] outputBuffer = new double[Inputs.Count()];

            if (isSingle) {
                //Give every inputs to every neurons, each dendrites
                for (int n = 0; n < Inputs.Length; n++) {
                    for (int d = 0; d < NeuronLayer.neurons[n].Dendrites.Length; d++) {
                        for (int i = 0; i < Inputs.Length; i++) {
                            NeuronLayer.neurons[n].Dendrites[d] = Inputs[i];
                        }
                    }
                }
                //Get outputs
                for (int i = 0; i < Inputs.Length; i++) {
                    outputBuffer[i] = NeuronLayer.neurons[i].Axon();
                }
                Decision.Invoke(outputBuffer);
            }
            else {
                //Process each layer
                //Set the output of process to next layer
                foreach (NeuronLayer nL in NeuronLayers) {
                    //Put the layer result in the buffer
                    for (int i = 0; i < Inputs.Count(); i++) {
                        outputBuffer[i] = nL.neurons[i].Axon();
                    }

                    //Set the buffer as the input
                    //Replace each item as per output?
                }
                Decision.Invoke(outputBuffer);
            }
        }
    }
}
