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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer {
    public class TrainingData {
        readonly public float[] Input;
        readonly public float[] Target;
        /// <summary>
        /// Create a single set of Training data
        /// </summary>
        /// <param name="I">Input</param>
        /// <param name="O">Output</param>
        public TrainingData (float[] I, float[] O) {
            Input = I;
            Target = O;
        }
    }

	public class TrainingDatas : IList<TrainingData> {
		List<TrainingData> _TrainingDatas;
		/// <summary>
		/// Cache of theoreticaly max fitness for the given training data
		/// </summary>
		public int MaxFitness { get; private set; } = 0;

		public TrainingDatas() {
			_TrainingDatas = new List<TrainingData>();
		}
		public TrainingData this[int index] {
			get => _TrainingDatas[index];
			set {
				MaxFitness -= _TrainingDatas[index].Target.Length;
				MaxFitness += value.Target.Length;
				_TrainingDatas[index] = value;
			}
		}

		public int Count => _TrainingDatas.Count;

		public bool IsReadOnly => false;

		public void Add(TrainingData item) {
			_TrainingDatas.Add(item);
			
			MaxFitness += item.Target.Length;
		}

		public void Clear() {
			_TrainingDatas.Clear();
		}

		public bool Contains(TrainingData item) {
			return _TrainingDatas.Contains(item);
		}

		public void CopyTo(TrainingData[] array, int arrayIndex) {
			_TrainingDatas.CopyTo(array, arrayIndex);
		}

		public IEnumerator<TrainingData> GetEnumerator() {
			return _TrainingDatas.GetEnumerator();
		}

		public int IndexOf(TrainingData item) {
			return _TrainingDatas.IndexOf(item);
		}

		public void Insert(int index, TrainingData item) {
			_TrainingDatas.Insert(index, item);
			MaxFitness += item.Target.Length;
		}

		public bool Remove(TrainingData item) {
			MaxFitness -= item.Target.Length;
			return _TrainingDatas.Remove(item);
		}

		public void RemoveAt(int index) {
			MaxFitness -= _TrainingDatas[index].Target.Length;
			_TrainingDatas.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _TrainingDatas.GetEnumerator();
		}
	}
}
