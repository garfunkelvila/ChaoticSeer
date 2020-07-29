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
			NodeGene other = obj as NodeGene;
			return
				Innovation == other.Innovation &&
				Type == other.Type;
		}

		public override int GetHashCode() {
			return Innovation;
		}
	}
}
