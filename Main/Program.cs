using Chaotic_Seer.NEAT;
using Chaotic_Seer.Util;
using System;
using System.Linq;

namespace Main {
	class Program {
		static void Main(string[] args) {
			Neat.Initialize();

			Console.WriteLine("Population: " + Neat.Genomes.Count);
			Console.WriteLine("Species: " + Neat.Species.Count);
			Console.WriteLine();

			// XOR
			TrainingData[] td = {
				new TrainingData(
					new float[2] { 1f, 1f},
					new float[1] { 0f }
				),
				new TrainingData(
					new float[2] { 1f, 0f},
					new float[1] { 1f }
				),
				new TrainingData(
					new float[2] { 0f, 1f},
					new float[1] { 1f }
				),
				new TrainingData(
					new float[2] { 0f, 0f},
					new float[1] { 0f }
				)
			};

			for (int i = 1; i < 800; i++) {
				Genome[] genome = Neat.Genomes.ToArray();

				Neat.Mutate();
				Console.WriteLine("Mutation:\t" + Neat.Genomes.Count);
				Neat.Evaluate(td);
				Neat.Purge();
				Console.WriteLine("Purge:\t\t" + Neat.Genomes.Count);
				Neat.Reproduce();
				Console.WriteLine("Species:\t" + Neat.Species.Count);
				Console.WriteLine("Gen:\t\t" + i);
				Console.WriteLine("=================");
				Console.WriteLine("Pred:\t" + r(Neat.GetOutput(td[0].Input)[0]) + " " +
				r(Neat.GetOutput(td[1].Input)[0]) + " " +
				r(Neat.GetOutput(td[2].Input)[0]) + " " +
				r(Neat.GetOutput(td[3].Input)[0]));
				Console.WriteLine("=================");
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("DONE");
			Console.WriteLine("Pred:\t" + r(Neat.GetOutput(td[0].Input)[0]) + " " +
				r(Neat.GetOutput(td[1].Input)[0]) + "  " +
				r(Neat.GetOutput(td[2].Input)[0]) + " " +
				r(Neat.GetOutput(td[3].Input)[0]));
			Console.ReadLine();


			int r(float a) {
				return a > 0.5 ? 1 : 0;
            }
		}

	}

}
