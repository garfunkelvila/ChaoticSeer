//  ChaoticSeer, a C# Artificial Neural Network Library
//  Copyright (C) 2020  Garfunkel Vila
//  
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 3 of the License, or any later version.
//  
//  This library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library. If not,
//  see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using gSeer.Genetic_Algorithm;

namespace gSeer.Util {
	///http://csharphelper.com/blog/2015/07/zoom-and-scroll-a-picture-drawn-in-c/
	internal class Paint {
		public static Bitmap GenBitmap(ChaoticSeer _seer) {
			Bitmap Bm;
			int PictureScale = 1;

			//PictureScale = 1;
			Pen connectionPen = new Pen(Color.Blue);
			SolidBrush nodeBrush = new SolidBrush(Color.Green);
			SolidBrush textBrushWhite = new SolidBrush(Color.White);
			SolidBrush textBrushBlack = new SolidBrush(Color.Black);

			Point[] nodePoints = NodeToPoints(_seer.Nodes.ToArray());
			Point[][] connectionPoints = ConnectionsToPoint(_seer.Connections.ToArray());

			float CanvasWidth = 100;    //Limit the minimun size
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

			//Console.WriteLine("Canvas Size: " + CanvasWidth + " x " + CanvasHeight);
			//Console.WriteLine("Nodes: " + _seer.Nodes.Count);
			//Console.WriteLine("Connections: " + _seer.Connections.Count);

			Graphics gr = Graphics.FromImage(Bm);
			gr.Clear(Color.AliceBlue);
			gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			gr.ScaleTransform(PictureScale, PictureScale);

			Rectangle[] rectangles = new Rectangle[nodePoints.Length];

			////Draw line
			//gr.DrawCurve(connectionPen, nodePoints, 0.0f);
			for (int i = 0; i < connectionPoints.Length; i++) {
				gr.DrawLine(connectionPen, connectionPoints[i][0], connectionPoints[i][1]);
			}

			//Draw circle/node
			for (int i = 0; i < nodePoints.Length; i++) {
				Point _offset = nodePoints[i];
				_offset.Offset(-8, -8);

				rectangles[i] = new Rectangle(_offset, new Size(16, 16));
			}
			foreach (Rectangle item in rectangles) {
				gr.FillEllipse(nodeBrush, item);
			}
			//Draw text InnovationNumber
			//gr.DrawString("ASDF", new Font("Arial", 16), textBrush, new Point(10,10));
			for (int i = 0; i < nodePoints.Length; i++) {
				Point _offset = nodePoints[i];
				_offset.Offset(-5, -7);

				gr.DrawString("" + _seer.Nodes[i].InnovationNumber, new Font("Courier New", 8), textBrushWhite, _offset);
				//rectangles[i] = new Rectangle(_offset, new Size(10, 10));
			}

			//Draw text Status
			string status = "Identity: " + _seer.Identity + Environment.NewLine + 
							"Fitness:  " + _seer.Fitness + Environment.NewLine +
							"Day:      " + _seer.Day + Environment.NewLine +
							"Age:      " + _seer.Year;
			gr.DrawString(status, new Font("Courier New", 8), textBrushBlack, new Point(600,0));

			//picCanvas.Image = Bm;
			return Bm;
		}
		private static Point[] NodeToPoints(NodeGene[] nodes) {
			Point[] _pBuffer = new Point[nodes.Length];
			for (int i = 0; i < nodes.Length; i++) {
				_pBuffer[i].X = (int)(nodes[i].X * 1000 - 90);
				_pBuffer[i].Y = (int)(nodes[i].Y * 100 - 90);

				//Console.WriteLine("X: " + _pBuffer[i].X + " Y:" + _pBuffer[i].Y);
			}
			return _pBuffer;
		}
		private static Point[][] ConnectionsToPoint(ConnectionGene[] connections) {
			Point[][] _connectionPoints = new Point[connections.Length][];

			for (int i = 0; i < connections.Length; i++) {
				_connectionPoints[i] = new Point[2];

				_connectionPoints[i][0].X = (int)((connections[i].From.X * 1000) - 90);
				_connectionPoints[i][0].Y = (int)((connections[i].From.Y * 100) - 90);

				_connectionPoints[i][1].X = (int)((connections[i].To.X * 1000) - 90);
				_connectionPoints[i][1].Y = (int)((connections[i].To.Y * 100) - 90);

				//Console.WriteLine("From X: " + _connectionPoints[i][0].X + " Y:" + _connectionPoints[i][0].Y + " To X: " + _connectionPoints[i][0].X + " Y:" + _connectionPoints[i][0].Y);
			}

			return _connectionPoints;
			//throw new NotImplementedException();
		}
	}
}
