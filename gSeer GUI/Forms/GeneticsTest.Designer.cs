namespace Nice_Seer.Forms {
    partial class GeneticsTest {
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
			this.button3 = new System.Windows.Forms.Button();
			this.btnEvaluate = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(6, 19);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(100, 50);
			this.button3.TabIndex = 1;
			this.button3.Text = "Evolve";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.btnEvolve_Click);
			// 
			// btnEvaluate
			// 
			this.btnEvaluate.Location = new System.Drawing.Point(6, 75);
			this.btnEvaluate.Name = "btnEvaluate";
			this.btnEvaluate.Size = new System.Drawing.Size(100, 50);
			this.btnEvaluate.TabIndex = 1;
			this.btnEvaluate.Text = "Evaluate";
			this.btnEvaluate.UseVisualStyleBackColor = true;
			this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_click);
			// 
			// groupBox2
			// 
			this.groupBox2.AutoSize = true;
			this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.button6);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.btnEvaluate);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(112, 410);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tribe";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 229);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 50);
			this.button2.TabIndex = 2;
			this.button2.Text = "Purge";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btnPurge_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(6, 285);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(100, 50);
			this.button6.TabIndex = 2;
			this.button6.Text = "Reproduce";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.btnReproduce_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 341);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 50);
			this.button1.TabIndex = 2;
			this.button1.Text = "Mutate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnMutate_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(131, 12);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(673, 558);
			this.flowLayoutPanel1.TabIndex = 6;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(13, 546);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 7;
			this.button4.Text = "100x";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// GeneticsTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(816, 582);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.groupBox2);
			this.Name = "GeneticsTest";
			this.Text = "GeneticsTest ChaoticNeat";
			this.Load += new System.EventHandler(this.GeneticsTest_Load);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btnEvaluate;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button4;
	}
}