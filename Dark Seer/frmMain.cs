using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neural_Network;
namespace Dark_Seer {
    public partial class frmMain : Form {
        System.Diagnostics.Stopwatch watch;
        Random r;
        neuralNetwork nn;

        public frmMain () {
            InitializeComponent();
            watch = new System.Diagnostics.Stopwatch();
            r = new Random();
        }

        private void btnGo_Click (object sender, EventArgs e) {
            //Create a seer with 8 input neurons with 4 output neurons with 16x8 hidden layers
            //After this, try the mutation explained by CodeBullet

            //Single seer first before 1000 seers
            NeuronLayer[] nL = new NeuronLayer[8];
            nL[0] = new NeuronLayer(8, 16);
            nL[1] = new NeuronLayer(16, 16);
            nL[2] = new NeuronLayer(16, 16);
            nL[3] = new NeuronLayer(16, 16);
            nL[4] = new NeuronLayer(16, 16);
            nL[5] = new NeuronLayer(16, 16);
            nL[6] = new NeuronLayer(16, 16);
            nL[7] = new NeuronLayer(16, 4, ActivationFunctions.Step);

            LayerGroup lG = new LayerGroup(nL);

            double[] ins = new double[8];
            ins[0] = double.Parse(textBox1.Text);
            ins[1] = double.Parse(textBox2.Text);
            ins[2] = double.Parse(textBox3.Text);
            ins[3] = double.Parse(textBox4.Text);
            ins[4] = double.Parse(textBox5.Text);
            ins[5] = double.Parse(textBox6.Text);
            ins[6] = double.Parse(textBox7.Text);
            ins[7] = double.Parse(textBox8.Text);

            double[] outs = lG.Decide(ins);
            textBox9.Text = outs[0].ToString();
            textBox10.Text = outs[1].ToString();
            textBox11.Text = outs[2].ToString();
            textBox12.Text = outs[3].ToString();
        }
    }
}
