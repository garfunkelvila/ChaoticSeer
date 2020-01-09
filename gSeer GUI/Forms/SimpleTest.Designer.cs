namespace Nice_Seer.Forms {
    partial class SimpleTest {
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
            this.btnTest = new System.Windows.Forms.Button();
            this.lblPred = new System.Windows.Forms.Label();
            this.trainLoop = new System.Windows.Forms.NumericUpDown();
            this.btnReTrain = new System.Windows.Forms.Button();
            this.lblCorrect = new System.Windows.Forms.Label();
            this.txbLogs = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trainLoop)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblPred
            // 
            this.lblPred.AutoSize = true;
            this.lblPred.Location = new System.Drawing.Point(13, 42);
            this.lblPred.Name = "lblPred";
            this.lblPred.Size = new System.Drawing.Size(35, 13);
            this.lblPred.TabIndex = 1;
            this.lblPred.Text = "label1";
            // 
            // trainLoop
            // 
            this.trainLoop.Location = new System.Drawing.Point(93, 15);
            this.trainLoop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trainLoop.Name = "trainLoop";
            this.trainLoop.Size = new System.Drawing.Size(55, 20);
            this.trainLoop.TabIndex = 2;
            this.trainLoop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnReTrain
            // 
            this.btnReTrain.Location = new System.Drawing.Point(12, 71);
            this.btnReTrain.Name = "btnReTrain";
            this.btnReTrain.Size = new System.Drawing.Size(75, 23);
            this.btnReTrain.TabIndex = 3;
            this.btnReTrain.Text = "Re-train";
            this.btnReTrain.UseVisualStyleBackColor = true;
            this.btnReTrain.Click += new System.EventHandler(this.btnReTrain_Click);
            // 
            // lblCorrect
            // 
            this.lblCorrect.AutoSize = true;
            this.lblCorrect.Location = new System.Drawing.Point(13, 55);
            this.lblCorrect.Name = "lblCorrect";
            this.lblCorrect.Size = new System.Drawing.Size(51, 13);
            this.lblCorrect.TabIndex = 1;
            this.lblCorrect.Text = "lblCorrect";
            // 
            // txbLogs
            // 
            this.txbLogs.Location = new System.Drawing.Point(13, 101);
            this.txbLogs.Multiline = true;
            this.txbLogs.Name = "txbLogs";
            this.txbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbLogs.Size = new System.Drawing.Size(290, 337);
            this.txbLogs.TabIndex = 4;
            // 
            // SimpleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 450);
            this.Controls.Add(this.txbLogs);
            this.Controls.Add(this.btnReTrain);
            this.Controls.Add(this.trainLoop);
            this.Controls.Add(this.lblCorrect);
            this.Controls.Add(this.lblPred);
            this.Controls.Add(this.btnTest);
            this.Name = "SimpleTest";
            this.Text = "SimpleTest";
            ((System.ComponentModel.ISupportInitialize)(this.trainLoop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblPred;
        private System.Windows.Forms.NumericUpDown trainLoop;
        private System.Windows.Forms.Button btnReTrain;
        private System.Windows.Forms.Label lblCorrect;
        private System.Windows.Forms.TextBox txbLogs;
    }
}