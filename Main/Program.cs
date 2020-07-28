using Chaotic_Seer.NEAT;
using System;

namespace Main {
	class Program {
		static void Main(string[] args) {
            Neat.Initialize();


            Console.WriteLine("Population: " + Neat.Genomes.Count);
            Console.WriteLine("Species: " + Neat.Species.Count);
            for (int i = 0; i < 400; i++) {
                Neat.Mutate();
                Console.WriteLine("Gen: " + i);
                Console.WriteLine("Population: " + Neat.Genomes.Count);
                Console.WriteLine("Species: " + Neat.Species.Count);
            }

            Console.ReadLine();
        }

	}

}
