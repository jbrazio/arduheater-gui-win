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
using System.IO.Ports;
using System.Windows.Forms;

namespace Arduheater_GUI.Forms
{
    public partial class SerialSetupForm : Form
    {
        public SerialSetupForm()
        {
            InitializeComponent();

            foreach (string item in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(item);
                if (item == Properties.Settings.Default.SerialPort) comboBox1.SelectedItem = item.ToString();
            }

            comboBox2.SelectedItem = Properties.Settings.Default.SerialRate.ToString();
            comboBox3.SelectedItem = Properties.Settings.Default.SerialData.ToString();

            foreach (Parity item in Enum.GetValues(typeof(Parity)))
            {
                comboBox4.Items.Add(item.ToString());
                if (item == Properties.Settings.Default.SerialParity) comboBox4.SelectedItem = item.ToString();
            }

            foreach (StopBits item in Enum.GetValues(typeof(StopBits)))
            {
                comboBox5.Items.Add(item.ToString());
                if (item == Properties.Settings.Default.SerialStop) comboBox5.SelectedItem = item.ToString();
            }

            foreach (Handshake item in Enum.GetValues(typeof(Handshake)))
            {
                comboBox6.Items.Add(item.ToString());
                if (item == Properties.Settings.Default.SerialFlow) comboBox6.SelectedItem = item.ToString();
            }
        }

        private void SerialConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerialSetupForm ssf = (SerialSetupForm)sender;
            if (ssf.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.SerialPort = (comboBox1.SelectedIndex > -1) ? comboBox1.SelectedItem.ToString() : null;
                Properties.Settings.Default.SerialRate = int.Parse(comboBox2.SelectedItem.ToString());
                Properties.Settings.Default.SerialData = (comboBox3.SelectedIndex == 0) ? 7 : 8;
                Properties.Settings.Default.SerialParity = (Parity)Enum.Parse(typeof(Parity), comboBox4.SelectedItem.ToString());
                Properties.Settings.Default.SerialStop = (StopBits)Enum.Parse(typeof(StopBits), comboBox5.SelectedItem.ToString());
                Properties.Settings.Default.SerialFlow = (Handshake)Enum.Parse(typeof(Handshake), comboBox6.SelectedItem.ToString());
                Properties.Settings.Default.Save();
            }
        }
    }
}
