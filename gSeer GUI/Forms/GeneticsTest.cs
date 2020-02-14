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

		public GeneticsTest() {
            InitializeComponent();
        }

        private void GeneticsTest_Load(object sender, EventArgs e) {
			tribe = new Tribe(2, 1, 10);
			genome = tribe.Representative;

			//InitializeNeat();
			//genome = new ChaoticSeer(neat);
			//genome = neat.NewEmptyGenome();

			picCanvas.Image = genome.GetBitmap();
			Console.WriteLine("Nodes: " + genome.Nodes.Count);
			Console.WriteLine("Connections: " + genome.Connections.Count);
		}

		private void btnMutateLink_Click(object sender, EventArgs e) {
			genome.MutateConnection();
			picCanvas.Image = genome.GetBitmap();
		}

		private void btnMutateNode_Click(object sender, EventArgs e) {
			genome.MutateNode();
			picCanvas.Image = genome.GetBitmap();
		}

		private void btnMutateWeightShift_Click(object sender, EventArgs e) {
			genome.MutateWeightShift();
			picCanvas.Image = genome.GetBitmap();
		}

		private void btnMutateWeightRandom_Click(object sender, EventArgs e) {
			genome.MutateWeightRandom();
			picCanvas.Image = genome.GetBitmap();
		}

		private void btnMutateLinkToggle_Click(object sender, EventArgs e) {
			genome.MutateToggleConnection();
			picCanvas.Image = genome.GetBitmap();
		}

		private void btnMutate_Click(object sender, EventArgs e) {
			genome.Mutate();
			picCanvas.Image = genome.GetBitmap();
		}

		private void button3_Click(object sender, EventArgs e) {
			tribe.Evolve();
			picCanvas.Image = genome.GetBitmap();
		}

		private void button4_Click(object sender, EventArgs e) {
			Console.WriteLine("Pred: " + genome.GetPrediction(1, 1)[0]);
		}
	}
}

