namespace Nice_Seer.Forms.Seer_Creation_setup {
    partial class frmNewSeer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numOutput = new System.Windows.Forms.NumericUpDown();
            this.numInput = new System.Windows.Forms.NumericUpDown();
            this.numLayer = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbModelName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numSpecie = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecie)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Output count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input count";
            // 
            // numOutput
            // 
            this.numOutput.Location = new System.Drawing.Point(92, 179);
            this.numOutput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOutput.Name = "numOutput";
            this.numOutput.Size = new System.Drawing.Size(60, 20);
            this.numOutput.TabIndex = 2;
            this.numOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOutput.ThousandsSeparator = true;
            this.numOutput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numInput
            // 
            this.numInput.Location = new System.Drawing.Point(92, 153);
            this.numInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInput.Name = "numInput";
            this.numInput.Size = new System.Drawing.Size(60, 20);
            this.numInput.TabIndex = 1;
            this.numInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numInput.ThousandsSeparator = true;
            this.numInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numLayer
            // 
            this.numLayer.Location = new System.Drawing.Point(92, 205);
            this.numLayer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLayer.Name = "numLayer";
            this.numLayer.Size = new System.Drawing.Size(60, 20);
            this.numLayer.TabIndex = 3;
            this.numLayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLayer.ThousandsSeparator = true;
            this.numLayer.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Layer count";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(77, 257);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(158, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Model name";
            // 
            // txbModelName
            // 
            this.txbModelName.Location = new System.Drawing.Point(92, 127);
            this.txbModelName.Name = "txbModelName";
            this.txbModelName.Size = new System.Drawing.Size(141, 20);
            this.txbModelName.TabIndex = 0;
            this.txbModelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3);
            this.label5.Size = new System.Drawing.Size(221, 101);
            this.label5.TabIndex = 5;
            this.label5.Text = "This thing creates a generic model. Hidden layer neuron count is 1.1 times the ou" +
    "tput. If you want to create a custom model, use the other one.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Specie count";
            // 
            // numSpecie
            // 
            this.numSpecie.Location = new System.Drawing.Point(92, 231);
            this.numSpecie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpecie.Name = "numSpecie";
            this.numSpecie.Size = new System.Drawing.Size(60, 20);
            this.numSpecie.TabIndex = 7;
            this.numSpecie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSpecie.ThousandsSeparator = true;
            this.numSpecie.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // frmNewSeer
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(249, 294);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numSpecie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbModelName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numLayer);
            this.Controls.Add(this.numInput);
            this.Controls.Add(this.numOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewSeer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Seer";
            ((System.ComponentModel.ISupportInitialize)(this.numOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numOutput;
        private System.Windows.Forms.NumericUpDown numInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numLayer;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbModelName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numSpecie;
    }
}