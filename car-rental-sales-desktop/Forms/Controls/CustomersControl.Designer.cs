namespace car_rental_sales_desktop.Forms.Controls
{
    partial class CustomersControl
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
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn1 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn2 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn3 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridCheckBoxColumn gridCheckBoxColumn1 = new Syncfusion.WinForms.DataGrid.GridCheckBoxColumn();
            Syncfusion.WinForms.DataGrid.GridComboBoxColumn gridComboBoxColumn1 = new Syncfusion.WinForms.DataGrid.GridComboBoxColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn4 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            tabControlCustomers = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageCustomersList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panelCustomerActions = new Panel();
            btnEditCustomer = new Syncfusion.Windows.Forms.ButtonAdv();
            btnDeleteCustomer = new Syncfusion.Windows.Forms.ButtonAdv();
            btnToggleCustomerStatus = new Syncfusion.Windows.Forms.ButtonAdv();
            btnRefreshCustomers = new Syncfusion.Windows.Forms.ButtonAdv();
            sfDataGridCustomers = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageCustomerAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panelCustomerForm = new Panel();
            btnCancelCustomer = new Syncfusion.Windows.Forms.ButtonAdv();
            btnSaveCustomer = new Syncfusion.Windows.Forms.ButtonAdv();
            cmbCustomerType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            dtpLicenseDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            dtpDateOfBirth = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            chkCustomerAvailable = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtCustomerAddress = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCustomerEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCustomerPhone = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCustomerLicenseClass = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCustomerLicenseNumber = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCustomerNationalID = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCustomerLastName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCustomerFirstName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblCustomerType = new Label();
            lblCustomerAddress = new Label();
            lblCustomerEmail = new Label();
            lblCustomerPhone = new Label();
            lblCustomerLicenseDate = new Label();
            lblCustomerLicenseClass = new Label();
            lblCustomerLicenseNumber = new Label();
            lblCustomerDateOfBirth = new Label();
            lblCustomerNationalID = new Label();
            lblCustomerLastName = new Label();
            lblCustomerFirstName = new Label();
            lblCustomerFormTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)tabControlCustomers).BeginInit();
            tabControlCustomers.SuspendLayout();
            tabPageCustomersList.SuspendLayout();
            panelCustomerActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridCustomers).BeginInit();
            tabPageCustomerAdd.SuspendLayout();
            panelCustomerForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbCustomerType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpLicenseDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpLicenseDate.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpDateOfBirth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpDateOfBirth.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkCustomerAvailable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerLicenseClass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerLicenseNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerNationalID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerLastName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerFirstName).BeginInit();
            SuspendLayout();
            // 
            // tabControlCustomers
            // 
            tabControlCustomers.BeforeTouchSize = new Size(1670, 1000);
            tabControlCustomers.Controls.Add(tabPageCustomersList);
            tabControlCustomers.Controls.Add(tabPageCustomerAdd);
            tabControlCustomers.Dock = DockStyle.Fill;
            tabControlCustomers.Location = new Point(0, 0);
            tabControlCustomers.Name = "tabControlCustomers";
            tabControlCustomers.Size = new Size(1670, 1000);
            tabControlCustomers.TabIndex = 0;
            // 
            // tabPageCustomersList
            // 
            tabPageCustomersList.Controls.Add(panelCustomerActions);
            tabPageCustomersList.Controls.Add(sfDataGridCustomers);
            tabPageCustomersList.Image = null;
            tabPageCustomersList.ImageSize = new Size(16, 16);
            tabPageCustomersList.Location = new Point(1, 33);
            tabPageCustomersList.Name = "tabPageCustomersList";
            tabPageCustomersList.Padding = new Padding(20);
            tabPageCustomersList.ShowCloseButton = true;
            tabPageCustomersList.Size = new Size(1667, 965);
            tabPageCustomersList.TabFont = new Font("Segoe UI", 12F);
            tabPageCustomersList.TabIndex = 1;
            tabPageCustomersList.Text = "Customers List";
            tabPageCustomersList.ThemesEnabled = false;
            // 
            // panelCustomerActions
            // 
            panelCustomerActions.Controls.Add(btnEditCustomer);
            panelCustomerActions.Controls.Add(btnDeleteCustomer);
            panelCustomerActions.Controls.Add(btnToggleCustomerStatus);
            panelCustomerActions.Controls.Add(btnRefreshCustomers);
            panelCustomerActions.Dock = DockStyle.Top;
            panelCustomerActions.Location = new Point(20, 20);
            panelCustomerActions.Name = "panelCustomerActions";
            panelCustomerActions.Size = new Size(1627, 60);
            panelCustomerActions.TabIndex = 1;
            // 
            // btnEditCustomer
            // 
            btnEditCustomer.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnEditCustomer.BackColor = Color.FromArgb(0, 120, 215);
            btnEditCustomer.BeforeTouchSize = new Size(140, 35);
            btnEditCustomer.FlatStyle = FlatStyle.Flat;
            btnEditCustomer.Font = new Font("Segoe UI Semibold", 10F);
            btnEditCustomer.ForeColor = Color.White;
            btnEditCustomer.Location = new Point(10, 15);
            btnEditCustomer.Name = "btnEditCustomer";
            btnEditCustomer.Size = new Size(140, 35);
            btnEditCustomer.TabIndex = 0;
            btnEditCustomer.Text = "Edit Customer";
            btnEditCustomer.ThemeName = "Metro";
            btnEditCustomer.UseVisualStyleBackColor = false;
            btnEditCustomer.Click += BtnEditCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnDeleteCustomer.BackColor = Color.FromArgb(215, 55, 55);
            btnDeleteCustomer.BeforeTouchSize = new Size(140, 35);
            btnDeleteCustomer.FlatStyle = FlatStyle.Flat;
            btnDeleteCustomer.Font = new Font("Segoe UI Semibold", 10F);
            btnDeleteCustomer.ForeColor = Color.White;
            btnDeleteCustomer.Location = new Point(160, 15);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(140, 35);
            btnDeleteCustomer.TabIndex = 1;
            btnDeleteCustomer.Text = "Delete Customer";
            btnDeleteCustomer.ThemeName = "Metro";
            btnDeleteCustomer.UseVisualStyleBackColor = false;
            btnDeleteCustomer.Click += BtnDeleteCustomer_Click;
            // 
            // btnToggleCustomerStatus
            // 
            btnToggleCustomerStatus.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnToggleCustomerStatus.BackColor = Color.FromArgb(255, 140, 0);
            btnToggleCustomerStatus.BeforeTouchSize = new Size(140, 35);
            btnToggleCustomerStatus.FlatStyle = FlatStyle.Flat;
            btnToggleCustomerStatus.Font = new Font("Segoe UI Semibold", 10F);
            btnToggleCustomerStatus.ForeColor = Color.White;
            btnToggleCustomerStatus.Location = new Point(310, 15);
            btnToggleCustomerStatus.Name = "btnToggleCustomerStatus";
            btnToggleCustomerStatus.Size = new Size(140, 35);
            btnToggleCustomerStatus.TabIndex = 2;
            btnToggleCustomerStatus.Text = "Toggle Status";
            btnToggleCustomerStatus.ThemeName = "Metro";
            btnToggleCustomerStatus.UseVisualStyleBackColor = false;
            btnToggleCustomerStatus.Click += BtnToggleCustomerStatus_Click;
            // 
            // btnRefreshCustomers
            // 
            btnRefreshCustomers.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnRefreshCustomers.BackColor = Color.FromArgb(34, 139, 34);
            btnRefreshCustomers.BeforeTouchSize = new Size(120, 35);
            btnRefreshCustomers.FlatStyle = FlatStyle.Flat;
            btnRefreshCustomers.Font = new Font("Segoe UI Semibold", 10F);
            btnRefreshCustomers.ForeColor = Color.White;
            btnRefreshCustomers.Location = new Point(460, 15);
            btnRefreshCustomers.Name = "btnRefreshCustomers";
            btnRefreshCustomers.Size = new Size(120, 35);
            btnRefreshCustomers.TabIndex = 3;
            btnRefreshCustomers.Text = "Refresh";
            btnRefreshCustomers.ThemeName = "Metro";
            btnRefreshCustomers.UseVisualStyleBackColor = false;
            btnRefreshCustomers.Click += BtnRefreshCustomers_Click;
            // 
            // sfDataGridCustomers
            // 
            sfDataGridCustomers.AccessibleName = "Table";
            sfDataGridCustomers.AllowEditing = false;
            sfDataGridCustomers.AutoGenerateColumns = false;
            gridNumericColumn1.AllowEditing = false;
            gridNumericColumn1.AllowResizing = true;
            gridNumericColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn1.Format = "0";
            gridNumericColumn1.HeaderText = "ID";
            gridNumericColumn1.MappingName = "CustomerID";
            gridNumericColumn1.Width = 50D;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.HeaderText = "First Name";
            gridTextColumn1.MappingName = "CustomerFirstName";
            gridTextColumn1.Width = 100D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Last Name";
            gridTextColumn2.MappingName = "CustomerLastName";
            gridTextColumn2.Width = 100D;
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn3.Format = "0";
            gridTextColumn3.HeaderText = "National ID";
            gridTextColumn3.MappingName = "CustomerNationalID";
            gridTextColumn3.Width = 100D;
            gridDateTimeColumn1.AllowEditing = false;
            gridDateTimeColumn1.AllowResizing = true;
            gridDateTimeColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn1.Format = "dd.MM.yyyy";
            gridDateTimeColumn1.HeaderText = "Birth Date";
            gridDateTimeColumn1.MappingName = "CustomerDateOfBirth";
            gridDateTimeColumn1.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn1.Width = 80D;
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowResizing = true;
            gridTextColumn4.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn4.HeaderText = "License No";
            gridTextColumn4.MappingName = "CustomerLicenseNumber";
            gridTextColumn4.Width = 100D;
            gridTextColumn5.AllowEditing = false;
            gridTextColumn5.AllowResizing = true;
            gridTextColumn5.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn5.HeaderText = "License";
            gridTextColumn5.MappingName = "CustomerLicenseClass";
            gridTextColumn5.Width = 66D;
            gridDateTimeColumn2.AllowEditing = false;
            gridDateTimeColumn2.AllowResizing = true;
            gridDateTimeColumn2.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn2.Format = "dd.MM.yyyy";
            gridDateTimeColumn2.HeaderText = "License Date";
            gridDateTimeColumn2.MappingName = "CustomerLicenseDate";
            gridDateTimeColumn2.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn2.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn2.Width = 85D;
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.AllowResizing = true;
            gridTextColumn6.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn6.HeaderText = "Phone No";
            gridTextColumn6.MappingName = "CustomerPhone";
            gridTextColumn6.Width = 110D;
            gridTextColumn7.AllowEditing = false;
            gridTextColumn7.AllowResizing = true;
            gridTextColumn7.HeaderText = "Email";
            gridTextColumn7.MappingName = "CustomerEmail";
            gridTextColumn7.Width = 180D;
            gridTextColumn8.AllowEditing = false;
            gridTextColumn8.AllowResizing = true;
            gridTextColumn8.HeaderText = "Address";
            gridTextColumn8.MappingName = "CustomerAddress";
            gridTextColumn8.Width = 230D;
            gridDateTimeColumn3.AllowEditing = false;
            gridDateTimeColumn3.AllowResizing = true;
            gridDateTimeColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn3.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn3.HeaderText = "Reg Date";
            gridDateTimeColumn3.MappingName = "CustomerRegistrationDate";
            gridDateTimeColumn3.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn3.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn3.Width = 140D;
            gridCheckBoxColumn1.AllowEditing = false;
            gridCheckBoxColumn1.AllowResizing = true;
            gridCheckBoxColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridCheckBoxColumn1.HeaderText = "Active";
            gridCheckBoxColumn1.MappingName = "CustomerAvailable";
            gridCheckBoxColumn1.Width = 50D;
            gridComboBoxColumn1.AllowEditing = false;
            gridComboBoxColumn1.AllowResizing = true;
            gridComboBoxColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridComboBoxColumn1.DataSource = new string[]
    {
    "Individual",
    "Corporate"
    };
            gridComboBoxColumn1.HeaderText = "Type";
            gridComboBoxColumn1.MappingName = "CustomerType";
            gridComboBoxColumn1.Width = 80D;
            gridDateTimeColumn4.AllowEditing = false;
            gridDateTimeColumn4.AllowResizing = true;
            gridDateTimeColumn4.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn4.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn4.HeaderText = "Updated At";
            gridDateTimeColumn4.MappingName = "CustomerUpdatedAt";
            gridDateTimeColumn4.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn4.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn4.Width = 140D;
            sfDataGridCustomers.Columns.Add(gridNumericColumn1);
            sfDataGridCustomers.Columns.Add(gridTextColumn1);
            sfDataGridCustomers.Columns.Add(gridTextColumn2);
            sfDataGridCustomers.Columns.Add(gridTextColumn3);
            sfDataGridCustomers.Columns.Add(gridDateTimeColumn1);
            sfDataGridCustomers.Columns.Add(gridTextColumn4);
            sfDataGridCustomers.Columns.Add(gridTextColumn5);
            sfDataGridCustomers.Columns.Add(gridDateTimeColumn2);
            sfDataGridCustomers.Columns.Add(gridTextColumn6);
            sfDataGridCustomers.Columns.Add(gridTextColumn7);
            sfDataGridCustomers.Columns.Add(gridTextColumn8);
            sfDataGridCustomers.Columns.Add(gridDateTimeColumn3);
            sfDataGridCustomers.Columns.Add(gridCheckBoxColumn1);
            sfDataGridCustomers.Columns.Add(gridComboBoxColumn1);
            sfDataGridCustomers.Columns.Add(gridDateTimeColumn4);
            sfDataGridCustomers.Dock = DockStyle.Fill;
            sfDataGridCustomers.Location = new Point(20, 20);
            sfDataGridCustomers.Name = "sfDataGridCustomers";
            sfDataGridCustomers.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            sfDataGridCustomers.Size = new Size(1627, 925);
            sfDataGridCustomers.Style.AddNewRowStyle.BackColor = Color.Transparent;
            sfDataGridCustomers.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGridCustomers.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGridCustomers.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridCustomers.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridCustomers.Style.CurrentCellStyle.BackColor = Color.FromArgb(166, 216, 255);
            sfDataGridCustomers.Style.CurrentCellStyle.BorderColor = Color.FromArgb(166, 216, 255);
            sfDataGridCustomers.Style.CurrentCellStyle.BorderThickness = Syncfusion.WinForms.DataGrid.Styles.GridBorderWeight.ExtraThin;
            sfDataGridCustomers.Style.CurrentCellStyle.TextColor = Color.Black;
            sfDataGridCustomers.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGridCustomers.Style.SelectionStyle.TextColor = Color.Black;
            sfDataGridCustomers.TabIndex = 0;
            sfDataGridCustomers.QueryRowStyle += SfDataGridCustomers_QueryRowStyle;
            // 
            // tabPageCustomerAdd
            // 
            tabPageCustomerAdd.Controls.Add(panelCustomerForm);
            tabPageCustomerAdd.Image = null;
            tabPageCustomerAdd.ImageSize = new Size(16, 16);
            tabPageCustomerAdd.Location = new Point(1, 33);
            tabPageCustomerAdd.Name = "tabPageCustomerAdd";
            tabPageCustomerAdd.Padding = new Padding(20);
            tabPageCustomerAdd.ShowCloseButton = true;
            tabPageCustomerAdd.Size = new Size(1667, 965);
            tabPageCustomerAdd.TabFont = new Font("Segoe UI", 12F);
            tabPageCustomerAdd.TabIndex = 2;
            tabPageCustomerAdd.Text = "Customer Add/Edit";
            tabPageCustomerAdd.ThemesEnabled = false;
            // 
            // panelCustomerForm
            // 
            panelCustomerForm.AutoScroll = true;
            panelCustomerForm.Controls.Add(btnCancelCustomer);
            panelCustomerForm.Controls.Add(btnSaveCustomer);
            panelCustomerForm.Controls.Add(cmbCustomerType);
            panelCustomerForm.Controls.Add(dtpLicenseDate);
            panelCustomerForm.Controls.Add(dtpDateOfBirth);
            panelCustomerForm.Controls.Add(chkCustomerAvailable);
            panelCustomerForm.Controls.Add(txtCustomerAddress);
            panelCustomerForm.Controls.Add(txtCustomerEmail);
            panelCustomerForm.Controls.Add(txtCustomerPhone);
            panelCustomerForm.Controls.Add(txtCustomerLicenseClass);
            panelCustomerForm.Controls.Add(txtCustomerLicenseNumber);
            panelCustomerForm.Controls.Add(txtCustomerNationalID);
            panelCustomerForm.Controls.Add(txtCustomerLastName);
            panelCustomerForm.Controls.Add(txtCustomerFirstName);
            panelCustomerForm.Controls.Add(lblCustomerType);
            panelCustomerForm.Controls.Add(lblCustomerAddress);
            panelCustomerForm.Controls.Add(lblCustomerEmail);
            panelCustomerForm.Controls.Add(lblCustomerPhone);
            panelCustomerForm.Controls.Add(lblCustomerLicenseDate);
            panelCustomerForm.Controls.Add(lblCustomerLicenseClass);
            panelCustomerForm.Controls.Add(lblCustomerLicenseNumber);
            panelCustomerForm.Controls.Add(lblCustomerDateOfBirth);
            panelCustomerForm.Controls.Add(lblCustomerNationalID);
            panelCustomerForm.Controls.Add(lblCustomerLastName);
            panelCustomerForm.Controls.Add(lblCustomerFirstName);
            panelCustomerForm.Controls.Add(lblCustomerFormTitle);
            panelCustomerForm.Dock = DockStyle.Fill;
            panelCustomerForm.Location = new Point(20, 20);
            panelCustomerForm.Name = "panelCustomerForm";
            panelCustomerForm.Size = new Size(1627, 925);
            panelCustomerForm.TabIndex = 0;
            // 
            // btnCancelCustomer
            // 
            btnCancelCustomer.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnCancelCustomer.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelCustomer.BeforeTouchSize = new Size(150, 45);
            btnCancelCustomer.FlatStyle = FlatStyle.Flat;
            btnCancelCustomer.Font = new Font("Segoe UI Semibold", 12F);
            btnCancelCustomer.ForeColor = Color.White;
            btnCancelCustomer.Location = new Point(818, 767);
            btnCancelCustomer.Name = "btnCancelCustomer";
            btnCancelCustomer.Size = new Size(150, 45);
            btnCancelCustomer.TabIndex = 25;
            btnCancelCustomer.Text = "Cancel";
            btnCancelCustomer.ThemeName = "Metro";
            btnCancelCustomer.UseVisualStyleBackColor = false;
            btnCancelCustomer.Click += BtnCancelCustomer_Click;
            // 
            // btnSaveCustomer
            // 
            btnSaveCustomer.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnSaveCustomer.BackColor = Color.FromArgb(40, 167, 69);
            btnSaveCustomer.BeforeTouchSize = new Size(150, 45);
            btnSaveCustomer.FlatStyle = FlatStyle.Flat;
            btnSaveCustomer.Font = new Font("Segoe UI Semibold", 12F);
            btnSaveCustomer.ForeColor = Color.White;
            btnSaveCustomer.Location = new Point(658, 767);
            btnSaveCustomer.Name = "btnSaveCustomer";
            btnSaveCustomer.Size = new Size(150, 45);
            btnSaveCustomer.TabIndex = 24;
            btnSaveCustomer.Text = "Save Customer";
            btnSaveCustomer.ThemeName = "Metro";
            btnSaveCustomer.UseVisualStyleBackColor = false;
            btnSaveCustomer.Click += BtnSaveCustomer_Click;
            // 
            // cmbCustomerType
            // 
            cmbCustomerType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomerType.Font = new Font("Segoe UI", 11F);
            cmbCustomerType.Height = 28;
            cmbCustomerType.Items.AddRange(new object[] { "Individual", "Corporate" });
            cmbCustomerType.Location = new Point(711, 650);
            cmbCustomerType.Name = "cmbCustomerType";
            cmbCustomerType.Size = new Size(310, 28);
            cmbCustomerType.TabIndex = 23;
            cmbCustomerType.Text = "Individual";
            // 
            // dtpLicenseDate
            // 
            dtpLicenseDate.BorderColor = Color.Empty;
            // 
            // 
            // 
            dtpLicenseDate.Calendar.BottomHeight = 0;
            dtpLicenseDate.Calendar.Font = new Font("Segoe UI", 11F);
            dtpLicenseDate.Calendar.Location = new Point(0, 0);
            dtpLicenseDate.Calendar.Name = "monthCalendar";
            dtpLicenseDate.Calendar.TabIndex = 0;
            // 
            // 
            // 
            dtpLicenseDate.Calendar.NoneButton.Location = new Point(78, 0);
            // 
            // 
            // 
            dtpLicenseDate.Calendar.TodayButton.Location = new Point(0, 0);
            dtpLicenseDate.CalendarFont = new Font("Segoe UI", 9F);
            dtpLicenseDate.CalendarSize = new Size(189, 176);
            dtpLicenseDate.DropDownImage = null;
            dtpLicenseDate.Font = new Font("Segoe UI", 11F);
            dtpLicenseDate.Location = new Point(711, 439);
            dtpLicenseDate.MetroColor = Color.FromArgb(22, 165, 220);
            dtpLicenseDate.MinValue = new DateTime(0L);
            dtpLicenseDate.Name = "dtpLicenseDate";
            dtpLicenseDate.Size = new Size(310, 35);
            dtpLicenseDate.TabIndex = 22;
            dtpLicenseDate.Value = new DateTime(2025, 5, 25, 17, 27, 9, 321);
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.BorderColor = Color.Empty;
            // 
            // 
            // 
            dtpDateOfBirth.Calendar.BottomHeight = 0;
            dtpDateOfBirth.Calendar.Font = new Font("Segoe UI", 11F);
            dtpDateOfBirth.Calendar.Location = new Point(0, 0);
            dtpDateOfBirth.Calendar.Name = "monthCalendar";
            dtpDateOfBirth.Calendar.TabIndex = 0;
            // 
            // 
            // 
            dtpDateOfBirth.Calendar.NoneButton.Location = new Point(78, 0);
            // 
            // 
            // 
            dtpDateOfBirth.Calendar.TodayButton.Location = new Point(0, 0);
            dtpDateOfBirth.CalendarFont = new Font("Segoe UI", 9F);
            dtpDateOfBirth.CalendarSize = new Size(189, 176);
            dtpDateOfBirth.DropDownImage = null;
            dtpDateOfBirth.Font = new Font("Segoe UI", 11F);
            dtpDateOfBirth.Location = new Point(711, 289);
            dtpDateOfBirth.MetroColor = Color.FromArgb(22, 165, 220);
            dtpDateOfBirth.MinValue = new DateTime(0L);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(310, 35);
            dtpDateOfBirth.TabIndex = 21;
            dtpDateOfBirth.Value = new DateTime(2025, 5, 25, 17, 27, 9, 329);
            // 
            // chkCustomerAvailable
            // 
            chkCustomerAvailable.AccessibilityEnabled = true;
            chkCustomerAvailable.BeforeTouchSize = new Size(156, 21);
            chkCustomerAvailable.Checked = true;
            chkCustomerAvailable.CheckState = CheckState.Checked;
            chkCustomerAvailable.Font = new Font("Segoe UI Semibold", 11F);
            chkCustomerAvailable.Location = new Point(865, 704);
            chkCustomerAvailable.Name = "chkCustomerAvailable";
            chkCustomerAvailable.Size = new Size(156, 21);
            chkCustomerAvailable.TabIndex = 20;
            chkCustomerAvailable.Text = "Customer is Active";
            // 
            // txtCustomerAddress
            // 
            txtCustomerAddress.BeforeTouchSize = new Size(310, 27);
            txtCustomerAddress.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerAddress.Font = new Font("Segoe UI", 11F);
            txtCustomerAddress.Location = new Point(711, 600);
            txtCustomerAddress.Name = "txtCustomerAddress";
            txtCustomerAddress.Size = new Size(310, 27);
            txtCustomerAddress.TabIndex = 19;
            // 
            // txtCustomerEmail
            // 
            txtCustomerEmail.BeforeTouchSize = new Size(310, 27);
            txtCustomerEmail.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerEmail.Font = new Font("Segoe UI", 11F);
            txtCustomerEmail.Location = new Point(711, 550);
            txtCustomerEmail.Name = "txtCustomerEmail";
            txtCustomerEmail.Size = new Size(310, 27);
            txtCustomerEmail.TabIndex = 18;
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.BeforeTouchSize = new Size(310, 27);
            txtCustomerPhone.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerPhone.Font = new Font("Segoe UI", 11F);
            txtCustomerPhone.Location = new Point(711, 500);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(310, 27);
            txtCustomerPhone.TabIndex = 17;
            // 
            // txtCustomerLicenseClass
            // 
            txtCustomerLicenseClass.BeforeTouchSize = new Size(310, 27);
            txtCustomerLicenseClass.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerLicenseClass.Font = new Font("Segoe UI", 11F);
            txtCustomerLicenseClass.Location = new Point(711, 389);
            txtCustomerLicenseClass.Name = "txtCustomerLicenseClass";
            txtCustomerLicenseClass.Size = new Size(310, 27);
            txtCustomerLicenseClass.TabIndex = 16;
            // 
            // txtCustomerLicenseNumber
            // 
            txtCustomerLicenseNumber.BeforeTouchSize = new Size(310, 27);
            txtCustomerLicenseNumber.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerLicenseNumber.Font = new Font("Segoe UI", 11F);
            txtCustomerLicenseNumber.Location = new Point(711, 339);
            txtCustomerLicenseNumber.Name = "txtCustomerLicenseNumber";
            txtCustomerLicenseNumber.Size = new Size(310, 27);
            txtCustomerLicenseNumber.TabIndex = 15;
            // 
            // txtCustomerNationalID
            // 
            txtCustomerNationalID.BeforeTouchSize = new Size(310, 27);
            txtCustomerNationalID.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerNationalID.Font = new Font("Segoe UI", 11F);
            txtCustomerNationalID.Location = new Point(711, 239);
            txtCustomerNationalID.Name = "txtCustomerNationalID";
            txtCustomerNationalID.Size = new Size(310, 27);
            txtCustomerNationalID.TabIndex = 14;
            // 
            // txtCustomerLastName
            // 
            txtCustomerLastName.BeforeTouchSize = new Size(310, 27);
            txtCustomerLastName.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerLastName.Font = new Font("Segoe UI", 11F);
            txtCustomerLastName.Location = new Point(711, 189);
            txtCustomerLastName.Name = "txtCustomerLastName";
            txtCustomerLastName.Size = new Size(310, 27);
            txtCustomerLastName.TabIndex = 13;
            // 
            // txtCustomerFirstName
            // 
            txtCustomerFirstName.BeforeTouchSize = new Size(310, 27);
            txtCustomerFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerFirstName.Font = new Font("Segoe UI", 11F);
            txtCustomerFirstName.Location = new Point(711, 139);
            txtCustomerFirstName.Name = "txtCustomerFirstName";
            txtCustomerFirstName.Size = new Size(310, 27);
            txtCustomerFirstName.TabIndex = 12;
            // 
            // lblCustomerType
            // 
            lblCustomerType.AutoSize = true;
            lblCustomerType.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerType.Location = new Point(541, 658);
            lblCustomerType.Name = "lblCustomerType";
            lblCustomerType.Size = new Size(45, 20);
            lblCustomerType.TabIndex = 11;
            lblCustomerType.Text = "Type:";
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.AutoSize = true;
            lblCustomerAddress.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerAddress.Location = new Point(541, 607);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(67, 20);
            lblCustomerAddress.TabIndex = 10;
            lblCustomerAddress.Text = "Address:";
            // 
            // lblCustomerEmail
            // 
            lblCustomerEmail.AutoSize = true;
            lblCustomerEmail.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerEmail.Location = new Point(541, 557);
            lblCustomerEmail.Name = "lblCustomerEmail";
            lblCustomerEmail.Size = new Size(50, 20);
            lblCustomerEmail.TabIndex = 9;
            lblCustomerEmail.Text = "Email:";
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerPhone.Location = new Point(541, 507);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(57, 20);
            lblCustomerPhone.TabIndex = 8;
            lblCustomerPhone.Text = "Phone:";
            // 
            // lblCustomerLicenseDate
            // 
            lblCustomerLicenseDate.AutoSize = true;
            lblCustomerLicenseDate.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerLicenseDate.Location = new Point(541, 449);
            lblCustomerLicenseDate.Name = "lblCustomerLicenseDate";
            lblCustomerLicenseDate.Size = new Size(98, 20);
            lblCustomerLicenseDate.TabIndex = 7;
            lblCustomerLicenseDate.Text = "License Date:";
            // 
            // lblCustomerLicenseClass
            // 
            lblCustomerLicenseClass.AutoSize = true;
            lblCustomerLicenseClass.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerLicenseClass.Location = new Point(541, 399);
            lblCustomerLicenseClass.Name = "lblCustomerLicenseClass";
            lblCustomerLicenseClass.Size = new Size(99, 20);
            lblCustomerLicenseClass.TabIndex = 6;
            lblCustomerLicenseClass.Text = "License Class:";
            // 
            // lblCustomerLicenseNumber
            // 
            lblCustomerLicenseNumber.AutoSize = true;
            lblCustomerLicenseNumber.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerLicenseNumber.Location = new Point(541, 349);
            lblCustomerLicenseNumber.Name = "lblCustomerLicenseNumber";
            lblCustomerLicenseNumber.Size = new Size(124, 20);
            lblCustomerLicenseNumber.TabIndex = 5;
            lblCustomerLicenseNumber.Text = "License Number:";
            // 
            // lblCustomerDateOfBirth
            // 
            lblCustomerDateOfBirth.AutoSize = true;
            lblCustomerDateOfBirth.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerDateOfBirth.Location = new Point(541, 299);
            lblCustomerDateOfBirth.Name = "lblCustomerDateOfBirth";
            lblCustomerDateOfBirth.Size = new Size(100, 20);
            lblCustomerDateOfBirth.TabIndex = 4;
            lblCustomerDateOfBirth.Text = "Date of Birth:";
            // 
            // lblCustomerNationalID
            // 
            lblCustomerNationalID.AutoSize = true;
            lblCustomerNationalID.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerNationalID.Location = new Point(541, 249);
            lblCustomerNationalID.Name = "lblCustomerNationalID";
            lblCustomerNationalID.Size = new Size(91, 20);
            lblCustomerNationalID.TabIndex = 3;
            lblCustomerNationalID.Text = "National ID:";
            // 
            // lblCustomerLastName
            // 
            lblCustomerLastName.AutoSize = true;
            lblCustomerLastName.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerLastName.Location = new Point(541, 199);
            lblCustomerLastName.Name = "lblCustomerLastName";
            lblCustomerLastName.Size = new Size(84, 20);
            lblCustomerLastName.TabIndex = 2;
            lblCustomerLastName.Text = "Last Name:";
            // 
            // lblCustomerFirstName
            // 
            lblCustomerFirstName.AutoSize = true;
            lblCustomerFirstName.Font = new Font("Segoe UI Semibold", 11F);
            lblCustomerFirstName.Location = new Point(541, 149);
            lblCustomerFirstName.Name = "lblCustomerFirstName";
            lblCustomerFirstName.Size = new Size(87, 20);
            lblCustomerFirstName.TabIndex = 1;
            lblCustomerFirstName.Text = "First Name:";
            // 
            // lblCustomerFormTitle
            // 
            lblCustomerFormTitle.AutoSize = true;
            lblCustomerFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCustomerFormTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblCustomerFormTitle.Location = new Point(695, 41);
            lblCustomerFormTitle.Name = "lblCustomerFormTitle";
            lblCustomerFormTitle.Size = new Size(236, 32);
            lblCustomerFormTitle.TabIndex = 0;
            lblCustomerFormTitle.Text = "Add New Customer";
            // 
            // CustomersControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlCustomers);
            Name = "CustomersControl";
            Size = new Size(1670, 1000);
            ((System.ComponentModel.ISupportInitialize)tabControlCustomers).EndInit();
            tabControlCustomers.ResumeLayout(false);
            tabPageCustomersList.ResumeLayout(false);
            panelCustomerActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDataGridCustomers).EndInit();
            tabPageCustomerAdd.ResumeLayout(false);
            panelCustomerForm.ResumeLayout(false);
            panelCustomerForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbCustomerType).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpLicenseDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpLicenseDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpDateOfBirth.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpDateOfBirth).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkCustomerAvailable).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerLicenseClass).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerLicenseNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerNationalID).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerLastName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerFirstName).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlCustomers;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageCustomersList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageCustomerAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridCustomers;
        private System.Windows.Forms.Panel panelCustomerActions;
        private Syncfusion.Windows.Forms.ButtonAdv btnEditCustomer;
        private Syncfusion.Windows.Forms.ButtonAdv btnDeleteCustomer;
        private Syncfusion.Windows.Forms.ButtonAdv btnToggleCustomerStatus;
        private Syncfusion.Windows.Forms.ButtonAdv btnRefreshCustomers;
        private System.Windows.Forms.Panel panelCustomerForm;
        private System.Windows.Forms.Label lblCustomerFormTitle;
        private System.Windows.Forms.Label lblCustomerFirstName;
        private System.Windows.Forms.Label lblCustomerLastName;
        private System.Windows.Forms.Label lblCustomerNationalID;
        private System.Windows.Forms.Label lblCustomerDateOfBirth;
        private System.Windows.Forms.Label lblCustomerLicenseNumber;
        private System.Windows.Forms.Label lblCustomerLicenseClass;
        private System.Windows.Forms.Label lblCustomerLicenseDate;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.Label lblCustomerType;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCustomerFirstName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCustomerLastName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCustomerNationalID;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCustomerLicenseNumber;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCustomerLicenseClass;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCustomerPhone;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCustomerEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCustomerAddress;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkCustomerAvailable;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpDateOfBirth;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpLicenseDate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbCustomerType;
        private Syncfusion.Windows.Forms.ButtonAdv btnSaveCustomer;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancelCustomer;
    }
}