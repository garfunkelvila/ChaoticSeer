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

using gSeer.Data_Structures;
using gSeer.Genetic_Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Forward_Propagation {

	/// <summary>
	/// Make this thing static, also maybe mutation
	/// </summary>
	public class FPropagateST : ForwardPropagation {
		public FPropagateST(ChaoticSeer seer) {
			InputNodes = new List<CalcNode>();
			HiddenNodes = new List<CalcNode>();
			OutputNodes = new List<CalcNode>();

			GeneHashSet<NodeGene> _nodes = seer.Nodes;
			GeneHashSet<ConnectionGene> _cons = seer.Connections;
			Dictionary<int, CalcNode> _nodeHashMap = new Dictionary<int, CalcNode>();
			foreach (NodeGene item in _nodes.Data) {
				CalcNode node = new CalcNode(item.X);
				_nodeHashMap.Add(item.InnovationNumber, node);

				if (item.X <= 0.1f) {
					InputNodes.Add(node);
				}
				else if (item.X >= 0.9f) {
					OutputNodes.Add(node);
				}
				else {
					HiddenNodes.Add(node);
				}
			}
			HiddenNodes.Sort();	//This thing is working correct
			foreach (ConnectionGene item in _cons.Data) {
				NodeGene from = item.From;
				NodeGene to = item.To;

				CalcNode node_from = _nodeHashMap[from.InnovationNumber];
				CalcNode node_to = _nodeHashMap[to.InnovationNumber];

				CalcConnection con = new CalcConnection(node_from, node_to) {
					Weight = item.Weight,
					IsEnabled = item.IsEnabled
				};

				node_to.Connections.Add(con);
			}
		}

		public override List<CalcNode> InputNodes { get; set; }
		public override List<CalcNode> HiddenNodes { get; set; }
		public override List<CalcNode> OutputNodes { get;  set; }

		public override float[] Output(params float[] input) {
			//Need to initialize this class/object

			if (input.Length != InputNodes.Count) throw new NotSupportedException();
			//Initialze input nodes
			for (int i = 0; i < InputNodes.Count; i++) {
				InputNodes[i].Output = input[i];
			}
			//Calculate hidden nodes
			foreach (CalcNode item in HiddenNodes) {
				item.Calculate();
			}
			float[] output = new float[OutputNodes.Count];
			//calculate ouput nodes
			for (int i = 0; i < OutputNodes.Count; i++) {
				OutputNodes[i].Calculate();
				output[i] = OutputNodes[i].Output;
			}
			return output;
		}
	}

	public class CalcNode : IComparable<CalcNode> {
		ActivationFunctions.Activation ActivationFunction;
		public float X { get; set; }
		public float Output { get; set; }
		public List<CalcConnection> Connections { get; set; }
		CalcNode() {
			ActivationFunction = new ActivationFunctions.Logistic();
			Connections = new List<CalcConnection>();
		}
		public CalcNode(float x) : this() {
			X = x;
		}
		public void Calculate() {
			float s = 0f;
			for (int i = 0; i < Connections.Count; i++) {
				if (Connections[i].IsEnabled) {
					s += Connections[i].Weight * Connections[i].From.Output;
				}
			}
			Output = ActivationFunction.GetAxon(s);
		}
		/// <summary>
		/// Compare position left to right
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(CalcNode other) {
			if (X > other.X) return -1;
			if (X < other.X) return 1;
			return 0;
		}
	}

	public class CalcConnection {
		public CalcNode From { get; set; }
		public CalcNode To { get; set; }
		public float Weight { get; set; }
		public bool IsEnabled { get; set; } = true;
		public CalcConnection(CalcNode from, CalcNode to) {
			From = from;
			To = to;
		}
	}
}
