namespace Arduheater_GUI
{
    partial class ToggleSwitch
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
            this.Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Image
            // 
            this.Image.BackColor = System.Drawing.Color.Transparent;
            this.Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image.Image = global::Arduheater_GUI.Properties.Resources.toggle_off;
            this.Image.InitialImage = null;
            this.Image.Location = new System.Drawing.Point(0, 0);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(45, 30);
            this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image.TabIndex = 0;
            this.Image.TabStop = false;
            this.Image.Click += new System.EventHandler(this.Image_Click);
            // 
            // ToggleSwitch
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Image);
            this.Name = "ToggleSwitch";
            this.Size = new System.Drawing.Size(45, 30);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Image;
    }
}
