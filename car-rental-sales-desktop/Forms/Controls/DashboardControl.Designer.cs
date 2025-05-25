namespace car_rental_sales_desktop.Forms.Controls
{
    partial class DashboardControl
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
            pnlCards = new Panel();
            pnlRentCard5 = new Panel();
            lblCanceledRentalsTitle = new Label();
            lblCanceledRentalsCount = new Label();
            iconCanceledRentals = new FontAwesome.Sharp.IconPictureBox();
            pnlRentCard4 = new Panel();
            lblMonthlyRentalsTitle = new Label();
            lblMonthlyRentalsCount = new Label();
            iconMonthlyRentals = new FontAwesome.Sharp.IconPictureBox();
            pnlRentCard3 = new Panel();
            lblActiveRentalsTitle = new Label();
            lblActiveRentalsCount = new Label();
            iconActiveRentals = new FontAwesome.Sharp.IconPictureBox();
            pnlRentCard1 = new Panel();
            lblTotalRentalsTitle = new Label();
            lblTotalRentalsCount = new Label();
            iconTotalRentals = new FontAwesome.Sharp.IconPictureBox();
            pnlCards.SuspendLayout();
            pnlRentCard5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCanceledRentals).BeginInit();
            pnlRentCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconMonthlyRentals).BeginInit();
            pnlRentCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconActiveRentals).BeginInit();
            pnlRentCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconTotalRentals).BeginInit();
            SuspendLayout();
            // 
            // pnlCards
            // 
            pnlCards.Controls.Add(pnlRentCard5);
            pnlCards.Controls.Add(pnlRentCard4);
            pnlCards.Controls.Add(pnlRentCard3);
            pnlCards.Controls.Add(pnlRentCard1);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(50, 50);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new Size(1570, 300);
            pnlCards.TabIndex = 0;
            // 
            // pnlRentCard5
            // 
            pnlRentCard5.BackColor = Color.FromArgb(255, 158, 158);
            pnlRentCard5.BorderStyle = BorderStyle.FixedSingle;
            pnlRentCard5.Controls.Add(lblCanceledRentalsTitle);
            pnlRentCard5.Controls.Add(lblCanceledRentalsCount);
            pnlRentCard5.Controls.Add(iconCanceledRentals);
            pnlRentCard5.Dock = DockStyle.Left;
            pnlRentCard5.Location = new Point(1176, 0);
            pnlRentCard5.Margin = new Padding(10);
            pnlRentCard5.Name = "pnlRentCard5";
            pnlRentCard5.Size = new Size(392, 300);
            pnlRentCard5.TabIndex = 4;
            // 
            // lblCanceledRentalsTitle
            // 
            lblCanceledRentalsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCanceledRentalsTitle.ForeColor = Color.FromArgb(50, 50, 50);
            lblCanceledRentalsTitle.Location = new Point(58, 204);
            lblCanceledRentalsTitle.Name = "lblCanceledRentalsTitle";
            lblCanceledRentalsTitle.Size = new Size(274, 50);
            lblCanceledRentalsTitle.TabIndex = 2;
            lblCanceledRentalsTitle.Text = "Canceled Rentals";
            lblCanceledRentalsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCanceledRentalsCount
            // 
            lblCanceledRentalsCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblCanceledRentalsCount.ForeColor = Color.FromArgb(50, 50, 50);
            lblCanceledRentalsCount.Location = new Point(58, 124);
            lblCanceledRentalsCount.Name = "lblCanceledRentalsCount";
            lblCanceledRentalsCount.Size = new Size(274, 70);
            lblCanceledRentalsCount.TabIndex = 1;
            lblCanceledRentalsCount.Text = "0";
            lblCanceledRentalsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconCanceledRentals
            // 
            iconCanceledRentals.BackColor = Color.Transparent;
            iconCanceledRentals.ForeColor = Color.FromArgb(80, 80, 80);
            iconCanceledRentals.IconChar = FontAwesome.Sharp.IconChar.CalendarXmark;
            iconCanceledRentals.IconColor = Color.FromArgb(80, 80, 80);
            iconCanceledRentals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCanceledRentals.IconSize = 60;
            iconCanceledRentals.Location = new Point(165, 44);
            iconCanceledRentals.Name = "iconCanceledRentals";
            iconCanceledRentals.Size = new Size(60, 60);
            iconCanceledRentals.TabIndex = 0;
            iconCanceledRentals.TabStop = false;
            // 
            // pnlRentCard4
            // 
            pnlRentCard4.BackColor = Color.FromArgb(255, 213, 128);
            pnlRentCard4.BorderStyle = BorderStyle.FixedSingle;
            pnlRentCard4.Controls.Add(lblMonthlyRentalsTitle);
            pnlRentCard4.Controls.Add(lblMonthlyRentalsCount);
            pnlRentCard4.Controls.Add(iconMonthlyRentals);
            pnlRentCard4.Dock = DockStyle.Left;
            pnlRentCard4.Location = new Point(784, 0);
            pnlRentCard4.Margin = new Padding(10);
            pnlRentCard4.Name = "pnlRentCard4";
            pnlRentCard4.Size = new Size(392, 300);
            pnlRentCard4.TabIndex = 3;
            // 
            // lblMonthlyRentalsTitle
            // 
            lblMonthlyRentalsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMonthlyRentalsTitle.ForeColor = Color.FromArgb(50, 50, 50);
            lblMonthlyRentalsTitle.Location = new Point(58, 204);
            lblMonthlyRentalsTitle.Name = "lblMonthlyRentalsTitle";
            lblMonthlyRentalsTitle.Size = new Size(274, 50);
            lblMonthlyRentalsTitle.TabIndex = 2;
            lblMonthlyRentalsTitle.Text = "Monthly Rentals (Last 30 Days)";
            lblMonthlyRentalsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMonthlyRentalsCount
            // 
            lblMonthlyRentalsCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblMonthlyRentalsCount.ForeColor = Color.FromArgb(50, 50, 50);
            lblMonthlyRentalsCount.Location = new Point(58, 124);
            lblMonthlyRentalsCount.Name = "lblMonthlyRentalsCount";
            lblMonthlyRentalsCount.Size = new Size(274, 70);
            lblMonthlyRentalsCount.TabIndex = 1;
            lblMonthlyRentalsCount.Text = "0";
            lblMonthlyRentalsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconMonthlyRentals
            // 
            iconMonthlyRentals.BackColor = Color.Transparent;
            iconMonthlyRentals.ForeColor = Color.FromArgb(80, 80, 80);
            iconMonthlyRentals.IconChar = FontAwesome.Sharp.IconChar.CalendarDay;
            iconMonthlyRentals.IconColor = Color.FromArgb(80, 80, 80);
            iconMonthlyRentals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMonthlyRentals.IconSize = 60;
            iconMonthlyRentals.Location = new Point(165, 44);
            iconMonthlyRentals.Name = "iconMonthlyRentals";
            iconMonthlyRentals.Size = new Size(60, 60);
            iconMonthlyRentals.TabIndex = 0;
            iconMonthlyRentals.TabStop = false;
            // 
            // pnlRentCard3
            // 
            pnlRentCard3.BackColor = Color.FromArgb(135, 206, 250);
            pnlRentCard3.BorderStyle = BorderStyle.FixedSingle;
            pnlRentCard3.Controls.Add(lblActiveRentalsTitle);
            pnlRentCard3.Controls.Add(lblActiveRentalsCount);
            pnlRentCard3.Controls.Add(iconActiveRentals);
            pnlRentCard3.Dock = DockStyle.Left;
            pnlRentCard3.Location = new Point(392, 0);
            pnlRentCard3.Margin = new Padding(10);
            pnlRentCard3.Name = "pnlRentCard3";
            pnlRentCard3.Size = new Size(392, 300);
            pnlRentCard3.TabIndex = 2;
            // 
            // lblActiveRentalsTitle
            // 
            lblActiveRentalsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblActiveRentalsTitle.ForeColor = Color.FromArgb(50, 50, 50);
            lblActiveRentalsTitle.Location = new Point(58, 204);
            lblActiveRentalsTitle.Name = "lblActiveRentalsTitle";
            lblActiveRentalsTitle.Size = new Size(274, 50);
            lblActiveRentalsTitle.TabIndex = 2;
            lblActiveRentalsTitle.Text = "Active Rentals";
            lblActiveRentalsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActiveRentalsCount
            // 
            lblActiveRentalsCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblActiveRentalsCount.ForeColor = Color.FromArgb(50, 50, 50);
            lblActiveRentalsCount.Location = new Point(58, 124);
            lblActiveRentalsCount.Name = "lblActiveRentalsCount";
            lblActiveRentalsCount.Size = new Size(274, 70);
            lblActiveRentalsCount.TabIndex = 1;
            lblActiveRentalsCount.Text = "0";
            lblActiveRentalsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconActiveRentals
            // 
            iconActiveRentals.BackColor = Color.Transparent;
            iconActiveRentals.ForeColor = Color.FromArgb(80, 80, 80);
            iconActiveRentals.IconChar = FontAwesome.Sharp.IconChar.CarSide;
            iconActiveRentals.IconColor = Color.FromArgb(80, 80, 80);
            iconActiveRentals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconActiveRentals.IconSize = 60;
            iconActiveRentals.Location = new Point(165, 44);
            iconActiveRentals.Name = "iconActiveRentals";
            iconActiveRentals.Size = new Size(60, 60);
            iconActiveRentals.TabIndex = 0;
            iconActiveRentals.TabStop = false;
            // 
            // pnlRentCard1
            // 
            pnlRentCard1.BackColor = Color.FromArgb(171, 197, 255);
            pnlRentCard1.BorderStyle = BorderStyle.FixedSingle;
            pnlRentCard1.Controls.Add(lblTotalRentalsTitle);
            pnlRentCard1.Controls.Add(lblTotalRentalsCount);
            pnlRentCard1.Controls.Add(iconTotalRentals);
            pnlRentCard1.Dock = DockStyle.Left;
            pnlRentCard1.Location = new Point(0, 0);
            pnlRentCard1.Margin = new Padding(10);
            pnlRentCard1.Name = "pnlRentCard1";
            pnlRentCard1.Size = new Size(392, 300);
            pnlRentCard1.TabIndex = 0;
            // 
            // lblTotalRentalsTitle
            // 
            lblTotalRentalsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalRentalsTitle.ForeColor = Color.FromArgb(50, 50, 50);
            lblTotalRentalsTitle.Location = new Point(58, 204);
            lblTotalRentalsTitle.Name = "lblTotalRentalsTitle";
            lblTotalRentalsTitle.Size = new Size(274, 50);
            lblTotalRentalsTitle.TabIndex = 2;
            lblTotalRentalsTitle.Text = "Total Rentals";
            lblTotalRentalsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalRentalsCount
            // 
            lblTotalRentalsCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblTotalRentalsCount.ForeColor = Color.FromArgb(50, 50, 50);
            lblTotalRentalsCount.Location = new Point(58, 124);
            lblTotalRentalsCount.Name = "lblTotalRentalsCount";
            lblTotalRentalsCount.Size = new Size(274, 70);
            lblTotalRentalsCount.TabIndex = 1;
            lblTotalRentalsCount.Text = "0";
            lblTotalRentalsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconTotalRentals
            // 
            iconTotalRentals.BackColor = Color.Transparent;
            iconTotalRentals.ForeColor = Color.FromArgb(80, 80, 80);
            iconTotalRentals.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            iconTotalRentals.IconColor = Color.FromArgb(80, 80, 80);
            iconTotalRentals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconTotalRentals.IconSize = 60;
            iconTotalRentals.Location = new Point(165, 44);
            iconTotalRentals.Name = "iconTotalRentals";
            iconTotalRentals.Size = new Size(60, 60);
            iconTotalRentals.TabIndex = 0;
            iconTotalRentals.TabStop = false;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlCards);
            Name = "DashboardControl";
            Padding = new Padding(50);
            Size = new Size(1670, 1000);
            Load += DashboardControl_Load;
            pnlCards.ResumeLayout(false);
            pnlRentCard5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconCanceledRentals).EndInit();
            pnlRentCard4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconMonthlyRentals).EndInit();
            pnlRentCard3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconActiveRentals).EndInit();
            pnlRentCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconTotalRentals).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCards;
        private Panel pnlRentCard5;
        private Panel pnlRentCard4;
        private Panel pnlRentCard3;
        private Panel pnlRentCard1;
        private FontAwesome.Sharp.IconPictureBox iconTotalRentals;
        private Label lblTotalRentalsCount;
        private Label lblTotalRentalsTitle;
        private Label lblActiveRentalsTitle;
        private Label lblActiveRentalsCount;
        private FontAwesome.Sharp.IconPictureBox iconActiveRentals;
        private Label lblMonthlyRentalsTitle;
        private Label lblMonthlyRentalsCount;
        private FontAwesome.Sharp.IconPictureBox iconMonthlyRentals;
        private Label lblCanceledRentalsTitle;
        private Label lblCanceledRentalsCount;
        private FontAwesome.Sharp.IconPictureBox iconCanceledRentals;
    }
}