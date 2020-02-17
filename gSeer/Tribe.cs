using gSeer.Data_Structures;
using gSeer.Genetic_Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer {
	/// <summary>
	/// Might rename this to Tribe
	/// </summary>
	public class Tribe {
		public GeneHashSet<ChaoticSeer> Species { get; set; }
		public ChaoticSeer Representative { get; set; }
		public NeatCNS Neat { get; set; }
		/// <summary>
		/// Create a batch of species filled with Genomes
		/// </summary>
		/// <param name="inputSize"></param>
		/// <param name="outputSize"></param>
		public Tribe(int inputSize, int outputSize, int maxPopulation) {
			Neat = new NeatCNS(inputSize, outputSize);
			Species = new GeneHashSet<ChaoticSeer>();
			for (int i = 0; i < maxPopulation; i++) {
				Species.Add(new ChaoticSeer(Neat) {
					Identity = i
				});
			}
			Representative = Species[0];
		}
		/// <summary>
		/// Create a batch of species filled with Genomes
		/// </summary>
		#region EVOLUTION
		public void Evolve() {
			//Populate();		// Base of natural selection // Create population
			///Kill();				//Basically like going extinct for now // Base of natural selection
			///Reproduce();		// Load up population by mating. Spread on some passing of genes
			Mutate();			// Evolve each species internally // Mutated babies
			//Calculate();		// Get their predictions, and probably 
			//Evaluate();		// set their scores
		}
		/// <summary>
		/// Natural Selection
		/// </summary>
		public void Purge() {
			//TODO: add somehting to make the fittest survive
			int speciesKilled = 0;
			for (int i = 0; i < Species.Count; i++) {
				if(Species[i].SURVIVAL_THRESHOLD > Util.GetRngF()) {
					Species.RemoveAt(i);
					speciesKilled++;
				}
			}
			Console.WriteLine("speciesKilled: " + speciesKilled);
		}
		/// <summary>
		/// Reproduce by mating with others
		/// </summary>
		public void Reproduce() {
			//Use mutate with to fill population
			//GeneHashSet<ChaoticSeer> selector = _Species;

			// Mutate with 10 times for now
			// TODO: add something to prevent mutation with self
			for (int i = 0; i < 1; i++) {
				ChaoticSeer _seerX = Species.Random;
				ChaoticSeer _seerY = Species[i];
				ChaoticSeer _seerChild = _seerY.MateWith(_seerX);
				_seerChild.Identity = Species.Count;
				Species.Add(_seerChild);
			}
		}
		/// <summary>
		/// Mutate self, like self evolve
		/// </summary>
		public void Mutate() {
			foreach (ChaoticSeer seer in Species) {
				seer.Mutate();
			}
		}
		public void Evaluate() {
			// Basically just give them their score
			throw new NotImplementedException();
		}
		#endregion
	}
}
