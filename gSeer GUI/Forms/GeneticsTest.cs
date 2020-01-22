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
using gSeer.Genetic_Algorithm;
namespace Nice_Seer.Forms {
    public partial class GeneticsTest : Form {
        Country nemic;

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
        public GeneticsTest() {
            InitializeComponent();
        }

        private void GeneticsTest_Load(object sender, EventArgs e) {
            InitializeSeers(10);
            FirstPrediction();
        }
        private void InitializeSeers(int count) {
            txbLog.AppendText("Initializing Seer..." + Environment.NewLine);
            nemic = new Country(new Seer(2, 1, 2), count);
            txbLog.AppendText(nemic.Seers.Count() + " seers Initialized" + Environment.NewLine);
            txbLog.AppendText(Environment.NewLine);
        }
        private void FirstPrediction() {
            txbLog.AppendText("Listing prediction..." + Environment.NewLine);
            foreach (Seer _seer in nemic.Seers) {
                txbLog.AppendText(Math.Round(_seer.Predict(_xor[0].Input)[0], 1) + " : ");
                txbLog.AppendText(Math.Round(_seer.Predict(_xor[1].Input)[0], 1) + " : ");
                txbLog.AppendText(Math.Round(_seer.Predict(_xor[2].Input)[0], 1) + " : ");
                txbLog.AppendText(Math.Round(_seer.Predict(_xor[3].Input)[0], 1) + " :-> ");
                txbLog.AppendText(_xor[0].Target[0] + "");
                txbLog.AppendText(_xor[1].Target[0] + "");
                txbLog.AppendText(_xor[2].Target[0] + "");
                txbLog.AppendText(_xor[3].Target[0] + Environment.NewLine);
            }
            txbLog.AppendText("Prediction end" + Environment.NewLine);
            txbLog.AppendText(Environment.NewLine);
        }

        private void StartChaos() {

        }
    }
}
