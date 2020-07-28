using Chaotic_Seer.NN;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.NEAT {
	class ConnectionGene : IConnection {
		public INode In { get; set; }
		public INode Out { get; set; }
		
		ConnectionGene() {

		}

		public ConnectionGene(ConnectionGene item) {
			In = item.In;
			Out = item.Out;
		}

		public ConnectionGene(ConnectionNeuron item) {
			In = item.In;
			Out = item.Out;
		}

		public override bool Equals(object obj) {
			if (!GetType().Equals(obj.GetType())) return false;

			ConnectionGene other = obj as ConnectionGene;
			return
				In.Equals(other.In) &&
				Out.Equals(other.Out);
		}

		public override int GetHashCode() {
			return In.Innovation * Parameters.MaxNodes + Out.Innovation;
		}
	}
}
