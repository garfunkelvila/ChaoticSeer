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
            StartChaos();
        }
        private void InitializeSeers(int count) {
			txbLog.AppendText("Cores" + Environment.ProcessorCount + Environment.NewLine);

            txbLog.AppendText("Initializing Seer..." + Environment.NewLine);
			/// Use the template converter to create a template from newly created seer
			Seer _TestSeer = new Seer(2, 1, 2);
			TSeer _TestSeerTemplate = new TSeer(_TestSeer);
			nemic = new Country(_TestSeerTemplate, count);

            txbLog.AppendText(nemic.Seers.Count() + " seers Initialized" + Environment.NewLine);
            txbLog.AppendText(Environment.NewLine);
        }
        private void FirstPrediction() {
            txbLog.AppendText("Listing prediction..." + Environment.NewLine);
            foreach (Seer _seer in nemic.Seers) {
                txbLog.AppendText(_seer.Predict(_xor[0].Input)[0] + " : ");
                txbLog.AppendText(_seer.Predict(_xor[1].Input)[0] + " : ");
                txbLog.AppendText(_seer.Predict(_xor[2].Input)[0] + " : ");
                txbLog.AppendText(_seer.Predict(_xor[3].Input)[0] + " :-> ");
                txbLog.AppendText(_xor[0].Target[0] + "");
                txbLog.AppendText(_xor[1].Target[0] + "");
                txbLog.AppendText(_xor[2].Target[0] + "");
                txbLog.AppendText(_xor[3].Target[0] + Environment.NewLine);
            }

            txbLog.AppendText("Prediction end" + Environment.NewLine);
            txbLog.AppendText(Environment.NewLine);
        }

        private void StartChaos() {
            nemic.Train(_xor);
        }
    }
}
