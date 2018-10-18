using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ALLOW SOMEHING LIKE THIS, ISOLATED LAYERS
// *-*-*-*-*-*-*-*-*-*
// *-*-*-*-*-*-*-*-*-*-*
// *-*-*-*-*-*-*-*-*-*-*-*-*-*
//         *-*-*-*-*-*-*-*-*-*
// *-*-*-*-*-*-*-*-*-*-*-*-*-*
// *-*-*-*-*-*-*-*-*-*-*-*-*-*
// *-*-*-*-*-*-*-*-*-*-*-*-*-*
//         *-*-*-*-*-*-*-*-*-*
// *-*-*-*-*-*-*-*-*-*-*-*-*-*
// *-*-*-*-*-*-*-*-*-*-*
// *-*-*-*-*-*-*-*-*-*
namespace Neural_Network {
    enum NeuronTypes {
        Sensory = 1,
        Inter = 2,
        Motor = 3
    }
    class NeuronLayer {
        public NeuronLayer (int count) {
            this.neurons = new Neuron[count];
            for (int i = 0; i < count; i++) {
                neurons[i] = new Neuron(3);
            }
        }
        void setUp () {
            
        }
        Neuron[] neurons { get; set; }
        //Add input
        //Add output
    }
}
