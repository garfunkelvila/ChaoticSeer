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
        public GeneticsTest() {
            InitializeComponent();
        }

        private void GeneticsTest_Load(object sender, EventArgs e) {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            Point[] points = {
                new Point(20, 50),
                new Point(100, 10),
                new Point(200, 100),
                new Point(300, 50),
                new Point(400, 80)
            };
            
            Rectangle[] rectangles = new Rectangle[points.Length];

            for (int i = 0; i < points.Length; i++) {
                Point _offset = points[i];
                _offset.Offset(-5, -5);

                rectangles[i] = new Rectangle(_offset, new Size(10, 10));
            }

            Pen RedPen = new Pen(Color.Red);
            Pen BluePen = new Pen(Color.Red);

            SolidBrush brush = new SolidBrush(Color.Red);
            e.Graphics.DrawCurve(BluePen, points, 0.0f);
            foreach (Rectangle item in rectangles) {
                e.Graphics.FillEllipse(brush, item);
            }
        }
    }
}

