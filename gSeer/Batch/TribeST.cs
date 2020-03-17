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
using gSeer.Util;

namespace gSeer.Batch {
	public class TribeST : Tribe {
		public TribeST(int inputSize, int outputSize, int maxPopulation, int maxNodes = 10)
			: base(inputSize, outputSize, maxPopulation, maxNodes) {
		}
		public TribeST(NeatCNS neat, int maxPopulation)
			: base(neat, maxPopulation) {

		}
		#region EVOLUTION
		public override void Purge() {
			if (Species.Count == 2) return;
			int speciesKilled = 0;
			float avgFitness = 0f;
			for (int i = 0; i < Species.Count; i++) {
				avgFitness += Species[i].Fitness;
			}
			avgFitness /= Species.Count;

			// attempt to kill lower fitness with survival threshold as luck
			for (int i = 0; i < Species.Count; i++) {
				if (Species[i].Fitness < avgFitness && Species[i].SURVIVAL_THRESHOLD > Rng.GetRngF()) {
					Species.RemoveAt(i);
					speciesKilled++;
				}
			}
		}
		public override void Reproduce() {
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
		public override void Mutate() {
			foreach (ChaoticSeer seer in Species) {
				//if(seer.AGE_THRESHOLD >= seer.Year) {
					seer.Mutate();
				//}
				//else {
				//	Species.Remove(seer);
				//}
			}
		}
		#endregion

		public override void Train(TrainingDatas td, int mutationIteration = 3600) {
			for (int i = 0; i < 3600; i++) {
				Mutate();
			}
			Evaluate(td);

			int purgeRNG = new Random().Next(1, 12);
			for (int i = 0; i < purgeRNG; i++) {
				Purge();
			}
			Reproduce();

			Evaluate(td);
		}
		public override void Train(TrainingData[] td, int mutationIteration = 3600) {
			for (int i = 0; i < 3600; i++) {
				Mutate();
			}
			Evaluate(td);

			int purgeRNG = new Random().Next(1, 12);
			for (int i = 0; i < purgeRNG; i++) {
				Purge();
			}
			Reproduce();

			Evaluate(td);
		}

		#region DECISIONS
		public override void Evaluate(TrainingData[] td) {
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
						float _cost = Rng.FloatingAnd(pred[i], td[iTd].Target[i]);
						Species[iSpecie].Fitness += _cost;
					}
				}
			}

			//throw new NotImplementedException();
		}
		public override void Evaluate(TrainingDatas td) {
			for (int iSpecie = 0; iSpecie < Species.Count; iSpecie++) {
				// Loop through species

				Species[iSpecie].Fitness = 0;
				for (int iTd = 0; iTd < td.Count; iTd++) {
					// Loop through training datas

					float[] pred = Species[iSpecie].GetPrediction(td[iTd].Input);
					for (int i = 0; i < pred.Length; i++) {
						// Loop througo output neurons

						//float _cost = pred[i] && td[iTd].Target[i];
						float _cost = Rng.FloatingAnd(pred[i], td[iTd].Target[i]);
						Species[iSpecie].Fitness += _cost;
					}
				}
			}
		}
		public override float[][] Decisions() {
			throw new NotImplementedException();
		}
		#endregion
	}
}