namespace Nice_Seer.Custom_Controls {
	partial class LT {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
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
		private void InitializeComponent() {
			this.lblCurrentPop = new System.Windows.Forms.Label();
			this.btnStart100 = new System.Windows.Forms.Button();
			this.btnStart1000 = new System.Windows.Forms.Button();
			this.lblTopPred = new System.Windows.Forms.Label();
			this.txbAllPred = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblCurrentPop
			// 
			this.lblCurrentPop.AutoSize = true;
			this.lblCurrentPop.Location = new System.Drawing.Point(9, 38);
			this.lblCurrentPop.Name = "lblCurrentPop";
			this.lblCurrentPop.Size = new System.Drawing.Size(100, 13);
			this.lblCurrentPop.TabIndex = 0;
			this.lblCurrentPop.Text = "Current Population: ";
			// 
			// btnStart100
			// 
			this.btnStart100.Location = new System.Drawing.Point(12, 12);
			this.btnStart100.Name = "btnStart100";
			this.btnStart100.Size = new System.Drawing.Size(75, 23);
			this.btnStart100.TabIndex = 2;
			this.btnStart100.Text = "Start 100";
			this.btnStart100.UseVisualStyleBackColor = true;
			this.btnStart100.Click += new System.EventHandler(this.btnStart100_Click);
			// 
			// btnStart1000
			// 
			this.btnStart1000.Location = new System.Drawing.Point(93, 12);
			this.btnStart1000.Name = "btnStart1000";
			this.btnStart1000.Size = new System.Drawing.Size(75, 23);
			this.btnStart1000.TabIndex = 2;
			this.btnStart1000.Text = "Start 1000";
			this.btnStart1000.UseVisualStyleBackColor = true;
			// 
			// lblTopPred
			// 
			this.lblTopPred.AutoSize = true;
			this.lblTopPred.Location = new System.Drawing.Point(9, 51);
			this.lblTopPred.Name = "lblTopPred";
			this.lblTopPred.Size = new System.Drawing.Size(82, 13);
			this.lblTopPred.TabIndex = 0;
			this.lblTopPred.Text = "Top Prediction: ";
			// 
			// txbAllPred
			// 
			this.txbAllPred.Location = new System.Drawing.Point(12, 67);
			this.txbAllPred.Multiline = true;
			this.txbAllPred.Name = "txbAllPred";
			this.txbAllPred.Size = new System.Drawing.Size(186, 387);
			this.txbAllPred.TabIndex = 3;
			// 
			// LT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(212, 466);
			this.Controls.Add(this.txbAllPred);
			this.Controls.Add(this.btnStart1000);
			this.Controls.Add(this.btnStart100);
			this.Controls.Add(this.lblTopPred);
			this.Controls.Add(this.lblCurrentPop);
			this.Name = "LT";
			this.Text = "LT";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblCurrentPop;
		private System.Windows.Forms.Button btnStart100;
		private System.Windows.Forms.Button btnStart1000;
		private System.Windows.Forms.Label lblTopPred;
		private System.Windows.Forms.TextBox txbAllPred;
	}
}