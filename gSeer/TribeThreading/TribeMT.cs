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
using gSeer.Util;

namespace gSeer.TribeThreading {
	public class TribeMT : Tribe {
		public TribeMT(int inputSize, int outputSize, int maxPopulation, int maxNodes = 10)
			: base(inputSize, outputSize, maxPopulation, maxNodes) {
		}
		#region EVOLUTION
		public override void Purge() {
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
			Parallel.ForEach(Species, new ParallelOptions() { MaxDegreeOfParallelism = Rng.Cores }, (seer) => {
				//if (seer.AGE_THRESHOLD >= seer.Year) {
					seer.Mutate();
				//}
				//else {
				//	Species.Remove(seer);
				//}
			});
		}
		#endregion

		public override void Train(TrainingData td) {
			//Mutate few times maybe 12, or 100+ don'y know yet
			//Get prediction to all training data, each correct output gives score
			//Purge
			//Reproduce
		}

		#region DECISIONS
		public override void Evaluate(TrainingData[] td) {
			// I just realized I need the BP error function here
			// TODO: use proper cost function

			Parallel.ForEach(Species, new ParallelOptions() { MaxDegreeOfParallelism = Rng.Cores }, (Specie) => {
				// Loop through species

				Specie.Fitness = 0;
				for (int iTd = 0; iTd < td.Length; iTd++) {
					// Loop through training datas

					float[] pred = Specie.GetPrediction(td[iTd].Input);
					for (int i = 0; i < pred.Length; i++) {
						// Loop througo output neurons

						//float _cost = pred[i] && td[iTd].Target[i];
						float _cost = Rng.FloatingAnd(pred[i], td[iTd].Target[i]);
						Specie.Fitness += _cost;
					}
				}
			});

			//throw new NotImplementedException();
		}

		public override void Evaluate(TrainingDatas td) {
			// I just realized I need the BP error function here
			// TODO: use proper cost function

			Parallel.ForEach(Species, new ParallelOptions() { MaxDegreeOfParallelism = Rng.Cores }, (Specie) => {
				// Loop through species

				Specie.Fitness = 0;
				for (int iTd = 0; iTd < td.Count; iTd++) {
					// Loop through training datas

					float[] pred = Specie.GetPrediction(td[iTd].Input);
					for (int i = 0; i < pred.Length; i++) {
						// Loop througo output neurons

						//float _cost = pred[i] && td[iTd].Target[i];
						float _cost = Rng.FloatingAnd(pred[i], td[iTd].Target[i]);
						Specie.Fitness += _cost;
					}
				}
			});
		}

		public override float[][] Decisions() {
			throw new NotImplementedException();
		}
		#endregion
	}
}
