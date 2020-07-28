using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.Util {
	interface IConnection {
		INode In { get; set; }
		INode Out { get; set; }
	}
}
