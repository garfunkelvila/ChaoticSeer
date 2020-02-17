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
		Tribe tribe;
		ChaoticSeer genome;
		PictureBox[] pictureBoxes;
		public GeneticsTest() {
            InitializeComponent();
        }

        private void GeneticsTest_Load(object sender, EventArgs e) {
			tribe = new Tribe(2, 1, 10);
			genome = tribe.Representative;
			pictureBoxes = new PictureBox[tribe._Species.Count];
			//InitializeNeat();
			//genome = new ChaoticSeer(neat);
			//genome = neat.NewEmptyGenome();
			pictureBoxes = new PictureBox[tribe._Species.Count];
			for (int i = 0; i < tribe._Species.Count; i++) {
				pictureBoxes[i] = new PictureBox {
					Parent = flowLayoutPanel1,
					SizeMode = PictureBoxSizeMode.AutoSize,
					Image = tribe._Species[i].GetBitmap(),
					BorderStyle = BorderStyle.FixedSingle
				};
			}

			//picCanvas.Image = genome.GetBitmap();
			Console.WriteLine("Nodes: " + genome.Nodes.Count);
			Console.WriteLine("Connections: " + genome.Connections.Count);
		}

		private void button3_Click(object sender, EventArgs e) {
			tribe.Evolve();
			//picCanvas.Image = genome.GetBitmap();
			for (int i = 0; i < tribe._Species.Count; i++) {
				pictureBoxes[i].Image = tribe._Species[i].GetBitmap();
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			Console.WriteLine("Pred: " + genome.GetPrediction(1, 1)[0]);
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
			//picCanvas.Image = genome.GetBitmap();
			for (int i = 0; i < tribe._Species.Count; i++) {
				pictureBoxes[i].Image = tribe._Species[i].GetBitmap();
			}
		}

		private void btnReproduce_Click(object sender, EventArgs e) {
			for (int i = 0; i < pictureBoxes.Length; i++) {
				pictureBoxes[i].Dispose();
			}
			pictureBoxes = null;

			tribe.Reproduce();

			pictureBoxes = new PictureBox[tribe._Species.Count];
			for (int i = 0; i < tribe._Species.Count; i++) {
				pictureBoxes[i] = new PictureBox {
					Parent = flowLayoutPanel1,
					SizeMode = PictureBoxSizeMode.AutoSize,
					Image = tribe._Species[i].GetBitmap(),
					BorderStyle = BorderStyle.FixedSingle
				};
			}
		}
		private void btnPurge_Click(object sender, EventArgs e) {
			for (int i = 0; i < pictureBoxes.Length; i++) {
				pictureBoxes[i].Dispose();
			}
			pictureBoxes = null;

			tribe.Purge();

			pictureBoxes = new PictureBox[tribe._Species.Count];
			for (int i = 0; i < tribe._Species.Count; i++) {
				pictureBoxes[i] = new PictureBox {
					Parent = flowLayoutPanel1,
					SizeMode = PictureBoxSizeMode.AutoSize,
					Image = tribe._Species[i].GetBitmap(),
					BorderStyle = BorderStyle.FixedSingle
				};
			}
		}
		private void button1_Click_1(object sender, EventArgs e) {
			tribe.Mutate();
			for (int i = 0; i < tribe._Species.Count; i++) {
				pictureBoxes[i].Image = tribe._Species[i].GetBitmap();
			}
		}
	}
}

