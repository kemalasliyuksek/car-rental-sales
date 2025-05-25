namespace car_rental_sales_desktop.Forms.Controls
{
    partial class StaffControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn2 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn9 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn10 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn11 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn12 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn13 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn14 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn4 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridCheckBoxColumn gridCheckBoxColumn2 = new Syncfusion.WinForms.DataGrid.GridCheckBoxColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn5 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn6 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            tabControlStaff = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageStaffList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panelStaffActions = new Panel();
            btnEditStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            btnDeleteStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            btnToggleStatus = new Syncfusion.Windows.Forms.ButtonAdv();
            btnRefreshStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            sfDataGridStaff = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageStaffAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panelStaffForm = new Panel();
            btnCancelStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            btnSaveStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            cmbBranch = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            cmbRole = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            chkUserActive = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtUserPhone = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtUserEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtUserPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtUsername = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtUserLastName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtUserFirstName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblBranch = new Label();
            lblRole = new Label();
            lblUserPhone = new Label();
            lblUserEmail = new Label();
            lblUserPassword = new Label();
            lblUsername = new Label();
            lblUserLastName = new Label();
            lblUserFirstName = new Label();
            lblStaffFormTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)tabControlStaff).BeginInit();
            tabControlStaff.SuspendLayout();
            tabPageStaffList.SuspendLayout();
            panelStaffActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridStaff).BeginInit();
            tabPageStaffAdd.SuspendLayout();
            panelStaffForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbBranch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkUserActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUsername).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserLastName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserFirstName).BeginInit();
            SuspendLayout();
            // 
            // tabControlStaff
            // 
            tabControlStaff.BeforeTouchSize = new Size(1670, 1000);
            tabControlStaff.Controls.Add(tabPageStaffList);
            tabControlStaff.Controls.Add(tabPageStaffAdd);
            tabControlStaff.Dock = DockStyle.Fill;
            tabControlStaff.Location = new Point(0, 0);
            tabControlStaff.Name = "tabControlStaff";
            tabControlStaff.Size = new Size(1670, 1000);
            tabControlStaff.TabIndex = 0;
            // 
            // tabPageStaffList
            // 
            tabPageStaffList.Controls.Add(panelStaffActions);
            tabPageStaffList.Controls.Add(sfDataGridStaff);
            tabPageStaffList.Image = null;
            tabPageStaffList.ImageSize = new Size(16, 16);
            tabPageStaffList.Location = new Point(1, 33);
            tabPageStaffList.Name = "tabPageStaffList";
            tabPageStaffList.Padding = new Padding(20);
            tabPageStaffList.ShowCloseButton = true;
            tabPageStaffList.Size = new Size(1667, 965);
            tabPageStaffList.TabFont = new Font("Segoe UI", 12F);
            tabPageStaffList.TabIndex = 1;
            tabPageStaffList.Text = "Staff List";
            tabPageStaffList.ThemesEnabled = false;
            // 
            // panelStaffActions
            // 
            panelStaffActions.Controls.Add(btnEditStaff);
            panelStaffActions.Controls.Add(btnDeleteStaff);
            panelStaffActions.Controls.Add(btnToggleStatus);
            panelStaffActions.Controls.Add(btnRefreshStaff);
            panelStaffActions.Dock = DockStyle.Top;
            panelStaffActions.Location = new Point(20, 20);
            panelStaffActions.Name = "panelStaffActions";
            panelStaffActions.Size = new Size(1627, 60);
            panelStaffActions.TabIndex = 1;
            // 
            // btnEditStaff
            // 
            btnEditStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnEditStaff.BackColor = Color.FromArgb(0, 120, 215);
            btnEditStaff.BeforeTouchSize = new Size(120, 35);
            btnEditStaff.FlatStyle = FlatStyle.Flat;
            btnEditStaff.Font = new Font("Segoe UI Semibold", 10F);
            btnEditStaff.ForeColor = Color.White;
            btnEditStaff.Location = new Point(10, 15);
            btnEditStaff.Name = "btnEditStaff";
            btnEditStaff.Size = new Size(120, 35);
            btnEditStaff.TabIndex = 0;
            btnEditStaff.Text = "Edit Staff";
            btnEditStaff.ThemeName = "Metro";
            btnEditStaff.UseVisualStyleBackColor = false;
            btnEditStaff.Click += BtnEditStaff_Click;
            // 
            // btnDeleteStaff
            // 
            btnDeleteStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnDeleteStaff.BackColor = Color.FromArgb(215, 55, 55);
            btnDeleteStaff.BeforeTouchSize = new Size(120, 35);
            btnDeleteStaff.FlatStyle = FlatStyle.Flat;
            btnDeleteStaff.Font = new Font("Segoe UI Semibold", 10F);
            btnDeleteStaff.ForeColor = Color.White;
            btnDeleteStaff.Location = new Point(140, 15);
            btnDeleteStaff.Name = "btnDeleteStaff";
            btnDeleteStaff.Size = new Size(120, 35);
            btnDeleteStaff.TabIndex = 1;
            btnDeleteStaff.Text = "Delete Staff";
            btnDeleteStaff.ThemeName = "Metro";
            btnDeleteStaff.UseVisualStyleBackColor = false;
            btnDeleteStaff.Click += BtnDeleteStaff_Click;
            // 
            // btnToggleStatus
            // 
            btnToggleStatus.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnToggleStatus.BackColor = Color.FromArgb(255, 140, 0);
            btnToggleStatus.BeforeTouchSize = new Size(140, 35);
            btnToggleStatus.FlatStyle = FlatStyle.Flat;
            btnToggleStatus.Font = new Font("Segoe UI Semibold", 10F);
            btnToggleStatus.ForeColor = Color.White;
            btnToggleStatus.Location = new Point(270, 15);
            btnToggleStatus.Name = "btnToggleStatus";
            btnToggleStatus.Size = new Size(140, 35);
            btnToggleStatus.TabIndex = 2;
            btnToggleStatus.Text = "Toggle Status";
            btnToggleStatus.ThemeName = "Metro";
            btnToggleStatus.UseVisualStyleBackColor = false;
            btnToggleStatus.Click += BtnToggleStatus_Click;
            // 
            // btnRefreshStaff
            // 
            btnRefreshStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnRefreshStaff.BackColor = Color.FromArgb(34, 139, 34);
            btnRefreshStaff.BeforeTouchSize = new Size(120, 35);
            btnRefreshStaff.FlatStyle = FlatStyle.Flat;
            btnRefreshStaff.Font = new Font("Segoe UI Semibold", 10F);
            btnRefreshStaff.ForeColor = Color.White;
            btnRefreshStaff.Location = new Point(420, 15);
            btnRefreshStaff.Name = "btnRefreshStaff";
            btnRefreshStaff.Size = new Size(120, 35);
            btnRefreshStaff.TabIndex = 3;
            btnRefreshStaff.Text = "Refresh";
            btnRefreshStaff.ThemeName = "Metro";
            btnRefreshStaff.UseVisualStyleBackColor = false;
            btnRefreshStaff.Click += BtnRefreshStaff_Click;
            // 
            // sfDataGridStaff
            // 
            sfDataGridStaff.AccessibleName = "Table";
            sfDataGridStaff.AllowEditing = false;
            sfDataGridStaff.AutoGenerateColumns = false;
            gridNumericColumn2.AllowEditing = false;
            gridNumericColumn2.AllowResizing = true;
            gridNumericColumn2.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn2.Format = "0";
            gridNumericColumn2.HeaderText = "ID";
            gridNumericColumn2.MappingName = "UserID";
            gridNumericColumn2.Width = 50D;
            gridTextColumn8.AllowEditing = false;
            gridTextColumn8.AllowResizing = true;
            gridTextColumn8.HeaderText = "First Name";
            gridTextColumn8.MappingName = "UserFirstName";
            gridTextColumn8.Width = 110D;
            gridTextColumn9.AllowEditing = false;
            gridTextColumn9.AllowResizing = true;
            gridTextColumn9.HeaderText = "Last Name";
            gridTextColumn9.MappingName = "UserLastName";
            gridTextColumn9.Width = 110D;
            gridTextColumn10.AllowEditing = false;
            gridTextColumn10.AllowResizing = true;
            gridTextColumn10.HeaderText = "Username";
            gridTextColumn10.MappingName = "Username";
            gridTextColumn10.Width = 120D;
            gridTextColumn11.AllowEditing = false;
            gridTextColumn11.AllowResizing = true;
            gridTextColumn11.HeaderText = "Email";
            gridTextColumn11.MappingName = "UserEmail";
            gridTextColumn11.Width = 231D;
            gridTextColumn12.AllowEditing = false;
            gridTextColumn12.AllowResizing = true;
            gridTextColumn12.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn12.HeaderText = "Phone No";
            gridTextColumn12.MappingName = "UserPhone";
            gridTextColumn12.Width = 130D;
            gridTextColumn13.AllowEditing = false;
            gridTextColumn13.AllowResizing = true;
            gridTextColumn13.HeaderText = "Role";
            gridTextColumn13.MappingName = "Role.RoleName";
            gridTextColumn13.Width = 150D;
            gridTextColumn14.AllowEditing = false;
            gridTextColumn14.AllowResizing = true;
            gridTextColumn14.HeaderText = "Branch Name";
            gridTextColumn14.MappingName = "Branch.BranchName";
            gridTextColumn14.Width = 160D;
            gridDateTimeColumn4.AllowEditing = false;
            gridDateTimeColumn4.AllowResizing = true;
            gridDateTimeColumn4.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn4.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn4.HeaderText = "Last Login";
            gridDateTimeColumn4.MappingName = "UserLastLogin";
            gridDateTimeColumn4.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn4.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn4.Width = 160D;
            gridCheckBoxColumn2.AllowEditing = false;
            gridCheckBoxColumn2.AllowResizing = true;
            gridCheckBoxColumn2.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridCheckBoxColumn2.HeaderText = "Active";
            gridCheckBoxColumn2.MappingName = "UserActive";
            gridCheckBoxColumn2.Width = 70D;
            gridDateTimeColumn5.AllowEditing = false;
            gridDateTimeColumn5.AllowResizing = true;
            gridDateTimeColumn5.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn5.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn5.HeaderText = "Created At";
            gridDateTimeColumn5.MappingName = "UserCreatedAt";
            gridDateTimeColumn5.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn5.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn5.Width = 160D;
            gridDateTimeColumn6.AllowEditing = false;
            gridDateTimeColumn6.AllowResizing = true;
            gridDateTimeColumn6.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn6.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn6.HeaderText = "Updated At";
            gridDateTimeColumn6.MappingName = "UserUpdatedAt";
            gridDateTimeColumn6.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn6.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn6.Width = 160D;
            sfDataGridStaff.Columns.Add(gridNumericColumn2);
            sfDataGridStaff.Columns.Add(gridTextColumn8);
            sfDataGridStaff.Columns.Add(gridTextColumn9);
            sfDataGridStaff.Columns.Add(gridTextColumn10);
            sfDataGridStaff.Columns.Add(gridTextColumn11);
            sfDataGridStaff.Columns.Add(gridTextColumn12);
            sfDataGridStaff.Columns.Add(gridTextColumn13);
            sfDataGridStaff.Columns.Add(gridTextColumn14);
            sfDataGridStaff.Columns.Add(gridDateTimeColumn4);
            sfDataGridStaff.Columns.Add(gridCheckBoxColumn2);
            sfDataGridStaff.Columns.Add(gridDateTimeColumn5);
            sfDataGridStaff.Columns.Add(gridDateTimeColumn6);
            sfDataGridStaff.Dock = DockStyle.Fill;
            sfDataGridStaff.Location = new Point(20, 20);
            sfDataGridStaff.Name = "sfDataGridStaff";
            sfDataGridStaff.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            sfDataGridStaff.Size = new Size(1627, 925);
            sfDataGridStaff.Style.AddNewRowStyle.BackColor = Color.Transparent;
            sfDataGridStaff.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGridStaff.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGridStaff.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridStaff.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridStaff.Style.CurrentCellStyle.BackColor = Color.FromArgb(166, 216, 255);
            sfDataGridStaff.Style.CurrentCellStyle.BorderColor = Color.FromArgb(166, 216, 255);
            sfDataGridStaff.Style.CurrentCellStyle.BorderThickness = Syncfusion.WinForms.DataGrid.Styles.GridBorderWeight.ExtraThin;
            sfDataGridStaff.Style.CurrentCellStyle.TextColor = Color.Black;
            sfDataGridStaff.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGridStaff.Style.SelectionStyle.TextColor = Color.Black;
            sfDataGridStaff.TabIndex = 0;
            sfDataGridStaff.QueryRowStyle += SfDataGridStaff_QueryRowStyle;
            // 
            // tabPageStaffAdd
            // 
            tabPageStaffAdd.Controls.Add(panelStaffForm);
            tabPageStaffAdd.Image = null;
            tabPageStaffAdd.ImageSize = new Size(16, 16);
            tabPageStaffAdd.Location = new Point(1, 33);
            tabPageStaffAdd.Name = "tabPageStaffAdd";
            tabPageStaffAdd.Padding = new Padding(20);
            tabPageStaffAdd.ShowCloseButton = true;
            tabPageStaffAdd.Size = new Size(1667, 965);
            tabPageStaffAdd.TabFont = new Font("Segoe UI", 12F);
            tabPageStaffAdd.TabIndex = 2;
            tabPageStaffAdd.Text = "Staff Add/Edit";
            tabPageStaffAdd.ThemesEnabled = false;
            // 
            // panelStaffForm
            // 
            panelStaffForm.AutoScroll = true;
            panelStaffForm.Controls.Add(btnCancelStaff);
            panelStaffForm.Controls.Add(btnSaveStaff);
            panelStaffForm.Controls.Add(cmbBranch);
            panelStaffForm.Controls.Add(cmbRole);
            panelStaffForm.Controls.Add(chkUserActive);
            panelStaffForm.Controls.Add(txtUserPhone);
            panelStaffForm.Controls.Add(txtUserEmail);
            panelStaffForm.Controls.Add(txtUserPassword);
            panelStaffForm.Controls.Add(txtUsername);
            panelStaffForm.Controls.Add(txtUserLastName);
            panelStaffForm.Controls.Add(txtUserFirstName);
            panelStaffForm.Controls.Add(lblBranch);
            panelStaffForm.Controls.Add(lblRole);
            panelStaffForm.Controls.Add(lblUserPhone);
            panelStaffForm.Controls.Add(lblUserEmail);
            panelStaffForm.Controls.Add(lblUserPassword);
            panelStaffForm.Controls.Add(lblUsername);
            panelStaffForm.Controls.Add(lblUserLastName);
            panelStaffForm.Controls.Add(lblUserFirstName);
            panelStaffForm.Controls.Add(lblStaffFormTitle);
            panelStaffForm.Dock = DockStyle.Fill;
            panelStaffForm.Location = new Point(20, 20);
            panelStaffForm.Name = "panelStaffForm";
            panelStaffForm.Size = new Size(1627, 925);
            panelStaffForm.TabIndex = 0;
            // 
            // btnCancelStaff
            // 
            btnCancelStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnCancelStaff.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelStaff.BeforeTouchSize = new Size(150, 45);
            btnCancelStaff.FlatStyle = FlatStyle.Flat;
            btnCancelStaff.Font = new Font("Segoe UI Semibold", 12F);
            btnCancelStaff.ForeColor = Color.White;
            btnCancelStaff.Location = new Point(818, 674);
            btnCancelStaff.Name = "btnCancelStaff";
            btnCancelStaff.Size = new Size(150, 45);
            btnCancelStaff.TabIndex = 19;
            btnCancelStaff.Text = "Cancel";
            btnCancelStaff.ThemeName = "Metro";
            btnCancelStaff.UseVisualStyleBackColor = false;
            btnCancelStaff.Click += BtnCancelStaff_Click;
            // 
            // btnSaveStaff
            // 
            btnSaveStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnSaveStaff.BackColor = Color.FromArgb(40, 167, 69);
            btnSaveStaff.BeforeTouchSize = new Size(150, 45);
            btnSaveStaff.FlatStyle = FlatStyle.Flat;
            btnSaveStaff.Font = new Font("Segoe UI Semibold", 12F);
            btnSaveStaff.ForeColor = Color.White;
            btnSaveStaff.Location = new Point(658, 674);
            btnSaveStaff.Name = "btnSaveStaff";
            btnSaveStaff.Size = new Size(150, 45);
            btnSaveStaff.TabIndex = 18;
            btnSaveStaff.Text = "Save Staff";
            btnSaveStaff.ThemeName = "Metro";
            btnSaveStaff.UseVisualStyleBackColor = false;
            btnSaveStaff.Click += BtnSaveStaff_Click;
            // 
            // cmbBranch
            // 
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.Font = new Font("Segoe UI", 11F);
            cmbBranch.Height = 28;
            cmbBranch.Location = new Point(707, 555);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(310, 28);
            cmbBranch.TabIndex = 17;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 11F);
            cmbRole.Height = 28;
            cmbRole.Location = new Point(707, 505);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(310, 28);
            cmbRole.TabIndex = 16;
            // 
            // chkUserActive
            // 
            chkUserActive.AccessibilityEnabled = true;
            chkUserActive.BeforeTouchSize = new Size(156, 21);
            chkUserActive.Checked = true;
            chkUserActive.CheckState = CheckState.Checked;
            chkUserActive.Font = new Font("Segoe UI Semibold", 11F);
            chkUserActive.Location = new Point(537, 605);
            chkUserActive.Name = "chkUserActive";
            chkUserActive.Size = new Size(156, 21);
            chkUserActive.TabIndex = 15;
            chkUserActive.Text = "User is Active";
            // 
            // txtUserPhone
            // 
            txtUserPhone.BeforeTouchSize = new Size(310, 27);
            txtUserPhone.BorderStyle = BorderStyle.FixedSingle;
            txtUserPhone.Font = new Font("Segoe UI", 11F);
            txtUserPhone.Location = new Point(707, 455);
            txtUserPhone.Name = "txtUserPhone";
            txtUserPhone.Size = new Size(310, 27);
            txtUserPhone.TabIndex = 14;
            // 
            // txtUserEmail
            // 
            txtUserEmail.BeforeTouchSize = new Size(310, 27);
            txtUserEmail.BorderStyle = BorderStyle.FixedSingle;
            txtUserEmail.Font = new Font("Segoe UI", 11F);
            txtUserEmail.Location = new Point(707, 405);
            txtUserEmail.Name = "txtUserEmail";
            txtUserEmail.Size = new Size(310, 27);
            txtUserEmail.TabIndex = 13;
            // 
            // txtUserPassword
            // 
            txtUserPassword.BeforeTouchSize = new Size(310, 27);
            txtUserPassword.BorderStyle = BorderStyle.FixedSingle;
            txtUserPassword.Font = new Font("Segoe UI", 11F);
            txtUserPassword.Location = new Point(707, 355);
            txtUserPassword.Name = "txtUserPassword";
            txtUserPassword.PasswordChar = '*';
            txtUserPassword.Size = new Size(310, 27);
            txtUserPassword.TabIndex = 12;
            // 
            // txtUsername
            // 
            txtUsername.BeforeTouchSize = new Size(310, 27);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(707, 305);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(310, 27);
            txtUsername.TabIndex = 11;
            // 
            // txtUserLastName
            // 
            txtUserLastName.BeforeTouchSize = new Size(310, 27);
            txtUserLastName.BorderStyle = BorderStyle.FixedSingle;
            txtUserLastName.Font = new Font("Segoe UI", 11F);
            txtUserLastName.Location = new Point(707, 255);
            txtUserLastName.Name = "txtUserLastName";
            txtUserLastName.Size = new Size(310, 27);
            txtUserLastName.TabIndex = 10;
            // 
            // txtUserFirstName
            // 
            txtUserFirstName.BeforeTouchSize = new Size(310, 27);
            txtUserFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtUserFirstName.Font = new Font("Segoe UI", 11F);
            txtUserFirstName.Location = new Point(707, 205);
            txtUserFirstName.Name = "txtUserFirstName";
            txtUserFirstName.Size = new Size(310, 27);
            txtUserFirstName.TabIndex = 9;
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Font = new Font("Segoe UI Semibold", 11F);
            lblBranch.Location = new Point(537, 565);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(61, 20);
            lblBranch.TabIndex = 8;
            lblBranch.Text = "Branch:";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI Semibold", 11F);
            lblRole.Location = new Point(537, 515);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(43, 20);
            lblRole.TabIndex = 7;
            lblRole.Text = "Role:";
            // 
            // lblUserPhone
            // 
            lblUserPhone.AutoSize = true;
            lblUserPhone.Font = new Font("Segoe UI Semibold", 11F);
            lblUserPhone.Location = new Point(537, 465);
            lblUserPhone.Name = "lblUserPhone";
            lblUserPhone.Size = new Size(57, 20);
            lblUserPhone.TabIndex = 6;
            lblUserPhone.Text = "Phone:";
            // 
            // lblUserEmail
            // 
            lblUserEmail.AutoSize = true;
            lblUserEmail.Font = new Font("Segoe UI Semibold", 11F);
            lblUserEmail.Location = new Point(537, 415);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(50, 20);
            lblUserEmail.TabIndex = 5;
            lblUserEmail.Text = "Email:";
            // 
            // lblUserPassword
            // 
            lblUserPassword.AutoSize = true;
            lblUserPassword.Font = new Font("Segoe UI Semibold", 11F);
            lblUserPassword.Location = new Point(537, 365);
            lblUserPassword.Name = "lblUserPassword";
            lblUserPassword.Size = new Size(77, 20);
            lblUserPassword.TabIndex = 4;
            lblUserPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 11F);
            lblUsername.Location = new Point(537, 315);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(82, 20);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username:";
            // 
            // lblUserLastName
            // 
            lblUserLastName.AutoSize = true;
            lblUserLastName.Font = new Font("Segoe UI Semibold", 11F);
            lblUserLastName.Location = new Point(537, 265);
            lblUserLastName.Name = "lblUserLastName";
            lblUserLastName.Size = new Size(84, 20);
            lblUserLastName.TabIndex = 2;
            lblUserLastName.Text = "Last Name:";
            // 
            // lblUserFirstName
            // 
            lblUserFirstName.AutoSize = true;
            lblUserFirstName.Font = new Font("Segoe UI Semibold", 11F);
            lblUserFirstName.Location = new Point(537, 215);
            lblUserFirstName.Name = "lblUserFirstName";
            lblUserFirstName.Size = new Size(87, 20);
            lblUserFirstName.TabIndex = 1;
            lblUserFirstName.Text = "First Name:";
            // 
            // lblStaffFormTitle
            // 
            lblStaffFormTitle.AutoSize = true;
            lblStaffFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStaffFormTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblStaffFormTitle.Location = new Point(724, 106);
            lblStaffFormTitle.Name = "lblStaffFormTitle";
            lblStaffFormTitle.Size = new Size(178, 32);
            lblStaffFormTitle.TabIndex = 0;
            lblStaffFormTitle.Text = "Add New Staff";
            // 
            // StaffControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlStaff);
            Name = "StaffControl";
            Size = new Size(1670, 1000);
            ((System.ComponentModel.ISupportInitialize)tabControlStaff).EndInit();
            tabControlStaff.ResumeLayout(false);
            tabPageStaffList.ResumeLayout(false);
            panelStaffActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDataGridStaff).EndInit();
            tabPageStaffAdd.ResumeLayout(false);
            panelStaffForm.ResumeLayout(false);
            panelStaffForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbBranch).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkUserActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUsername).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserLastName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserFirstName).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlStaff;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageStaffList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageStaffAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridStaff;
        private System.Windows.Forms.Panel panelStaffActions;
        private Syncfusion.Windows.Forms.ButtonAdv btnEditStaff;
        private Syncfusion.Windows.Forms.ButtonAdv btnDeleteStaff;
        private Syncfusion.Windows.Forms.ButtonAdv btnToggleStatus;
        private Syncfusion.Windows.Forms.ButtonAdv btnRefreshStaff;
        private System.Windows.Forms.Panel panelStaffForm;
        private System.Windows.Forms.Label lblStaffFormTitle;
        private System.Windows.Forms.Label lblUserFirstName;
        private System.Windows.Forms.Label lblUserLastName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Label lblUserEmail;
        private System.Windows.Forms.Label lblUserPhone;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblBranch;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtUserFirstName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtUserLastName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtUsername;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtUserPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtUserEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtUserPhone;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkUserActive;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbRole;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbBranch;
        private Syncfusion.Windows.Forms.ButtonAdv btnSaveStaff;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancelStaff;
    }
}