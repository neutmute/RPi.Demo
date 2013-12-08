namespace RPi.WinForms
{
    partial class FrmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericServo = new System.Windows.Forms.NumericUpDown();
            this.btnServoGo = new System.Windows.Forms.Button();
            this.trackBarServo = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackBarDcMotor = new System.Windows.Forms.TrackBar();
            this.groupBoxStepper = new System.Windows.Forms.GroupBox();
            this.textStepperBasic = new System.Windows.Forms.TextBox();
            this.numericStepperDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStepper = new System.Windows.Forms.Button();
            this.groupBoxLEF = new System.Windows.Forms.GroupBox();
            this.trackBarLed = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnStepperSequenceSet = new System.Windows.Forms.Button();
            this.btnStepperSequenceLoad = new System.Windows.Forms.Button();
            this.txtSequence = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackBarDcMotor2 = new System.Windows.Forms.TrackBar();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.textLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericServo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarServo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDcMotor)).BeginInit();
            this.groupBoxStepper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStepperDelay)).BeginInit();
            this.groupBoxLEF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLed)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDcMotor2)).BeginInit();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numericServo);
            this.groupBox1.Controls.Add(this.btnServoGo);
            this.groupBox1.Controls.Add(this.trackBarServo);
            this.groupBox1.Location = new System.Drawing.Point(6, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servo";
            // 
            // numericServo
            // 
            this.numericServo.Location = new System.Drawing.Point(10, 70);
            this.numericServo.Name = "numericServo";
            this.numericServo.Size = new System.Drawing.Size(58, 20);
            this.numericServo.TabIndex = 2;
            this.numericServo.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnServoGo
            // 
            this.btnServoGo.Location = new System.Drawing.Point(74, 70);
            this.btnServoGo.Name = "btnServoGo";
            this.btnServoGo.Size = new System.Drawing.Size(75, 23);
            this.btnServoGo.TabIndex = 1;
            this.btnServoGo.Text = "Go";
            this.btnServoGo.UseVisualStyleBackColor = true;
            this.btnServoGo.Click += new System.EventHandler(this.btnServoGo_Click);
            // 
            // trackBarServo
            // 
            this.trackBarServo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarServo.Location = new System.Drawing.Point(6, 19);
            this.trackBarServo.Maximum = 100;
            this.trackBarServo.Name = "trackBarServo";
            this.trackBarServo.Size = new System.Drawing.Size(440, 45);
            this.trackBarServo.TabIndex = 0;
            this.trackBarServo.Value = 50;
            this.trackBarServo.Scroll += new System.EventHandler(this.trackBarServo_Scroll);
            this.trackBarServo.ValueChanged += new System.EventHandler(this.trackBarServo_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.trackBarDcMotor);
            this.groupBox2.Location = new System.Drawing.Point(6, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DC Motor";
            // 
            // trackBarDcMotor
            // 
            this.trackBarDcMotor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarDcMotor.Location = new System.Drawing.Point(6, 19);
            this.trackBarDcMotor.Maximum = 100;
            this.trackBarDcMotor.Minimum = -100;
            this.trackBarDcMotor.Name = "trackBarDcMotor";
            this.trackBarDcMotor.Size = new System.Drawing.Size(444, 45);
            this.trackBarDcMotor.TabIndex = 0;
            this.trackBarDcMotor.Scroll += new System.EventHandler(this.trackBarDcMotor_Scroll);
            // 
            // groupBoxStepper
            // 
            this.groupBoxStepper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStepper.Controls.Add(this.textStepperBasic);
            this.groupBoxStepper.Controls.Add(this.numericStepperDelay);
            this.groupBoxStepper.Controls.Add(this.label2);
            this.groupBoxStepper.Controls.Add(this.label1);
            this.groupBoxStepper.Controls.Add(this.btnStepper);
            this.groupBoxStepper.Location = new System.Drawing.Point(6, 294);
            this.groupBoxStepper.Name = "groupBoxStepper";
            this.groupBoxStepper.Size = new System.Drawing.Size(483, 81);
            this.groupBoxStepper.TabIndex = 2;
            this.groupBoxStepper.TabStop = false;
            this.groupBoxStepper.Text = "Stepper";
            // 
            // textStepperBasic
            // 
            this.textStepperBasic.Location = new System.Drawing.Point(100, 17);
            this.textStepperBasic.Name = "textStepperBasic";
            this.textStepperBasic.Size = new System.Drawing.Size(68, 20);
            this.textStepperBasic.TabIndex = 5;
            this.textStepperBasic.Text = "100";
            // 
            // numericStepperDelay
            // 
            this.numericStepperDelay.Location = new System.Drawing.Point(100, 44);
            this.numericStepperDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericStepperDelay.Name = "numericStepperDelay";
            this.numericStepperDelay.Size = new System.Drawing.Size(68, 20);
            this.numericStepperDelay.TabIndex = 4;
            this.numericStepperDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Step Delay (ms)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Steps";
            // 
            // btnStepper
            // 
            this.btnStepper.Location = new System.Drawing.Point(186, 44);
            this.btnStepper.Name = "btnStepper";
            this.btnStepper.Size = new System.Drawing.Size(75, 23);
            this.btnStepper.TabIndex = 1;
            this.btnStepper.Text = "Go";
            this.btnStepper.UseVisualStyleBackColor = true;
            this.btnStepper.Click += new System.EventHandler(this.btnStepper_Click);
            // 
            // groupBoxLEF
            // 
            this.groupBoxLEF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLEF.Controls.Add(this.trackBarLed);
            this.groupBoxLEF.Location = new System.Drawing.Point(6, 19);
            this.groupBoxLEF.Name = "groupBoxLEF";
            this.groupBoxLEF.Size = new System.Drawing.Size(481, 73);
            this.groupBoxLEF.TabIndex = 4;
            this.groupBoxLEF.TabStop = false;
            this.groupBoxLEF.Text = "LED";
            // 
            // trackBarLed
            // 
            this.trackBarLed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarLed.Location = new System.Drawing.Point(7, 20);
            this.trackBarLed.Maximum = 100;
            this.trackBarLed.Name = "trackBarLed";
            this.trackBarLed.Size = new System.Drawing.Size(439, 45);
            this.trackBarLed.TabIndex = 0;
            this.trackBarLed.Scroll += new System.EventHandler(this.trackBarLed_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 539);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxLEF);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBoxStepper);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(495, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnStepperSequenceSet);
            this.tabPage3.Controls.Add(this.btnStepperSequenceLoad);
            this.tabPage3.Controls.Add(this.txtSequence);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(495, 513);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Stepper Debug";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnStepperSequenceSet
            // 
            this.btnStepperSequenceSet.Location = new System.Drawing.Point(160, 32);
            this.btnStepperSequenceSet.Name = "btnStepperSequenceSet";
            this.btnStepperSequenceSet.Size = new System.Drawing.Size(135, 23);
            this.btnStepperSequenceSet.TabIndex = 2;
            this.btnStepperSequenceSet.Text = "Set Sequence";
            this.btnStepperSequenceSet.UseVisualStyleBackColor = true;
            this.btnStepperSequenceSet.Click += new System.EventHandler(this.btnStepperSequenceSet_Click);
            // 
            // btnStepperSequenceLoad
            // 
            this.btnStepperSequenceLoad.Location = new System.Drawing.Point(160, 3);
            this.btnStepperSequenceLoad.Name = "btnStepperSequenceLoad";
            this.btnStepperSequenceLoad.Size = new System.Drawing.Size(135, 23);
            this.btnStepperSequenceLoad.TabIndex = 1;
            this.btnStepperSequenceLoad.Text = "Load Sequence";
            this.btnStepperSequenceLoad.UseVisualStyleBackColor = true;
            this.btnStepperSequenceLoad.Click += new System.EventHandler(this.btnStepperSequenceLoad_Click);
            // 
            // txtSequence
            // 
            this.txtSequence.Location = new System.Drawing.Point(0, 0);
            this.txtSequence.Multiline = true;
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.Size = new System.Drawing.Size(154, 384);
            this.txtSequence.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(495, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RPi.WinForms.Properties.Resources.rightArrow;
            this.pictureBox2.Location = new System.Drawing.Point(107, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 48);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RPi.WinForms.Properties.Resources.LeftArrow;
            this.pictureBox1.Location = new System.Drawing.Point(35, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 48);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(28, 185);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(450, 77);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ball Load";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Fire";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.trackBarDcMotor2);
            this.groupBox3.Location = new System.Drawing.Point(21, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 66);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Launcher";
            // 
            // trackBarDcMotor2
            // 
            this.trackBarDcMotor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarDcMotor2.Location = new System.Drawing.Point(3, 16);
            this.trackBarDcMotor2.Maximum = 100;
            this.trackBarDcMotor2.Minimum = -100;
            this.trackBarDcMotor2.Name = "trackBarDcMotor2";
            this.trackBarDcMotor2.Size = new System.Drawing.Size(444, 47);
            this.trackBarDcMotor2.TabIndex = 0;
            this.trackBarDcMotor2.Scroll += new System.EventHandler(this.trackBarDcMotor_Scroll);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.textLog);
            this.groupBoxLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxLog.Location = new System.Drawing.Point(503, 0);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(336, 539);
            this.groupBoxLog.TabIndex = 6;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // textLog
            // 
            this.textLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLog.Location = new System.Drawing.Point(3, 16);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(330, 520);
            this.textLog.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 539);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBoxLog);
            this.Name = "FrmMain";
            this.Text = "PWM Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericServo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarServo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDcMotor)).EndInit();
            this.groupBoxStepper.ResumeLayout(false);
            this.groupBoxStepper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStepperDelay)).EndInit();
            this.groupBoxLEF.ResumeLayout(false);
            this.groupBoxLEF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLed)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDcMotor2)).EndInit();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBarServo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar trackBarDcMotor;
        private System.Windows.Forms.GroupBox groupBoxStepper;
        private System.Windows.Forms.NumericUpDown numericStepperDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStepper;
        private System.Windows.Forms.GroupBox groupBoxLEF;
        private System.Windows.Forms.TrackBar trackBarLed;
        private System.Windows.Forms.NumericUpDown numericServo;
        private System.Windows.Forms.Button btnServoGo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackBarDcMotor2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnStepperSequenceLoad;
        private System.Windows.Forms.TextBox txtSequence;
        private System.Windows.Forms.Button btnStepperSequenceSet;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.TextBox textStepperBasic;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

