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


		public GeneticsTest() {
            InitializeComponent();
        }

        private void GeneticsTest_Load(object sender, EventArgs e) {
			DrawSeer();
		}

		///http://csharphelper.com/blog/2015/07/zoom-and-scroll-a-picture-drawn-in-c/
		private void DrawSeer() {
			PictureScale = 1;
			Pen connectionPen = new Pen(Color.Blue);
			SolidBrush nodeBrush = new SolidBrush(Color.Green);

			Point[] nodePoints = {
				new Point(10, 50),
				new Point(100, 10),
				new Point(200, 100),
				new Point(300, 50),
				new Point(400, 80)
			};

			float CanvasWidth = 100;
			float CanvasHeight = 100;

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

			Graphics gr = Graphics.FromImage(Bm);
			gr.Clear(Color.AliceBlue);
			gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			gr.ScaleTransform(PictureScale, PictureScale);

			Rectangle[] rectangles = new Rectangle[nodePoints.Length];

			////Draw line
			//gr.DrawCurve(connectionPen, nodePoints, 0.0f);

			//Draw circle
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
	}
}

