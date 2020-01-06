//  Copyright (C) 2018  Garfunkel Vila
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
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

        List<Seer> Seers;
        List<SeerVisualizer> sv;
        List<TrainingData> td;

        public frmMain () {
            InitializeComponent();
            watch = new System.Diagnostics.Stopwatch();
            r = new Random();
            Seers = new List<Seer>();
            sv = new List<SeerVisualizer>();
            td = new List<TrainingData>();
        }


        void initTestData () {
            td.Add( new TrainingData(new float[3] { 0, 0, 0 }, new float[3] { 0, 0, 1 }));
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
            Seers.AddRange(nSeer.seers);
            refreshView();
            nSeer.Dispose();


            int cappedView = Seers.Count <= 100 ? Seers.Count : 100;
            for (int i = 0; i < cappedView; i++) {
                sv.Add(new SeerVisualizer());
                sv[i].Parent = flowLayoutPanel1;
            }
        }
        private void aboutToolStripMenuItem_Click (object sender, EventArgs e) {
            frmAbout formAbout = new frmAbout();
            formAbout.ShowDialog();
            formAbout.Dispose();
        }
        private void refreshView () {
            // THis thins is to sync the sv values
        }

        private void frmMain_Load (object sender, EventArgs e) {
            
        }

        private void btnRefreshView_Click (object sender, EventArgs e) {
            refreshView();
        }

        private void lTToolStripMenuItem_Click (object sender, EventArgs e) {
            Seer[] _Seers = new Seer[3];
            _Seers[0] = new Seer(108, 36, 6);
            _Seers[1] = new Seer(108, 36, 6);
            _Seers[2] = new Seer(108, 36, 6);


            Seers.AddRange(_Seers);
            refreshView();


            int cappedView = Seers.Count <= 100 ? Seers.Count : 100;
            for (int i = 0; i < cappedView; i++) {
                sv.Add(new SeerVisualizer());
                sv[i].Parent = flowLayoutPanel1;
            }
        }

        private void lTToolStripMenuItem1_Click (object sender, EventArgs e) {
            td.Add(new TrainingData(
                new float[3] {1,1,1 },
                new float[3] { 1, 1, 1 }));
        }

        private void lTToolStripMenuItem_Click_1 (object sender, EventArgs e) {
            //forms.lt.lt frmlt = new forms.lt.lt();
            //frmlt.show();
        }
    }
}
