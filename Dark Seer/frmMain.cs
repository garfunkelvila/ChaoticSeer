using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dark_Seer {
    public partial class frmMain : Form {
        neuralNetwork.NeuralNetwork nn;
        public frmMain () {
            InitializeComponent();

            List<int> layers = new List<int>();
            layers.Add(5);
            layers.Add(10);
            nn = new neuralNetwork.NeuralNetwork(5, layers);
        }
        private void button1_Click (object sender, EventArgs e) {
            List<float> inputs = new List<float>();
            inputs.Add(0f);
            inputs.Add(0.9f);
            label1.Text = "Output: " + nn.Execute(inputs);
        }

        private void timer1_Tick (object sender, EventArgs e) {
            
        }
    }
}
