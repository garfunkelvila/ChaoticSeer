//  Copyright (C) 2018  Garfunkel Vila
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
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
            this.Close();
        }
    }
}
