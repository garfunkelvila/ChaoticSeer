using gSeer.Genetic_Algorithm;
using gSeer.TribeThreading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer {
    /// <summary>
    /// Basically minibatch I think
    /// </summary>
    public abstract class Region {
        Tribe[] tribes;
        public NeatCNS Neat;

        public delegate void EventHandler();
        public event EventHandler BeforePurge;
        public event EventHandler AfterPurge;

        public Region(int tribeSize, int inputSize, int outputSize, int maxPopulation, int maxNodes = 10) {
            Neat = new NeatCNS(inputSize, outputSize, maxNodes);
            tribes = new Tribe[tribeSize];
            for (int i = 0; i < tribes.Length; i++) {
                tribes[i] = new TribeST(Neat, maxPopulation);
            }
        }

        public void Purge() {
            BeforePurge.Invoke();

            AfterPurge.Invoke();
        }

        public void StartChaos(TrainingDatas tds) {
            //Mutate for 36500 times
            for (int i = 0; i < 36500; i++) {
                foreach (Tribe tribe in tribes) {
                    tribe.Mutate();
                }
            }
        }
    }
}
