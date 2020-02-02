using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Genetic_Algorithm {
    /// <summary>
    /// Might rename this to CNS
    /// </summary>
    public class Neat {
        public const float WEIGHT_SHIFT_STRENGTH = 0.3f;
        public const float WEIGHT_RANDOM_STRENGTH = 1.0f;

        public const float PROBABILITY_MUTATE_CONNECTION = 0.005f;
        public const float PROBABILITY_MUTATE_NODE = 0.003f;
        public const float PROBABILITY_MUTATE_WEIGHT_SHIFT = 0.025f;
        public const float PROBABILITY_MUTATE_WEIGHT_RANDOM = 0.0f;
        public const float PROBABILITY_MUTATE_TOGGLE = 0.005f;
        ///Protecting Innovation through Speciation
        public float C1 { get; }
        public float C2 { get; }
        public float C3 { get; }
        public int InputSize { get; set; }  //Sensor
        public int OutputSize { get; set; } //Motor
    }
}
