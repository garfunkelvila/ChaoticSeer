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

        TrainingData[] td;

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

        private void btnNext_Click (object sender, EventArgs e) {
            initSeer(1024);
        }
        void initSeer (int i) {
            for (int s = 0; s < i; s++) {
                Seers.Add(new Seer());
            }
        }
        void initTestData () {
            td = new TrainingData[7];

            td[0].Input[0] = 0;
            td[0].Input[1] = 0;
            td[0].Input[2] = 0;
            td[0].Output[0] = 0;
            td[0].Output[1] = 0;
            td[0].Output[2] = 1;
            td[1].Input = td[0].Output;
            td[1].Output[0] = 0;
            td[1].Output[1] = 1;
            td[1].Output[2] = 0;
            td[2].Input = td[1].Output;
            td[2].Output[0] = 0;
            td[2].Output[1] = 1;
            td[2].Output[2] = 1;
            td[3].Input = td[2].Output;
            td[3].Output[0] = 1;
            td[3].Output[1] = 0;
            td[3].Output[2] = 0;
            td[4].Input = td[3].Output;
            td[4].Output[0] = 1;
            td[4].Output[1] = 0;
            td[4].Output[2] = 1;
            td[5].Input = td[4].Output;
            td[5].Output[0] = 1;
            td[5].Output[1] = 1;
            td[5].Output[2] = 0;
            td[6].Input = td[5].Output;
            td[6].Output[0] = 1;
            td[6].Output[1] = 1;
            td[6].Output[2] = 1;
            td[7].Input = td[6].Output;
            td[7].Output[0] = td[7].Input[0];
        }
    }
}
