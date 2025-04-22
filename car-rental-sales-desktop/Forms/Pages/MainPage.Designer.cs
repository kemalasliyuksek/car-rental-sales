namespace car_rental_sales_desktop.Forms.Pages
{
    partial class MainPage
    {
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlSideMenu = new Panel();
            btnSettings = new FontAwesome.Sharp.IconButton();
            btnService = new FontAwesome.Sharp.IconButton();
            btnReports = new FontAwesome.Sharp.IconButton();
            btnStaff = new FontAwesome.Sharp.IconButton();
            btnBranches = new FontAwesome.Sharp.IconButton();
            btnSales = new FontAwesome.Sharp.IconButton();
            btnRentals = new FontAwesome.Sharp.IconButton();
            btnVehicles = new FontAwesome.Sharp.IconButton();
            btnCustomers = new FontAwesome.Sharp.IconButton();
            btnDashboard = new FontAwesome.Sharp.IconButton();
            btnMainPage = new FontAwesome.Sharp.IconButton();
            pnlCurrentUser = new Panel();
            pnlDivider = new Panel();
            btnLogOut = new FontAwesome.Sharp.IconButton();
            picUserAvatar = new FontAwesome.Sharp.IconPictureBox();
            lblUsername = new Label();
            lblBranchName = new Label();
            lblUserRole = new Label();
            pnlTopBar = new Panel();
            lblPageTitle = new Label();
            iconCurrentPage = new FontAwesome.Sharp.IconPictureBox();
            pnlContent = new Panel();
            toolTip = new ToolTip(components);
            pnlSideMenu.SuspendLayout();
            pnlCurrentUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).BeginInit();
            pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentPage).BeginInit();
            SuspendLayout();
            // 
            // pnlSideMenu
            // 
            pnlSideMenu.BackColor = Color.FromArgb(49, 76, 143);
            pnlSideMenu.Controls.Add(btnSettings);
            pnlSideMenu.Controls.Add(btnService);
            pnlSideMenu.Controls.Add(btnReports);
            pnlSideMenu.Controls.Add(btnStaff);
            pnlSideMenu.Controls.Add(btnBranches);
            pnlSideMenu.Controls.Add(btnSales);
            pnlSideMenu.Controls.Add(btnRentals);
            pnlSideMenu.Controls.Add(btnVehicles);
            pnlSideMenu.Controls.Add(btnCustomers);
            pnlSideMenu.Controls.Add(btnDashboard);
            pnlSideMenu.Controls.Add(btnMainPage);
            pnlSideMenu.Controls.Add(pnlCurrentUser);
            pnlSideMenu.Dock = DockStyle.Left;
            pnlSideMenu.Location = new Point(0, 0);
            pnlSideMenu.Name = "pnlSideMenu";
            pnlSideMenu.Size = new Size(250, 800);
            pnlSideMenu.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F);
            btnSettings.ForeColor = Color.White;
            btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnSettings.IconColor = Color.White;
            btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSettings.IconSize = 32;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(0, 620);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(10, 0, 0, 0);
            btnSettings.Size = new Size(250, 50);
            btnSettings.TabIndex = 10;
            btnSettings.Text = "  Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnService
            // 
            btnService.Cursor = Cursors.Hand;
            btnService.Dock = DockStyle.Top;
            btnService.FlatAppearance.BorderSize = 0;
            btnService.FlatStyle = FlatStyle.Flat;
            btnService.Font = new Font("Segoe UI", 11F);
            btnService.ForeColor = Color.White;
            btnService.IconChar = FontAwesome.Sharp.IconChar.Tools;
            btnService.IconColor = Color.White;
            btnService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnService.IconSize = 32;
            btnService.ImageAlign = ContentAlignment.MiddleLeft;
            btnService.Location = new Point(0, 570);
            btnService.Name = "btnService";
            btnService.Padding = new Padding(10, 0, 0, 0);
            btnService.Size = new Size(250, 50);
            btnService.TabIndex = 9;
            btnService.Text = "  Service";
            btnService.TextAlign = ContentAlignment.MiddleLeft;
            btnService.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnService.UseVisualStyleBackColor = true;
            btnService.Click += btnService_Click;
            // 
            // btnReports
            // 
            btnReports.Cursor = Cursors.Hand;
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 11F);
            btnReports.ForeColor = Color.White;
            btnReports.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            btnReports.IconColor = Color.White;
            btnReports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReports.IconSize = 32;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.Location = new Point(0, 520);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(10, 0, 0, 0);
            btnReports.Size = new Size(250, 50);
            btnReports.TabIndex = 8;
            btnReports.Text = "  Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnStaff
            // 
            btnStaff.Cursor = Cursors.Hand;
            btnStaff.Dock = DockStyle.Top;
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.Font = new Font("Segoe UI", 11F);
            btnStaff.ForeColor = Color.White;
            btnStaff.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            btnStaff.IconColor = Color.White;
            btnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStaff.IconSize = 32;
            btnStaff.ImageAlign = ContentAlignment.MiddleLeft;
            btnStaff.Location = new Point(0, 470);
            btnStaff.Name = "btnStaff";
            btnStaff.Padding = new Padding(10, 0, 0, 0);
            btnStaff.Size = new Size(250, 50);
            btnStaff.TabIndex = 7;
            btnStaff.Text = "  Staff";
            btnStaff.TextAlign = ContentAlignment.MiddleLeft;
            btnStaff.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnStaff.UseVisualStyleBackColor = true;
            btnStaff.Click += btnStaff_Click;
            // 
            // btnBranches
            // 
            btnBranches.Cursor = Cursors.Hand;
            btnBranches.Dock = DockStyle.Top;
            btnBranches.FlatAppearance.BorderSize = 0;
            btnBranches.FlatStyle = FlatStyle.Flat;
            btnBranches.Font = new Font("Segoe UI", 11F);
            btnBranches.ForeColor = Color.White;
            btnBranches.IconChar = FontAwesome.Sharp.IconChar.Building;
            btnBranches.IconColor = Color.White;
            btnBranches.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnBranches.IconSize = 32;
            btnBranches.ImageAlign = ContentAlignment.MiddleLeft;
            btnBranches.Location = new Point(0, 420);
            btnBranches.Name = "btnBranches";
            btnBranches.Padding = new Padding(10, 0, 0, 0);
            btnBranches.Size = new Size(250, 50);
            btnBranches.TabIndex = 6;
            btnBranches.Text = "  Branches";
            btnBranches.TextAlign = ContentAlignment.MiddleLeft;
            btnBranches.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBranches.UseVisualStyleBackColor = true;
            btnBranches.Click += btnBranches_Click;
            // 
            // btnSales
            // 
            btnSales.Cursor = Cursors.Hand;
            btnSales.Dock = DockStyle.Top;
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI", 11F);
            btnSales.ForeColor = Color.White;
            btnSales.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnSales.IconColor = Color.White;
            btnSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSales.IconSize = 32;
            btnSales.ImageAlign = ContentAlignment.MiddleLeft;
            btnSales.Location = new Point(0, 370);
            btnSales.Name = "btnSales";
            btnSales.Padding = new Padding(10, 0, 0, 0);
            btnSales.Size = new Size(250, 50);
            btnSales.TabIndex = 5;
            btnSales.Text = "  Sales";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnRentals
            // 
            btnRentals.Cursor = Cursors.Hand;
            btnRentals.Dock = DockStyle.Top;
            btnRentals.FlatAppearance.BorderSize = 0;
            btnRentals.FlatStyle = FlatStyle.Flat;
            btnRentals.Font = new Font("Segoe UI", 11F);
            btnRentals.ForeColor = Color.White;
            btnRentals.IconChar = FontAwesome.Sharp.IconChar.CalendarDays;
            btnRentals.IconColor = Color.White;
            btnRentals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRentals.IconSize = 32;
            btnRentals.ImageAlign = ContentAlignment.MiddleLeft;
            btnRentals.Location = new Point(0, 320);
            btnRentals.Name = "btnRentals";
            btnRentals.Padding = new Padding(10, 0, 0, 0);
            btnRentals.Size = new Size(250, 50);
            btnRentals.TabIndex = 4;
            btnRentals.Text = "  Rentals";
            btnRentals.TextAlign = ContentAlignment.MiddleLeft;
            btnRentals.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRentals.UseVisualStyleBackColor = true;
            btnRentals.Click += btnRentals_Click;
            // 
            // btnVehicles
            // 
            btnVehicles.Cursor = Cursors.Hand;
            btnVehicles.Dock = DockStyle.Top;
            btnVehicles.FlatAppearance.BorderSize = 0;
            btnVehicles.FlatStyle = FlatStyle.Flat;
            btnVehicles.Font = new Font("Segoe UI", 11F);
            btnVehicles.ForeColor = Color.White;
            btnVehicles.IconChar = FontAwesome.Sharp.IconChar.Car;
            btnVehicles.IconColor = Color.White;
            btnVehicles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVehicles.IconSize = 32;
            btnVehicles.ImageAlign = ContentAlignment.MiddleLeft;
            btnVehicles.Location = new Point(0, 270);
            btnVehicles.Name = "btnVehicles";
            btnVehicles.Padding = new Padding(10, 0, 0, 0);
            btnVehicles.Size = new Size(250, 50);
            btnVehicles.TabIndex = 3;
            btnVehicles.Text = "  Vehicles";
            btnVehicles.TextAlign = ContentAlignment.MiddleLeft;
            btnVehicles.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVehicles.UseVisualStyleBackColor = true;
            btnVehicles.Click += btnVehicles_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Cursor = Cursors.Hand;
            btnCustomers.Dock = DockStyle.Top;
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Segoe UI", 11F);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnCustomers.IconColor = Color.White;
            btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCustomers.IconSize = 32;
            btnCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomers.Location = new Point(0, 220);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Padding = new Padding(10, 0, 0, 0);
            btnCustomers.Size = new Size(250, 50);
            btnCustomers.TabIndex = 2;
            btnCustomers.Text = "  Customers";
            btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.IconChar = FontAwesome.Sharp.IconChar.PieChart;
            btnDashboard.IconColor = Color.White;
            btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashboard.IconSize = 32;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 170);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 0, 0);
            btnDashboard.Size = new Size(250, 50);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "  Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnMainPage
            // 
            btnMainPage.Cursor = Cursors.Hand;
            btnMainPage.Dock = DockStyle.Top;
            btnMainPage.FlatAppearance.BorderSize = 0;
            btnMainPage.FlatStyle = FlatStyle.Flat;
            btnMainPage.Font = new Font("Segoe UI", 11F);
            btnMainPage.ForeColor = Color.White;
            btnMainPage.IconChar = FontAwesome.Sharp.IconChar.House;
            btnMainPage.IconColor = Color.White;
            btnMainPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMainPage.IconSize = 32;
            btnMainPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnMainPage.Location = new Point(0, 120);
            btnMainPage.Name = "btnMainPage";
            btnMainPage.Padding = new Padding(10, 0, 0, 0);
            btnMainPage.Size = new Size(250, 50);
            btnMainPage.TabIndex = 11;
            btnMainPage.Text = "  Main Page";
            btnMainPage.TextAlign = ContentAlignment.MiddleLeft;
            btnMainPage.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMainPage.UseVisualStyleBackColor = true;
            btnMainPage.Click += btnMainPage_Click;
            // 
            // pnlCurrentUser
            // 
            pnlCurrentUser.BackColor = Color.FromArgb(33, 50, 100);
            pnlCurrentUser.Controls.Add(pnlDivider);
            pnlCurrentUser.Controls.Add(btnLogOut);
            pnlCurrentUser.Controls.Add(picUserAvatar);
            pnlCurrentUser.Controls.Add(lblUsername);
            pnlCurrentUser.Controls.Add(lblBranchName);
            pnlCurrentUser.Controls.Add(lblUserRole);
            pnlCurrentUser.Dock = DockStyle.Top;
            pnlCurrentUser.Location = new Point(0, 0);
            pnlCurrentUser.Name = "pnlCurrentUser";
            pnlCurrentUser.Size = new Size(250, 120);
            pnlCurrentUser.TabIndex = 0;
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.FromArgb(70, 100, 170);
            pnlDivider.Location = new Point(0, 119);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(250, 1);
            pnlDivider.TabIndex = 10;
            // 
            // btnLogOut
            // 
            btnLogOut.Anchor = AnchorStyles.Right;
            btnLogOut.BackColor = Color.Transparent;
            btnLogOut.Cursor = Cursors.Hand;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLogOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 80, 130);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            btnLogOut.IconColor = Color.LightGray;
            btnLogOut.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnLogOut.IconSize = 25;
            btnLogOut.Location = new Point(210, 85);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(30, 30);
            btnLogOut.TabIndex = 9;
            toolTip.SetToolTip(btnLogOut, "Logout");
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // picUserAvatar
            // 
            picUserAvatar.BackColor = Color.Transparent;
            picUserAvatar.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            picUserAvatar.IconColor = Color.White;
            picUserAvatar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            picUserAvatar.IconSize = 70;
            picUserAvatar.Location = new Point(10, 25);
            picUserAvatar.Name = "picUserAvatar";
            picUserAvatar.Size = new Size(70, 70);
            picUserAvatar.TabIndex = 0;
            picUserAvatar.TabStop = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(90, 20);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(117, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Name Surname";
            // 
            // lblBranchName
            // 
            lblBranchName.AutoSize = true;
            lblBranchName.Font = new Font("Segoe UI", 9F);
            lblBranchName.ForeColor = Color.FromArgb(180, 180, 235);
            lblBranchName.Location = new Point(90, 65);
            lblBranchName.Name = "lblBranchName";
            lblBranchName.Size = new Size(77, 15);
            lblBranchName.TabIndex = 3;
            lblBranchName.Text = "Branch: Main";
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 9F);
            lblUserRole.ForeColor = Color.FromArgb(200, 200, 255);
            lblUserRole.Location = new Point(90, 45);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(72, 15);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "Role: Admin";
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.White;
            pnlTopBar.Controls.Add(lblPageTitle);
            pnlTopBar.Controls.Add(iconCurrentPage);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(250, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(950, 80);
            pnlTopBar.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(49, 76, 143);
            lblPageTitle.Location = new Point(69, 26);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(112, 28);
            lblPageTitle.TabIndex = 1;
            lblPageTitle.Text = "Main Page";
            // 
            // iconCurrentPage
            // 
            iconCurrentPage.BackColor = Color.Transparent;
            iconCurrentPage.ForeColor = Color.FromArgb(49, 76, 143);
            iconCurrentPage.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentPage.IconColor = Color.FromArgb(49, 76, 143);
            iconCurrentPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentPage.IconSize = 40;
            iconCurrentPage.Location = new Point(23, 20);
            iconCurrentPage.Name = "iconCurrentPage";
            iconCurrentPage.Size = new Size(40, 40);
            iconCurrentPage.TabIndex = 0;
            iconCurrentPage.TabStop = false;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 245, 245);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(250, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(950, 720);
            pnlContent.TabIndex = 2;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopBar);
            Controls.Add(pnlSideMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Car Rental and Sales System";
            WindowState = FormWindowState.Maximized;
            Load += MainPage_Load;
            pnlSideMenu.ResumeLayout(false);
            pnlCurrentUser.ResumeLayout(false);
            pnlCurrentUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).EndInit();
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentPage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSideMenu;
        private Panel pnlCurrentUser;
        private FontAwesome.Sharp.IconButton btnMainPage;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnVehicles;
        private FontAwesome.Sharp.IconButton btnRentals;
        private FontAwesome.Sharp.IconButton btnSales;
        private FontAwesome.Sharp.IconButton btnBranches;
        private FontAwesome.Sharp.IconButton btnStaff;
        private FontAwesome.Sharp.IconButton btnReports;
        private FontAwesome.Sharp.IconButton btnService;
        private FontAwesome.Sharp.IconButton btnSettings;
        private Panel pnlTopBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentPage;
        private Label lblPageTitle;
        private Label lblUsername;
        private Label lblUserRole;
        private Label lblBranchName;
        private Panel pnlContent;
        private FontAwesome.Sharp.IconButton btnLogOut;
        private FontAwesome.Sharp.IconPictureBox picUserAvatar;
        private Panel pnlDivider;
        private ToolTip toolTip;
        private System.ComponentModel.IContainer components;
    }
}