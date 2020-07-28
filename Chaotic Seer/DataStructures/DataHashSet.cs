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
using System.Text;

namespace Chaotic_Seer.DataStructures {
	public class DataHashSet<T> : IList<T> {
		// Local Variable containers
		public HashSet<T> Hash { get; private set; } = new HashSet<T>();
		public List<T> Data { get; private set; } = new List<T>();

		// Implementations
		public T this[int index] {
			get => Data[index]; set => throw new NotImplementedException();
		}

		public int Count => Data.Count;

		public bool IsReadOnly => false;

		public void Add(T item) {
			if (!Hash.Contains(item)) {
				Hash.Add(item);
				Data.Add(item);
			}
		}

		public void Clear() {
			Hash.Clear();
			Data.Clear();
		}

		public bool Contains(T item) {
			return Hash.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex) {
			Data.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator() {
			return Data.GetEnumerator();
		}

		public int IndexOf(T item) {
			return Data.IndexOf(item);
		}

		public void Insert(int index, T item) {
			throw new NotImplementedException();
		}

		public bool Remove(T item) {
			Hash.Remove(item);
			Data.Remove(item);
			return true;
		}

		public void RemoveAt(int index) {
			Hash.Remove(Data[index]);
			Data.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			throw new NotImplementedException();
		}

		public T Random {
			get {
				if (Data.Count > 0)
					return Data[Rng.GetRng(Count)];
				throw new Exception("Data is empty");
			}
		}
	}
}
