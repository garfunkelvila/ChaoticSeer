using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dark_Seer {
    public partial class SeerVisualizer : UserControl {
        //this thing is planned to visualize seer via text, and might be created dynamic and transfered into specie visualizer with weight view on different user control
        public SeerVisualizer () {
            InitializeComponent();
        }
        public void SetAnswer (double[] value) {
            a.Text = value[0].ToString();
            b.Text = value[0].ToString();
            c.Text = value[0].ToString();
            d.Text = value[0].ToString();
        }
    }
}
