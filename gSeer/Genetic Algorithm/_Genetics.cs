//  gSeer, a C# Artificial Neural Network Library
//  Copyright (C) 2018  Garfunkel Vila
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

using gSeer.Neuron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace gSeer.Genetic_Algorithm {
	/// <summary>
	/// This class contains method for mutations and maybe others.
	/// I did not expect this thing to get this messy. I havent tested this thing.
	/// Codes are based on CodeBullet's tutoral, with my customizations.
	/// 
	/// Formula: (wX * mBias) + (wY * rng).
	/// </summary>
	abstract class Genetics {
		/// <summary>
		/// Use this to mutate two layers
		/// </summary>
		/// <param name="neuronLayerX">First</param>
		/// <param name="neuronLayerY">Second</param>
		/// <param name="mutationBias">Rate of mutation</param>
		/// <returns>Returns the result of the mutation as a NeuronLayer</returns>
		public abstract NeuronLayer Mutate(NeuronLayer neuronLayerX, NeuronLayer neuronLayerY, float mutationBias = 0.5f);
		/// <summary>
		/// Use this to mutate using neuron layer groups from different species where the first one is the dominante gene
		/// </summary>
		/// <param name="neuronLayerGroup"></param>
		/// <param name="mutationBias"></param>
		/// <returns></returns>
		public abstract NeuronLayerGroup Mutate(NeuronLayerGroup[] neuronLayerGroup, float mutationBias = 0.01f);
		public abstract NeuronLayerGroup Mutate(NeuronLayerGroup neuronLayerGroupX, NeuronLayerGroup neuronLayerGroupY, float mutationBias = 0.5f);
		
		/// Debug Functions
		[Conditional("DEBUG")]
		protected void CheckNeuronLayerGroupScheme(NeuronLayerGroup neuronLayerGroupX, NeuronLayerGroup neuronLayerGroupY) {
			/// Check if layers match
			if (neuronLayerGroupX.NeuronLayers.Length != neuronLayerGroupY.NeuronLayers.Length)
				throw new Exception("X and Y Should have the same number of layers.");
			/// Match the number of neurons per layer
			for (int i = 0; i < neuronLayerGroupX.NeuronLayers.Length; i++) {
				if (neuronLayerGroupX.NeuronLayers[i].Neurons.Length != neuronLayerGroupY.NeuronLayers[i].Neurons.Length)
					throw new Exception("X and Y Should have the same number of layers.");
			}
		}
		[Conditional("DEBUG")]
		protected void CheckNeuronLayerScheme(NeuronLayer neuronLayerX, NeuronLayer neuronLayerY) {
			if (neuronLayerX.Neurons.Length != neuronLayerY.Neurons.Length) throw new Exception("X and Y Should have thesame number of neurons.");
		}
		[Conditional("DEBUG")]
		protected void CheckNeuronLayerGroupScheme(NeuronLayerGroup[] neuronLayerGroup) {
			if (neuronLayerGroup.Length == 1) throw new Exception("Cant be solo, use clone instead");
		}
	}
}
