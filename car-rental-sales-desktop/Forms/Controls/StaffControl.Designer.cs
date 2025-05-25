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
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn1 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridCheckBoxColumn gridCheckBoxColumn1 = new Syncfusion.WinForms.DataGrid.GridCheckBoxColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn2 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn3 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            this.tabControlStaff = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageStaffList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.panelStaffActions = new System.Windows.Forms.Panel();
            this.btnEditStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnDeleteStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnToggleStatus = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRefreshStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            this.sfDataGridStaff = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.tabPageStaffAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.panelStaffForm = new System.Windows.Forms.Panel();
            this.btnCancelStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSaveStaff = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cmbBranch = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbRole = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkUserActive = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.txtUserPhone = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtUserEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtUserPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtUsername = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtUserLastName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtUserFirstName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUserPhone = new System.Windows.Forms.Label();
            this.lblUserEmail = new System.Windows.Forms.Label();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUserLastName = new System.Windows.Forms.Label();
            this.lblUserFirstName = new System.Windows.Forms.Label();
            this.lblStaffFormTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaff)).BeginInit();
            this.tabControlStaff.SuspendLayout();
            this.tabPageStaffList.SuspendLayout();
            this.panelStaffActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridStaff)).BeginInit();
            this.tabPageStaffAdd.SuspendLayout();
            this.panelStaffForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserFirstName)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlStaff
            // 
            this.tabControlStaff.BeforeTouchSize = new System.Drawing.Size(1670, 1000);
            this.tabControlStaff.Controls.Add(this.tabPageStaffList);
            this.tabControlStaff.Controls.Add(this.tabPageStaffAdd);
            this.tabControlStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlStaff.Location = new System.Drawing.Point(0, 0);
            this.tabControlStaff.Name = "tabControlStaff";
            this.tabControlStaff.Size = new System.Drawing.Size(1670, 1000);
            this.tabControlStaff.TabIndex = 0;
            // 
            // tabPageStaffList
            // 
            this.tabPageStaffList.Controls.Add(this.panelStaffActions);
            this.tabPageStaffList.Controls.Add(this.sfDataGridStaff);
            this.tabPageStaffList.Image = null;
            this.tabPageStaffList.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageStaffList.Location = new System.Drawing.Point(1, 33);
            this.tabPageStaffList.Name = "tabPageStaffList";
            this.tabPageStaffList.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageStaffList.ShowCloseButton = true;
            this.tabPageStaffList.Size = new System.Drawing.Size(1667, 965);
            this.tabPageStaffList.TabFont = new System.Drawing.Font("Segoe UI", 12F);
            this.tabPageStaffList.TabIndex = 1;
            this.tabPageStaffList.Text = "Staff List";
            this.tabPageStaffList.ThemesEnabled = false;
            // 
            // panelStaffActions
            // 
            this.panelStaffActions.Controls.Add(this.btnEditStaff);
            this.panelStaffActions.Controls.Add(this.btnDeleteStaff);
            this.panelStaffActions.Controls.Add(this.btnToggleStatus);
            this.panelStaffActions.Controls.Add(this.btnRefreshStaff);
            this.panelStaffActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStaffActions.Location = new System.Drawing.Point(20, 20);
            this.panelStaffActions.Name = "panelStaffActions";
            this.panelStaffActions.Size = new System.Drawing.Size(1627, 60);
            this.panelStaffActions.TabIndex = 1;
            // 
            // btnEditStaff
            // 
            this.btnEditStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnEditStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEditStaff.BeforeTouchSize = new System.Drawing.Size(120, 35);
            this.btnEditStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnEditStaff.ForeColor = System.Drawing.Color.White;
            this.btnEditStaff.Location = new System.Drawing.Point(10, 15);
            this.btnEditStaff.Name = "btnEditStaff";
            this.btnEditStaff.Size = new System.Drawing.Size(120, 35);
            this.btnEditStaff.TabIndex = 0;
            this.btnEditStaff.Text = "Edit Staff";
            this.btnEditStaff.UseVisualStyleBackColor = false;
            this.btnEditStaff.Click += new System.EventHandler(this.BtnEditStaff_Click);
            // 
            // btnDeleteStaff
            // 
            this.btnDeleteStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnDeleteStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnDeleteStaff.BeforeTouchSize = new System.Drawing.Size(120, 35);
            this.btnDeleteStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnDeleteStaff.ForeColor = System.Drawing.Color.White;
            this.btnDeleteStaff.Location = new System.Drawing.Point(140, 15);
            this.btnDeleteStaff.Name = "btnDeleteStaff";
            this.btnDeleteStaff.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteStaff.TabIndex = 1;
            this.btnDeleteStaff.Text = "Delete Staff";
            this.btnDeleteStaff.UseVisualStyleBackColor = false;
            this.btnDeleteStaff.Click += new System.EventHandler(this.BtnDeleteStaff_Click);
            // 
            // btnToggleStatus
            // 
            this.btnToggleStatus.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnToggleStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnToggleStatus.BeforeTouchSize = new System.Drawing.Size(140, 35);
            this.btnToggleStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnToggleStatus.ForeColor = System.Drawing.Color.White;
            this.btnToggleStatus.Location = new System.Drawing.Point(270, 15);
            this.btnToggleStatus.Name = "btnToggleStatus";
            this.btnToggleStatus.Size = new System.Drawing.Size(140, 35);
            this.btnToggleStatus.TabIndex = 2;
            this.btnToggleStatus.Text = "Toggle Status";
            this.btnToggleStatus.UseVisualStyleBackColor = false;
            this.btnToggleStatus.Click += new System.EventHandler(this.BtnToggleStatus_Click);
            // 
            // btnRefreshStaff
            // 
            this.btnRefreshStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnRefreshStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnRefreshStaff.BeforeTouchSize = new System.Drawing.Size(120, 35);
            this.btnRefreshStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnRefreshStaff.ForeColor = System.Drawing.Color.White;
            this.btnRefreshStaff.Location = new System.Drawing.Point(420, 15);
            this.btnRefreshStaff.Name = "btnRefreshStaff";
            this.btnRefreshStaff.Size = new System.Drawing.Size(120, 35);
            this.btnRefreshStaff.TabIndex = 3;
            this.btnRefreshStaff.Text = "Refresh";
            this.btnRefreshStaff.UseVisualStyleBackColor = false;
            this.btnRefreshStaff.Click += new System.EventHandler(this.BtnRefreshStaff_Click);
            // 
            // sfDataGridStaff
            // 
            this.sfDataGridStaff.AccessibleName = "Table";
            this.sfDataGridStaff.AllowEditing = false;
            this.sfDataGridStaff.AutoGenerateColumns = false;
            gridNumericColumn1.AllowEditing = false;
            gridNumericColumn1.AllowResizing = true;
            gridNumericColumn1.CellStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            gridNumericColumn1.Format = "0";
            gridNumericColumn1.HeaderText = "ID";
            gridNumericColumn1.MappingName = "UserID";
            gridNumericColumn1.Width = 50D;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.HeaderText = "First Name";
            gridTextColumn1.MappingName = "UserFirstName";
            gridTextColumn1.Width = 110D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Last Name";
            gridTextColumn2.MappingName = "UserLastName";
            gridTextColumn2.Width = 110D;
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.HeaderText = "Username";
            gridTextColumn3.MappingName = "Username";
            gridTextColumn3.Width = 120D;
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowResizing = true;
            gridTextColumn4.HeaderText = "Email";
            gridTextColumn4.MappingName = "UserEmail";
            gridTextColumn4.Width = 231D;
            gridTextColumn5.AllowEditing = false;
            gridTextColumn5.AllowResizing = true;
            gridTextColumn5.CellStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            gridTextColumn5.HeaderText = "Phone No";
            gridTextColumn5.MappingName = "UserPhone";
            gridTextColumn5.Width = 130D;
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.AllowResizing = true;
            gridTextColumn6.HeaderText = "Role";
            gridTextColumn6.MappingName = "Role.RoleName";
            gridTextColumn6.Width = 150D;
            gridTextColumn7.AllowEditing = false;
            gridTextColumn7.AllowResizing = true;
            gridTextColumn7.HeaderText = "Branch Name";
            gridTextColumn7.MappingName = "Branch.BranchName";
            gridTextColumn7.Width = 160D;
            gridDateTimeColumn1.AllowEditing = false;
            gridDateTimeColumn1.AllowResizing = true;
            gridDateTimeColumn1.CellStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            gridDateTimeColumn1.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn1.HeaderText = "Last Login";
            gridDateTimeColumn1.MappingName = "UserLastLogin";
            gridDateTimeColumn1.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn1.Width = 160D;
            gridCheckBoxColumn1.AllowEditing = false;
            gridCheckBoxColumn1.AllowResizing = true;
            gridCheckBoxColumn1.CellStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            gridCheckBoxColumn1.HeaderText = "Active";
            gridCheckBoxColumn1.MappingName = "UserActive";
            gridCheckBoxColumn1.Width = 70D;
            gridDateTimeColumn2.AllowEditing = false;
            gridDateTimeColumn2.AllowResizing = true;
            gridDateTimeColumn2.CellStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            gridDateTimeColumn2.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn2.HeaderText = "Created At";
            gridDateTimeColumn2.MappingName = "UserCreatedAt";
            gridDateTimeColumn2.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn2.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn2.Width = 160D;
            gridDateTimeColumn3.AllowEditing = false;
            gridDateTimeColumn3.AllowResizing = true;
            gridDateTimeColumn3.CellStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            gridDateTimeColumn3.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn3.HeaderText = "Updated At";
            gridDateTimeColumn3.MappingName = "UserUpdatedAt";
            gridDateTimeColumn3.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn3.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn3.Width = 160D;
            this.sfDataGridStaff.Columns.Add(gridNumericColumn1);
            this.sfDataGridStaff.Columns.Add(gridTextColumn1);
            this.sfDataGridStaff.Columns.Add(gridTextColumn2);
            this.sfDataGridStaff.Columns.Add(gridTextColumn3);
            this.sfDataGridStaff.Columns.Add(gridTextColumn4);
            this.sfDataGridStaff.Columns.Add(gridTextColumn5);
            this.sfDataGridStaff.Columns.Add(gridTextColumn6);
            this.sfDataGridStaff.Columns.Add(gridTextColumn7);
            this.sfDataGridStaff.Columns.Add(gridDateTimeColumn1);
            this.sfDataGridStaff.Columns.Add(gridCheckBoxColumn1);
            this.sfDataGridStaff.Columns.Add(gridDateTimeColumn2);
            this.sfDataGridStaff.Columns.Add(gridDateTimeColumn3);
            this.sfDataGridStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfDataGridStaff.Location = new System.Drawing.Point(20, 80);
            this.sfDataGridStaff.Name = "sfDataGridStaff";
            this.sfDataGridStaff.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            this.sfDataGridStaff.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            this.sfDataGridStaff.Size = new System.Drawing.Size(1627, 865);
            this.sfDataGridStaff.Style.AddNewRowStyle.BackColor = System.Drawing.Color.Transparent;
            this.sfDataGridStaff.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfDataGridStaff.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGridStaff.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGridStaff.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGridStaff.Style.CurrentCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.sfDataGridStaff.Style.CurrentCellStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.sfDataGridStaff.Style.CurrentCellStyle.BorderThickness = Syncfusion.WinForms.DataGrid.Styles.GridBorderWeight.ExtraThin;
            this.sfDataGridStaff.Style.CurrentCellStyle.TextColor = System.Drawing.Color.Black;
            this.sfDataGridStaff.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGridStaff.Style.SelectionStyle.TextColor = System.Drawing.Color.Black;
            this.sfDataGridStaff.TabIndex = 0;
            this.sfDataGridStaff.QueryRowStyle += new Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventHandler(this.SfDataGridStaff_QueryRowStyle);
            // 
            // tabPageStaffAdd
            // 
            this.tabPageStaffAdd.Controls.Add(this.panelStaffForm);
            this.tabPageStaffAdd.Image = null;
            this.tabPageStaffAdd.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageStaffAdd.Location = new System.Drawing.Point(1, 33);
            this.tabPageStaffAdd.Name = "tabPageStaffAdd";
            this.tabPageStaffAdd.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageStaffAdd.ShowCloseButton = true;
            this.tabPageStaffAdd.Size = new System.Drawing.Size(1667, 965);
            this.tabPageStaffAdd.TabFont = new System.Drawing.Font("Segoe UI", 12F);
            this.tabPageStaffAdd.TabIndex = 2;
            this.tabPageStaffAdd.Text = "Staff Add/Edit";
            this.tabPageStaffAdd.ThemesEnabled = false;
            // 
            // panelStaffForm
            // 
            this.panelStaffForm.AutoScroll = true;
            this.panelStaffForm.Controls.Add(this.btnCancelStaff);
            this.panelStaffForm.Controls.Add(this.btnSaveStaff);
            this.panelStaffForm.Controls.Add(this.cmbBranch);
            this.panelStaffForm.Controls.Add(this.cmbRole);
            this.panelStaffForm.Controls.Add(this.chkUserActive);
            this.panelStaffForm.Controls.Add(this.txtUserPhone);
            this.panelStaffForm.Controls.Add(this.txtUserEmail);
            this.panelStaffForm.Controls.Add(this.txtUserPassword);
            this.panelStaffForm.Controls.Add(this.txtUsername);
            this.panelStaffForm.Controls.Add(this.txtUserLastName);
            this.panelStaffForm.Controls.Add(this.txtUserFirstName);
            this.panelStaffForm.Controls.Add(this.lblBranch);
            this.panelStaffForm.Controls.Add(this.lblRole);
            this.panelStaffForm.Controls.Add(this.lblUserPhone);
            this.panelStaffForm.Controls.Add(this.lblUserEmail);
            this.panelStaffForm.Controls.Add(this.lblUserPassword);
            this.panelStaffForm.Controls.Add(this.lblUsername);
            this.panelStaffForm.Controls.Add(this.lblUserLastName);
            this.panelStaffForm.Controls.Add(this.lblUserFirstName);
            this.panelStaffForm.Controls.Add(this.lblStaffFormTitle);
            this.panelStaffForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStaffForm.Location = new System.Drawing.Point(20, 20);
            this.panelStaffForm.Name = "panelStaffForm";
            this.panelStaffForm.Size = new System.Drawing.Size(1627, 925);
            this.panelStaffForm.TabIndex = 0;
            // 
            // btnCancelStaff
            // 
            this.btnCancelStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancelStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelStaff.BeforeTouchSize = new System.Drawing.Size(150, 45);
            this.btnCancelStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnCancelStaff.ForeColor = System.Drawing.Color.White;
            this.btnCancelStaff.Location = new System.Drawing.Point(380, 600);
            this.btnCancelStaff.Name = "btnCancelStaff";
            this.btnCancelStaff.Size = new System.Drawing.Size(150, 45);
            this.btnCancelStaff.TabIndex = 19;
            this.btnCancelStaff.Text = "Cancel";
            this.btnCancelStaff.UseVisualStyleBackColor = false;
            this.btnCancelStaff.Click += new System.EventHandler(this.BtnCancelStaff_Click);
            // 
            // btnSaveStaff
            // 
            this.btnSaveStaff.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnSaveStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSaveStaff.BeforeTouchSize = new System.Drawing.Size(150, 45);
            this.btnSaveStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnSaveStaff.ForeColor = System.Drawing.Color.White;
            this.btnSaveStaff.Location = new System.Drawing.Point(220, 600);
            this.btnSaveStaff.Name = "btnSaveStaff";
            this.btnSaveStaff.Size = new System.Drawing.Size(150, 45);
            this.btnSaveStaff.TabIndex = 18;
            this.btnSaveStaff.Text = "Save Staff";
            this.btnSaveStaff.UseVisualStyleBackColor = false;
            this.btnSaveStaff.Click += new System.EventHandler(this.BtnSaveStaff_Click);
            // 
            // cmbBranch
            // 
            this.cmbBranch.BeforeTouchSize = new System.Drawing.Size(310, 35);
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbBranch.Location = new System.Drawing.Point(220, 520);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(310, 35);
            this.cmbBranch.TabIndex = 17;
            // 
            // cmbRole
            // 
            this.cmbRole.BeforeTouchSize = new System.Drawing.Size(310, 35);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbRole.Location = new System.Drawing.Point(220, 470);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(310, 35);
            this.cmbRole.TabIndex = 16;
            // 
            // chkUserActive
            // 
            this.chkUserActive.BeforeTouchSize = new System.Drawing.Size(156, 21);
            this.chkUserActive.Checked = true;
            this.chkUserActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserActive.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.chkUserActive.Location = new System.Drawing.Point(50, 570);
            this.chkUserActive.Name = "chkUserActive";
            this.chkUserActive.Size = new System.Drawing.Size(156, 21);
            this.chkUserActive.TabIndex = 15;
            this.chkUserActive.Text = "User is Active";
            this.chkUserActive.ThemesEnabled = false;
            // 
            // txtUserPhone
            // 
            this.txtUserPhone.BeforeTouchSize = new System.Drawing.Size(310, 35);
            this.txtUserPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserPhone.Location = new System.Drawing.Point(220, 420);
            this.txtUserPhone.Name = "txtUserPhone";
            this.txtUserPhone.Size = new System.Drawing.Size(310, 35);
            this.txtUserPhone.TabIndex = 14;
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.BeforeTouchSize = new System.Drawing.Size(310, 35);
            this.txtUserEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserEmail.Location = new System.Drawing.Point(220, 370);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(310, 35);
            this.txtUserEmail.TabIndex = 13;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BeforeTouchSize = new System.Drawing.Size(310, 35);
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserPassword.Location = new System.Drawing.Point(220, 320);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(310, 35);
            this.txtUserPassword.TabIndex = 12;
            // 
            // txtUsername
            // 
            this.txtUsername.BeforeTouchSize = new System.Drawing.Size(310, 35);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(220, 270);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(310, 35);
            this.txtUsername.TabIndex = 11;
            // 
            // txtUserLastName
            // 
            this.txtUserLastName.BeforeTouchSize = new System.Drawing.Size(310, 35);
            this.txtUserLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserLastName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserLastName.Location = new System.Drawing.Point(220, 220);
            this.txtUserLastName.Name = "txtUserLastName";
            this.txtUserLastName.Size = new System.Drawing.Size(310, 35);
            this.txtUserLastName.TabIndex = 10;
            // 
            // txtUserFirstName
            // 
            this.txtUserFirstName.BeforeTouchSize = new System.Drawing.Size(310, 35);
            this.txtUserFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserFirstName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserFirstName.Location = new System.Drawing.Point(220, 170);
            this.txtUserFirstName.Name = "txtUserFirstName";
            this.txtUserFirstName.Size = new System.Drawing.Size(310, 35);
            this.txtUserFirstName.TabIndex = 9;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblBranch.Location = new System.Drawing.Point(50, 530);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(58, 20);
            this.lblBranch.TabIndex = 8;
            this.lblBranch.Text = "Branch:";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblRole.Location = new System.Drawing.Point(50, 480);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(41, 20);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "Role:";
            // 
            // lblUserPhone
            // 
            this.lblUserPhone.AutoSize = true;
            this.lblUserPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblUserPhone.Location = new System.Drawing.Point(50, 430);
            this.lblUserPhone.Name = "lblUserPhone";
            this.lblUserPhone.Size = new System.Drawing.Size(54, 20);
            this.lblUserPhone.TabIndex = 6;
            this.lblUserPhone.Text = "Phone:";
            // 
            // lblUserEmail
            // 
            this.lblUserEmail.AutoSize = true;
            this.lblUserEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblUserEmail.Location = new System.Drawing.Point(50, 380);
            this.lblUserEmail.Name = "lblUserEmail";
            this.lblUserEmail.Size = new System.Drawing.Size(49, 20);
            this.lblUserEmail.TabIndex = 5;
            this.lblUserEmail.Text = "Email:";
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblUserPassword.Location = new System.Drawing.Point(50, 330);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(73, 20);
            this.lblUserPassword.TabIndex = 4;
            this.lblUserPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblUsername.Location = new System.Drawing.Point(50, 280);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 20);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            // 
            // lblUserLastName
            // 
            this.lblUserLastName.AutoSize = true;
            this.lblUserLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblUserLastName.Location = new System.Drawing.Point(50, 230);
            this.lblUserLastName.Name = "lblUserLastName";
            this.lblUserLastName.Size = new System.Drawing.Size(84, 20);
            this.lblUserLastName.TabIndex = 2;
            this.lblUserLastName.Text = "Last Name:";
            // 
            // lblUserFirstName
            // 
            this.lblUserFirstName.AutoSize = true;
            this.lblUserFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblUserFirstName.Location = new System.Drawing.Point(50, 180);
            this.lblUserFirstName.Name = "lblUserFirstName";
            this.lblUserFirstName.Size = new System.Drawing.Size(86, 20);
            this.lblUserFirstName.TabIndex = 1;
            this.lblUserFirstName.Text = "First Name:";
            // 
            // lblStaffFormTitle
            // 
            this.lblStaffFormTitle.AutoSize = true;
            this.lblStaffFormTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStaffFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblStaffFormTitle.Location = new System.Drawing.Point(50, 50);
            this.lblStaffFormTitle.Name = "lblStaffFormTitle";
            this.lblStaffFormTitle.Size = new System.Drawing.Size(158, 32);
            this.lblStaffFormTitle.TabIndex = 0;
            this.lblStaffFormTitle.Text = "Add New Staff";
            // 
            // StaffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlStaff);
            this.Name = "StaffControl";
            this.Size = new System.Drawing.Size(1670, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaff)).EndInit();
            this.tabControlStaff.ResumeLayout(false);
            this.tabPageStaffList.ResumeLayout(false);
            this.panelStaffActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridStaff)).EndInit();
            this.tabPageStaffAdd.ResumeLayout(false);
            this.panelStaffForm.ResumeLayout(false);
            this.panelStaffForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserFirstName)).EndInit();
            this.ResumeLayout(false);
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