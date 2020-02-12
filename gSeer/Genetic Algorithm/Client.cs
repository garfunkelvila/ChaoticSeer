using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gSeer.Calculations;
using gSeer.Data_Structures;
using gSeer.Genetic_Algorithm;
namespace gSeer.Genetic_Algorithm {
	/// <summary>
	/// THis class holds the genomes
	/// </summary>
    public class Client : IComparable<Client> {
        Calculator _Calculator;

        public ChaoticSeer Genome { get; set; }
        public float Score { get; set; }
        public Species Species { get; set; }
        public Client() {

        }
        public void InitializeCalculator() {
			/// Transfer calculator on the genome soon
			/// Genome calculate its own network
            _Calculator = new Calculator(Genome);
        }
        public float[] Calculate(params float[] arr) {
            if (_Calculator == null) InitializeCalculator();
            return _Calculator.Calculate(arr);
        }
        public float Distance(Client other) {
            return Genome.DistanceTo(other.Genome);
        }
        public void Mutate() {
            Genome.Mutate();
        }
        /// <summary>
        /// Test the sort if this is corect
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Client other) {
            if (Score < other.Score) return 1;
            if (Score > other.Score) return -1;
            return 0;
        }
    }
}
