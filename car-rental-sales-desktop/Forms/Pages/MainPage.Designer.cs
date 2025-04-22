using FontAwesome.Sharp;

namespace car_rental_sales_desktop
{
    partial class MainPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSide = new Panel();
            btnLogout = new IconButton();
            btnSettings = new IconButton();
            btnReports = new IconButton();
            btnStaff = new IconButton();
            btnMaintenance = new IconButton();
            btnSales = new IconButton();
            btnRentals = new IconButton();
            btnVehicles = new IconButton();
            btnCustomers = new IconButton();
            btnDashboard = new IconButton();
            pnlLogo = new Panel();
            lblCompanyName = new Label();
            pnlTop = new Panel();
            lblBranchName = new Label();
            lblUserRole = new Label();
            lblUserName = new Label();
            lblPageTitle = new Label();
            pnlContent = new Panel();
            pnlSide.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSide
            // 
            pnlSide.BackColor = Color.FromArgb(51, 51, 76);
            pnlSide.Controls.Add(btnLogout);
            pnlSide.Controls.Add(btnSettings);
            pnlSide.Controls.Add(btnReports);
            pnlSide.Controls.Add(btnStaff);
            pnlSide.Controls.Add(btnMaintenance);
            pnlSide.Controls.Add(btnSales);
            pnlSide.Controls.Add(btnRentals);
            pnlSide.Controls.Add(btnVehicles);
            pnlSide.Controls.Add(btnCustomers);
            pnlSide.Controls.Add(btnDashboard);
            pnlSide.Controls.Add(pnlLogo);
            pnlSide.Dock = DockStyle.Left;
            pnlSide.Location = new Point(0, 0);
            pnlSide.Name = "pnlSide";
            pnlSide.Size = new Size(201, 732);
            pnlSide.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Gainsboro;
            btnLogout.IconChar = IconChar.SignOutAlt;
            btnLogout.IconColor = Color.Gainsboro;
            btnLogout.IconFont = IconFont.Auto;
            btnLogout.IconSize = 32;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 685);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 0, 0);
            btnLogout.Size = new Size(201, 47);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "  Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.Gainsboro;
            btnSettings.IconChar = IconChar.Cog;
            btnSettings.IconColor = Color.Gainsboro;
            btnSettings.IconFont = IconFont.Auto;
            btnSettings.IconSize = 32;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(0, 470);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(10, 0, 0, 0);
            btnSettings.Size = new Size(201, 47);
            btnSettings.TabIndex = 9;
            btnSettings.Text = "  Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.Gainsboro;
            btnReports.IconChar = IconChar.BarChart;
            btnReports.IconColor = Color.Gainsboro;
            btnReports.IconFont = IconFont.Auto;
            btnReports.IconSize = 32;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.Location = new Point(0, 423);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(10, 0, 0, 0);
            btnReports.Size = new Size(201, 47);
            btnReports.TabIndex = 8;
            btnReports.Text = "  Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnStaff
            // 
            btnStaff.Dock = DockStyle.Top;
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStaff.ForeColor = Color.Gainsboro;
            btnStaff.IconChar = IconChar.UserTie;
            btnStaff.IconColor = Color.Gainsboro;
            btnStaff.IconFont = IconFont.Auto;
            btnStaff.IconSize = 32;
            btnStaff.ImageAlign = ContentAlignment.MiddleLeft;
            btnStaff.Location = new Point(0, 376);
            btnStaff.Name = "btnStaff";
            btnStaff.Padding = new Padding(10, 0, 0, 0);
            btnStaff.Size = new Size(201, 47);
            btnStaff.TabIndex = 7;
            btnStaff.Text = "  Staff";
            btnStaff.TextAlign = ContentAlignment.MiddleLeft;
            btnStaff.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnStaff.UseVisualStyleBackColor = true;
            btnStaff.Click += btnStaff_Click;
            // 
            // btnMaintenance
            // 
            btnMaintenance.Dock = DockStyle.Top;
            btnMaintenance.FlatAppearance.BorderSize = 0;
            btnMaintenance.FlatStyle = FlatStyle.Flat;
            btnMaintenance.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMaintenance.ForeColor = Color.Gainsboro;
            btnMaintenance.IconChar = IconChar.Tools;
            btnMaintenance.IconColor = Color.Gainsboro;
            btnMaintenance.IconFont = IconFont.Auto;
            btnMaintenance.IconSize = 32;
            btnMaintenance.ImageAlign = ContentAlignment.MiddleLeft;
            btnMaintenance.Location = new Point(0, 329);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Padding = new Padding(10, 0, 0, 0);
            btnMaintenance.Size = new Size(201, 47);
            btnMaintenance.TabIndex = 6;
            btnMaintenance.Text = "  Maintenance";
            btnMaintenance.TextAlign = ContentAlignment.MiddleLeft;
            btnMaintenance.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMaintenance.UseVisualStyleBackColor = true;
            btnMaintenance.Click += btnMaintenance_Click;
            // 
            // btnSales
            // 
            btnSales.Dock = DockStyle.Top;
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSales.ForeColor = Color.Gainsboro;
            btnSales.IconChar = IconChar.Tags;
            btnSales.IconColor = Color.Gainsboro;
            btnSales.IconFont = IconFont.Auto;
            btnSales.IconSize = 32;
            btnSales.ImageAlign = ContentAlignment.MiddleLeft;
            btnSales.Location = new Point(0, 282);
            btnSales.Name = "btnSales";
            btnSales.Padding = new Padding(10, 0, 0, 0);
            btnSales.Size = new Size(201, 47);
            btnSales.TabIndex = 5;
            btnSales.Text = "  Sales";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnRentals
            // 
            btnRentals.Dock = DockStyle.Top;
            btnRentals.FlatAppearance.BorderSize = 0;
            btnRentals.FlatStyle = FlatStyle.Flat;
            btnRentals.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRentals.ForeColor = Color.Gainsboro;
            btnRentals.IconChar = IconChar.CalendarDays;
            btnRentals.IconColor = Color.Gainsboro;
            btnRentals.IconFont = IconFont.Auto;
            btnRentals.IconSize = 32;
            btnRentals.ImageAlign = ContentAlignment.MiddleLeft;
            btnRentals.Location = new Point(0, 235);
            btnRentals.Name = "btnRentals";
            btnRentals.Padding = new Padding(10, 0, 0, 0);
            btnRentals.Size = new Size(201, 47);
            btnRentals.TabIndex = 4;
            btnRentals.Text = "  Rentals";
            btnRentals.TextAlign = ContentAlignment.MiddleLeft;
            btnRentals.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRentals.UseVisualStyleBackColor = true;
            btnRentals.Click += btnRentals_Click;
            // 
            // btnVehicles
            // 
            btnVehicles.Dock = DockStyle.Top;
            btnVehicles.FlatAppearance.BorderSize = 0;
            btnVehicles.FlatStyle = FlatStyle.Flat;
            btnVehicles.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVehicles.ForeColor = Color.Gainsboro;
            btnVehicles.IconChar = IconChar.Car;
            btnVehicles.IconColor = Color.Gainsboro;
            btnVehicles.IconFont = IconFont.Auto;
            btnVehicles.IconSize = 32;
            btnVehicles.ImageAlign = ContentAlignment.MiddleLeft;
            btnVehicles.Location = new Point(0, 188);
            btnVehicles.Name = "btnVehicles";
            btnVehicles.Padding = new Padding(10, 0, 0, 0);
            btnVehicles.Size = new Size(201, 47);
            btnVehicles.TabIndex = 3;
            btnVehicles.Text = "  Vehicles";
            btnVehicles.TextAlign = ContentAlignment.MiddleLeft;
            btnVehicles.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVehicles.UseVisualStyleBackColor = true;
            btnVehicles.Click += btnVehicles_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Dock = DockStyle.Top;
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCustomers.ForeColor = Color.Gainsboro;
            btnCustomers.IconChar = IconChar.Users;
            btnCustomers.IconColor = Color.Gainsboro;
            btnCustomers.IconFont = IconFont.Auto;
            btnCustomers.IconSize = 32;
            btnCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomers.Location = new Point(0, 141);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Padding = new Padding(10, 0, 0, 0);
            btnCustomers.Size = new Size(201, 47);
            btnCustomers.TabIndex = 2;
            btnCustomers.Text = "  Customers";
            btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.Gainsboro;
            btnDashboard.IconChar = IconChar.ChartLine;
            btnDashboard.IconColor = Color.Gainsboro;
            btnDashboard.IconFont = IconFont.Auto;
            btnDashboard.IconSize = 32;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 94);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 0, 0);
            btnDashboard.Size = new Size(201, 47);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "  Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(39, 39, 58);
            pnlLogo.Controls.Add(lblCompanyName);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(201, 94);
            pnlLogo.TabIndex = 0;
            // 
            // lblCompanyName
            // 
            lblCompanyName.Dock = DockStyle.Fill;
            lblCompanyName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyName.ForeColor = Color.White;
            lblCompanyName.Location = new Point(0, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(201, 94);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Car Rental & Sales";
            lblCompanyName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(49, 76, 143);
            pnlTop.Controls.Add(lblBranchName);
            pnlTop.Controls.Add(lblUserRole);
            pnlTop.Controls.Add(lblUserName);
            pnlTop.Controls.Add(lblPageTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(201, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1010, 94);
            pnlTop.TabIndex = 1;
            // 
            // lblBranchName
            // 
            lblBranchName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBranchName.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBranchName.ForeColor = Color.White;
            lblBranchName.Location = new Point(802, 66);
            lblBranchName.Name = "lblBranchName";
            lblBranchName.Size = new Size(197, 22);
            lblBranchName.TabIndex = 3;
            lblBranchName.Text = "Branch";
            lblBranchName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUserRole
            // 
            lblUserRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserRole.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserRole.ForeColor = Color.White;
            lblUserRole.Location = new Point(802, 38);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(197, 22);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "Role";
            lblUserRole.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(802, 9);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(197, 22);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "User Name";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPageTitle
            // 
            lblPageTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.Location = new Point(14, 28);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(350, 38);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Dashboard";
            lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(201, 94);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(13, 14, 13, 14);
            pnlContent.Size = new Size(1010, 638);
            pnlContent.TabIndex = 2;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 732);
            Controls.Add(pnlContent);
            Controls.Add(pnlTop);
            Controls.Add(pnlSide);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(877, 565);
            Name = "MainPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Car Rental & Sales Management System";
            WindowState = FormWindowState.Maximized;
            pnlSide.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblCompanyName;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnVehicles;
        private FontAwesome.Sharp.IconButton btnRentals;
        private FontAwesome.Sharp.IconButton btnSales;
        private FontAwesome.Sharp.IconButton btnMaintenance;
        private FontAwesome.Sharp.IconButton btnStaff;
        private FontAwesome.Sharp.IconButton btnReports;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnLogout;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Panel pnlContent;
    }
}