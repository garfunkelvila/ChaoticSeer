using gSeer;
using gSeer.Genetic_Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsTest {
	class Program {
		
		static void Main(string[] args) {
			Neat neat = new Neat(3, 3, 100);
			ChaoticSeer g = new ChaoticSeer(neat);
			//Genome g = neat.NewEmptyGenome();
			Console.WriteLine(g.Nodes.Count);
			Console.ReadKey();
		}
	}
}
