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
namespace Dark_Seer {
    public partial class frmMain : Form {
        System.Diagnostics.Stopwatch watch;
        Random r;
        List<TestSeer> Seers;
        TestSeer Seer;
        //Seer[] Seers;        

        TrainingData[] td;

        public frmMain () {
            InitializeComponent();
            watch = new System.Diagnostics.Stopwatch();
            r = new Random();
            //Seers = new List<TestSeer>();

            Seer = new TestSeer();
            initTestData();
            textBox1.AppendText(Math.Round(Seer.Predict(td[0].Input)[0], 4) + " -> " + td[0].Target[0] + Environment.NewLine);
            textBox1.AppendText(Math.Round(Seer.Predict(td[1].Input)[0], 4) + " -> " + td[1].Target[0] + Environment.NewLine);
            textBox1.AppendText(Math.Round(Seer.Predict(td[2].Input)[0], 4) + " -> " + td[2].Target[0] + Environment.NewLine);
            textBox1.AppendText(Math.Round(Seer.Predict(td[3].Input)[0], 4) + " -> " + td[3].Target[0] + Environment.NewLine);
            textBox1.AppendText("-------------------------------" + Environment.NewLine);
            Start();
        }

        private void btnInit_Click (object sender, EventArgs e) {
            for (int i = 0; i < 4096; i++) {
                Seers.Add(new TestSeer());  //This thing cause massive memory, maybe because of many not simmilar number within its class
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
                Seers.Add(new TestSeer());
            }
        }
        void initTestData () {
            td = new TrainingData[8];
            td[0] = new TrainingData(new float[3] { 0, 0, 0 }, new float[3] { 0, 0, 1 });
            td[1] = new TrainingData(td[0].Target, new float[3] { 0, 1, 0 });
            td[2] = new TrainingData(td[1].Target, new float[3] { 0, 1, 1 });
            td[3] = new TrainingData(td[2].Target, new float[3] { 1, 0, 0 });
            td[4] = new TrainingData(td[3].Target, new float[3] { 1, 0, 1 });
            td[5] = new TrainingData(td[4].Target, new float[3] { 1, 1, 0 });
            td[6] = new TrainingData(td[5].Target, new float[3] { 1, 1, 1 });
            td[7] = new TrainingData(td[5].Target, td[5].Input);
        }

        private void aboutToolStripMenuItem_Click (object sender, EventArgs e) {
            frmAbout _frmAbout = new frmAbout();
            _frmAbout.ShowDialog();
        }

        private void button1_Click (object sender, EventArgs e) {
            //textBox1.AppendText(Math.Round(Seer.Predict(td[0].Input)[0], 8) + " -> " + td[0].Target[0] + Environment.NewLine);
            //textBox1.AppendText(Math.Round(Seer.Predict(td[1].Input)[0], 8) + " -> " + td[1].Target[0] + Environment.NewLine);
            //textBox1.AppendText(Math.Round(Seer.Predict(td[2].Input)[0], 8) + " -> " + td[2].Target[0] + Environment.NewLine);
            //textBox1.AppendText(Math.Round(Seer.Predict(td[3].Input)[0], 8) + " -> " + td[3].Target[0] + Environment.NewLine);
            //textBox1.AppendText("-------------------------------" + Environment.NewLine);
        }


        private void Start () {


            prgMain.Style = ProgressBarStyle.Marquee;
            for (int i = 0; i < 50000; i++) {
                Seer.BP(td);
            }
            prgMain.Style = ProgressBarStyle.Blocks;
            System.Diagnostics.Debug.WriteLine("Err: " + string.Join(", ", Seer.getError()));

            textBox1.AppendText(string.Join("", Seer.Predict(td[0].Input)) + " -> " + string.Join("", td[0].Target) + Environment.NewLine);
            textBox1.AppendText(string.Join("", Seer.Predict(td[1].Input)) + " -> " + string.Join("", td[1].Target) + Environment.NewLine);
            textBox1.AppendText(string.Join("", Seer.Predict(td[2].Input)) + " -> " + string.Join("", td[2].Target) + Environment.NewLine);
            textBox1.AppendText(string.Join("", Seer.Predict(td[3].Input)) + " -> " + string.Join("", td[3].Target) + Environment.NewLine);
            textBox1.AppendText(string.Join("", Seer.Predict(td[4].Input)) + " -> " + string.Join("", td[4].Target) + Environment.NewLine);
            textBox1.AppendText(string.Join("", Seer.Predict(td[5].Input)) + " -> " + string.Join("", td[5].Target) + Environment.NewLine);
            textBox1.AppendText(string.Join("", Seer.Predict(td[6].Input)) + " -> " + string.Join("", td[6].Target) + Environment.NewLine);
            textBox1.AppendText(string.Join("", Seer.Predict(td[7].Input)) + " -> " + string.Join("", td[7].Target) + Environment.NewLine);
            textBox1.AppendText("-------------------------------" + Environment.NewLine);
        }

        private void button2_Click (object sender, EventArgs e) {
            Start();
        }
    }
}
