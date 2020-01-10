using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer {
    static class rng {
        static Random random = new Random();
        internal static double getRng() {
            return random.NextDouble();
        }
        internal static int getRngMinMax(int min, int max) {
            return random.Next(min,max);
        }
    }
}
