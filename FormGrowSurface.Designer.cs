namespace GrowingSurfaces
{
    partial class FormGrowSurface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonAutomatic = new System.Windows.Forms.Button();
            this.buttonDeposition = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonReset = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownIt = new System.Windows.Forms.NumericUpDown();
            this.label_Latency = new System.Windows.Forms.Label();
            this.trackBar_Latency = new System.Windows.Forms.TrackBar();
            this.groupBoxMethod = new System.Windows.Forms.GroupBox();
            this.radioButtonDST = new System.Windows.Forms.RadioButton();
            this.radioButtonWolfV = new System.Windows.Forms.RadioButton();
            this.radioButtonRDSR = new System.Windows.Forms.RadioButton();
            this.radioButtonRSOS = new System.Windows.Forms.RadioButton();
            this.radioButtonDLA = new System.Windows.Forms.RadioButton();
            this.radioButtonBallistic = new System.Windows.Forms.RadioButton();
            this.radioButtonRandom = new System.Windows.Forms.RadioButton();
            this.radioButtonEden = new System.Windows.Forms.RadioButton();
            this.groupBoxStructure = new System.Windows.Forms.GroupBox();
            this.textBox_H = new System.Windows.Forms.TextBox();
            this.textBox_L = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMethod = new System.Windows.Forms.Label();
            this.label_Step = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_W_t = new System.Windows.Forms.PictureBox();
            this.pictureBoxHave = new System.Windows.Forms.PictureBox();
            this.buttonSnapshot = new System.Windows.Forms.Button();
            this.checkBoxWedged = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Latency)).BeginInit();
            this.groupBoxMethod.SuspendLayout();
            this.groupBoxStructure.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_W_t)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHave)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAutomatic
            // 
            this.buttonAutomatic.Location = new System.Drawing.Point(12, 27);
            this.buttonAutomatic.Name = "buttonAutomatic";
            this.buttonAutomatic.Size = new System.Drawing.Size(124, 23);
            this.buttonAutomatic.TabIndex = 0;
            this.buttonAutomatic.Text = "Automatic Depositions";
            this.buttonAutomatic.UseVisualStyleBackColor = true;
            this.buttonAutomatic.Click += new System.EventHandler(this.buttonAutomatic_Click);
            // 
            // buttonDeposition
            // 
            this.buttonDeposition.Location = new System.Drawing.Point(142, 27);
            this.buttonDeposition.Name = "buttonDeposition";
            this.buttonDeposition.Size = new System.Drawing.Size(124, 23);
            this.buttonDeposition.TabIndex = 1;
            this.buttonDeposition.Text = "One Deposition";
            this.buttonDeposition.UseVisualStyleBackColor = true;
            this.buttonDeposition.Click += new System.EventHandler(this.buttonDeposition_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(22, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(382, 510);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(286, 27);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(665, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "steps";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Show a sample every";
            // 
            // numericUpDownIt
            // 
            this.numericUpDownIt.Location = new System.Drawing.Point(595, 30);
            this.numericUpDownIt.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownIt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIt.Name = "numericUpDownIt";
            this.numericUpDownIt.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownIt.TabIndex = 22;
            this.numericUpDownIt.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label_Latency
            // 
            this.label_Latency.AutoSize = true;
            this.label_Latency.Location = new System.Drawing.Point(724, 32);
            this.label_Latency.Name = "label_Latency";
            this.label_Latency.Size = new System.Drawing.Size(190, 26);
            this.label_Latency.TabIndex = 21;
            this.label_Latency.Text = "Latency \r\n( time interval  between  two  showing )";
            // 
            // trackBar_Latency
            // 
            this.trackBar_Latency.Location = new System.Drawing.Point(910, 28);
            this.trackBar_Latency.Name = "trackBar_Latency";
            this.trackBar_Latency.Size = new System.Drawing.Size(126, 45);
            this.trackBar_Latency.TabIndex = 20;
            this.trackBar_Latency.Value = 9;
            this.trackBar_Latency.Scroll += new System.EventHandler(this.trackBar_Latency_Scroll);
            // 
            // groupBoxMethod
            // 
            this.groupBoxMethod.Controls.Add(this.checkBoxWedged);
            this.groupBoxMethod.Controls.Add(this.radioButtonDST);
            this.groupBoxMethod.Controls.Add(this.radioButtonWolfV);
            this.groupBoxMethod.Controls.Add(this.radioButtonRDSR);
            this.groupBoxMethod.Controls.Add(this.radioButtonRSOS);
            this.groupBoxMethod.Controls.Add(this.radioButtonDLA);
            this.groupBoxMethod.Controls.Add(this.radioButtonBallistic);
            this.groupBoxMethod.Controls.Add(this.radioButtonRandom);
            this.groupBoxMethod.Controls.Add(this.radioButtonEden);
            this.groupBoxMethod.Location = new System.Drawing.Point(410, 191);
            this.groupBoxMethod.Name = "groupBoxMethod";
            this.groupBoxMethod.Size = new System.Drawing.Size(129, 240);
            this.groupBoxMethod.TabIndex = 25;
            this.groupBoxMethod.TabStop = false;
            this.groupBoxMethod.Text = "Deposition Method";
            // 
            // radioButtonDST
            // 
            this.radioButtonDST.AutoSize = true;
            this.radioButtonDST.Location = new System.Drawing.Point(6, 180);
            this.radioButtonDST.Name = "radioButtonDST";
            this.radioButtonDST.Size = new System.Drawing.Size(107, 17);
            this.radioButtonDST.TabIndex = 7;
            this.radioButtonDST.Text = "Das.Sarma-Tam..";
            this.radioButtonDST.UseVisualStyleBackColor = true;
            // 
            // radioButtonWolfV
            // 
            this.radioButtonWolfV.AutoSize = true;
            this.radioButtonWolfV.Checked = true;
            this.radioButtonWolfV.Location = new System.Drawing.Point(6, 157);
            this.radioButtonWolfV.Name = "radioButtonWolfV";
            this.radioButtonWolfV.Size = new System.Drawing.Size(77, 17);
            this.radioButtonWolfV.TabIndex = 6;
            this.radioButtonWolfV.TabStop = true;
            this.radioButtonWolfV.Text = "Wolf-Villain";
            this.radioButtonWolfV.UseVisualStyleBackColor = true;
            // 
            // radioButtonRDSR
            // 
            this.radioButtonRDSR.AutoSize = true;
            this.radioButtonRDSR.Location = new System.Drawing.Point(6, 134);
            this.radioButtonRDSR.Name = "radioButtonRDSR";
            this.radioButtonRDSR.Size = new System.Drawing.Size(56, 17);
            this.radioButtonRDSR.TabIndex = 5;
            this.radioButtonRDSR.TabStop = true;
            this.radioButtonRDSR.Text = "RDSR";
            this.radioButtonRDSR.UseVisualStyleBackColor = true;
            // 
            // radioButtonRSOS
            // 
            this.radioButtonRSOS.AutoSize = true;
            this.radioButtonRSOS.Location = new System.Drawing.Point(6, 111);
            this.radioButtonRSOS.Name = "radioButtonRSOS";
            this.radioButtonRSOS.Size = new System.Drawing.Size(55, 17);
            this.radioButtonRSOS.TabIndex = 4;
            this.radioButtonRSOS.TabStop = true;
            this.radioButtonRSOS.Text = "RSOS";
            this.radioButtonRSOS.UseVisualStyleBackColor = true;
            // 
            // radioButtonDLA
            // 
            this.radioButtonDLA.AutoSize = true;
            this.radioButtonDLA.Location = new System.Drawing.Point(6, 89);
            this.radioButtonDLA.Name = "radioButtonDLA";
            this.radioButtonDLA.Size = new System.Drawing.Size(46, 17);
            this.radioButtonDLA.TabIndex = 3;
            this.radioButtonDLA.TabStop = true;
            this.radioButtonDLA.Text = "DLA";
            this.radioButtonDLA.UseVisualStyleBackColor = true;
            // 
            // radioButtonBallistic
            // 
            this.radioButtonBallistic.AutoSize = true;
            this.radioButtonBallistic.Location = new System.Drawing.Point(6, 66);
            this.radioButtonBallistic.Name = "radioButtonBallistic";
            this.radioButtonBallistic.Size = new System.Drawing.Size(60, 17);
            this.radioButtonBallistic.TabIndex = 2;
            this.radioButtonBallistic.TabStop = true;
            this.radioButtonBallistic.Text = "Ballistic";
            this.radioButtonBallistic.UseVisualStyleBackColor = true;
            // 
            // radioButtonRandom
            // 
            this.radioButtonRandom.AutoSize = true;
            this.radioButtonRandom.Location = new System.Drawing.Point(6, 43);
            this.radioButtonRandom.Name = "radioButtonRandom";
            this.radioButtonRandom.Size = new System.Drawing.Size(65, 17);
            this.radioButtonRandom.TabIndex = 1;
            this.radioButtonRandom.TabStop = true;
            this.radioButtonRandom.Text = "Random";
            this.radioButtonRandom.UseVisualStyleBackColor = true;
            // 
            // radioButtonEden
            // 
            this.radioButtonEden.AutoSize = true;
            this.radioButtonEden.Location = new System.Drawing.Point(6, 20);
            this.radioButtonEden.Name = "radioButtonEden";
            this.radioButtonEden.Size = new System.Drawing.Size(82, 17);
            this.radioButtonEden.TabIndex = 0;
            this.radioButtonEden.Text = "Eden Model";
            this.radioButtonEden.UseVisualStyleBackColor = true;
            // 
            // groupBoxStructure
            // 
            this.groupBoxStructure.Controls.Add(this.textBox_H);
            this.groupBoxStructure.Controls.Add(this.textBox_L);
            this.groupBoxStructure.Controls.Add(this.label3);
            this.groupBoxStructure.Controls.Add(this.label2);
            this.groupBoxStructure.Location = new System.Drawing.Point(410, 76);
            this.groupBoxStructure.Name = "groupBoxStructure";
            this.groupBoxStructure.Size = new System.Drawing.Size(129, 109);
            this.groupBoxStructure.TabIndex = 26;
            this.groupBoxStructure.TabStop = false;
            this.groupBoxStructure.Text = "Structure";
            // 
            // textBox_H
            // 
            this.textBox_H.Location = new System.Drawing.Point(56, 84);
            this.textBox_H.Name = "textBox_H";
            this.textBox_H.Size = new System.Drawing.Size(55, 20);
            this.textBox_H.TabIndex = 28;
            // 
            // textBox_L
            // 
            this.textBox_L.Location = new System.Drawing.Point(56, 40);
            this.textBox_L.Name = "textBox_L";
            this.textBox_L.Size = new System.Drawing.Size(55, 20);
            this.textBox_L.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "H (max Height of Box)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "L (Width of Substrate)";
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMethod.Location = new System.Drawing.Point(19, 61);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(49, 13);
            this.labelMethod.TabIndex = 27;
            this.labelMethod.Text = "Method";
            // 
            // label_Step
            // 
            this.label_Step.AutoSize = true;
            this.label_Step.Location = new System.Drawing.Point(239, 62);
            this.label_Step.Name = "label_Step";
            this.label_Step.Size = new System.Drawing.Size(26, 13);
            this.label_Step.TabIndex = 28;
            this.label_Step.Text = "stps";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1040, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBox_W_t
            // 
            this.pictureBox_W_t.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_W_t.Location = new System.Drawing.Point(545, 83);
            this.pictureBox_W_t.Name = "pictureBox_W_t";
            this.pictureBox_W_t.Size = new System.Drawing.Size(309, 244);
            this.pictureBox_W_t.TabIndex = 30;
            this.pictureBox_W_t.TabStop = false;
            this.pictureBox_W_t.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_W_t_Paint);
            this.pictureBox_W_t.DoubleClick += new System.EventHandler(this.pictureBox_W_t_DoubleClick);
            // 
            // pictureBoxHave
            // 
            this.pictureBoxHave.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxHave.Location = new System.Drawing.Point(545, 333);
            this.pictureBoxHave.Name = "pictureBoxHave";
            this.pictureBoxHave.Size = new System.Drawing.Size(309, 244);
            this.pictureBoxHave.TabIndex = 31;
            this.pictureBoxHave.TabStop = false;
            this.pictureBoxHave.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxHave_Paint);
            this.pictureBoxHave.DoubleClick += new System.EventHandler(this.pictureBoxHave_DoubleClick);
            // 
            // buttonSnapshot
            // 
            this.buttonSnapshot.Location = new System.Drawing.Point(378, 27);
            this.buttonSnapshot.Name = "buttonSnapshot";
            this.buttonSnapshot.Size = new System.Drawing.Size(75, 23);
            this.buttonSnapshot.TabIndex = 32;
            this.buttonSnapshot.Text = "Snapshot";
            this.buttonSnapshot.UseVisualStyleBackColor = true;
            this.buttonSnapshot.Click += new System.EventHandler(this.buttonSnapshot_Click);
            // 
            // checkBoxWedged
            // 
            this.checkBoxWedged.AutoSize = true;
            this.checkBoxWedged.Location = new System.Drawing.Point(6, 217);
            this.checkBoxWedged.Name = "checkBoxWedged";
            this.checkBoxWedged.Size = new System.Drawing.Size(109, 17);
            this.checkBoxWedged.TabIndex = 8;
            this.checkBoxWedged.Text = "Wedged Substrte";
            this.checkBoxWedged.UseVisualStyleBackColor = true;
            // 
            // FormGrowSurface
            // 
            this.AcceptButton = this.buttonAutomatic;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1040, 609);
            this.Controls.Add(this.buttonSnapshot);
            this.Controls.Add(this.pictureBoxHave);
            this.Controls.Add(this.pictureBox_W_t);
            this.Controls.Add(this.label_Step);
            this.Controls.Add(this.labelMethod);
            this.Controls.Add(this.groupBoxStructure);
            this.Controls.Add(this.groupBoxMethod);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownIt);
            this.Controls.Add(this.label_Latency);
            this.Controls.Add(this.trackBar_Latency);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonDeposition);
            this.Controls.Add(this.buttonAutomatic);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGrowSurface";
            this.Text = "Growing Surfaces";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGrowSurface_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Latency)).EndInit();
            this.groupBoxMethod.ResumeLayout(false);
            this.groupBoxMethod.PerformLayout();
            this.groupBoxStructure.ResumeLayout(false);
            this.groupBoxStructure.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_W_t)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAutomatic;
        private System.Windows.Forms.Button buttonDeposition;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownIt;
        private System.Windows.Forms.Label label_Latency;
        private System.Windows.Forms.TrackBar trackBar_Latency;
        private System.Windows.Forms.GroupBox groupBoxMethod;
        private System.Windows.Forms.RadioButton radioButtonDLA;
        private System.Windows.Forms.RadioButton radioButtonBallistic;
        private System.Windows.Forms.RadioButton radioButtonRandom;
        private System.Windows.Forms.RadioButton radioButtonEden;
        private System.Windows.Forms.GroupBox groupBoxStructure;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.TextBox textBox_H;
        private System.Windows.Forms.TextBox textBox_L;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Step;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonRSOS;
        private System.Windows.Forms.PictureBox pictureBox_W_t;
        private System.Windows.Forms.PictureBox pictureBoxHave;
        private System.Windows.Forms.RadioButton radioButtonRDSR;
        private System.Windows.Forms.Button buttonSnapshot;
        private System.Windows.Forms.RadioButton radioButtonWolfV;
        private System.Windows.Forms.RadioButton radioButtonDST;
        private System.Windows.Forms.CheckBox checkBoxWedged;
    }
}

