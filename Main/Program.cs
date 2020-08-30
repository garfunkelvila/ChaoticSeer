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

			// AND
			TrainingData[] td = {
				new TrainingData(
					new float[2] { 1f, 1f},
					new float[1] { 1f }
				),
				new TrainingData(
					new float[2] { 1f, 0f},
					new float[1] { 0f }
				),
				new TrainingData(
					new float[2] { 0f, 1f},
					new float[1] { 0f }
				),
				new TrainingData(
					new float[2] { 0f, 0f},
					new float[1] { 0f }
				)
			};

			for (int i = 1; i < 1000; i++) {
				Neat.BackPropagate(td);
				
				//Console.WriteLine("Mutation:\t" + Neat.Genomes.Count);
				//Neat.Evaluate(td);
				//Neat.Purge();
				//Console.WriteLine("Purge:\t\t" + Neat.Genomes.Count);
				//Neat.Reproduce();
				//Console.WriteLine("Species:\t" + Neat.Species.Count);
				Console.WriteLine("Gen:\t\t" + i);
				Console.WriteLine("=================");
				Console.WriteLine("Pred:\n" +
					(Neat.GetOutput(td[0].Inputs)[0]) + "\n" +
					(Neat.GetOutput(td[1].Inputs)[0]) + "\n" +
					(Neat.GetOutput(td[2].Inputs)[0]) + "\n" +
					(Neat.GetOutput(td[3].Inputs)[0]));
				Console.WriteLine("=================");
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("DONE");
			Console.WriteLine("Pred:\t" + r(Neat.GetOutput(td[0].Inputs)[0]) + " " +
				r(Neat.GetOutput(td[1].Inputs)[0]) + "  " +
				r(Neat.GetOutput(td[2].Inputs)[0]) + " " +
				r(Neat.GetOutput(td[3].Inputs)[0]));
			Console.ReadLine();


			int r(float a) {
				return a > 0.5 ? 1 : 0;
            }
		}

	}

}
