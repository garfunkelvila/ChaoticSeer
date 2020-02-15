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
namespace Nice_Seer.Custom_Controls {
	public partial class LT : Form {
		Tribe tribe;
		ChaoticSeer seer;
		public LT() {
			InitializeComponent();
			tribe = new Tribe(10, 10, 100);
			seer = tribe.Representative;
		}

		private void btnStart100_Click(object sender, EventArgs e) {
			for (int i = 0; i < 100; i++) {
				tribe.Evolve();
			}
			lblCurrentPop.Text = "Current Population: " + tribe._Species.Count;
			lblTopPred.Text = "Top Prediction: ";

			for (int i = 0; i < tribe._Species.Count; i++) {
				//tribe._Species.ge
			}
		}
	}
}
