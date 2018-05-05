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

using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Arduheater_GUI
{
    class Serial : SerialPort
    {
        private Buffer_t<string> Buffer_TX = new Buffer_t<string>(64);
        private Buffer_t<char> Buffer_RX = new Buffer_t<char>(64);
        private Timer Main_Timer = new Timer();

        public event EventHandler ProcessCommand;
        public event EventHandler IncomingData;
        public event EventHandler OutgoingData;

        public Serial()
        {
            Main_Timer.Tick += Tick;
            Main_Timer.Interval = 250;
            this.DataReceived += new SerialDataReceivedEventHandler(this.DataReceivedEvent);
        }

        public void Connect()
        {
            Disconnect();

            Program.Serial.PortName = Properties.Settings.Default.SerialPort;
            Program.Serial.BaudRate = Properties.Settings.Default.SerialRate;
            Program.Serial.DataBits = Properties.Settings.Default.SerialData;
            Program.Serial.Parity = Properties.Settings.Default.SerialParity;
            Program.Serial.StopBits = Properties.Settings.Default.SerialStop;
            Program.Serial.Handshake = Properties.Settings.Default.SerialFlow;
            Program.Serial.Open();

            if (!this.IsOpen)
            {
                Main_Timer.Enabled = false;
            }
            else
            {
                Main_Timer.Enabled = true;
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            if (!this.IsOpen)
            {
                Main_Timer.Enabled = false;
            }

            while (!Buffer_TX.Empty)
            {
                string text = Buffer_TX.Dequeue;

                OutgoingData?.Invoke(this, EventArgs.Empty);
                Console.WriteLine($"<< :{text}#");

                Write(":");

                long now = 0, before = 0;
                foreach (char c in text)
                {
                    do
                    {
                        now = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000);
                    } while (now - before < 15);

                    before = now;
                    Write($"{c}");
                }

                Write("#");
            }
        }

        public void Disconnect()
        {
            try
            {
                if (this.IsOpen) { this.Close(); }
                Main_Timer.Enabled = false;
            }
            catch { ; }
        }

        public string RX()
        {
            var sb = new System.Text.StringBuilder();
            while (!Buffer_RX.Empty)
            {
                sb.Append(Buffer_RX.Dequeue);
            }

            Console.WriteLine($">> :{sb.ToString()}#");
            IncomingData?.Invoke(this, EventArgs.Empty);

            return sb.ToString();
        }

        public void TX(string text)
        {
            Buffer_TX.Enqueue(text);
        }

        private void DataReceivedEvent(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort tty = (SerialPort)sender;

            while (tty.IsOpen && tty.BytesToRead > 0)
            {
                char c = (char)tty.ReadByte();

                switch (c)
                {
                    case '\r': // ignore windows line ending
                    case '\n':
                        break;

                    case ':': // cmd start
                        Buffer_RX.Reset();
                        break;

                    case '#': // cmd end
                        ProcessCommand?.Invoke(this, EventArgs.Empty);
                        break;

                    default:
                        try
                        {
                            Buffer_RX.Enqueue(c);
                        }

                        catch { ; }
                        break;
                }
            }
        }
    }
}
