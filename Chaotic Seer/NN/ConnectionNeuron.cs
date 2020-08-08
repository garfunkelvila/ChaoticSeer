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

using Chaotic_Seer.NEAT;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.NN {
	class ConnectionNeuron : IConnection {
		public INode In { get; set; }
		public INode Out { get; set; }
		public float Weight { get; set; }
		public int Innovation { get; set; }

		public ConnectionNeuron() {
			Weight = Rng.GetFloat();
		}

		public ConnectionNeuron(ConnectionNeuron gene) {
			In = gene.In;
			Out = gene.Out;
			Innovation = gene.Innovation;
			Weight = gene.Weight;
		}

		public override bool Equals(object obj) {
			if (!GetType().Equals(obj.GetType())) return false;

			ConnectionNeuron other = obj as ConnectionNeuron;
			return
				In.Equals(other.In) &&
				Out.Equals(other.Out);
		}

		public override int GetHashCode() {
			return In.Innovation * Parameters.MaxNodes + Out.Innovation;
		}
    }
}
