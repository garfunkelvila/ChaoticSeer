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
			pictureBoxes = new PictureBox[tribe.Species.Count];

			pictureBoxes = new PictureBox[tribe.Species.Count];
			for (int i = 0; i < tribe.Species.Count; i++) {
				pictureBoxes[i] = new PictureBox {
					Parent = flowLayoutPanel1,
					SizeMode = PictureBoxSizeMode.AutoSize,
					Image = tribe.Species[i].GetBitmap(),
					BorderStyle = BorderStyle.FixedSingle
				};
			}

			Console.WriteLine("Nodes: " + genome.Nodes.Count);
			Console.WriteLine("Connections: " + genome.Connections.Count);
		}

		private void button3_Click(object sender, EventArgs e) {
			tribe.Evolve();
			for (int i = 0; i < tribe.Species.Count; i++) {
				pictureBoxes[i].Image = tribe.Species[i].GetBitmap();
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			Console.WriteLine("Pred: " + genome.GetPrediction(1, 1)[0]);
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
			for (int i = 0; i < tribe.Species.Count; i++) {
				pictureBoxes[i].Image = tribe.Species[i].GetBitmap();
			}
		}

		private void btnReproduce_Click(object sender, EventArgs e) {
			for (int i = 0; i < pictureBoxes.Length; i++) {
				pictureBoxes[i].Dispose();
			}
			pictureBoxes = null;

			tribe.Reproduce();

			pictureBoxes = new PictureBox[tribe.Species.Count];
			for (int i = 0; i < tribe.Species.Count; i++) {
				pictureBoxes[i] = new PictureBox {
					Parent = flowLayoutPanel1,
					SizeMode = PictureBoxSizeMode.AutoSize,
					Image = tribe.Species[i].GetBitmap(),
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

			pictureBoxes = new PictureBox[tribe.Species.Count];
			for (int i = 0; i < tribe.Species.Count; i++) {
				pictureBoxes[i] = new PictureBox {
					Parent = flowLayoutPanel1,
					SizeMode = PictureBoxSizeMode.AutoSize,
					Image = tribe.Species[i].GetBitmap(),
					BorderStyle = BorderStyle.FixedSingle
				};
			}
		}
		private void btnMutate_Click(object sender, EventArgs e) {
			tribe.Mutate();
			for (int i = 0; i < tribe.Species.Count; i++) {
				pictureBoxes[i].Image = tribe.Species[i].GetBitmap();
			}
		}
	}
}

