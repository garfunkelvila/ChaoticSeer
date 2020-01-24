﻿using System;
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
		internal static float GetRngF() {
			return (float)random.NextDouble();
		}
		internal static int GetRngMinMax(int min, int max) {
			return random.Next(min, max);
		}
	}
}