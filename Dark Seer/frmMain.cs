using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neural_Network;
namespace Dark_Seer {
    public partial class frmMain : Form {
        System.Diagnostics.Stopwatch watch;
        Random r;
        neuralNetwork nn;
        public frmMain () {
            InitializeComponent();
            watch = new System.Diagnostics.Stopwatch();
        }
        private void btnTest_Click (object sender, EventArgs e) {
            //nn = new neuralNetwork(2,1);
#if DEBUG
            MessageBox.Show("DEBUG");
#endif
        }
    }
}
