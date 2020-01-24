//  gSeer, a C# Artificial Neural Network Library
//  Copyright (C) 2018  Garfunkel Vila
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
using System.Threading.Tasks;

namespace gSeer.Genetic_Algorithm {

    public class Country {
        /// I might need an indexer for the fitness function
        public Seer[] Seers { get; }
        public Country(TSeer _seer, int seerCount) {
            Seers = new Seer[seerCount];
            for (int i = 0; i < Seers.Length; i++) {
                Seers[i] = new Seer(_seer);
            }
        }
		/// <summary>
		/// Use this if there is a training data. Access the seer directly for
		/// the chaotic simulation thing. For now it will be like Thanos 50:50
		/// </summary>
		/// <param name="trainingData"></param>
		public void Train(TrainingData[] trainingData, int GenIteration) {
			for (int i = 0; i < GenIteration; i++) {
				/// This one fills the fitness for each seer for it to be sortable
				CalcFitness(trainingData);
				Array.Sort(Seers);
				int Thanos = Seers.Length / 2; //Replace the half of population
				for (int iSeer = Thanos; iSeer < Seers.Length; iSeer++) {
					Seers[iSeer] = Seers[Util.GetRngMinMax(0, Thanos)].MutateWith(Seers[Util.GetRngMinMax(0, Thanos)]);
				}
			}
			CalcFitness(trainingData);
			Array.Sort(Seers);
		}

        /// <summary>
        /// Get the predictions of all seer
        /// </summary>
        /// <param name="Sensories"></param>
        /// <returns></returns>
        public float[][] Predict(float[] Sensories) {
            float[][] _predBuffer = new float[Seers.Length][];
			Parallel.For(0, Seers.Length, new ParallelOptions { MaxDegreeOfParallelism = Util.Cores }, i => {
			    _predBuffer[i] = Seers[i].Predict(Sensories);
			});
            return _predBuffer;
        }
        /// <summary>
        /// This function calculates the fitness off each seers relative to the
        /// training data
        /// </summary>
        /// <param name="td"></param>
        public void CalcFitness(TrainingData[] td) {
			/// Loop through seers in parallel
			Parallel.For(0, Seers.Length, new ParallelOptions { MaxDegreeOfParallelism = Util.Cores }, i => {
				int tDr = Util.GetRngMinMax(0, td.Length);
				Seer seer = Seers[i];

				float[] _Pred = seer.Predict(td[tDr].Input);
				float _FitnessBuffer = 0.0f;
				for (int n = 0; n < _Pred.Length; n++) {
					_FitnessBuffer += td[tDr].Target[n] - _Pred[n];
				}

				Seers[i].Fitness = _FitnessBuffer;
			});
		}
    }
}
