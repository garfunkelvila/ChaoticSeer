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
using Chaotic_Seer.NN;
using Chaotic_Seer.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.BackPropagation {
internal class NeuronLayer {
		public List<BpNeuron> neurons = new List<BpNeuron>();
		public List<BpConnection> connections = new List<BpConnection>();
	}
	internal class BpNeuron : INode {
		public int Innovation { get; set; }
		public NeuronTypes Type { get; set; }
		public float Axon { get => Parameters.af.GetAxon(WeightedSum); }
		public float AxonPrime { get => Parameters.af.GetDerv(WeightedSum); }
		public float NetAxon { get; set; }
		public float WeightedSum { get => NetAxon; } // This exist because of bias
		public float Error { get; set; }

        public BpNeuron(SensorNeuron nodeNeuron) {
			Innovation = nodeNeuron.Innovation;
			Type = nodeNeuron.Type;
			NetAxon = nodeNeuron.Axon;
		}
		public BpNeuron(InterNeuron nodeNeuron) {
			Innovation = nodeNeuron.Innovation;
			Type = nodeNeuron.Type;
			NetAxon = nodeNeuron.NetAxon;
		}
		public BpNeuron(MotorNeuron nodeNeuron) {
			Innovation = nodeNeuron.Innovation;
			Type = nodeNeuron.Type;
			NetAxon = nodeNeuron.NetAxon;
		}
	}
	internal class BpConnection : Util.IConnection {
		public INode In { get; set; }
		public INode Out { get; set; }
		public float Weight { get; set; }
		//public float Error { get; set; }
		public BpConnection(ConnectionNeuron connectionNeuron) {
			In = connectionNeuron.In;
			Out = connectionNeuron.Out;
			Weight = connectionNeuron.Weight;
		}
	}
}
