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

using gSeer.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Genetic_Algorithm {
    public class ConnectionGene : Gene {
        public NodeGene From { get; set; }
        public NodeGene To { get; set; }
        public float Weight { get; set; }
        public bool IsEnabled { get; set; }
        public int ReplaceIndex { get; set; }
        public override int InnovationNumber { get; set; }
        public ConnectionGene(bool isEnabled = true) {
            IsEnabled = isEnabled;
        }
        public ConnectionGene(NodeGene from, NodeGene to) : this() {
            From = from;
            To = to;
        }
        public override bool Equals(object obj) {
            if (!GetType().Equals(obj.GetType())) return false;
            ConnectionGene cg = (ConnectionGene)obj;
            return (From.Equals(cg.From) && To.Equals(cg.To));
        }
        public override int GetHashCode() {
            return From.InnovationNumber * NeatCNS.MAX_NODES + To.InnovationNumber;
        }
    }
}
