using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Seer.neuralNetwork {
    class NeuralNetwork {
        private static Random r = new Random();
        public class Dendrite {
            public Dendrite () { Weight = (float) r.NextDouble(); }
            public float Weight {get; set;}
        }
        public class Neuron {
            public List<Dendrite> Dendrites { get; set; }
            public float Bias { get; set; }
            public float Value { get; set; }
            public float Delta { get; set; }
            public int DendriteCount { get { return Dendrites.Count; } }
            public Neuron () {
                Bias = (float)r.NextDouble();
                Dendrites = new List<Dendrite>();
            }
        }
        public class Layer {
            public List<Neuron> Neurons { get; set; }
            public Layer(int neuronNum) {
                Neurons = new List<Neuron>(neuronNum);
            }
        }
        public List<Layer> Layers { get; set; }
        public float LearningRate { get; set; }
        public NeuralNetwork (float lr, List<int> nLayers) {
            if (nLayers.Count < 2) return;
            Layers = new List<Layer>();
            //Neuron neuronBuffer = new Neuron();

            LearningRate = lr;
            for (int i = 0; i < nLayers.Count; i++) {
                Layer l = new Layer(nLayers[i] - 1);
                Layers.Add(l);
                for (int ii = 0; ii < nLayers[i]; ii++) {
                    l.Neurons.Add(new Neuron());
                }
                foreach (Neuron n in l.Neurons) {
                    for (int iii = 0; iii < nLayers[i]; iii++) {
                        n.Dendrites.Add(new Dendrite());
                    }
                }
            }
        }
        public List<float> Execute(List<float> inputs) {
            List<float> outputs = new List<float>();
            if (inputs.Count != Layers[0].Neurons.Count()){
                return outputs;
                throw new Exception("Returned Nothing");
            }
            for (int i = 0; i < Layers.Count(); i++) {
                Layer curLayer = Layers[i];
                for (int ii = 0; ii < curLayer.Neurons.Count(); ii++) {
                    Neuron curNeuron = curLayer.Neurons[ii];
                    if(ii == 0) {
                        curNeuron.Value = inputs[ii];
                    }
                    else {
                        curNeuron.Value = 0;
                        for (int iii = 0; iii < Layers[ii - 1].Neurons.Count(); iii++) {
                            curNeuron.Value += Layers[i - 1].Neurons[iii].Value * curNeuron.Dendrites[iii].Weight;
                        }
                        curNeuron.Value = Sigmoid(curNeuron.Value + curNeuron.Bias);
                    }
                }
            }
            
            Layer l = Layers[Layers.Count - 1];
            for (int i = 0; i < l.Neurons.Count(); i++) {
                outputs.Add(l.Neurons[i].Value);
            }
            return outputs;
        }
        public static float Sigmoid(float v) { return  (float)(1 / (1 + Math.Exp(v * -1))); }
    }
}
