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
            this.components = new System.ComponentModel.Container();
            this.lblPred = new System.Windows.Forms.Label();
            this.trainLoop = new System.Windows.Forms.NumericUpDown();
            this.lblCorrect = new System.Windows.Forms.Label();
            this.txbLogs = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.l1n1w1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.l1n1w2 = new System.Windows.Forms.TextBox();
            this.l1n1e = new System.Windows.Forms.TextBox();
            this.l1n1b = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.o1n1e = new System.Windows.Forms.TextBox();
            this.o1n1b = new System.Windows.Forms.TextBox();
            this.o1n1w2 = new System.Windows.Forms.TextBox();
            this.o1n1w1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l1n2w2 = new System.Windows.Forms.TextBox();
            this.l1n2e = new System.Windows.Forms.TextBox();
            this.l1n2b = new System.Windows.Forms.TextBox();
            this.l1n2w1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pred1 = new System.Windows.Forms.Label();
            this.pred2 = new System.Windows.Forms.Label();
            this.pred3 = new System.Windows.Forms.Label();
            this.pred4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trainLoop)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPred
            // 
            this.lblPred.AutoSize = true;
            this.lblPred.Location = new System.Drawing.Point(12, 9);
            this.lblPred.Name = "lblPred";
            this.lblPred.Size = new System.Drawing.Size(35, 13);
            this.lblPred.TabIndex = 1;
            this.lblPred.Text = "label1";
            // 
            // trainLoop
            // 
            this.trainLoop.Location = new System.Drawing.Point(222, 22);
            this.trainLoop.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
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
            // lblCorrect
            // 
            this.lblCorrect.AutoSize = true;
            this.lblCorrect.Location = new System.Drawing.Point(12, 22);
            this.lblCorrect.Name = "lblCorrect";
            this.lblCorrect.Size = new System.Drawing.Size(51, 13);
            this.lblCorrect.TabIndex = 1;
            this.lblCorrect.Text = "lblCorrect";
            // 
            // txbLogs
            // 
            this.txbLogs.Location = new System.Drawing.Point(13, 64);
            this.txbLogs.Multiline = true;
            this.txbLogs.Name = "txbLogs";
            this.txbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbLogs.Size = new System.Drawing.Size(102, 173);
            this.txbLogs.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // l1n1w1
            // 
            this.l1n1w1.Location = new System.Drawing.Point(6, 32);
            this.l1n1w1.Name = "l1n1w1";
            this.l1n1w1.Size = new System.Drawing.Size(65, 20);
            this.l1n1w1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.l1n1w2);
            this.groupBox1.Controls.Add(this.l1n1e);
            this.groupBox1.Controls.Add(this.l1n1b);
            this.groupBox1.Controls.Add(this.l1n1w1);
            this.groupBox1.Location = new System.Drawing.Point(141, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 95);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Weight";
            // 
            // l1n1w2
            // 
            this.l1n1w2.Location = new System.Drawing.Point(6, 58);
            this.l1n1w2.Name = "l1n1w2";
            this.l1n1w2.Size = new System.Drawing.Size(65, 20);
            this.l1n1w2.TabIndex = 5;
            // 
            // l1n1e
            // 
            this.l1n1e.Location = new System.Drawing.Point(77, 58);
            this.l1n1e.Name = "l1n1e";
            this.l1n1e.Size = new System.Drawing.Size(49, 20);
            this.l1n1e.TabIndex = 5;
            // 
            // l1n1b
            // 
            this.l1n1b.Location = new System.Drawing.Point(77, 32);
            this.l1n1b.Name = "l1n1b";
            this.l1n1b.Size = new System.Drawing.Size(49, 20);
            this.l1n1b.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.o1n1e);
            this.groupBox3.Controls.Add(this.o1n1b);
            this.groupBox3.Controls.Add(this.o1n1w2);
            this.groupBox3.Controls.Add(this.o1n1w1);
            this.groupBox3.Location = new System.Drawing.Point(279, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(132, 95);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bias";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Weight";
            // 
            // o1n1e
            // 
            this.o1n1e.Location = new System.Drawing.Point(77, 58);
            this.o1n1e.Name = "o1n1e";
            this.o1n1e.Size = new System.Drawing.Size(49, 20);
            this.o1n1e.TabIndex = 5;
            // 
            // o1n1b
            // 
            this.o1n1b.Location = new System.Drawing.Point(77, 32);
            this.o1n1b.Name = "o1n1b";
            this.o1n1b.Size = new System.Drawing.Size(49, 20);
            this.o1n1b.TabIndex = 5;
            // 
            // o1n1w2
            // 
            this.o1n1w2.Location = new System.Drawing.Point(6, 58);
            this.o1n1w2.Name = "o1n1w2";
            this.o1n1w2.Size = new System.Drawing.Size(65, 20);
            this.o1n1w2.TabIndex = 5;
            // 
            // o1n1w1
            // 
            this.o1n1w1.Location = new System.Drawing.Point(6, 32);
            this.o1n1w1.Name = "o1n1w1";
            this.o1n1w1.Size = new System.Drawing.Size(65, 20);
            this.o1n1w1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.l1n2w2);
            this.groupBox2.Controls.Add(this.l1n2e);
            this.groupBox2.Controls.Add(this.l1n2b);
            this.groupBox2.Controls.Add(this.l1n2w1);
            this.groupBox2.Location = new System.Drawing.Point(141, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 95);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Bias";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Weight";
            // 
            // l1n2w2
            // 
            this.l1n2w2.Location = new System.Drawing.Point(6, 58);
            this.l1n2w2.Name = "l1n2w2";
            this.l1n2w2.Size = new System.Drawing.Size(65, 20);
            this.l1n2w2.TabIndex = 5;
            // 
            // l1n2e
            // 
            this.l1n2e.Location = new System.Drawing.Point(77, 58);
            this.l1n2e.Name = "l1n2e";
            this.l1n2e.Size = new System.Drawing.Size(49, 20);
            this.l1n2e.TabIndex = 5;
            // 
            // l1n2b
            // 
            this.l1n2b.Location = new System.Drawing.Point(77, 32);
            this.l1n2b.Name = "l1n2b";
            this.l1n2b.Size = new System.Drawing.Size(49, 20);
            this.l1n2b.TabIndex = 5;
            // 
            // l1n2w1
            // 
            this.l1n2w1.Location = new System.Drawing.Point(6, 32);
            this.l1n2w1.Name = "l1n2w1";
            this.l1n2w1.Size = new System.Drawing.Size(65, 20);
            this.l1n2w1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pred1
            // 
            this.pred1.AutoSize = true;
            this.pred1.Location = new System.Drawing.Point(417, 64);
            this.pred1.Name = "pred1";
            this.pred1.Size = new System.Drawing.Size(35, 13);
            this.pred1.TabIndex = 8;
            this.pred1.Text = "label7";
            // 
            // pred2
            // 
            this.pred2.AutoSize = true;
            this.pred2.Location = new System.Drawing.Point(417, 77);
            this.pred2.Name = "pred2";
            this.pred2.Size = new System.Drawing.Size(35, 13);
            this.pred2.TabIndex = 8;
            this.pred2.Text = "label7";
            // 
            // pred3
            // 
            this.pred3.AutoSize = true;
            this.pred3.Location = new System.Drawing.Point(417, 90);
            this.pred3.Name = "pred3";
            this.pred3.Size = new System.Drawing.Size(35, 13);
            this.pred3.TabIndex = 8;
            this.pred3.Text = "label7";
            // 
            // pred4
            // 
            this.pred4.AutoSize = true;
            this.pred4.Location = new System.Drawing.Point(417, 103);
            this.pred4.Name = "pred4";
            this.pred4.Size = new System.Drawing.Size(35, 13);
            this.pred4.TabIndex = 8;
            this.pred4.Text = "label7";
            // 
            // SimpleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 434);
            this.Controls.Add(this.pred4);
            this.Controls.Add(this.pred3);
            this.Controls.Add(this.pred2);
            this.Controls.Add(this.pred1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txbLogs);
            this.Controls.Add(this.trainLoop);
            this.Controls.Add(this.lblCorrect);
            this.Controls.Add(this.lblPred);
            this.Name = "SimpleTest";
            this.Text = "SimpleTest";
            ((System.ComponentModel.ISupportInitialize)(this.trainLoop)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPred;
        private System.Windows.Forms.NumericUpDown trainLoop;
        private System.Windows.Forms.Label lblCorrect;
        private System.Windows.Forms.TextBox txbLogs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox l1n1w1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox l1n1w2;
        private System.Windows.Forms.TextBox l1n1b;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox o1n1b;
        private System.Windows.Forms.TextBox o1n1w1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox l1n2w2;
        private System.Windows.Forms.TextBox l1n2b;
        private System.Windows.Forms.TextBox l1n2w1;
        private System.Windows.Forms.TextBox o1n1w2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox l1n1e;
        private System.Windows.Forms.TextBox o1n1e;
        private System.Windows.Forms.TextBox l1n2e;
        private System.Windows.Forms.Label pred1;
        private System.Windows.Forms.Label pred2;
        private System.Windows.Forms.Label pred3;
        private System.Windows.Forms.Label pred4;
    }
}