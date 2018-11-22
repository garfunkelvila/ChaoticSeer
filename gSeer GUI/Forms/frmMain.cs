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
namespace Nice_Seer {
    public partial class frmMain : Form {
        System.Diagnostics.Stopwatch watch;
        static Random r;

        Seer[] Seers;
        TrainingData[] td;

        public frmMain () {
            InitializeComponent();
            watch = new System.Diagnostics.Stopwatch();
            r = new Random();
        }


        void initTestData () {
            td = new TrainingData[3];
            td[0] = new TrainingData(new float[3] { 0, 0, 0 }, new float[3] { 0, 0, 1 });
        }

        

        private void Start () {
            //prgMain.Style = ProgressBarStyle.Marquee;
            //for (int i = 0; i < 50000; i++) {
            //    Seer.Train(td);
            //}
            //prgMain.Style = ProgressBarStyle.Blocks;
            //System.Diagnostics.Debug.WriteLine("Err: " + string.Join(", ", Seer.getError()));

            //txbLog.AppendText(string.Join("", Seer.Predict(td[0].Input)) + " -> " + string.Join("", td[0].Target) + Environment.NewLine);
            //txbLog.AppendText(string.Join("", Seer.Predict(td[1].Input)) + " -> " + string.Join("", td[1].Target) + Environment.NewLine);
            //txbLog.AppendText(string.Join("", Seer.Predict(td[2].Input)) + " -> " + string.Join("", td[2].Target) + Environment.NewLine);
            //txbLog.AppendText(string.Join("", Seer.Predict(td[3].Input)) + " -> " + string.Join("", td[3].Target) + Environment.NewLine);
            //txbLog.AppendText(string.Join("", Seer.Predict(td[4].Input)) + " -> " + string.Join("", td[4].Target) + Environment.NewLine);
            //txbLog.AppendText(string.Join("", Seer.Predict(td[5].Input)) + " -> " + string.Join("", td[5].Target) + Environment.NewLine);
            //txbLog.AppendText(string.Join("", Seer.Predict(td[6].Input)) + " -> " + string.Join("", td[6].Target) + Environment.NewLine);
            //txbLog.AppendText(string.Join("", Seer.Predict(td[7].Input)) + " -> " + string.Join("", td[7].Target) + Environment.NewLine);
            //txbLog.AppendText("-------------------------------" + Environment.NewLine);
        }

        private void genericSeerToolStripMenuItem_Click (object sender, EventArgs e) {
            Forms.Seer_Creation_setup.frmNewSeer nSeer = new Forms.Seer_Creation_setup.frmNewSeer();
            nSeer.ShowDialog();
            Seers = nSeer.seers;
            refreshView();
            nSeer.Dispose();
        }
        private void aboutToolStripMenuItem_Click (object sender, EventArgs e) {
            frmAbout formAbout = new frmAbout();
            formAbout.ShowDialog();
            formAbout.Dispose();
        }
        private void refreshView () {

        }
    }
}
