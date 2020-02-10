using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Genetic_Algorithm {
    /// <summary>
    /// I just learned that you can do custom list implementations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class RandomSelector<T> {
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
            float v = Util.GetRngF() * TotalScore;
            float c = 0;
            for (int i = 0; i < seers.Count; i++) {
                c += scores[i];
                if(c > v) 
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
