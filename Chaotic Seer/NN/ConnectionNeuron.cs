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
	}
}
