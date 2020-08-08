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
