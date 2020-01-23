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
        /// the chaotic simulation thing.
        /// </summary>
        public void Train(TrainingData[] trainingData) {
            CalcFitness(trainingData );
            //Array.Sort(Seers);
            Console.WriteLine("Sorting Test");
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
            /// less error difference, more fitness
            /// Loop through all training data, no skip. More TD affects fitness
            /// calculation with others

            /// Loop through seers in parallel
            Parallel.For(0, Seers.Length, new ParallelOptions { MaxDegreeOfParallelism = Util.Cores }, i => {
                float _fitnessBuffer = 0.0f;
                /// Loop through training data
                for (int iTd = 0; iTd < td.Length; iTd++) {
                    float[] _predBuffer = Seers[i].Predict(td[iTd].Input);
                    
                    /// Loop through outputs and expected output
                    for (int iPb = 0; iPb < _predBuffer.Length; iPb++) {
                        /// Calc error and stack
                        float _errBuffer;
                        /// THis process may push positive numbers greately. Must find a better solution
                        _errBuffer = td[iTd].Target[iPb] - _predBuffer[iPb];  /// Near zero is less error
                        _errBuffer = Math.Abs(_errBuffer) * -1;             /// Make all negative
                        _errBuffer = _errBuffer + 1;                        /// Offset

                        _fitnessBuffer += _errBuffer;
                    }
                }
                Seers[i].Fitness = _fitnessBuffer;
            });

        }
    }
}
