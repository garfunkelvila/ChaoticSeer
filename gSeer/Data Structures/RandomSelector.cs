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

namespace gSeer.GeneticAlgorithm {
    /// <summary>
    /// I just learned that you can do custom list implementations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RandomSelector<T> {
        private readonly List<T> seers = new List<T>();
        private readonly List<float> scores = new List<float>();
        public float TotalScore = 0;
        /// <summary>
        /// Add a seer with its score, 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="score"></param>
        public void Add(T element, float score) {
            seers.Add(element);
            scores.Add(score);
            TotalScore += score;
        }
        /// <summary>
        /// Returns a random seer based on score
        /// </summary>
        /// <returns>Returns a random seer based on score</returns>
        public T Random() {
            float v = Rng.GetRngF() * TotalScore;
            float c = 0;
            for (int i = 0; i < seers.Count; i++) {
                c += scores[i];
                if(c >= v) 
                    return seers[i];
            }
            return default(T);
        }
        public void Reset() {
            seers.Clear();
            scores.Clear();
            TotalScore = 0;
        }
    }
}
