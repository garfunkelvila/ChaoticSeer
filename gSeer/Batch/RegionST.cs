using gSeer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Batch {
    public class RegionST : Region {
        public RegionST(int tribeSize, int inputSize, int outputSize, int maxPopulation, int maxNodes = 10)
            : base(tribeSize, inputSize, outputSize, maxPopulation, maxNodes) {
        }

        public override void Purge() {
            throw new NotImplementedException();
        }

        public override void StartChaos(TrainingDatas tds, int mutationIteration = 3600) {
            for (int i = 0; i < mutationIteration; i++) {
                foreach (Tribe tribe in tribes) {
                    tribe.Train(tds);
                }
            }
        }

        public override void StartChaos(TrainingData[] tds, int mutationIteration = 3600) {
            for (int i = 0; i < mutationIteration; i++) {
                foreach (Tribe tribe in tribes) {
                    tribe.Train(tds);
                }
            }
        }
    }
}
