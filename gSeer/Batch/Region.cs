//  ChaoticSeer, a C# Artificial Neural Network Library
//  Copyright (C) 2020  Garfunkel Vila
//  
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 3 of the License, or any later version.
//  
//  This library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library. If not,
//  see<https://www.gnu.org/licenses/>.

using gSeer.Genetic_Algorithm;
using gSeer.Batch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Util;

namespace gSeer.Batch {
    /// <summary>
    /// Basically minibatch I think
    /// </summary>
    public abstract class Region {
        protected Tribe[] tribes;
        public NeatCNS Neat;

        // public delegate void EventHandler();
        // public event EventHandler BeforePurge;
        // public event EventHandler AfterPurge;

        public Region(int tribeSize, int inputSize, int outputSize, int maxPopulation, int maxNodes = 10) {
            Neat = new NeatCNS(inputSize, outputSize, maxNodes);
            tribes = new Tribe[tribeSize];
            for (int i = 0; i < tribes.Length; i++) {
                tribes[i] = new TribeST(Neat, maxPopulation);
            }
        }

        public abstract void Purge();
        public abstract void StartChaos(TrainingDatas tds, int mutationIteration = 3600);
        public abstract void StartChaos(TrainingData[] tds, int mutationIteration = 3600);
    }
}
