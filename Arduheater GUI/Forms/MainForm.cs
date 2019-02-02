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
using System.Windows.Forms;
using Arduheater_GUI.Properties;

namespace Arduheater_GUI.Forms
{
    public partial class MainForm : Form
    {
        // Structures -----------------------------------------------------------------------------
        private struct Runtime_t
        {
            public Int32 Timeout;
            public int RotationFlag;
            public Timer Main_Timer;
            public Timer SerialPort_Timer;
        };


        // Attributes -----------------------------------------------------------------------------
        private Runtime_t Runtime = new Runtime_t();


        // Constructor ----------------------------------------------------------------------------
        public MainForm()

        {
            InitializeComponent();

            outputChart1.Active = false;
            outputChart2.Active = false;
            outputChart3.Active = false;
            outputChart4.Active = false;

            outputChart1.Title = Properties.Settings.Default.Output_1_Title;
            outputChart2.Title = Properties.Settings.Default.Output_2_Title;
            outputChart3.Title = Properties.Settings.Default.Output_3_Title;
            outputChart4.Title = Properties.Settings.Default.Output_4_Title;

            Runtime.RotationFlag = 0;
            Runtime.Main_Timer = new Timer();
            Runtime.SerialPort_Timer = new Timer();

            Program.Serial.ProcessCommand += new EventHandler(this.ProcessIncomingData);
            Program.Serial.IncomingData += new EventHandler(this.Activity_RX);
            Program.Serial.OutgoingData += new EventHandler(this.Activity_TX);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.Location.Equals(new System.Drawing.Point(0, 0)))
            {
                this.Location = Properties.Settings.Default.Location;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Location = this.Location;
            Properties.Settings.Default.Output_1_Title = outputChart1.Title;
            Properties.Settings.Default.Output_2_Title = outputChart2.Title;
            Properties.Settings.Default.Output_3_Title = outputChart3.Title;
            Properties.Settings.Default.Output_4_Title = outputChart4.Title;
            Properties.Settings.Default.Save();
        }


        // Menu items -----------------------------------------------------------------------------
        private void Open_URL_From_Menu_Item(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Equals(githubToolStripMenuItem))
            {
                System.Diagnostics.Process.Start(Resources.ResourceManager.GetString("URL_Github"));
            }
            else if (item.Equals(payPalToolStripMenuItem))
            {
                System.Diagnostics.Process.Start(Resources.ResourceManager.GetString("URL_PayPal"));
            }
            else if (item.Equals(twitterToolStripMenuItem))
            {
                System.Diagnostics.Process.Start(Resources.ResourceManager.GetString("URL_Twitter"));
            }
            else if (item.Equals(supportToolStripMenuItem))
            {
                System.Diagnostics.Process.Start(Resources.ResourceManager.GetString("URL_Support"));
            }
            else throw new ArgumentOutOfRangeException("Unknown URL requested,");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm ab = new AboutForm();
            ab.ShowDialog();
        }

        private void SerialSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialSetupForm sc = new SerialSetupForm();
            sc.ShowDialog();
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            item.Enabled = false;

            try
            {
                if(Runtime.SerialPort_Timer.Enabled)
                {
                    Runtime.SerialPort_Timer.Enabled = false;
                }

                Program.Serial.Connect();
                Runtime.SerialPort_Timer.Enabled = true;
                Runtime.SerialPort_Timer.Interval = 1000;
                Runtime.SerialPort_Timer.Tick += SerialPort_Connecting;
                Runtime.Timeout = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                StatusLabel.Text = $"Serial port ({Properties.Settings.Default.SerialPort}) is connecting.";
            }

            catch
            {
                item.Enabled = true;
                StatusLabel.Text = $"Error connection to serial port, please check settings.";
            }
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            item.Enabled = false;

            try
            {
                StatusLabel.Text = $"Serial port ({Properties.Settings.Default.SerialPort}) is closing..";
                if (Program.Serial.IsOpen) { SerialPort_Disconnected(); }
            }

