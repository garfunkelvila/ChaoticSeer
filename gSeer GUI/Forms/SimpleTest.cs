using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gSeer;
namespace Nice_Seer.Forms {
    public partial class SimpleTest : Form {
        Seer _seer = new Seer(2, 1, 2,true);
        //Out 1
        TrainingData[] _and = new TrainingData[] {
                new TrainingData(
                    new float[2] { 0, 0 },
                    new float[1] { 0 }
                ),
                new TrainingData(
                    new float[2] { 0, 1 },
                    new float[1] { 1 }
                ),
                new TrainingData(
                    new float[2] { 1, 0 },
                    new float[1] { 0 }
                ),
                new TrainingData(
                    new float[2] { 1, 1 },
                    new float[1] { 1 }
                )
            };
        //Out 1
        TrainingData[] _or = new TrainingData[] {
                new TrainingData(
                    new float[2] { 0, 0 },
                    new float[1] { 0 }
                ),
                new TrainingData(
                    new float[2] { 0, 1 },
                    new float[1] { 1 }
                ),
                new TrainingData(
                    new float[2] { 1, 0 },
                    new float[1] { 1 }
                ),
                new TrainingData(
                    new float[2] { 1, 1 },
                    new float[1] { 1 }
                )
            };
        //Out 0
        TrainingData[] _xor = new TrainingData[] {
                new TrainingData(
                    new float[2] { 0, 0 },
                    new float[1] { 0 }
                ),
                new TrainingData(
                    new float[2] { 0, 1 },
                    new float[1] { 1 }
                ),
                new TrainingData(
                    new float[2] { 1, 0 },
                    new float[1] { 1 }
                ),
                new TrainingData(
                    new float[2] { 1, 1 },
                    new float[1] { 0 }
                )
            };
        public SimpleTest() {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            
        }

        private void button1_Click(object sender, EventArgs e) {
            _seer.Train(_or, (int)trainLoop.Value);
            float _pred1 = _seer.Predict(new float[2] { 0, 0 })[0];
            float _pred2 = _seer.Predict(new float[2] { 0, 1 })[0];
            float _pred3 = _seer.Predict(new float[2] { 1, 0 })[0];
            float _pred4 = _seer.Predict(new float[2] { 1, 1 })[0];
            pred1.Text = "0 :: Prediction: " + _pred1;
            pred2.Text = "1 :: Prediction: " + _pred2;
            pred3.Text = "1 :: Prediction: " + _pred3;
            pred4.Text = "1 :: Prediction: " + _pred4;
            lblCorrect.Text = "Correct: 0 : err : " + _seer.GetError()[0];
            txbLogs.AppendText("err:" + _seer.GetError()[0] + Environment.NewLine);

            l1n1w1.Text = _seer.NeuronLayerGroups.NeuronLayers[0].neurons[0].Weights[0].ToString();
            l1n1w2.Text = _seer.NeuronLayerGroups.NeuronLayers[0].neurons[0].Weights[1].ToString();
            l1n1b.Text = _seer.NeuronLayerGroups.NeuronLayers[0].neurons[0].Bias.ToString();
            l1n1e.Text = _seer.NeuronLayerGroups.NeuronLayers[0].neurons[0].Error.ToString();

            l1n2w1.Text = _seer.NeuronLayerGroups.NeuronLayers[0].neurons[1].Weights[0].ToString();
            l1n2w2.Text = _seer.NeuronLayerGroups.NeuronLayers[0].neurons[1].Weights[1].ToString();
            l1n2b.Text = _seer.NeuronLayerGroups.NeuronLayers[0].neurons[1].Bias.ToString();
            l1n2e.Text = _seer.NeuronLayerGroups.NeuronLayers[0].neurons[1].Error.ToString();

            o1n1w1.Text = _seer.NeuronLayerGroups.NeuronLayers[1].neurons[0].Weights[0].ToString();
            o1n1w2.Text = _seer.NeuronLayerGroups.NeuronLayers[1].neurons[0].Weights[1].ToString();
            o1n1b.Text = _seer.NeuronLayerGroups.NeuronLayers[1].neurons[0].Bias.ToString();
            o1n1e.Text = _seer.NeuronLayerGroups.NeuronLayers[1].neurons[0].Error.ToString();

            //Update color
            l1n1w1.BackColor = weightColor(_seer.NeuronLayerGroups.NeuronLayers[0].neurons[0].Weights[0]);
            l1n1w2.BackColor = weightColor(_seer.NeuronLayerGroups.NeuronLayers[0].neurons[0].Weights[1]);
            l1n2w1.BackColor = weightColor(_seer.NeuronLayerGroups.NeuronLayers[0].neurons[1].Weights[0]);
            l1n2w2.BackColor = weightColor(_seer.NeuronLayerGroups.NeuronLayers[0].neurons[1].Weights[1]);
            
            o1n1w1.BackColor = weightColor(_seer.NeuronLayerGroups.NeuronLayers[1].neurons[0].Weights[0]);
            o1n1w2.BackColor = weightColor(_seer.NeuronLayerGroups.NeuronLayers[1].neurons[0].Weights[1]);
        }

        private Color weightColor(float weight) {
            float newColor = -weight * 255;
            Console.WriteLine("NC: " + (int)newColor);

            int nc = (int)newColor + 255;
            //clamp
            nc = nc > 255 ? 255 : nc;
            nc = nc < 0 ? 0 : nc;

            if (weight > 0) {
                return Color.FromArgb(255, nc, nc);
            }
            else {
                return TextBox.DefaultBackColor;
            }
        }
        private void test() {

        }
    }
}
