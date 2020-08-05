using Chaotic_Seer.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.NEAT {
	public class Specie {
		public int TopFitness;
		public float AverageFitness;

		public int Staleness;
		public RandomList<Genome> genomes = new RandomList<Genome>();
		public Genome Representative;
		
		public Specie(Genome Representative) {
			this.Representative = Representative;
			genomes.Add(Representative);
		}
		public void AddGenome(Genome genome) {
			genomes.Add(genome);
		}
	}
}
