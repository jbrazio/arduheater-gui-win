namespace Arduheater_GUI
{
    partial class OutputChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.title = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.PictureBox();
            this.power = new System.Windows.Forms.ProgressBar();
            this.powerButton = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerButton)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.IsReversed = true;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Maximum = 300D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.IsMarginVisible = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY2.Title = "ºC";
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 97F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 3F;
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.SystemColors.Control;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Consolas", 9F);
            legend1.IsEquallySpacedItems = true;
            legend1.IsTextAutoFit = false;
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.ReversedSeriesOrder;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.MaximumAutoSize = 100F;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend1.TextWrapThreshold = 0;
            legend1.TitleAlignment = System.Drawing.StringAlignment.Far;
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(3, 33);
            this.chart.Margin = new System.Windows.Forms.Padding(0);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.Legend = "Legend1";
            series1.Name = "Temperature";
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Setpoint";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(374, 108);
            this.chart.SuppressExceptions = true;
            this.chart.TabIndex = 19;
            this.chart.MouseEnter += new System.EventHandler(this.Chart_MouseEnter);
            this.chart.MouseLeave += new System.EventHandler(this.Chart_MouseLeave);
            this.chart.MouseHover += new System.EventHandler(this.Chart_MouseHover);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.BackColor = System.Drawing.SystemColors.ControlLight;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Margin = new System.Windows.Forms.Padding(0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(380, 30);
            this.title.TabIndex = 20;
            this.title.Text = "Generic device";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.title.DoubleClick += new System.EventHandler(this.Title_DoubleClick);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.Image = global::Arduheater_GUI.Properties.Resources.edit;
            this.editButton.Location = new System.Drawing.Point(317, 7);
            this.editButton.Margin = new System.Windows.Forms.Padding(7);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(18, 16);
            this.editButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.editButton.TabIndex = 23;
            this.editButton.TabStop = false;
            this.editButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditButton_MouseClick);
            this.editButton.MouseEnter += new System.EventHandler(this.EditButton_MouseEnter);
            this.editButton.MouseLeave += new System.EventHandler(this.EditButton_MouseLeave);
            // 
            // power
            // 
            this.power.Location = new System.Drawing.Point(203, 7);
            this.power.Margin = new System.Windows.Forms.Padding(7);
            this.power.MarqueeAnimationSpeed = 3000;
            this.power.Maximum = 255;
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(100, 16);
            this.power.TabIndex = 24;
            // 
            // powerButton
            // 
            this.powerButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.powerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.powerButton.Image = global::Arduheater_GUI.Properties.Resources.toggle_off;
            this.powerButton.Location = new System.Drawing.Point(349, 7);
            this.powerButton.Margin = new System.Windows.Forms.Padding(7);
            this.powerButton.Name = "powerButton";
            this.powerButton.Size = new System.Drawing.Size(24, 16);
            this.powerButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.powerButton.TabIndex = 25;
            this.powerButton.TabStop = false;
            this.powerButton.Click += new System.EventHandler(this.PowerButton_Click);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(0, 33);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(374, 108);
            this.label.TabIndex = 22;
            this.label.Text = "Waiting for data..";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label.Visible = false;
            // 
            // OutputChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.powerButton);
            this.Controls.Add(this.power);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.title);
            this.Name = "OutputChart";
            this.Size = new System.Drawing.Size(380, 145);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox editButton;
        private System.Windows.Forms.ProgressBar power;
        private System.Windows.Forms.PictureBox powerButton;
        private System.Windows.Forms.Label label;
    }
}
