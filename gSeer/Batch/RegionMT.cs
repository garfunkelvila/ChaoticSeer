using gSeer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Batch {
    /// <summary>
    /// Even this thing is multi threaded, it is using the single threaded tribe
    /// But each instance of tribe in theory have their own threads
    /// </summary>
    public class RegionMT : Region {
        public RegionMT(int tribeSize, int inputSize, int outputSize, int maxPopulation, int maxNodes = 10)
            : base(tribeSize, inputSize, outputSize, maxPopulation, maxNodes) {
        }

        public override void Purge() {
            
        }

        public override void StartChaos(TrainingDatas tds, int mutationIteration = 3600) {
            for (int i = 0; i < 36500; i++) {
                Parallel.ForEach(tribes, new ParallelOptions() { MaxDegreeOfParallelism = Rng.Cores }, (tribe) => {
                    tribe.Mutate();
                });
            }
        }
    }
}
