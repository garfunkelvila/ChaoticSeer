using Chaotic_Seer.NEAT;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.NN {
	class NodeNeuron : INode {
		public int Innovation { get; set; }
		public NeuronTypes Type { get; set; }

		public NodeNeuron() {

		}
		public NodeNeuron(NodeGene node) {
			Innovation = node.Innovation;
			Type = node.Type;
		}
	}
}
