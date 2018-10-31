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

        static LayerGroup[] Seers;

        public frmMain () {
            InitializeComponent();
            watch = new System.Diagnostics.Stopwatch();
            r = new Random();           
        }

        private void btnGo_Click (object sender, EventArgs e) {
            string logB = "";

            double[] _in = new double[8];
            _in[0] = double.Parse(textBox1.Text);
            _in[1] = double.Parse(textBox2.Text);
            _in[2] = double.Parse(textBox3.Text);
            _in[3] = double.Parse(textBox4.Text);
            _in[4] = double.Parse(textBox5.Text);
            _in[5] = double.Parse(textBox6.Text);
            _in[6] = double.Parse(textBox7.Text);
            _in[7] = double.Parse(textBox8.Text);





            txbLogs.AppendText("Started calculating" + Environment.NewLine);
            Parallel.For(0, Seers.Length, seer => {
                double[] ins = new double[8];
                ins[0] = _in[0];
                ins[1] = _in[1];
                ins[2] = _in[2];
                ins[3] = _in[3];
                ins[4] = _in[4];
                ins[5] = _in[5];
                ins[6] = _in[6];
                ins[7] = _in[7];
                double[] outs = Seers[seer].Decide(ins);

                logB += "" + outs[0] + outs[1] + outs[2] + outs[3] + Environment.NewLine;
            });
            txbLogs.AppendText(logB + Environment.NewLine);
            txbLogs.AppendText("Done calculating" + Environment.NewLine);
        }

        private void btnInit_Click (object sender, EventArgs e) {
            Seers = new LayerGroup[4096]; //Number of seers
            txbLogs.AppendText("Initializing..." + Environment.NewLine);
            /*Parallel.For(0, Seers.Length, seer => {
                NeuronLayer[] nL = new NeuronLayer[8];
                nL[0] = new NeuronLayer(8, 16);
                nL[1] = new NeuronLayer(16, 32);
                nL[2] = new NeuronLayer(32, 64);
                nL[3] = new NeuronLayer(64, 128);
                nL[4] = new NeuronLayer(128, 128);
                nL[5] = new NeuronLayer(128, 64);
                nL[6] = new NeuronLayer(64, 16);
                nL[7] = new NeuronLayer(16, 4, ActivationFunctions.Step);

                Seers[seer] = new LayerGroup(nL);

            });*/

            for (int i = 0; i < Seers.Length; i++) {
                NeuronLayer[] nL = new NeuronLayer[8];
                nL[0] = new NeuronLayer(8, 16);
                nL[1] = new NeuronLayer(16, 32);
                nL[2] = new NeuronLayer(32, 64);
                nL[3] = new NeuronLayer(64, 128);
                nL[4] = new NeuronLayer(128, 128);
                nL[5] = new NeuronLayer(128, 64);
                nL[6] = new NeuronLayer(64, 16);
                nL[7] = new NeuronLayer(16, 4, ActivationFunctions.Step);

                Seers[i] = new LayerGroup(nL);
            }




            txbLogs.AppendText("Initalize done" + Environment.NewLine);
        }

        private void button1_Click (object sender, EventArgs e) {
            NeuronLayer[] nL = new NeuronLayer[8];
            nL[0] = new NeuronLayer(8, 16);
            nL[1] = new NeuronLayer(16, 32);
            nL[2] = new NeuronLayer(32, 64);
            nL[3] = new NeuronLayer(64, 128);
            nL[4] = new NeuronLayer(128, 128);
            nL[5] = new NeuronLayer(128, 64);
            nL[6] = new NeuronLayer(64, 16);
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
        //Create a seer with 8 input neurons with 4 output neurons with 16x8 hidden layers
        //After this, try the mutation explained by CodeBullet

        //Single seer first before 1000 seers
        /*NeuronLayer[] nL = new NeuronLayer[8];
        nL[0] = new NeuronLayer(8, 16);
        nL[1] = new NeuronLayer(16, 32);
        nL[2] = new NeuronLayer(32, 64);
        nL[3] = new NeuronLayer(64, 128);
        nL[4] = new NeuronLayer(128, 128);
        nL[5] = new NeuronLayer(128, 64);
        nL[6] = new NeuronLayer(64, 16);
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
        textBox12.Text = outs[3].ToString();*/
    }
}
