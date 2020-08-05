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
			TrainingData td = new TrainingData(
					new float[2] { 1f, 0f},
					new float[1] { 1f }
				);

			for (int i = 1; i < 400; i++) {
				Genome[] genome = Neat.Genomes.ToArray();

				Neat.Mutate();
				Console.WriteLine("Mutation:\t" + Neat.Genomes.Count);
				Neat.Evaluate(td);
				Neat.Purge();
				Console.WriteLine("Purge:\t\t" + Neat.Genomes.Count);
				Console.WriteLine("Species:\t" + Neat.Species.Count);
				Console.WriteLine("Gen:\t\t" + i);
				Console.WriteLine("=================");
			}

			Console.ReadLine();
		}

	}

}