            catch
            {
                item.Enabled = true;
            }
        }

        private void SerialPort_Connecting(object sender, EventArgs e)
        {
            const int TIMEOUT = 30;
            const int RESET = 6;

            long now = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            long t = now - Runtime.Timeout;
            if (t > TIMEOUT)
            {
                SerialPort_Disconnected(true);
                Runtime.SerialPort_Timer.Enabled = false;
                Runtime.SerialPort_Timer.Tick -= SerialPort_Connecting;
            }
            else
            {
                if(t % RESET == 0)
                {
                    Program.Serial.Disconnect();
                    Program.Serial.Connect();
                }
                else
                {
                    Program.Serial.TXNow(":V#");
                }

                StatusLabel.Text = $"Serial port ({Properties.Settings.Default.SerialPort}) is connecting.. ({TIMEOUT - t}s)";
            }
        }

        private void SerialPort_Activity(object sender, EventArgs e)
        {
            if(LedRX.BackColor != System.Drawing.Color.DarkRed) LedRX.BackColor = System.Drawing.Color.DarkRed;
            if(LedTX.BackColor != System.Drawing.Color.DarkGreen) LedTX.BackColor = System.Drawing.Color.DarkGreen;
        }

        private void Activity_RX(object sender, EventArgs e)
        {
            if (LedRX.BackColor != System.Drawing.Color.Red) LedRX.BackColor = System.Drawing.Color.Red;
        }

        private void Activity_TX(object sender, EventArgs e)
        {
            if (LedTX.BackColor != System.Drawing.Color.Green) LedTX.BackColor = System.Drawing.Color.Green;
        }

        private void SerialPort_Connected()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    SerialPort_Connected();
                });
                return;
            }

            if (Runtime.SerialPort_Timer.Enabled)
            {
                Runtime.SerialPort_Timer.Enabled = false;
                Runtime.SerialPort_Timer.Tick -= SerialPort_Connecting;
                Runtime.SerialPort_Timer.Tick -= SerialPort_Activity;
            }

            if (Runtime.Main_Timer.Enabled)
            {
                Runtime.Main_Timer.Enabled = false;
                Runtime.Main_Timer.Tick -= Tick;
            }

            Runtime.Main_Timer.Tick += Tick;
            Runtime.Main_Timer.Interval = 250;
            Runtime.Main_Timer.Enabled = true;

            Runtime.SerialPort_Timer.Interval = 50;
            Runtime.SerialPort_Timer.Enabled = true;
            Runtime.SerialPort_Timer.Tick += SerialPort_Activity;

            sendToolStripMenuItem.Enabled = true;

            environmentChart1.Active = true;
            connectToolStripMenuItem.Enabled = true;
            connectToolStripMenuItem.Text = "&Disconnect";
            connectToolStripMenuItem.Click -= ConnectToolStripMenuItem_Click;
            connectToolStripMenuItem.Click += new EventHandler(DisconnectToolStripMenuItem_Click);
            StatusLabel.Text = $"Serial port ({Properties.Settings.Default.SerialPort}) is connected.";
        }

        private void SerialPort_Disconnected(Boolean timeout = false)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    SerialPort_Disconnected(timeout);
                });
                return;
            }

            if (Runtime.SerialPort_Timer.Enabled)
            {
                Runtime.SerialPort_Timer.Enabled = false;
                Runtime.SerialPort_Timer.Tick -= SerialPort_Connecting;
                Runtime.SerialPort_Timer.Tick -= SerialPort_Activity;
            }

            if (Runtime.Main_Timer.Enabled)
            {
                Runtime.Main_Timer.Enabled = false;
                Runtime.Main_Timer.Tick -= Tick;
            }

            Program.Serial.Disconnect();

            environmentChart1.Active = false;

            outputChart1.Active = false;
            outputChart2.Active = false;
            outputChart3.Active = false;
            outputChart4.Active = false;

            outputChart1.Powered = false;
            outputChart2.Powered = false;
            outputChart3.Powered = false;
            outputChart4.Powered = false;

            foreach (Control c in this.Controls)
            {
                if (c is OutputChart oc)
                {
                    if (oc.SetupForm_Handler != null)
                    {
                        oc.SetupForm_Handler.Dispose();
                        oc.SetupForm_Handler = null;
                    }
                }
            }

            sendToolStripMenuItem.Enabled = false;

            connectToolStripMenuItem.Enabled = true;
            connectToolStripMenuItem.Text = "&Connect";
            connectToolStripMenuItem.Click -= DisconnectToolStripMenuItem_Click;
            connectToolStripMenuItem.Click += new EventHandler(ConnectToolStripMenuItem_Click);

            if (timeout)
            {
                StatusLabel.Text = $"Connecting to serial port ({Properties.Settings.Default.SerialPort}) timed out, please check settings.";
            }
            else
            {
                StatusLabel.Text = $"Serial port ({Properties.Settings.Default.SerialPort}) is disconnected.";
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            if (!Program.Serial.IsOpen)
            {
                return;
            }

            switch (Runtime.RotationFlag++)
            {
                case 0: // Request Ambient info
                    Program.Serial.TX("A");
                    break;

                case 1:
                    Program.Serial.TX("?");
                    break;

                case 2: // Request Output info
                    foreach (Control c in this.Controls)
                    {
                        if (c is OutputChart oc)
                        {
                            if (oc.Active) { Program.Serial.TX($"B{oc.OutputIndex - 1}"); }
                        }
                    }
                    break;

                case 3: // Request PID info
                    foreach (Control c in this.Controls)
                    {
                        if (c is OutputChart oc)
                        {
                            if (oc.Active) { Program.Serial.TX($"C{oc.OutputIndex - 1}"); }
                        }
                    }
                    break;

                default:
                    Runtime.RotationFlag = 0;
                    break;
            }

            if (Runtime.RotationFlag == 4)
            {
                environmentChart1.UpdateChart();

                foreach (Control c in this.Controls)
                {
                    if (c is OutputChart oc)
                    {
                        if (oc.Active) oc.UpdateChart();
                    }
                }
            }
        }

        private void ProcessIncomingData(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    ProcessIncomingData(sender, e);
                });
                return;
            }

            Serial tty = (Serial)sender;
            string buffer = tty.RX();
            string[] args = buffer.Substring(1).Split(',');

            switch (char.Parse(buffer.Substring(0, 1)))
            {
                case '?':
                    try
                    {
                        outputChart1.Active = ((args[0] == "1") && (args[4] == "1"));
                        outputChart2.Active = ((args[1] == "1") && (args[5] == "1"));
                        outputChart3.Active = ((args[2] == "1") && (args[6] == "1"));
                        outputChart4.Active = ((args[3] == "1") && (args[7] == "1"));

                        outputChart1.Powered = (args[8] == "1");
                        outputChart2.Powered = (args[9] == "1");
                        outputChart3.Powered = (args[10] == "1");
                        outputChart4.Powered = (args[11] == "1");

                        foreach (Control c in this.Controls)
                        {
                            if (c is OutputChart oc)
                            {
                                if (oc.SetupForm_Handler == null)
                                {
                                    oc.SetupForm_Handler = new OutputSetupForm(oc.OutputIndex - 1);
                                }
                            }
                        }
                    }
                    catch {; }
                    break;

                case 'A':
                    UpdateChart_Ambient(args);
                    break;

                case 'B':
                    UpdateChart(args, new OutputChart.Point_t());
                    break;

                case 'C':
                    UpdateChart(args, new PIDChart.Point_t());
                    break;

                case 'D':
                    UpdateChart(args, new OutputSetupForm.Configuration_t());
                    break;

                case 'F':

                    break;

                case 'V':
                    SerialPort_Connected();
                    StatusLabel.Text = $"Arduheater firmware v{args[0]}.";

                    Program.Serial.TX("?");
                    break;
            }
        }

        private void UpdateChart(string[] args, Object o)
        {
            OutputChart chart;

            switch (int.Parse(args[0]))
            {
                case 0:
                    chart = outputChart1;
                    break;

                case 1:
                    chart = outputChart2;
                    break;

                case 2:
                    chart = outputChart3;
                    break;

                case 3:
                    chart = outputChart4;
                    break;

                default:
                    return;
            }

            if (o is OutputChart.Point_t)
            {
                try
                {
                    chart.SetPower(int.Parse(args[3]));
                    chart.AddDataPoint(new OutputChart.Point_t
                    {
                        Temperature = (float)(int.Parse(args[1]) / 10.0),
                        Setpoint = (float)(int.Parse(args[2]) / 10.0)
                    });
                }
                catch {; }
            }

            else if (o is PIDChart.Point_t)
            {
                try
                {
                    if (chart.SetupForm_Handler != null) chart.SetupForm_Handler.AddDataPoint(new PIDChart.Point_t
                    {
                        P = (float)(int.Parse(args[1]) / 10.0),
                        I = (float)(int.Parse(args[2]) / 10.0),
                        D = (float)(int.Parse(args[3]) / 10.0)
                    });
                }
                catch {; }
            }

            else if (o is OutputSetupForm.Configuration_t)
            {
                try
                {
                    if (chart.SetupForm_Handler != null && args.Length == 9) chart.SetupForm_Handler.AddConfiguration(new OutputSetupForm.Configuration_t
                    {
                        min = int.Parse(args[1]),
                        max = int.Parse(args[2]),
                        autostart = (args[3] == "1"),
                        temp_offset     = (float)(int.Parse(args[4]) / 10.0),
                        setpoint_offset = (float)(int.Parse(args[5]) / 10.0),
                        Kp = (float)(int.Parse(args[6]) / 10.0),
                        Ki = (float)(int.Parse(args[7]) / 10.0),
                        Kd = (float)(int.Parse(args[8]) / 10.0)
                    });
                }
                catch {; }
            }
        }

        private void UpdateChart_Ambient(string[] args)
        {
            try
            {
                environmentChart1.AddDataPoint(new EnvironmentChart.Point_t
                {
                    Ambient = float.Parse(args[0]) / 10,
                    Humidity = float.Parse(args[1]) / 10,
                    Dewpoint = float.Parse(args[2]) / 10
                });
            }
            catch {; }
        }

        private void EditButtonClick(object sender, EventArgs e)
        {
            OutputChart oc = (OutputChart)sender;

            if(oc.SetupForm_Handler == null)
            {
                oc.SetupForm_Handler = new OutputSetupForm(oc.OutputIndex - 1);
            }

            oc.SetupForm_Handler.ShowDialog();
        }

        private void PowerButtonClick(object sender, EventArgs e)
        {
            OutputChart oc = (OutputChart)sender;

            if (oc.Powered)
            {
                Program.Serial.TX("-" + (oc.OutputIndex - 1));
            }
            else
            {
                Program.Serial.TX("+" + (oc.OutputIndex - 1));
            }

            Program.Serial.TX("?");
        }

        private void SendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = Microsoft.VisualBasic.Interaction.InputBox("Command:", "Serial", "");
            if (!string.IsNullOrEmpty(s)) Program.Serial.TX(s);
        }
    }
}

