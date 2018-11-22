using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer {
    public class Seer {
        public NeuronLayerGroup nlg;

        /// <summary>
        /// This seer creates a fully connected network
        /// </summary>
        /// <param name="inputCount"></param>
        /// <param name="outputCount"></param>
        /// <param name="numLayers"></param>
        public Seer (int inputCount, int outputCount, int numLayers) {
            NeuronLayer[] nL = new NeuronLayer[numLayers];
            // If single layer
            if (numLayers == 1) {
                nL[0] = new NeuronLayer(inputCount, outputCount);
                nlg = new NeuronLayerGroup(nL);
                return;
            }
            // If multilayer
            int hn = (int)Math.Ceiling(outputCount * 1.1d);
            nL[0] = new NeuronLayer(inputCount, hn);
            for (int nli = 1; nli < numLayers - 1; nli++) { // Skip the last
                nL[nli] = new NeuronLayer(hn, hn);
            }
            nL[numLayers - 1] = new NeuronLayer(hn, outputCount);   // Select the last
            nlg = new NeuronLayerGroup(nL);
        }

        public float[] Predict (float[] Sensories) {
            return nlg.Predict(Sensories);
            //This thing is supposed to raise an event when finished. But instead, I just directly accesed its field xD
            //Will add event feature soon
        }

        public void Train (TrainingData[] td) {
            BackPropagation bp = new BackPropagation();
            nlg = bp.BackPropagate(nlg, td);
        }

        public float[] getError () {
            float[] _rBuffer = new float[nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons.Length];
            for (int n = 0; n < nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons.Length; n++) {
                _rBuffer[n] = nlg.NeuronLayers[nlg.NeuronLayers.Length - 1].neurons[n].Error;
            }
            return _rBuffer;
        }

        public NeuronLayerGroup MutateWith (NeuronLayerGroup nlg) {
            Genetics ga = new Genetics();
            return ga.Mutate(this.nlg, nlg);
        }
    }
}
