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
        List<Seer> Seers;
        //Seer[] Seers;
        SeerVisualizer[] sv;
        

        double[] _in = new double[8];
        double[] correctAns = new double[4];
        int correctSeers = 0;

        public frmMain () {
            InitializeComponent();
            watch = new System.Diagnostics.Stopwatch();
            r = new Random();
            Seers = new List<Seer>();

        }

        private void btnInit_Click (object sender, EventArgs e) {
            for (int i = 0; i < 4096; i++) {
                Seers.Add(new Seer());  //This thing cause massive memory, maybe because of many not simmilar number within its class
            }
        }

        private void btnGo_Click (object sender, EventArgs e) {
            //This will be transfered to a kind of planet class, mini batched by countries
            //Generation reset or something
            /*Parallel.For(0,
                Seers.Count,
                seer => {
                    Seers[seer].isCorrect = false;
                }
            );*/
        }


        private void DecideAll () {
            //This will be transfered to a kind of planet class, mini batched by countries
            /*
            Parallel.For(0,
                Seers.Count,
                new ParallelOptions {
                    MaxDegreeOfParallelism = 128
                },
                seer => {
                    //https://stackoverflow.com/questions/15931346/how-to-configure-a-maximum-number-of-threads-in-a-parallel-for
                    double[] ins = new double[8];
                    ins = _in;
                    double[] outs = Seers[seer].nlg.Decide(ins);

                    if (Enumerable.SequenceEqual(outs, correctAns)) {
                        Seers[seer].Fitness++;
                        correctSeers++;
                    }
                    logB += "" + outs[0] + outs[1] + outs[2] + outs[3] + Environment.NewLine;
                }
            );*/
        }

        private void btnMutate_Click (object sender, EventArgs e) {
            //This thing will be transfered to genetics
            //Will be adding fitness
            //Will be creating a class or function to hold selection
            //Genetics will only be focusing on mutation/mariage
            /*Seer BabySeer = new Seer();
            List<Seer> BabySeers = new List<Seer>();
            Genetics GA = new Genetics();
            for (int i = 0; i < numMutate.Value; i++) {
                BabySeer = new Seer(GA.Mutate(Seers[r.Next(0, Seers.Count)].nlg, Seers[r.Next(0, Seers.Count)].nlg));
                BabySeers.Add(BabySeer);
            }
            Seers.AddRange(BabySeers);*/

        }

        private void button1_Click (object sender, EventArgs e) {

        }
    }
}
