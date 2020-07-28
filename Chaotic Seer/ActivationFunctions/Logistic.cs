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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seer.ActivationFunctions {
    class Logistic : ActivationFunction {
        protected override float CalcAxon(float x) {
            return (float)(1 / (1 + Math.Exp(-x)));
        }

        protected override float CalcAxon(float x, float y) {
            throw new NotImplementedException();
        }

        protected override float CalcDerv(float x) {
            float _logistic = new Logistic().CalcAxon(x);
            return _logistic * (1 - _logistic);
        }

        protected override float CalcDerv(float x, float y) {
            throw new NotImplementedException();
        }
    }
}
