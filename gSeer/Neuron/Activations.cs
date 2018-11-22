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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer {
    public enum ActivationFunctions {
        Any = 0,
        Logistic = 1,
        TanH = 2,
        ReLu = 3,
        Step = 4
    }
    public abstract class Activations {
        readonly public static Random r = new Random();
        /// <summary>
        /// Returns logistic function
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returns logistic function</returns>
        public float Logistic (float x) {
            return (float) (1 / (1 + Math.Exp(-x)));
        }
        /// <summary>
        /// Returnes derivative of Logistic
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes derivative of Logistic</returns>
        public float LogisticPrime (float x) {
            return Logistic(x) * (1 - Logistic(x));
        }
        /// <summary>
        /// Returnes hyperbolic tangent
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes hyperbolic tangent</returns>
        public float TanH (float x) {
            return (float) Math.Tanh(x);
        }
        /// <summary>
        /// Returnes derivative of HyperbolicTangent
        /// </summary>
        /// <param name="x">Input</param>
        /// <returns>Returnes derivative of HyperbolicTangent</returns>
        float TanHPrime (float x) {
            return  (float) (1 / (Math.Cosh(x) * Math.Cosh(x)));
        }
        //--------------------------------------------------------------
        /// <summary>
        /// Retuns a rectified linear unit
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="trigger">The starting point</param>
        /// <returns>Rectified linerar unit</returns>
        public float ReLU (float x, float trigger = 0.5f) {
            return x > trigger ? x : 0;
        }
        /// <summary>
        /// Returns a Step or 0 and 1
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="trigger">Threshold</param>
        /// <returns>Either 0 or 1</returns>
        public float Step (float x, float trigger = 0.5f) {
            return x > trigger ? 1 : 0;
        }
        /// <summary>
        /// This one calculates axon, added support for multiple AF
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="ActivationFunction">Activation function to use</param>
        /// <returns></returns>
        public float calcAxon (float x, ActivationFunctions ActivationFunction) {
            switch (ActivationFunction) {
                case ActivationFunctions.Any:
                    int af = r.Next(1, 3);
                    switch (af) {
                        case 1: return Logistic(x);
                        case 2: return TanH(x);
                        case 3: return ReLU(x);
                        case 4: return Step(x);
#if DEBUG 
                        default: throw new Exception("Please add the new AF here");
#endif

                    }
                case ActivationFunctions.Logistic: return Logistic(x);
                case ActivationFunctions.TanH: return TanH(x);
                case ActivationFunctions.ReLu: return ReLU(x);
                case ActivationFunctions.Step: return Step(x);
#if DEBUG
                default: throw new Exception("Activation function selection error occured");
#endif
            }
        }
    }

}
