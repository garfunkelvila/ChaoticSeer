using System;
using System.Collections.Generic;
using System.Text;

namespace Chaotic_Seer.Util {
    public class TrainingData {
        public float[] Input { get; }
        public float[] Output { get; }
        public TrainingData(float[] Input, float[] Output) {
            this.Input = Input;
            this.Output = Output;
        }
    }
}
