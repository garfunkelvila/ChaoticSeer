using gSeer.Genetic_Algorithm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Data_Structures {
    /// <summary>
    /// A list that uses hashing to see if connection or node is in a list or
    /// not using HashSet.
    /// I just learned that you can do custom list implementations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GeneHashSet<T> : IList<T> {
        public HashSet<T> Hash { get; private set; } = new HashSet<T>();
        public List<T> Data { get; private set; } = new List<T>();

        public T this[int index] {
            get => Data[index];
            set => throw new NotImplementedException();
        }
        public T Random {
            //might need to check if set has items
            get {
                if(Hash.Count > 0)
                    return Data[Util.GetRng(Count)];
                return default;
            } 
        }
        //Might be removed
        //public T get(T template) {
        //    return Data[Data.IndexOf(template)];
        //}
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
            //https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist?view=netframework-4.8
            for (int i = 0; i < Data.Count; i++) {
                array.SetValue(Data[i], arrayIndex++);
            }
            Console.WriteLine("Gene Hash Set CopyTo Triggered");
        }
        public IEnumerator<T> GetEnumerator() {
            throw new NotImplementedException();
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
    }
}
