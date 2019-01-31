/**
 * Arduheater GUI for Windows
 * Copyright (C) 2018 João Brázio [joao@brazio.org]
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 */

using Arduheater_GUI.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Arduheater_GUI
{
    public partial class OutputChart : UserControl
    {
        // Structures -----------------------------------------------------------------------------
        private struct Settings_t
        {
            public bool Active { get; set; }
            public string Title { get; set; }
            public bool Powered { get; set; }
            public int OutputIndex { get; set; }
        };

        public struct Point_t
        {
            public double Temperature { get; set; }
            public double Setpoint { get; set; }
        };


        // Events ---------------------------------------------------------------------------------
        public event EventHandler ActiveChanged;
        public event EventHandler EditButtonClick;
        public event EventHandler PowerButtonClick;


        // Attributes -----------------------------------------------------------------------------
        private Settings_t Settings = new Settings_t();
        public OutputSetupForm SetupForm_Handler;

        private Point_t[] Dataset = new Point_t[300];
        private Point_t LastDataPoint = new Point_t();
        private Buffer_t<Point_t> Buffer = new Buffer_t<Point_t>(10);

         
        // Constructor ----------------------------------------------------------------------------
        public OutputChart()
        {
            InitializeComponent();

            Settings.Active = false;
            Settings.Powered = false;
            Settings.OutputIndex = 0;
            Settings.Title = "Output chart";

            label.Visible = true;
            chart.Visible = false;
            power.Visible = false;

            if (Properties.Settings.Default.Output_Legend_Visible) chart.Legends[0].Enabled = true;
        }


        // Properties -----------------------------------------------------------------------------
        [Description("Controls the runtime state of the chart"), Category("Custom"), DefaultValue(false), Browsable(true)]
        public bool Active
        {
            get { return Settings.Active; }
            set
            {
                if (value == Settings.Active) return;
                Settings.Active = value;

                chart.Visible = Settings.Active;
                power.Visible = Settings.Active;
                label.Visible = !Settings.Active;

                if (!Settings.Active)
                {
                    power.Value = 0;
                    LastDataPoint = new Point_t();
                    Array.Clear(Dataset, 0, Dataset.Length);
                }

                ActiveChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }

        [Description("The number of the output being charted"), Category("Custom"), DefaultValue(false), Browsable(true)]
        public int OutputIndex
        {
            get { return Settings.OutputIndex; }
            set
            {
                if (value == Settings.OutputIndex) return;
                Settings.OutputIndex = value;
                Invalidate();
            }
        }

        [Description("The title of the chart"), Category("Custom"), DefaultValue(false), Browsable(true)]
        public string Title
        {
            get { return Settings.Title; }
            set
            {
                if (value == Settings.Title) return;
                Settings.Title = value;
                Invalidate();
            }
        }

        [Description("Power state of the output being charted"), Category("Custom"), DefaultValue(false), Browsable(true)]
        public bool Powered
        {
            get { return Settings.Powered; }
            set
            {
                if (value == Settings.Powered) return;
                Settings.Powered = value;

                if (Settings.Powered)
                {
                    powerButton.Image = Properties.Resources.toggle_on;
                }
                else
                {
                    powerButton.Image = Properties.Resources.toggle_off;
                }

                Invalidate();
            }
        }


        // Overrides ------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            title.Text = $"{Settings.OutputIndex}: {Settings.Title}";
            base.OnPaint(e);
        }


        // Methods --------------------------------------------------------------------------------
        public void UpdateChart()
        {
            uint Counter = 0;
            Point_t Datapoint = new Point_t();

            if (Buffer.Empty)
            {
                Datapoint = LastDataPoint;
                Counter = 1;
            }
            else
            {
                while (!Buffer.Empty)
                {
                    Point_t Item = Buffer.Dequeue;

                    Datapoint.Temperature += Item.Temperature;
                    Datapoint.Setpoint += Item.Setpoint;
                    Counter++;
                }

                Datapoint.Temperature /= Counter;
                Datapoint.Setpoint /= Counter;
                LastDataPoint = Datapoint;
            }

            Dataset[Dataset.Length - 1] = Datapoint;
            Array.Copy(Dataset, 1, Dataset, 0, Dataset.Length - 1);

            for (int i = 0; i < chart.Series.Count; i++)
            {
                chart.Series[i].Points.Clear();
            }

            for (int i = Dataset.Length - 1; i > 0; i--)
            {
                chart.Series[0].Points.Add(Dataset[i].Temperature);
                chart.Series[1].Points.Add(Dataset[i].Setpoint);
            }

            chart.Series[0].Name = $"Temp ({Dataset[Dataset.Length - 1].Temperature.ToString("0.0")}°C)";
            chart.Series[1].Name = $"Set ({Dataset[Dataset.Length - 1].Setpoint.ToString("0.0")}°C)";

            double MaxYY = 0, MinYY = 0;

            MaxYY = chart.Series[0].Points.FindMaxByValue().YValues[0];
            MinYY = chart.Series[0].Points.FindMinByValue().YValues[0];

            if (chart.Series[1].Points.FindMaxByValue().YValues[0] > MaxYY)
                MaxYY = chart.Series[1].Points.FindMaxByValue().YValues[0];

            if (chart.Series[1].Points.FindMinByValue().YValues[0] < MinYY)
                MinYY = chart.Series[1].Points.FindMinByValue().YValues[0];

            chart.ChartAreas[0].AxisY2.Maximum = Math.Round(MaxYY + 10, 0);
            chart.ChartAreas[0].AxisY2.Minimum = Math.Round((MinYY < 0) ? MinYY - 10 : 0, 0);
        }

        public void AddDataPoint(Point_t datapoint) => Buffer.Enqueue(datapoint);

        public void SetPower(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    SetPower(value);
                });
                return;
            }

            power.Value = value;
        }

        private void Title_DoubleClick(object sender, EventArgs e)
        {
            string s = Microsoft.VisualBasic.Interaction.InputBox("New output identifier:", "Settings", this.Title);
            if (!string.IsNullOrEmpty(s)) this.Title = s;
        }

        private void Chart_MouseEnter(object sender, EventArgs e)
        {
            if (!Settings.Active) { return; }
            if (!Properties.Settings.Default.Output_Legend_Visible) chart.Legends[0].Enabled = true;
        }

        private void Chart_MouseHover(object sender, EventArgs e)
        {
            if (!Settings.Active) { return; }
            if (!Properties.Settings.Default.Output_Legend_Visible) chart.Legends[0].Enabled = true;
        }

        private void Chart_MouseLeave(object sender, EventArgs e)
        {
            if (!Settings.Active) { return; }
            if (! Properties.Settings.Default.Output_Legend_Visible) chart.Legends[0].Enabled = false;
        }

        private void EditButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Settings.Active) { return; }
            editButton.Image = Properties.Resources.edit_hover;
        }

        private void EditButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Settings.Active) { return; }
            editButton.Image = Properties.Resources.edit;
        }

        private void EditButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Settings.Active) { return; }
            EditButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            if (!Settings.Active) { return; }
            PowerButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
