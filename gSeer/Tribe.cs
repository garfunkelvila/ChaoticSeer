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

namespace gSeer {
	/// <summary>
	/// Might rename this to Tribe
	/// </summary>
	public class Tribe {
		public GeneHashSet<ChaoticSeer> Species { get; private set; }
		public ChaoticSeer Representative { get => Species[0]; }
		public NeatCNS Neat { get; }
		public int MAX_POPULATION { get; }
		/// <summary>
		/// Create a batch of species filled with Genomes
		/// </summary>
		/// <param name="inputSize"></param>
		/// <param name="outputSize"></param>
		/// <param name="maxPopulation">Target population</param>
		/// <param name="maxNodes">Target nodes</param>
		public Tribe(int inputSize, int outputSize, int maxPopulation, int maxNodes = 10) {
			MAX_POPULATION = maxPopulation;
			Neat = new NeatCNS(inputSize, outputSize);
			Species = new GeneHashSet<ChaoticSeer>();
			for (int i = 0; i < maxPopulation; i++) {
				Species.Add(new ChaoticSeer(Neat) {
					Identity = i
				});
			}
		}
		/// Will use polymorph soon
		#region EVOLUTION
		/// <summary>
		/// Natural Selection
		/// </summary>
		public void Purge() {
			if (Species.Count == 2) return;
			//TODO: add somehting to make the highest score survive
			int speciesKilled = 0;
			float avgFitness = 0f;
			for (int i = 0; i < Species.Count; i++) {
				avgFitness += Species[i].Fitness;
			}
			avgFitness /= Species.Count;

			// attempt to kill lower fitness with survival threshold as luck
			for (int i = 0; i < Species.Count; i++) {
				if(Species[i].Fitness < avgFitness && Species[i].SURVIVAL_THRESHOLD > Util.GetRngF()) {
					Species.RemoveAt(i);
					speciesKilled++;
				}
			}
		}
		/// <summary>
		/// Reproduce by mating with others
		/// </summary>
		public void Reproduce() {
			//Currently it will just fill up to max population

			// TODO: add something to prevent mating with self
			//for (int i = 0; i < 1; i++) {
			//	ChaoticSeer _seerX = Species.Random;
			//	ChaoticSeer _seerY = Species[i];
			//	ChaoticSeer _seerChild = _seerY.MateWith(_seerX);
			//	_seerChild.Identity = _seerX.Identity + _seerY.Identity;
			//	Species.Add(_seerChild);
			//}

			do {
				ChaoticSeer _seerX = Species.Random;
				ChaoticSeer _seerY = Species.Random;
				ChaoticSeer _seerChild = _seerY.MateWith(_seerX);
				_seerChild.Identity = _seerX.Identity + _seerY.Identity;
				Species.Add(_seerChild);
			} while (Species.Count < MAX_POPULATION);
		}
		/// <summary>
		/// Mutate self, like self evolve
		/// </summary>
		public void Mutate() {
			foreach (ChaoticSeer seer in Species) {
				seer.Mutate();
			}
		}
		#endregion

		public void Train(TrainingData td) {
			//Mutate few times maybe 12, or 100+ don'y know yet
			//Get prediction to all training data, each correct output gives score
			//Purge
			//Reproduce
		}

		#region DECISIONS
		/// <summary>
		/// Fill their score based on their predictions
		/// </summary>
		/// <param name="td"></param>
		public void Evaluate(TrainingData[] td) {
			// I just realized I need the BP error function here
			// TODO: use proper cost function

			for (int iSpecie = 0; iSpecie < Species.Count; iSpecie++) {
				// Loop through species
				
				Species[iSpecie].Fitness = 0;
				for (int iTd = 0; iTd < td.Length; iTd++) {
					// Loop through training datas

					float[] pred = Species[iSpecie].GetPrediction(td[iTd].Input);
					for (int i = 0; i < pred.Length; i++) {
						// Loop througo output neurons

						//float _cost = pred[i] && td[iTd].Target[i];
						float _cost = Util.FloatingAnd(pred[i] , td[iTd].Target[i]);
						Species[iSpecie].Fitness += _cost;
					}
				}
			}

			//throw new NotImplementedException();
		}


		public float[][] Decisions() {
			throw new NotImplementedException();
		}
		#endregion
	}
}
