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

using gSeer.Genetic_Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Mutation {
	class MutationST : Mutation {
		public override void MutateConnection(ChaoticSeer seer) {
			for (int i = 0; i < 100; i++) {
				NodeGene a = seer.Nodes.Random;
				NodeGene b = seer.Nodes.Random;

				if (a == null || b == null) continue;   //skip if empty
				if (a.X == b.X) continue;              //skip if thesame

				// Create connection for the new seed
				ConnectionGene con;
				if (a.X < b.X)
					con = new ConnectionGene(a, b);
				else
					con = new ConnectionGene(b, a);

				if (seer.Connections.Contains(con)) {
					//skip if newly generated connection already exist
					continue;
				}

				con = seer.Cns.AddConnection(con.From, con.To);
				con.Weight = ((Util.GetRngF() * 2) - 1) * NeatCNS.WEIGHT_RANDOM_STRENGTH;

				//Attempt to ensure that the data is sorted by its InnovaitonNumber
				for (int cI = 0; i < seer.Connections.Count; i++) {
					int innovation = seer.Connections[cI].InnovationNumber;
					if (con.InnovationNumber < innovation) {
						//Insert it right next
						seer.Connections.Insert(cI, con);
						return;
					}
				}
				seer.Connections.Add(con);
				return;
			}
		}
		public override void MutateNode(ChaoticSeer seer) {
			if (seer.Nodes.Count >= NeatCNS.MAX_NODES) return;
			ConnectionGene con = seer.Connections.Random;
			if (con == null) return;

			NodeGene from = con.From;
			NodeGene middle;
			NodeGene to = con.To;

			int replaceIndex = seer.Cns.GetReplaceIndex(from, to);

			if (replaceIndex == 0) {
				middle = seer.Cns.AddNode();
				middle.X = (from.X + to.X) / 2;
				middle.Y = (from.Y + to.Y) / 2 + (float)((Util.GetRngF() * 0.1) - 0.05);
				seer.Cns.SetReplaceIndex(from, to, middle.InnovationNumber);
			}
			else {
				middle = seer.Cns.AddNode(replaceIndex);
			}

			//NodeGene middle = Neat.AddNode();
			//middle.X = (from.X + to.X) / 2; //Divide by to to get the center
			//middle.Y = (from.Y + to.Y) / 2; //Divide by to to get the center

			ConnectionGene con1 = seer.Cns.AddConnection(from, middle);
			ConnectionGene con2 = seer.Cns.AddConnection(middle, to);


			con1.Weight = 1;
			con2.Weight = con.Weight;
			con2.IsEnabled = con.IsEnabled;

			seer.Connections.Remove(con);
			seer.Connections.Add(con1);
			seer.Connections.Add(con2);

			seer.Nodes.Add(middle);
		}
		public override void MutateToggleConnection(ChaoticSeer seer) {
			ConnectionGene con = seer.Connections.Random;
			if (con != null) {
				con.IsEnabled = con.IsEnabled;
			}
		}
		public override void MutateWeightRandom(ChaoticSeer seer) {
			ConnectionGene con = seer.Connections.Random;
			if (con != null) {
				con.Weight = ((Util.GetRngF() * 2) - 1) * NeatCNS.WEIGHT_RANDOM_STRENGTH;
			}
		}
		public override void MutateWeightShift(ChaoticSeer seer) {
			ConnectionGene con = seer.Connections.Random;
			if (con != null) {
				con.Weight += ((Util.GetRngF() * 2) - 1) * NeatCNS.WEIGHT_SHIFT_STRENGTH;
			}
		}
		public override ChaoticSeer CrossOver(ChaoticSeer g1, ChaoticSeer g2) {
			/// current g1 should have the higher score
			/// take all the genes of g1
			/// if there is a genome in g1 that is also in g2, choose randomly
			/// do not take disjoint genes of g2
			/// take excess genes of g1 if they exist
			NeatCNS neat = g1.Cns;
			//Genome _genomeBuffer = neat.NewEmptyGenome();
			ChaoticSeer _genomeBuffer = new ChaoticSeer(neat);

			int indexG1 = 0;
			int indexG2 = 0;

			//Handle not connectec genes
			while (indexG1 < g1.Connections.Count && indexG2 < g2.Connections.Count) {
				ConnectionGene gene1 = g1.Connections[indexG1];
				ConnectionGene gene2 = g2.Connections[indexG2];


				//Because I seperated the client, the innovation number for them is different. This is a problem
				int in1 = gene1.InnovationNumber;
				int in2 = gene2.InnovationNumber;

				if (in1 == in2) {
					// basically if they are thesame, just select either of them randomly
					if (Util.GetRngF() > 0.5f)
						_genomeBuffer.Connections.Add(neat.Connections[gene1]);
					else
						_genomeBuffer.Connections.Add(neat.Connections[gene2]);

					indexG1++;
					indexG2++;
				}
				else if (in1 > in2) {
					//genome.Connections.Add(neat.Connections[gene2]);
					//disjoint/skip gene of b
					indexG2++;
				}
				else {
					//disjoint/skip gene of a
					_genomeBuffer.Connections.Add(neat.Connections[gene1]);
					indexG1++;
				}
			}
			// Add the connections
			while (indexG1 < g1.Connections.Count) {
				ConnectionGene gene1 = g1.Connections[indexG1];
				_genomeBuffer.Connections.Add(neat.Connections[gene1]);
				indexG1++;
			}
			// Add the nodes
			foreach (ConnectionGene c in _genomeBuffer.Connections) {
				_genomeBuffer.Nodes.Add(c.From);
				_genomeBuffer.Nodes.Add(c.To);
			}

			return _genomeBuffer;
		}
	}
}
