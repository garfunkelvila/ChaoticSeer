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

using Chaotic_Seer.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.DataStructures {
	public class RandomList<T> : IList<T>{
		readonly List<T> Data = new List<T>();

		public T Random {
			get {
				if (Data.Count > 0)
					return Data[Rng.GetInt(Count)];
				throw new Exception("Data is empty");
			}
		}

		public T this[int index] { get => Data[index]; set => Data[index] = value; }
		public int Count => Data.Count;
		public bool IsReadOnly => throw new NotImplementedException();
		public void Add(T item) { Data.Add(item); }
		public void Clear() { Data.Clear(); }
		public bool Contains(T item) { return Data.Contains(item); }
		public void CopyTo(T[] array, int arrayIndex) { Data.CopyTo(array, arrayIndex); }
		public IEnumerator<T> GetEnumerator() { return Data.GetEnumerator(); }
		public int IndexOf(T item) { return Data.IndexOf(item); }
		public void Insert(int index, T item) { Data.Insert(index, item); }
		public bool Remove(T item) { return Data.Remove(item); }
		public void RemoveAt(int index) { Data.RemoveAt(index); }
		IEnumerator IEnumerable.GetEnumerator() {
			throw new NotImplementedException();
		}
	}
}
