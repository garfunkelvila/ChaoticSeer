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
using Neural_Network;

namespace Dark_Seer {
    class Seer {
        //This is the specie, planned to requre to have a mutation class
        //Planned to hold the selection class. Specie selects whom to mutate
        public bool isCorrect = false;
        public UInt16 Fitness = 0;  //Each every correct answer, this thing increases
        public readonly NeuronLayerGroup nlg;
        Genetics GA;

        public Seer () {
            NeuronLayer[] nL = new NeuronLayer[8];
            nL[0] = new NeuronLayer(3, 64);
            nL[1] = new NeuronLayer(64, 64);
            nL[2] = new NeuronLayer(64, 64);
            nL[3] = new NeuronLayer(64, 128);
            nL[4] = new NeuronLayer(128, 128);
            nL[5] = new NeuronLayer(128, 128);
            nL[6] = new NeuronLayer(128, 16);
            nL[7] = new NeuronLayer(16, 3, ActivationFunctions.Step);
            nlg = new NeuronLayerGroup(nL);
        }
        public Seer (NeuronLayerGroup nL) {
            nlg = nL;
        }
        public void Decide (double[] Sensories) {
            nlg.Predict(Sensories);
            //This thing is supposed to raise an event when finished. But instead, I just directly accesed its field xD
            //Will add event feature soon
        }
    }
}
