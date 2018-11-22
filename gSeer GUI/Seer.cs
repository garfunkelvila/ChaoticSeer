//  Copyright (C) 2018  Garfunkel Vila
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer;

namespace Dark_Seer {
    class TestSeer {
        //This is the specie, planned to requre to have a mutation class
        //Planned to hold the selection class. Specie selects whom to mutate
        public bool isCorrect = false;
        public UInt16 Fitness = 0;  //Each every correct answer, this thing increases
        public NeuronLayerGroup nlg;

        public TestSeer () {
            NeuronLayer[] nL = new NeuronLayer[4];
            nL[0] = new NeuronLayer(3, 5);
            nL[1] = new NeuronLayer(5, 5);
            nL[2] = new NeuronLayer(5, 5);
            nL[3] = new NeuronLayer(5, 3, ActivationFunctions.Step);
            //nL[2] = new NeuronLayer(2, 1);
            nlg = new NeuronLayerGroup(nL);
        }
        public TestSeer (NeuronLayerGroup nL) {
            nlg = nL;
        }
        public float[] Predict (float[] Sensories) {
            return nlg.Predict(Sensories);
            //This thing is supposed to raise an event when finished. But instead, I just directly accesed its field xD
            //Will add event feature soon
        }
        public void BP (TrainingData[] td) {
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

        public NeuronLayerGroup MutateWith(NeuronLayerGroup nlg) {
            Genetics ga = new Genetics();
            return ga.Mutate(this.nlg, nlg);
        }
    }
}
