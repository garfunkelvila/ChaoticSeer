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
using gSeer.Batch;
using gSeer.GeneticAlgorithm;
using System.Diagnostics;
using gSeer.Util;
using SeerRegion = gSeer.Batch.Region;

namespace Nice_Seer.Forms {
    public partial class GeneticsTest : Form {
		Tribe tribe;
		SeerRegion region;
		ChaoticSeer genomeRepresentative;
		PictureBox[] pictureBoxes;
		public GeneticsTest() {
            InitializeComponent();
        }

        private void GeneticsTest_Load(object sender, EventArgs e) {
			tribe = new TribeMT(2, 1, 10);
			region = new RegionST(3,2,1,10);
			genomeRepresentative = tribe.Species[0];
			pictureBoxes = new PictureBox[tribe.Species.Count];

			InitializePictureBoxes();

			Console.WriteLine("Nodes: " + genomeRepresentative.Nodes.Count);
			Console.WriteLine("Connections: " + genomeRepresentative.Connections.Count);
		}

		private void btnEvolve_Click(object sender, EventArgs e) {

		}

		private void btnEvaluate_click(object sender, EventArgs e) {
			tribe.Evaluate(_and);
			UpdatePictureBoxes();
		}

		private void btnReproduce_Click(object sender, EventArgs e) {
			ClearPictureBoxes();
			tribe.Reproduce();
			InitializePictureBoxes();
		}
		private void btnPurge_Click(object sender, EventArgs e) {
			ClearPictureBoxes();
			tribe.Purge();
			InitializePictureBoxes();
		}
		private void btnMutate_Click(object sender, EventArgs e) {
			tribe.Mutate();
			UpdatePictureBoxes();
		}
		private void ClearPictureBoxes() {
			for (int i = 0; i < pictureBoxes.Length; i++) {
				pictureBoxes[i].Dispose();
			}
			pictureBoxes = null;
		}
		private void InitializePictureBoxes() {
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
		private void UpdatePictureBoxes() {
			for (int i = 0; i < tribe.Species.Count; i++) {
				pictureBoxes[i].Image = tribe.Species[i].GetBitmap();
			}
		}
		TrainingData[] _and = new TrainingData[] {
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
					new float[1] { 0 }
				),
				new TrainingData(
					new float[2] { 1, 1 },
					new float[1] { 1 }
				)
			};
		TrainingData[] _or = new TrainingData[] {
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
					new float[1] { 1 }
				)
			};
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

		private void button4_Click(object sender, EventArgs e) {
			int mutateRNG = new Random().Next(1,3600);

			tribe.Train(_and, mutateRNG);

			ClearPictureBoxes();
			InitializePictureBoxes();

			LogAge();

			tribe.Species[0].GetPrediction(_and[0].Input);
		}

		private void LogRepWeights() {
			for (int i = 0; i < tribe.Species[0].Connections.Count; i++) {
				Console.WriteLine("ID:" + tribe.Species[0].Connections[i].InnovationNumber + "W: " + tribe.Species[0].Connections[i].Weight);
			}
		}
		private void LogAge() {
			Console.WriteLine("Age" + tribe.Species[0].Year);
		}

		private void button5_Click(object sender, EventArgs e) {
			Console.WriteLine("Starting single threaded bench");
			GC.Collect();
			Stopwatch sw = new Stopwatch();
			tribe = new TribeST(2, 1, 128);
			sw.Start();
			for (int st = 0; st < 1000; st++) {
				for (int i = 0; i < 100; i++) {
					tribe.Mutate();
				}
				tribe.Evaluate(_and);
				for (int i = 0; i < 100; i++) {
					tribe.Purge();
				}
				tribe.Reproduce();

				tribe.Evaluate(_and);
			}
			sw.Stop();
			Console.WriteLine("Single Threading: " + sw.Elapsed);


			GC.Collect();
			Console.WriteLine("Starting multi threaded bench");
			//tribe = new TribeMT(2, 1, 128);
			sw.Reset();
			sw.Start();
			for (int st = 0; st < 1000; st++) {
				for (int i = 0; i < 100; i++) {
					tribe.Mutate();
				}
				tribe.Evaluate(_and);
				for (int i = 0; i < 100; i++) {
					tribe.Purge();
				}
				tribe.Reproduce();

				tribe.Evaluate(_and);
			}
			sw.Stop();
			Console.WriteLine("Multi Threading: " + sw.Elapsed);
		}

		private void button7_Click(object sender, EventArgs e) {
			region.StartChaos(_and,10);
		}
	}
}

