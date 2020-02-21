using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer {
	static internal class Util {
		public static readonly int Cores = Environment.ProcessorCount;
		static Random random = new Random();
		internal static double GetRng() {
			return random.NextDouble();
		}
		internal static int GetRng(int max) {
			return random.Next(max);
		}
		internal static float GetRngF() {
			return (float)random.NextDouble();
		}
		internal static int GetRngMinMax(int min, int max) {
			return random.Next(min, max);
		}
		internal static float FloatingAnd(float x, float y) {
			if (x < y) {
				return (x + 1) - y;
			}
			else {
				return (y + 1) - x;
			}
		}
	}
}
