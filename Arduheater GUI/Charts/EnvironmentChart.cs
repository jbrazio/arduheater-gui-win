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
using System.ComponentModel;
using System.Windows.Forms;

namespace Arduheater_GUI
{
    public partial class EnvironmentChart : UserControl
    {
        // Structures -----------------------------------------------------------------------------
        private struct Settings_t
        {
            public bool Active { get; set; }
        };

        public struct Point_t
        {
            public double Ambient { get; set; }
            public double Humidity { get; set; }
            public double Dewpoint { get; set; }
        };


        // Events ---------------------------------------------------------------------------------
        public event EventHandler ActiveChanged;


        // Attributes -----------------------------------------------------------------------------
        private Settings_t Settings = new Settings_t();

        private Point_t[] Dataset = new Point_t[300];
        private Point_t LastDataPoint = new Point_t();
        private Buffer_t<Point_t> Buffer = new Buffer_t<Point_t>(10);


        // Constructor ----------------------------------------------------------------------------
        public EnvironmentChart()
        {
            InitializeComponent();

            label.Visible = true;
            chart.Visible = false;
            Settings.Active = false;

            if (Properties.Settings.Default.Ambient_Legend_Visible) chart.Legends[0].Enabled = true;
        }

        // Properties -----------------------------------------------------------------------------
        [Description("Controls the runtime state of the chart"), Category("Custom"), DefaultValue(false), Browsable(false)]
        public bool Active
        {
            get { return Settings.Active; }
            set
            {
                if (value == Settings.Active) return;
                Settings.Active = value;

                chart.Visible = Settings.Active;
                label.Visible = !Settings.Active;

                if (!Settings.Active)
                {
                    LastDataPoint = new Point_t();
                    Array.Clear(Dataset, 0, Dataset.Length);
                }

                ActiveChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }


        // Overrides ------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
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

                    Datapoint.Ambient += Item.Ambient;
                    Datapoint.Humidity += Item.Humidity;
                    Datapoint.Dewpoint += Item.Dewpoint;
                    Counter++;
                }

                Datapoint.Ambient /= Counter;
                Datapoint.Humidity /= Counter;
                Datapoint.Dewpoint /= Counter;
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
                chart.Series[0].Points.Add(Dataset[i].Ambient);
                chart.Series[1].Points.Add(Dataset[i].Humidity);
                chart.Series[2].Points.Add(Dataset[i].Dewpoint);
            }

            chart.Series[0].Name = $"Ambient  ({Dataset[Dataset.Length - 1].Ambient.ToString("0.0")}°C)";
            chart.Series[1].Name = $"Humidity ({Dataset[Dataset.Length - 1].Humidity.ToString("0.0")}%)";
            chart.Series[2].Name = $"Dewpoint ({Dataset[Dataset.Length - 1].Dewpoint.ToString("0.0")}°C)";

            double MaxY = 0, MaxYY = 0;
            double MinY = 0, MinYY = 0;

            MaxY = chart.Series[1].Points.FindMaxByValue().YValues[0];
            MinY = chart.Series[1].Points.FindMinByValue().YValues[0];

            MaxYY = chart.Series[0].Points.FindMaxByValue().YValues[0];
            MinYY = chart.Series[0].Points.FindMinByValue().YValues[0];

            if (chart.Series[2].Points.FindMaxByValue().YValues[0] > MaxYY)
            {
                MaxYY = chart.Series[2].Points.FindMaxByValue().YValues[0];
            }

            if (chart.Series[2].Points.FindMinByValue().YValues[0] < MinYY)
            {
                MinYY = chart.Series[2].Points.FindMinByValue().YValues[0];
            }

            chart.ChartAreas[0].AxisY.Maximum = Math.Round(MaxY + 10, 0);
            chart.ChartAreas[0].AxisY.Minimum = Math.Round((MinY < 0) ? MinY - 10 : 0, 0);

            chart.ChartAreas[0].AxisY2.Maximum = Math.Round(MaxYY + 10);
            chart.ChartAreas[0].AxisY2.Minimum = Math.Round((MinYY < 0) ? MinYY - 10 : 0, 0);
        }

        public void AddDataPoint(Point_t datapoint) => Buffer.Enqueue(datapoint);

        private void chart_MouseEnter(object sender, EventArgs e)
        {
            if(! Properties.Settings.Default.Ambient_Legend_Visible) chart.Legends[0].Enabled = true;
        }
         
        private void chart_MouseHover(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.Ambient_Legend_Visible) chart.Legends[0].Enabled = true;
        }

        private void chart_MouseLeave(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.Ambient_Legend_Visible) chart.Legends[0].Enabled = false;
        }
    }
}
