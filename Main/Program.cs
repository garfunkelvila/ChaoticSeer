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

			TrainingData td = new TrainingData(
					new float[2] { 1f, 0f},
					new float[1] { 1f }
				);

			for (int i = 1; i < 400; i++) {
				Genome[] genome = Neat.Genomes.ToArray();

				Neat.Mutate();
				Neat.Evaluate(td);
				Neat.Purge();
				Console.WriteLine("Gen: " + i);
				Console.WriteLine("Population: " + Neat.Genomes.Count);
				Console.WriteLine("Species: " + Neat.Species.Count);
			}

			Console.ReadLine();
		}

	}

}
