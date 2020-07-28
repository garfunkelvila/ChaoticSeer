using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.NEAT {
	class Genome {
		public Genome() {
		}

		public Genome(bool preMutate) {
		}

		/// <summary>
		/// Use speciation to compare
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }
    }
}
