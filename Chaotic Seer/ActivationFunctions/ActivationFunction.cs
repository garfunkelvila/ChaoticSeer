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

namespace Seer.ActivationFunctions {
	internal abstract class ActivationFunction {
		protected abstract float CalcAxon(float x);
		protected abstract float CalcAxon(float x, float y);
		protected abstract float CalcDerv(float x);
		protected abstract float CalcDerv(float x, float y);

		public float GetAxon(float x) {
			return CalcAxon(x);
		}
		public float GetAxon(float x, float y) {
			return CalcAxon(x, y);
		}
		public float GetDerv(float x) {
			return CalcDerv(x);
		}
		public float GetDerv(float x, float y) {
			return CalcDerv(x, y);
		}
	}
}
