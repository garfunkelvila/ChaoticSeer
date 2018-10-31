using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    public class NeuronLayerGroup {
        public delegate void OutputHandler (double[] motors);
        public event OutputHandler Decision;
        readonly bool isSingleNl; //Might remove this and just use array

        public NeuronLayer[] NeuronLayers;
        //public double[] Inputs;
        public double[] Outputs;
        //TODO: Output buffer into a thread?
        #region Constructors
        /// <summary>
        /// Holds an array of Neuron layers.
        /// </summary>
        /// <param name="nLayers"></param>
        public NeuronLayerGroup (NeuronLayer[] nLayers) {
            isSingleNl = false;
            NeuronLayers = nLayers;
        }
        #endregion
        public double[] Decide (double[] Inputs) {
            double[] outputBuffer;
            
            //Layer > Neuron > Dendrites > Inputs
                
            //Feed Input on the first layer and put into buffer
            for (int n = 0; n < NeuronLayers[0].neurons.Length; n++) {
                for (int d = 0; d < NeuronLayers[0].neurons[n].Dendrites.Length; d++) {
                    //for (int i = 0; i < Inputs.Length; i++) {
                    //NeuronLayers[0].neurons[n].Dendrites[d] = Inputs[i];
                    NeuronLayers[0].neurons[n].Dendrites[d] = Inputs[d];
                    //}
                }
            }
            outputBuffer = new double[NeuronLayers[0].neurons.Length];
            for (int oB = 0; oB < outputBuffer.Length; oB++) {
                //Output should match the neuron count
                outputBuffer[oB] = NeuronLayers[0].neurons[oB].Axon();
            }

            //Get outputs then feed into next layer
            for (int nL = 1; nL < NeuronLayers.Length; nL++) {
                for (int n = 0; n < NeuronLayers[nL].neurons.Length; n++) {
                    for (int d = 0; d < NeuronLayers[nL].neurons[n].Dendrites.Length; d++) {
                        //for (int i = 0; i < Inputs.Length; i++) {
                        //NeuronLayers[nL].neurons[n].Dendrites[d] = Inputs[i];
                        NeuronLayers[nL].neurons[n].Dendrites[d] = outputBuffer[d];
                        //}
                    }
                }
                //I think this is still WRONG, Im lost xD
                //i am not sure how do i feed the output of last layer to next

                //I think output buffer should be re initialized based on dendrite count]
                outputBuffer = new double[NeuronLayers[nL].neurons.Length];
                /*for (int oB = 0; oB < outputBuffer.Length; oB++) {
                    outputBuffer[oB] = NeuronLayers[nL].neurons[oB].Axon();
                }*/

                //My first time
                //https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallel.for?view=netframework-4.7.2#System_Threading_Tasks_Parallel_For_System_Int32_System_Int32_System_Action_System_Int32__
                Parallel.For(0, outputBuffer.Length, oB => {
                    outputBuffer[oB] = NeuronLayers[nL].neurons[oB].Axon();
                });
            }
            //Decision.Invoke(outputBuffer);
            return outputBuffer;
        }
    }
}
