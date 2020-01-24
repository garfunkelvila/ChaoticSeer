using gSeer;
using gSeer.Genetic_Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsTest {
	class Program {
		static Country nemic;
		static TrainingData[] _xor = new TrainingData[] {
				new TrainingData(
					new float[2] { 0, 0 },
					new float[1] { 0 }
				),
				new TrainingData(
					new float[2] { 0, 1 },
					new float[1] { 1 }
				),
				new TrainingData(
					new float[2] { 1, 0 },
					new float[1] { 1 }
				),
				new TrainingData(
					new float[2] { 1, 1 },
					new float[1] { 0 }
				)
			};
		static void Main(string[] args) {
			InitializeSeers(50);
			FirstPrediction();
			do {
				Console.Write("Enter gen limit: ");
				StartChaos(int.Parse(Console.ReadLine()));
				FirstPrediction();
			} while (true);
		}
		static private void InitializeSeers(int count) {
			Console.WriteLine("Cores" + Environment.ProcessorCount);
			Console.WriteLine("Initializing Seer...");
			/// Use the template converter to create a template from newly created seer
			Seer _TestSeer = new Seer(2, 1, 2);
			TSeer _TestSeerTemplate = new TSeer(_TestSeer);
			nemic = new Country(_TestSeerTemplate, count);

			Console.WriteLine(nemic.Seers.Length + " seers Initialized");
			Console.WriteLine();
		}
		static private void FirstPrediction() {
			Console.WriteLine("Listing prediction...");
			Array.Sort(nemic.Seers);
			nemic.CalcFitness(_xor);
			foreach (Seer _seer in nemic.Seers) {
				
				Console.Write(_seer.Predict(_xor[0].Input)[0] + " \t ");
				Console.Write(_seer.Predict(_xor[1].Input)[0] + " \t ");

				Console.Write(_seer.Predict(_xor[2].Input)[0] + " \t ");
				Console.Write(_seer.Predict(_xor[3].Input)[0] + " \t|-> ");
				Console.Write(_xor[0].Target[0] + "");
				Console.Write(_xor[1].Target[0] + "");
				Console.Write(_xor[2].Target[0] + "");
				Console.Write(_xor[3].Target[0] + "\t");
				Console.Write("F:" + _seer.Fitness + "\t");
				Console.WriteLine("E:" + _seer.GetError()[0]);
			}

			Console.WriteLine("Prediction end");
			Console.WriteLine();
		}

		static private void StartChaos(int Loop) {
			Console.WriteLine("Training until: " + Loop + " generations");
			nemic.Train(_xor, Loop);
		}
	}
}
