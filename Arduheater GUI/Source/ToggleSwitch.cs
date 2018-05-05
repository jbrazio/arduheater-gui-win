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
using System.Windows.Forms;

namespace Arduheater_GUI
{
    public partial class ToggleSwitch : UserControl
    {
        private struct Settings_t
        {
            public bool Checked { get; set; }
        };

        private Settings_t Settings = new Settings_t();
        public event EventHandler CheckedChanged;

        public ToggleSwitch()
        {
            IsChecked = false;
            InitializeComponent();
        }

        public bool IsChecked
        {
            get { return Settings.Checked; }
            set
            {
                if (value == Settings.Checked) return;
                Settings.Checked = value;

                if (Settings.Checked)
                {
                    Image.Image = Properties.Resources.toggle_on;
                }
                else
                {
                    Image.Image = Properties.Resources.toggle_off;
                }

                Invalidate();
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void Image_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
