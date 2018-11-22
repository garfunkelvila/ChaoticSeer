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

namespace Nice_Seer.Forms.Seer_Creation_setup {
    public partial class frmNewSeer : Form {
        public Seer[] seers = new Seer[123];

        public frmNewSeer () {
            InitializeComponent();
        }

        private void btnOk_Click (object sender, EventArgs e) {
            seers = new Seer[(int) numSpecie.Value];
            for (int i = 0; i < seers.Length; i++) {
                seers[i] = new Seer((int)numInput.Value, (int)numOutput.Value, (int)numLayer.Value);
            }            
        }
    }
}
