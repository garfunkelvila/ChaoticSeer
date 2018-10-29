using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    class LayerGroup {
        public delegate void OutputHandler (double[] motors);
        public event OutputHandler Decision;
        readonly bool isSingleNl; //Might remove this and just use array

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
            isSingleNl = false;
            NeuronLayers = nLayers;
        }
        /// <summary>
        /// Holds a Neuron layer.
        /// </summary>
        /// <param name="nLayers"></param>
        public LayerGroup (NeuronLayer nLayer) {
            isSingleNl = true;
            NeuronLayer = nLayer;
        }
        #endregion
        public void Decide () {
            double[] outputBuffer = new double[Inputs.Count()]; //I think this sould equal to axons or neurons of last layer

            if (isSingleNl) {
                //Feed Input
                for (int n = 0; n < NeuronLayer.neurons.Length; n++) {
                    for (int d = 0; d < NeuronLayer.neurons[n].Dendrites.Length; d++) {
                        for (int i = 0; i < Inputs.Length; i++) {
                            NeuronLayer.neurons[n].Dendrites[d] = Inputs[i];
                        }
                    }
                }

                //Get outputs
                for (int o = 0; o < Inputs.Length; o++) {
                    outputBuffer[o] = NeuronLayer.neurons[o].Axon();
                }

                Decision.Invoke(outputBuffer);
            }
            else {
                //Layer > Neuron > Dendrites > Inputs

                //Feed Input on the first layer and put into buffer
                for (int n = 0; n < NeuronLayers[0].neurons.Length; n++) {
                    for (int d = 0; d < NeuronLayers[0].neurons[n].Dendrites.Length; d++) {
                        for (int i = 0; i < Inputs.Length; i++) {
                            NeuronLayers[0].neurons[n].Dendrites[d] = Inputs[i];
                        }
                    }
                }
                for (int i = 0; i < Inputs.Length; i++) {
                    outputBuffer[i] = NeuronLayer.neurons[i].Axon();
                }

                //Get outputs then feed into next layer
                for (int nL = 1; nL < NeuronLayers.Length; nL++) {
                    for (int n = 0; n < NeuronLayers[nL].neurons.Length; n++) {
                        for (int d = 0; d < NeuronLayers[nL].neurons[n].Dendrites.Length; d++) {
                            for (int i = 0; i < Inputs.Length; i++) {
                                NeuronLayers[nL].neurons[n].Dendrites[d] = Inputs[i];
                            }
                        }
                    }
                    //I think this is still WRONG, Im lost xD
                    //i am not sure how do i feed the output of last layer to next
                    
                    //I think output buffer should be re initialized based on dendrite count
                    for (int i = 0; i < Inputs.Length; i++) {
                        outputBuffer[i] = NeuronLayer.neurons[i].Axon();
                    }
                }
                Decision.Invoke(outputBuffer);
            }
        }
    }
}
