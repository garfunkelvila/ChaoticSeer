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
        Seer _seer = new Seer(2, 1, 2);
        TrainingData[] tds = new TrainingData[] {
                new TrainingData(
                    new float[2] { 0, 0 },
                    new float[1] { 0 }
                ),
                new TrainingData(
                    new float[2] { 0, 1 },
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

        private void btnTest_Click(object sender, EventArgs e) {
            _seer.Train(tds, (int) trainLoop.Value);
            float pred = _seer.Predict(new float[2] { 1, 0 })[0];
            lblPred.Text = "Prediction: " + pred;
            lblCorrect.Text = "Correct: 1";
            txbLogs.AppendText("err:" + _seer.getError()[0] + Environment.NewLine);
        }

        private void btnReTrain_Click(object sender, EventArgs e) {
            _seer.Train(tds, (int)trainLoop.Value);
            float pred = _seer.Predict(new float[2] { 1, 0 })[0];
            lblPred.Text = "Prediction: " + pred;
            lblCorrect.Text = "Correct: 1 : err : " +_seer.getError()[0];
            txbLogs.AppendText("err:" + _seer.getError()[0] + Environment.NewLine);
        }
    }
}
