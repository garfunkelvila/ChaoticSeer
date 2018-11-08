//  Copyright (C) 2018  Garfunkel Vila
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network {
    public enum ActivationFunctions {
        Any = 0,
        Logistic = 1,
        TanH = 2,
        ReLu = 3,
        Step = 4
    }
    public abstract class Activations {
        readonly public static Random r = new Random();
        public double Logistic (double x) {
            return (1 / (1 + Math.Exp(-x)));
        }
        public double LogisticPrime (double x) {
            return Logistic(x) * (1 - Logistic(x));
        }

        public double TanH (double x) {
            return Math.Tanh(x);
        }

        double TanHPrime (double x) {
            return 1 / (Math.Cosh(x) * Math.Cosh(x));
        }

        /// <summary>
        /// Specify starting point at trigger
        /// </summary>
        /// <param name="x"></param>
        /// <param name="trigger">The starting point</param>
        /// <returns></returns>
        public double ReLU (double x, double trigger = 0.5) {
            return x > trigger ? x : 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Step (double x, double trigger = 0.5) {
            return x > trigger ? 1 : 0;
        }
        /// <summary>
        /// This one adds randomness.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="ActivationFunction"></param>
        /// <returns></returns>
        public double calcAxon (double x, ActivationFunctions ActivationFunction) {
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
