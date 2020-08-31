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
	class SensorNeuron : INode {
		public int Innovation { get; set; }
		public NeuronTypes Type { get; set; } = NeuronTypes.Sensor;
		public float Axon { get => Parameters.af.GetAxon(NetAxon); } // -0.5 Compensate Sigmoid 0-1 range, because 0 input makes it not move at all
		public float NetAxon { get; set; }
		public SensorNeuron() { }
		public SensorNeuron(INode node) {
			Innovation = node.Innovation;
		}
		public SensorNeuron(NodeGene node) {
			Innovation = node.Innovation;
			if (node.Type != NeuronTypes.Sensor)
				throw new Exception("THis is an input neuron!!");
		}
		public override bool Equals(object obj) {
			if (!GetType().Equals(obj.GetType())) return false;
			SensorNeuron other = obj as SensorNeuron;
			return
				Innovation == other.Innovation &&
				Type == other.Type;
		}
		public override int GetHashCode() {
			return Innovation;
		}
	}
	class InterNeuron : INode {
		public int Innovation { get; set; }
		public NeuronTypes Type { get; set; } = NeuronTypes.Inter;
		public float Axon { get => Parameters.af.GetAxon(NetAxon + Bias); }
		// Used on BP, might relocate this one
		public float NetAxon { get; set; }
		public float Bias { get; set; } = 1; // Default to 1 to push sigmoid on start
		public InterNeuron() {
			//Bias = Rng.GetFloat();
		}

		public InterNeuron(NodeGene node) {
			Innovation = node.Innovation;
			if (node.Type != NeuronTypes.Inter)
				throw new Exception("This is a hidden neuron!!");
		}

		public override bool Equals(object obj) {
			if (!GetType().Equals(obj.GetType())) return false;
			InterNeuron other = obj as InterNeuron;
			return
				Innovation == other.Innovation &&
				Type == other.Type;
		}

		public override int GetHashCode() {
			return Innovation;
		}
	}
	class MotorNeuron : INode {
		public int Innovation { get; set; }
		public NeuronTypes Type { get; set; } = NeuronTypes.Motor;
		public float Axon { get => Parameters.af.GetAxon(NetAxon + Bias); }
		// Used on BP, might relocate this one
		public float NetAxon { get; set; }
		public float Bias { get; set; } = 1;
		public MotorNeuron() {
			//Bias = Rng.GetFloat();
		}
		public MotorNeuron(INode node) {
			Innovation = node.Innovation;
		}

		public MotorNeuron(NodeGene node) {
			Innovation = node.Innovation;
			if (node.Type != NeuronTypes.Motor)
				throw new Exception("This is a motor neuron!!");
		}

		public override bool Equals(object obj) {
			if (!GetType().Equals(obj.GetType())) return false;
			MotorNeuron other = obj as MotorNeuron;
			return
				Innovation == other.Innovation &&
				Type == other.Type;
		}

		public override int GetHashCode() {
			return Innovation;
		}
	}
}
