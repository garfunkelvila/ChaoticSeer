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
