namespace car_rental_sales_desktop.Forms.Controls
{
    partial class MainPageControl
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
            picBanner = new PictureBox();
            btnGoWebsite = new Button();
            ((System.ComponentModel.ISupportInitialize)picBanner).BeginInit();
            SuspendLayout();
            // 
            // picBanner
            // 
            picBanner.Dock = DockStyle.Fill;
            picBanner.Image = Properties.Resources.car_rental_banner;
            picBanner.Location = new Point(0, 0);
            picBanner.Margin = new Padding(0);
            picBanner.Name = "picBanner";
            picBanner.Size = new Size(1670, 1000);
            picBanner.TabIndex = 0;
            picBanner.TabStop = false;
            // 
            // btnGoWebsite
            // 
            btnGoWebsite.BackColor = Color.FromArgb(49, 76, 143);
            btnGoWebsite.BackgroundImageLayout = ImageLayout.None;
            btnGoWebsite.Cursor = Cursors.Hand;
            btnGoWebsite.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 76, 143);
            btnGoWebsite.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 60, 117);
            btnGoWebsite.FlatStyle = FlatStyle.Flat;
            btnGoWebsite.Font = new Font("Microsoft Sans Serif", 25F, FontStyle.Bold);
            btnGoWebsite.ForeColor = Color.Transparent;
            btnGoWebsite.Location = new Point(74, 783);
            btnGoWebsite.Name = "btnGoWebsite";
            btnGoWebsite.Size = new Size(274, 79);
            btnGoWebsite.TabIndex = 1;
            btnGoWebsite.Text = "GO WEBSITE";
            btnGoWebsite.UseVisualStyleBackColor = false;
            btnGoWebsite.Click += btnGoWebsite_Click;
            // 
            // MainPageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnGoWebsite);
            Controls.Add(picBanner);
            Margin = new Padding(0);
            Name = "MainPageControl";
            Size = new Size(1670, 1000);
            ((System.ComponentModel.ISupportInitialize)picBanner).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picBanner;
        private Button btnGoWebsite;
    }
}
