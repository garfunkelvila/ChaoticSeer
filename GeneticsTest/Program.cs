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
		static TrainingData[] _and = new TrainingData[] {
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
					new float[1] { 0 }
				),
				new TrainingData(
					new float[2] { 1, 1 },
					new float[1] { 1 }
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
			nemic.CalcFitness(_and);
			foreach (Seer _seer in nemic.Seers) {
				
				Console.Write(_seer.Predict(_and[0].Input)[0] + " \t ");
				Console.Write(_seer.Predict(_and[1].Input)[0] + " \t ");

				Console.Write(_seer.Predict(_and[2].Input)[0] + " \t ");
				Console.Write(_seer.Predict(_and[3].Input)[0] + " \t|-> ");
				Console.Write(_and[0].Target[0] + "");
				Console.Write(_and[1].Target[0] + "");
				Console.Write(_and[2].Target[0] + "");
				Console.Write(_and[3].Target[0] + "\t");
				Console.WriteLine("F:" + _seer.Fitness + "\t");
				//Console.WriteLine("E:" + _seer.GetError()[0]);
			}

			Console.WriteLine("Prediction end");
			Console.WriteLine();

			Seer topSeer = nemic.Seers[0];

			Console.WriteLine("First Seer Status");
			Console.WriteLine("Layer 1 ==================");
			Console.WriteLine("\tNeuron 1 ------------------");
			Console.Write("\t\tW1: " + topSeer.NeuronLayerGroups.NeuronLayers[0].Neurons[0].Weights[0] + "\t");
			Console.Write("\t\tW2: " + topSeer.NeuronLayerGroups.NeuronLayers[0].Neurons[0].Weights[1] + "\t");
			Console.Write("\t\tB: " + topSeer.NeuronLayerGroups.NeuronLayers[0].Neurons[0].Bias + "\t");
			Console.WriteLine();
			Console.WriteLine("\tNeuron 2 ------------------");
			Console.Write("\t\tW1: " + topSeer.NeuronLayerGroups.NeuronLayers[0].Neurons[1].Weights[0] + "\t");
			Console.Write("\t\tW2: " + topSeer.NeuronLayerGroups.NeuronLayers[0].Neurons[1].Weights[1] + "\t");
			Console.Write("\t\tB: " + topSeer.NeuronLayerGroups.NeuronLayers[0].Neurons[1].Bias + "\t");
			Console.WriteLine();
			Console.WriteLine("Layer 2 ==================");
			Console.WriteLine("\tNeuron 1 ------------------");
			Console.Write("\t\tW1: " + topSeer.NeuronLayerGroups.NeuronLayers[1].Neurons[0].Weights[0] + "\t");
			Console.Write("\t\tW2: " + topSeer.NeuronLayerGroups.NeuronLayers[1].Neurons[0].Weights[1] + "\t");
			Console.Write("\t\tB: " + topSeer.NeuronLayerGroups.NeuronLayers[1].Neurons[0].Bias + "\t");
			Console.WriteLine();
			Console.WriteLine();
		}

		static private void StartChaos(int Loop) {
			Console.WriteLine("Training until: " + Loop + " generations");
			nemic.Train(_and, Loop);
		}
	}
}
