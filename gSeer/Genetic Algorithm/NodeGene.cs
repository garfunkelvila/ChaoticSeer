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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.GeneticAlgorithm {
    /// <summary>
    /// X,Y handles recursion
    /// </summary>
    public class NodeGene : Gene, IComparable<NodeGene> {
        /// <summary>
        /// Used for drawing and comparing the position of node
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Used for drawing and comparing the position of node
        /// </summary>
        public double Y { get; set; }
        public override int InnovationNumber { get; set; }
        //Transfer from Neat
        public NodeGene(int innovationNumber) {
            InnovationNumber = innovationNumber;
        }
        public override bool Equals(Object obj) {
            // Attemp not to use equals that is overriden
            if (!GetType().Equals(obj.GetType())) return false;
            return InnovationNumber == ((NodeGene) obj).InnovationNumber;
        }
        public override int GetHashCode() {
            return InnovationNumber;
        }
		/// <summary>
		/// Put the lower X value on top of array
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(NodeGene other) {
			if (X > other.X) return -1;
			if (X < other.X) return 1;
			return 0;
		}
	}
}
