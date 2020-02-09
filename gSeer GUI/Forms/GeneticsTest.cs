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
		float PictureScale;
		Bitmap Bm;
		Neat neat;
		ChaoticSeer genome;

		public GeneticsTest() {
            InitializeComponent();
        }

        private void GeneticsTest_Load(object sender, EventArgs e) {
			InitializeNeat();
			genome = new ChaoticSeer(neat);
			//genome = neat.NewEmptyGenome();
			
			PaintSeer(genome);
			Console.WriteLine("Nodes: " + genome.Nodes.Count);
			Console.WriteLine("Connections: " + genome.Connections.Count);
		}
		private void InitializeNeat() {
			neat = new Neat(10, 1, 1000);
			float[] input = new float[10];
			for (int i = 0; i < 10; i++) {
				input[i] = (float)new Random().NextDouble();
			}
		}

		///http://csharphelper.com/blog/2015/07/zoom-and-scroll-a-picture-drawn-in-c/
		private void PaintSeer(ChaoticSeer _seer) {
			PictureScale = 1;
			Pen connectionPen = new Pen(Color.Blue);
			SolidBrush nodeBrush = new SolidBrush(Color.Green);

			Point[] nodePoints = NodeToPoints(_seer.Nodes.ToArray());

			float CanvasWidth = 100;	//Limit the minimun size
			float CanvasHeight = 100;   //Limit the minimun size

			//Get the largest point
			for (int i = 0; i < nodePoints.Length; i++) {
				CanvasWidth = Math.Max(nodePoints[i].X, CanvasWidth);
				CanvasHeight = Math.Max(nodePoints[i].Y, CanvasHeight);
			}
			CanvasWidth += 10;
			CanvasHeight += 10;

			Bm = new Bitmap(
				(int)(PictureScale * CanvasWidth),
				(int)(PictureScale * CanvasHeight));

			Console.WriteLine("Canvas Size: " + CanvasWidth + " x " + CanvasHeight);

			Graphics gr = Graphics.FromImage(Bm);
			gr.Clear(Color.AliceBlue);
			gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			gr.ScaleTransform(PictureScale, PictureScale);

			Rectangle[] rectangles = new Rectangle[nodePoints.Length];

			////Draw line
			//gr.DrawCurve(connectionPen, nodePoints, 0.0f);

			//Draw circle/node
			for (int i = 0; i < nodePoints.Length; i++) {
				Point _offset = nodePoints[i];
				_offset.Offset(-5, -5);

				rectangles[i] = new Rectangle(_offset, new Size(10, 10));
			}
			foreach (Rectangle item in rectangles) {
				gr.FillEllipse(nodeBrush, item);
			}
			picCanvas.Image = Bm;

		}

		private Point[] NodeToPoints(NodeGene[] nodes) {
			Point[] _pBuffer = new Point[nodes.Length];
			for (int i = 0; i < nodes.Length; i++) {
				_pBuffer[i].X = (int)(nodes[i].X * 1000 - 90);
				_pBuffer[i].Y = (int)(nodes[i].Y * 100);

				Console.WriteLine("X: " + _pBuffer[i].X + " Y:" + _pBuffer[i].Y);
			}
			return _pBuffer;
		}

		private void btnInitializeNeat(object sender, EventArgs e) {
			InitializeNeat();
		}

		private void btnMutateLink_Click(object sender, EventArgs e) {
			genome.MutateConnection();
			PaintSeer(genome);
		}

		private void btnMutateNode_Click(object sender, EventArgs e) {
			genome.MutateNode();
			PaintSeer(genome);
		}

		private void btnMutateWeightShift_Click(object sender, EventArgs e) {
			genome.MutateWeightShift();
			PaintSeer(genome);
		}

		private void btnMutateWeightRandom_Click(object sender, EventArgs e) {
			genome.MutateWeightRandom();
			PaintSeer(genome);
		}

		private void btnMutateLinkToggle_Click(object sender, EventArgs e) {
			genome.MutateToggleConnection();
			PaintSeer(genome);
		}
	}
}

