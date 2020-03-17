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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Util {
	static internal class Rng {
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
