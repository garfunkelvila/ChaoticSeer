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
        public double Logistics (double x) {
            return (1 / (1 + Math.Exp(-x)));
        }
        /// <summary>
        /// Based on https://en.wikipedia.org/wiki/Logistic_function
        /// </summary>
        /// <param name="x"></param>
        /// <param name="k">the steepness of the curve</param>
        /// <param name="L">the curve's maximum value</param>
        /// <param name="X0">the x-value of the sigmoid's midpoint</param>
        /// <returns></returns>
        public virtual double Logistics (double x, double k = 1, double L = 1, double X0 = 0.0f) {
#if DEBUG
            if (k < 0) throw new Exception("Steepness cant be negative");
            //if (L < X0) throw new Exception("maxValue is lower than midPoint");
            //if (X0 < 0.5f) throw new Exception("midPoint just dont");
#endif
            return (L / (1 + Math.Exp(-k * (x - X0))));
        }
        public double LogisticPrime (double x) {
            return Logistics(x) * (1 - Logistics(x));
        }

        public double TanH (double x) {
            return Math.Tanh(x);
            //return ((Math.Exp(x)) - (Math.Exp(-x))) / ((Math.Exp(x)) + (Math.Exp(-x)));
        }

        double TanHPrime (double x) {
            //I know it is different, but just for now xD
            return Math.Tanh(x) * (1 - Math.Tanh(x));
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
                        case 1: return Logistics(x);
                        case 2: return TanH(x);
                        case 3: return ReLU(x);
                        case 4: return Step(x);
#if DEBUG 
                        default: throw new Exception("Please add the new AF here");
#endif

                    }
                case ActivationFunctions.Logistic: return Logistics(x);
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
