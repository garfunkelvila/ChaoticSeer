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
	class NodeNeuron : INode {
		public int Innovation { get; set; }
		public NeuronTypes Type { get; set; }
		public float Axon { get; set; }

		public NodeNeuron() {

		}

		public NodeNeuron(NodeGene node) {
			Innovation = node.Innovation;
			Type = node.Type;
		}

		public override bool Equals(object obj) {
			if (!GetType().Equals(obj.GetType())) return false;
			NodeNeuron other = obj as NodeNeuron;
			return
				Innovation == other.Innovation &&
				Type == other.Type;
		}

		public override int GetHashCode() {
			return Innovation;
		}
	}
}
