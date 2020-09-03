using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Chaotic_Seer.NEAT;
using Chaotic_Seer.Util;

namespace GUI {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Neat.Initialize();

            lblPopulation.Text = "Population: " + Neat.Genomes.Count;
            lblSpecies.Text = "Species: " + Neat.Species.Count;
        }

    }
}
