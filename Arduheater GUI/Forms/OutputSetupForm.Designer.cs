namespace Arduheater_GUI.Forms
{
    partial class OutputSetupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Temperature = new System.Windows.Forms.NumericUpDown();
            this.Setpoint = new System.Windows.Forms.NumericUpDown();
            this.MinPWM = new System.Windows.Forms.NumericUpDown();
            this.MaxPWM = new System.Windows.Forms.NumericUpDown();
            this.Kp = new System.Windows.Forms.NumericUpDown();
            this.Ki = new System.Windows.Forms.NumericUpDown();
            this.Kd = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.Autostart = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Chart = new Arduheater_GUI.PIDChart();
            ((System.ComponentModel.ISupportInitialize)(this.Temperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Setpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kd)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Temperature offset:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Setpoint offset:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Min PWM:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max PWM:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kp:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ki:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Kd:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Temperature
            // 
            this.Temperature.DecimalPlaces = 1;
            this.Temperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Temperature.Enabled = false;
            this.Temperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Temperature.Location = new System.Drawing.Point(133, 3);
            this.Temperature.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Temperature.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(64, 20);
            this.Temperature.TabIndex = 7;
            // 
            // Setpoint
            // 
            this.Setpoint.DecimalPlaces = 1;
            this.Setpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Setpoint.Enabled = false;
            this.Setpoint.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Setpoint.Location = new System.Drawing.Point(133, 29);
            this.Setpoint.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Setpoint.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.Setpoint.Name = "Setpoint";
            this.Setpoint.Size = new System.Drawing.Size(64, 20);
            this.Setpoint.TabIndex = 8;
            // 
            // MinPWM
            // 
            this.MinPWM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinPWM.Enabled = false;
            this.MinPWM.Location = new System.Drawing.Point(133, 55);
            this.MinPWM.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MinPWM.Name = "MinPWM";
            this.MinPWM.Size = new System.Drawing.Size(64, 20);
            this.MinPWM.TabIndex = 9;
            // 
            // MaxPWM
            // 
            this.MaxPWM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxPWM.Enabled = false;
            this.MaxPWM.Location = new System.Drawing.Point(133, 81);
            this.MaxPWM.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MaxPWM.Name = "MaxPWM";
            this.MaxPWM.Size = new System.Drawing.Size(64, 20);
            this.MaxPWM.TabIndex = 10;
            // 
            // Kp
            // 
            this.Kp.DecimalPlaces = 1;
            this.Kp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kp.Enabled = false;
            this.Kp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Kp.Location = new System.Drawing.Point(133, 107);
            this.Kp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Kp.Name = "Kp";
            this.Kp.Size = new System.Drawing.Size(64, 20);
            this.Kp.TabIndex = 11;
            // 
            // Ki
            // 
            this.Ki.DecimalPlaces = 1;
            this.Ki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ki.Enabled = false;
            this.Ki.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Ki.Location = new System.Drawing.Point(133, 133);
            this.Ki.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Ki.Name = "Ki";
            this.Ki.Size = new System.Drawing.Size(64, 20);
            this.Ki.TabIndex = 12;
            // 
            // Kd
            // 
            this.Kd.DecimalPlaces = 1;
            this.Kd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kd.Enabled = false;
            this.Kd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Kd.Location = new System.Drawing.Point(133, 159);
            this.Kd.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Kd.Name = "Kd";
            this.Kd.Size = new System.Drawing.Size(64, 20);
            this.Kd.TabIndex = 13;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(510, 233);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(78, 34);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(594, 233);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(78, 34);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // Autostart
            // 
            this.Autostart.AutoSize = true;
            this.Autostart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Autostart.Enabled = false;
            this.Autostart.Location = new System.Drawing.Point(133, 185);
            this.Autostart.Name = "Autostart";
            this.Autostart.Size = new System.Drawing.Size(64, 22);
            this.Autostart.TabIndex = 17;
            this.Autostart.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Autostart:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.Temperature, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Autostart, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Kd, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.MaxPWM, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Ki, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Kp, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.MinPWM, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Setpoint, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 210);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Chart
            // 
            this.Chart.BackColor = System.Drawing.SystemColors.Control;
            this.Chart.Location = new System.Drawing.Point(218, 12);
            this.Chart.Name = "Chart";
            this.Chart.Size = new System.Drawing.Size(454, 215);
            this.Chart.TabIndex = 14;
            // 
            // OutputSetupForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(684, 279);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutputSetupForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OutputSetupForm";
            this.Activated += new System.EventHandler(this.OutputSetupForm_Activated);
            this.Deactivate += new System.EventHandler(this.OutputSetupForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OutputSetupForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OutputSetupForm_FormClosed);
            this.Shown += new System.EventHandler(this.OutputSetupForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Temperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Setpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kd)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Temperature;
        private System.Windows.Forms.NumericUpDown Setpoint;
        private System.Windows.Forms.NumericUpDown MinPWM;
        private System.Windows.Forms.NumericUpDown MaxPWM;
        private System.Windows.Forms.NumericUpDown Kp;
        private System.Windows.Forms.NumericUpDown Ki;
        private System.Windows.Forms.NumericUpDown Kd;
        private PIDChart Chart;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox Autostart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}