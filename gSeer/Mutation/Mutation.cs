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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Mutation {
	public abstract class Mutation {
		/// <summary>
		/// Check existing link first
		/// </summary>
		public abstract void MutateConnection(ChaoticSeer seer);
		/// <summary>
		/// Add node
		/// </summary>
		public abstract void MutateNode(ChaoticSeer seer);
		/// <summary>
		/// Shift weight based on shift strength
		/// </summary>
		public abstract void MutateWeightShift(ChaoticSeer seer);
		/// <summary>
		/// Shift weight based on random strength
		/// </summary>
		public abstract void MutateWeightRandom(ChaoticSeer seer);
		/// <summary>
		/// Toggle connection
		/// </summary>
		public abstract void MutateToggleConnection(ChaoticSeer seer);
		/// <summary>
		/// Creates a new genome based on two genomes
		/// </summary>
		/// <param name="g1">X Genome</param>
		/// <param name="g2">Y Genome</param>
		/// <returns></returns>
		public abstract ChaoticSeer CrossOver(ChaoticSeer g1, ChaoticSeer g2);
	}
}
