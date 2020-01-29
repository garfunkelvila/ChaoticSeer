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
			this.btnMutateLink = new System.Windows.Forms.Button();
			this.btnMutateNode = new System.Windows.Forms.Button();
			this.btnMutateWeightShift = new System.Windows.Forms.Button();
			this.btnMutateWeightRandom = new System.Windows.Forms.Button();
			this.btnMutateLinkToggle = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.picCanvas = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
			this.SuspendLayout();
			// 
			// btnMutateLink
			// 
			this.btnMutateLink.Location = new System.Drawing.Point(12, 12);
			this.btnMutateLink.Name = "btnMutateLink";
			this.btnMutateLink.Size = new System.Drawing.Size(100, 51);
			this.btnMutateLink.TabIndex = 1;
			this.btnMutateLink.Text = "Mutate Link";
			this.btnMutateLink.UseVisualStyleBackColor = true;
			// 
			// btnMutateNode
			// 
			this.btnMutateNode.Location = new System.Drawing.Point(12, 69);
			this.btnMutateNode.Name = "btnMutateNode";
			this.btnMutateNode.Size = new System.Drawing.Size(100, 50);
			this.btnMutateNode.TabIndex = 1;
			this.btnMutateNode.Text = "Mutate Node";
			this.btnMutateNode.UseVisualStyleBackColor = true;
			// 
			// btnMutateWeightShift
			// 
			this.btnMutateWeightShift.Location = new System.Drawing.Point(12, 125);
			this.btnMutateWeightShift.Name = "btnMutateWeightShift";
			this.btnMutateWeightShift.Size = new System.Drawing.Size(100, 50);
			this.btnMutateWeightShift.TabIndex = 1;
			this.btnMutateWeightShift.Text = "Mutate Weight Shift";
			this.btnMutateWeightShift.UseVisualStyleBackColor = true;
			// 
			// btnMutateWeightRandom
			// 
			this.btnMutateWeightRandom.Location = new System.Drawing.Point(12, 181);
			this.btnMutateWeightRandom.Name = "btnMutateWeightRandom";
			this.btnMutateWeightRandom.Size = new System.Drawing.Size(100, 50);
			this.btnMutateWeightRandom.TabIndex = 1;
			this.btnMutateWeightRandom.Text = "Mutate Weight Random";
			this.btnMutateWeightRandom.UseVisualStyleBackColor = true;
			// 
			// btnMutateLinkToggle
			// 
			this.btnMutateLinkToggle.Location = new System.Drawing.Point(12, 237);
			this.btnMutateLinkToggle.Name = "btnMutateLinkToggle";
			this.btnMutateLinkToggle.Size = new System.Drawing.Size(100, 50);
			this.btnMutateLinkToggle.TabIndex = 1;
			this.btnMutateLinkToggle.Text = "Mutate Toggle Link";
			this.btnMutateLinkToggle.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.picCanvas);
			this.panel1.Location = new System.Drawing.Point(118, 12);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(686, 494);
			this.panel1.TabIndex = 2;
			// 
			// picCanvas
			// 
			this.picCanvas.Location = new System.Drawing.Point(5, 5);
			this.picCanvas.Name = "picCanvas";
			this.picCanvas.Size = new System.Drawing.Size(100, 50);
			this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picCanvas.TabIndex = 0;
			this.picCanvas.TabStop = false;
			// 
			// GeneticsTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(816, 518);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnMutateLinkToggle);
			this.Controls.Add(this.btnMutateWeightRandom);
			this.Controls.Add(this.btnMutateWeightShift);
			this.Controls.Add(this.btnMutateNode);
			this.Controls.Add(this.btnMutateLink);
			this.Name = "GeneticsTest";
			this.Text = "GeneticsTest";
			this.Load += new System.EventHandler(this.GeneticsTest_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMutateLink;
        private System.Windows.Forms.Button btnMutateNode;
        private System.Windows.Forms.Button btnMutateWeightShift;
        private System.Windows.Forms.Button btnMutateWeightRandom;
        private System.Windows.Forms.Button btnMutateLinkToggle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox picCanvas;
	}
}