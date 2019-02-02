/**
 * Arduheater GUI for Windows
 * Copyright (C) 2018-2019 João Brázio [joao@brazio.org]
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

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Arduheater_GUI.Forms
{
    public partial class OutputSetupForm : Form
    {
        private struct Settings_t
        {
            public int OutputIndex { get; set; }
        }

        public struct Configuration_t
        {
            public int min, max;
            public bool autostart;
            public float temp_offset, setpoint_offset, Kp, Ki, Kd;
        }

        private Settings_t Settings = new Settings_t();
        private Timer Main_Timer = new Timer();

        public OutputSetupForm()
        {
            InitializeComponent();
        }

        public OutputSetupForm(int index)
        {
            InitializeComponent();

            OutputIndex = index;
            Main_Timer.Tick += Tick;
            Main_Timer.Interval = 1000;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.Text = $"Output #{(Settings.OutputIndex + 1)} setup";
            base.OnPaint(e);
        }

        private void OutputSetupForm_Shown(object sender, EventArgs e)
        {
            Program.Serial.TX("D" + Settings.OutputIndex);
            Chart.UpdateChart();
        }

        private void OutputSetupForm_Activated(object sender, EventArgs e)
        {
            Main_Timer.Enabled = true;
        }

        private void OutputSetupForm_Deactivate(object sender, EventArgs e)
        {
            Main_Timer.Enabled = false;
        }

        private void Tick(object sender, EventArgs e)
        {
            Chart.UpdateChart();
        }

        private void OutputSetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OutputSetupForm osf = (OutputSetupForm)sender;
            if (osf.DialogResult == DialogResult.OK)
            {
                Program.Serial.TX($"D{(int)(OutputIndex)},{(int)MinPWM.Value},{(int)MaxPWM.Value},{(int)((Autostart.Checked) ? 1 : 0)}," +
                    $"{(int)(Temperature.Value * 10)},{(int)(Setpoint.Value * 10)},{(int)(Kp.Value * 10)},{(int)(Ki.Value * 10)},{(int)(Kd.Value * 10)}");

                Console.WriteLine($"D{(int)(OutputIndex)},{(int)MinPWM.Value},{(int)MaxPWM.Value},{(int)((Autostart.Checked) ? 1 : 0)}," +
                    $"{(int)(Temperature.Value * 10)},{(int)(Setpoint.Value * 10)},{(int)(Kp.Value * 10)},{(int)(Ki.Value * 10)},{(int)(Kd.Value * 10)}");
            }
        }

        private void OutputSetupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MinPWM.Enabled = false;
            MaxPWM.Enabled = false;
            Autostart.Enabled = false;
            Temperature.Enabled = false;
            Setpoint.Enabled = false;
            Kp.Enabled = false;
            Ki.Enabled = false;
            Kd.Enabled = false;
        }

        [System.ComponentModel.Description("The number of the output being charted"), Category("Custom"), DefaultValue(false), Browsable(true)]
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

        public void AddDataPoint(PIDChart.Point_t datapoint) => Chart.AddDataPoint(datapoint);

        public void AddConfiguration(Configuration_t config)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    AddConfiguration(config);
                });
                return;
            }

            MinPWM.Value = config.min;
            MinPWM.Enabled = true;

            MaxPWM.Value = config.max;
            MaxPWM.Enabled = true;

            Autostart.Checked = config.autostart;
            Autostart.Enabled = true;

            Temperature.Value = (decimal)config.temp_offset;
            Temperature.Enabled = true;

            Setpoint.Value = (decimal)config.setpoint_offset;
            Setpoint.Enabled = true;

            Kp.Value = (decimal)config.Kp;
            Kp.Enabled = true;

            Ki.Value = (decimal)config.Ki;
            Ki.Enabled = true;

            Kd.Value = (decimal)config.Kd;
            Kd.Enabled = true;

            Invalidate();
        }
    }
}
