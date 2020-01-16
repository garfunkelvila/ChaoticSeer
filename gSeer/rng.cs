using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer {
    static class rng {
        static Random random = new Random();
        internal static double GetRng() {
            return random.NextDouble();
        }
        internal static float GetRngF() {
            return (float)random.NextDouble();
        }
        internal static int GetRngMinMax(int min, int max) {
            return random.Next(min,max);
        }
    }
}
