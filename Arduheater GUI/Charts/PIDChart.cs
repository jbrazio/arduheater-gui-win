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

namespace Arduheater_GUI
{
    public partial class PIDChart : UserControl
    {
        // Structures -----------------------------------------------------------------------------
        public struct Point_t
        {
            public float P { get; set; }
            public float I { get; set; }
            public float D { get; set; }
        };


        // Attributes -----------------------------------------------------------------------------
        private Point_t[] Dataset = new Point_t[300];
        private Buffer_t<Point_t> Buffer = new Buffer_t<Point_t>(10);


        // Constructor ----------------------------------------------------------------------------
        public PIDChart()
        {
            InitializeComponent();
            chart.Visible = true;
            label.Visible = false;
        }


        // Overrides ------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            title.Text = "PID Chart";
            base.OnPaint(e);
        }


        // Methods --------------------------------------------------------------------------------
        public void UpdateChart()
        {
            for (int i = 0; i < chart.Series.Count; i++)
            {
                chart.Series[i].Points.Clear();
            }

            for (int i = Dataset.Length - 1; i > 0; i--)
            {
                chart.Series[0].Points.Add(Dataset[i].P);
                chart.Series[1].Points.Add(Dataset[i].I);
                chart.Series[2].Points.Add(Dataset[i].D);
            }

            chart.Series[0].Name = $"P ({Dataset[Dataset.Length-1].P.ToString("0")})";
            chart.Series[1].Name = $"I ({Dataset[Dataset.Length-1].I.ToString("0")})";
            chart.Series[2].Name = $"D ({Dataset[Dataset.Length-1].D.ToString("0")})";

            double MaxYY = 0, MinYY = 0;

            MaxYY = chart.Series[0].Points.FindMaxByValue().YValues[0];
            MinYY = chart.Series[0].Points.FindMinByValue().YValues[0];

            if (chart.Series[1].Points.FindMaxByValue().YValues[0] > MaxYY)
                MaxYY = chart.Series[1].Points.FindMaxByValue().YValues[0];
            else if (chart.Series[2].Points.FindMaxByValue().YValues[0] > MaxYY)
                MaxYY = chart.Series[2].Points.FindMaxByValue().YValues[0];

            if (chart.Series[1].Points.FindMinByValue().YValues[0] < MinYY)
                MinYY = chart.Series[1].Points.FindMinByValue().YValues[0];
            else if (chart.Series[2].Points.FindMinByValue().YValues[0] < MinYY)
                MinYY = chart.Series[2].Points.FindMinByValue().YValues[0];

            chart.ChartAreas[0].AxisY2.Maximum = Math.Round(MaxYY + 10, 0);
            chart.ChartAreas[0].AxisY2.Minimum = Math.Round((MinYY < 0) ? MinYY - 10 : 0, 0);
        }

        public void AddDataPoint(Point_t datapoint)
        {
            Dataset[Dataset.Length - 1] = datapoint;
            Array.Copy(Dataset, 1, Dataset, 0, Dataset.Length - 1);
        }

        private void chart_MouseEnter(object sender, EventArgs e)
        {
            chart.Legends[0].Enabled = true;
        }

        private void chart_MouseHover(object sender, EventArgs e)
        {
            chart.Legends[0].Enabled = true;
        }

        private void chart_MouseLeave(object sender, EventArgs e)
        {
            chart.Legends[0].Enabled = false;
        }
    }
}
