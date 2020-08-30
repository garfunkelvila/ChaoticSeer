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

using Seer.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.NEAT {
	class Parameters {
		public static readonly int MaxNodes = 10;

		public static readonly float c1 = 1.0f;
		public static readonly float c2 = 1.0f;
		public static readonly float c3 = 2.0f;
		public static readonly float ct = 1.0f;

		// I will transfer these threshold to me local on genome

		// The maximum magnitude of a mutation that changes the weight
		// of a connection(Section 3.1).
		public static readonly float WeightMutationRange = 2.5f;
		public static readonly float WeightMutationProbability = 0.25f;
		// Percentage of each species allowed to reproduce (Section 3.3).
		public static readonly float SurvivalThreshold = 0.2f;
		// Probability that a reproduction will only result from mutation and
		// not crossover.
		public static readonly float MutateOnlyProbability = 0.25f;
		// Probability a new node gene will be added to the genome (Section 3.1).
		public static readonly float AddNodeProbability = 0.005f;
		// Probability a new connection will be added (Section 3.1).
		public static readonly float AddLinkProbability = 0.05f;

		// Percentage of crossovers allowed to occur between parents of different species(Section 3.3).
		public static readonly float InterspeciesMatingRate = 0.01f;
		// Probability that genes will be chosen one at a time from either parent during crossover(Section 3.2).
		public static readonly float MateByChoosingProbability = 0.6f;
		// Probability that matching genes will be averaged crossover(Section 3.2).
		public static readonly float MateOnlyProbability = 0.2f;
		// Probability a new connection will be recurrent.
		public static readonly float RecurrentConnectionProbability = 0.2f;

		// Number of networks in the population.
		public static int PopulationSize = 1;
		// Maximum number of generations a species is allowed to stay the 
		// same fitness before it is removed.In competitive coevolution, the worst species is removed if
		// it has been around this many generations(Section 3.3).
		public static int MaximumStagnation = 130;
		// Desired number of species in the population; used only in dynamic
		// compatibility thresholding(Section 3.3).
		public static int TargetNumberOfSpecies = 20;

		// Back Propagation
		public static float LearningRate = 1.02f;
		public static readonly ActivationFunction af = new Logistic();
	}
}
