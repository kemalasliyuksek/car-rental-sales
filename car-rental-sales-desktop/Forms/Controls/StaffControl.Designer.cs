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
            sfDataGridStaff = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageStaffAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panelStaffInfo = new Panel();
            labelStaffInfo = new Label();
            checkBoxActive = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            comboBoxBranch = new Syncfusion.WinForms.ListView.SfComboBox();
            comboBoxRole = new Syncfusion.WinForms.ListView.SfComboBox();
            textBoxPhone = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            textBoxEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            textBoxPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            textBoxUsername = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            textBoxLastName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            textBoxFirstName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            labelActive = new Label();
            labelBranch = new Label();
            labelRole = new Label();
            labelPhone = new Label();
            labelEmail = new Label();
            labelPassword = new Label();
            labelUsername = new Label();
            labelLastName = new Label();
            labelFirstName = new Label();
            panelButtons = new Panel();
            buttonClear = new Syncfusion.WinForms.Controls.SfButton();
            buttonSave = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)tabControlStaff).BeginInit();
            tabControlStaff.SuspendLayout();
            tabPageStaffList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridStaff).BeginInit();
            tabPageStaffAdd.SuspendLayout();
            panelStaffInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkBoxActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxBranch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxRole).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxUsername).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxLastName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxFirstName).BeginInit();
            panelButtons.SuspendLayout();
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
            tabPageStaffAdd.Controls.Add(panelStaffInfo);
            tabPageStaffAdd.Controls.Add(panelButtons);
            tabPageStaffAdd.Image = null;
            tabPageStaffAdd.ImageSize = new Size(16, 16);
            tabPageStaffAdd.Location = new Point(1, 33);
            tabPageStaffAdd.Name = "tabPageStaffAdd";
            tabPageStaffAdd.Padding = new Padding(20);
            tabPageStaffAdd.ShowCloseButton = true;
            tabPageStaffAdd.Size = new Size(1667, 965);
            tabPageStaffAdd.TabFont = new Font("Segoe UI", 12F);
            tabPageStaffAdd.TabIndex = 2;
            tabPageStaffAdd.Text = "Staff Add";
            tabPageStaffAdd.ThemesEnabled = false;
            // 
            // panelStaffInfo
            // 
            panelStaffInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelStaffInfo.BorderStyle = BorderStyle.FixedSingle;
            panelStaffInfo.Controls.Add(labelStaffInfo);
            panelStaffInfo.Controls.Add(checkBoxActive);
            panelStaffInfo.Controls.Add(comboBoxBranch);
            panelStaffInfo.Controls.Add(comboBoxRole);
            panelStaffInfo.Controls.Add(textBoxPhone);
            panelStaffInfo.Controls.Add(textBoxEmail);
            panelStaffInfo.Controls.Add(textBoxPassword);
            panelStaffInfo.Controls.Add(textBoxUsername);
            panelStaffInfo.Controls.Add(textBoxLastName);
            panelStaffInfo.Controls.Add(textBoxFirstName);
            panelStaffInfo.Controls.Add(labelActive);
            panelStaffInfo.Controls.Add(labelBranch);
            panelStaffInfo.Controls.Add(labelRole);
            panelStaffInfo.Controls.Add(labelPhone);
            panelStaffInfo.Controls.Add(labelEmail);
            panelStaffInfo.Controls.Add(labelPassword);
            panelStaffInfo.Controls.Add(labelUsername);
            panelStaffInfo.Controls.Add(labelLastName);
            panelStaffInfo.Controls.Add(labelFirstName);
            panelStaffInfo.Location = new Point(508, 152);
            panelStaffInfo.Name = "panelStaffInfo";
            panelStaffInfo.Size = new Size(650, 560);
            panelStaffInfo.TabIndex = 0;
            // 
            // labelStaffInfo
            // 
            labelStaffInfo.AutoSize = true;
            labelStaffInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelStaffInfo.ForeColor = Color.FromArgb(68, 68, 68);
            labelStaffInfo.Location = new Point(253, 13);
            labelStaffInfo.Name = "labelStaffInfo";
            labelStaffInfo.Size = new Size(142, 21);
            labelStaffInfo.TabIndex = 18;
            labelStaffInfo.Text = "Staff Information";
            // 
            // checkBoxActive
            // 
            checkBoxActive.AccessibilityEnabled = true;
            checkBoxActive.BeforeTouchSize = new Size(150, 35);
            checkBoxActive.BorderColor = Color.FromArgb(197, 197, 197);
            checkBoxActive.Checked = true;
            checkBoxActive.CheckState = CheckState.Checked;
            checkBoxActive.Font = new Font("Segoe UI", 11F);
            checkBoxActive.ForeColor = Color.FromArgb(68, 68, 68);
            checkBoxActive.HotBorderColor = Color.FromArgb(150, 150, 150);
            checkBoxActive.Location = new Point(250, 510);
            checkBoxActive.Name = "checkBoxActive";
            checkBoxActive.Size = new Size(150, 35);
            checkBoxActive.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro;
            checkBoxActive.TabIndex = 17;
            checkBoxActive.Text = "Active";
            checkBoxActive.ThemeName = "Metro";
            // 
            // comboBoxBranch
            // 
            comboBoxBranch.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            comboBoxBranch.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            comboBoxBranch.Font = new Font("Segoe UI", 11F);
            comboBoxBranch.Location = new Point(250, 450);
            comboBoxBranch.Name = "comboBoxBranch";
            comboBoxBranch.Size = new Size(350, 35);
            comboBoxBranch.Style.DropDownStyle.BorderColor = Color.FromArgb(100, 100, 100);
            comboBoxBranch.Style.EditorStyle.Font = new Font("Segoe UI", 11F);
            comboBoxBranch.Style.ReadOnlyEditorStyle.BorderColor = Color.FromArgb(100, 100, 100);
            comboBoxBranch.Style.ReadOnlyEditorStyle.Font = new Font("Segoe UI", 11F);
            comboBoxBranch.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            comboBoxBranch.Style.TokenStyle.Font = new Font("Segoe UI", 11F);
            comboBoxBranch.TabIndex = 16;
            comboBoxBranch.ThemeName = "Default";
            // 
            // comboBoxRole
            // 
            comboBoxRole.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            comboBoxRole.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            comboBoxRole.Font = new Font("Segoe UI", 11F);
            comboBoxRole.Location = new Point(250, 386);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(350, 35);
            comboBoxRole.Style.DropDownStyle.BorderColor = Color.FromArgb(100, 100, 100);
            comboBoxRole.Style.EditorStyle.Font = new Font("Segoe UI", 11F);
            comboBoxRole.Style.ReadOnlyEditorStyle.BorderColor = Color.FromArgb(100, 100, 100);
            comboBoxRole.Style.ReadOnlyEditorStyle.Font = new Font("Segoe UI", 11F);
            comboBoxRole.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            comboBoxRole.Style.TokenStyle.Font = new Font("Segoe UI", 11F);
            comboBoxRole.TabIndex = 15;
            comboBoxRole.ThemeName = "Default";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BeforeTouchSize = new Size(350, 27);
            textBoxPhone.BorderColor = Color.FromArgb(100, 100, 100);
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 11F);
            textBoxPhone.Location = new Point(250, 330);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(350, 27);
            textBoxPhone.TabIndex = 14;
            textBoxPhone.ThemeName = "Default";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BeforeTouchSize = new Size(350, 27);
            textBoxEmail.BorderColor = Color.FromArgb(100, 100, 100);
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 11F);
            textBoxEmail.Location = new Point(250, 274);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(350, 27);
            textBoxEmail.TabIndex = 13;
            textBoxEmail.ThemeName = "Default";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BeforeTouchSize = new Size(350, 27);
            textBoxPassword.BorderColor = Color.FromArgb(100, 100, 100);
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 11F);
            textBoxPassword.Location = new Point(250, 218);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(350, 27);
            textBoxPassword.TabIndex = 12;
            textBoxPassword.ThemeName = "Default";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BeforeTouchSize = new Size(350, 27);
            textBoxUsername.BorderColor = Color.FromArgb(100, 100, 100);
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Font = new Font("Segoe UI", 11F);
            textBoxUsername.Location = new Point(250, 162);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(350, 27);
            textBoxUsername.TabIndex = 11;
            textBoxUsername.ThemeName = "Default";
            // 
            // textBoxLastName
            // 
            textBoxLastName.BeforeTouchSize = new Size(350, 27);
            textBoxLastName.BorderColor = Color.FromArgb(100, 100, 100);
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 11F);
            textBoxLastName.Location = new Point(250, 106);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(350, 27);
            textBoxLastName.TabIndex = 10;
            textBoxLastName.ThemeName = "Default";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BeforeTouchSize = new Size(350, 27);
            textBoxFirstName.BorderColor = Color.FromArgb(100, 100, 100);
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 11F);
            textBoxFirstName.Location = new Point(250, 50);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(350, 27);
            textBoxFirstName.TabIndex = 9;
            textBoxFirstName.ThemeName = "Default";
            // 
            // labelActive
            // 
            labelActive.AutoSize = true;
            labelActive.Font = new Font("Segoe UI", 11F);
            labelActive.ForeColor = Color.FromArgb(68, 68, 68);
            labelActive.Location = new Point(31, 515);
            labelActive.Name = "labelActive";
            labelActive.Size = new Size(57, 20);
            labelActive.TabIndex = 8;
            labelActive.Text = "Active :";
            // 
            // labelBranch
            // 
            labelBranch.AutoSize = true;
            labelBranch.Font = new Font("Segoe UI", 11F);
            labelBranch.ForeColor = Color.FromArgb(68, 68, 68);
            labelBranch.Location = new Point(31, 465);
            labelBranch.Name = "labelBranch";
            labelBranch.Size = new Size(61, 20);
            labelBranch.TabIndex = 7;
            labelBranch.Text = "Branch :";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 11F);
            labelRole.ForeColor = Color.FromArgb(68, 68, 68);
            labelRole.Location = new Point(31, 401);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(46, 20);
            labelRole.TabIndex = 6;
            labelRole.Text = "Role :";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 11F);
            labelPhone.ForeColor = Color.FromArgb(68, 68, 68);
            labelPhone.Location = new Point(30, 337);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(57, 20);
            labelPhone.TabIndex = 5;
            labelPhone.Text = "Phone :";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 11F);
            labelEmail.ForeColor = Color.FromArgb(68, 68, 68);
            labelEmail.Location = new Point(30, 281);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(53, 20);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "Email :";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 11F);
            labelPassword.ForeColor = Color.FromArgb(68, 68, 68);
            labelPassword.Location = new Point(31, 225);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(77, 20);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Password :";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 11F);
            labelUsername.ForeColor = Color.FromArgb(68, 68, 68);
            labelUsername.Location = new Point(30, 169);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(82, 20);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Username :";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 11F);
            labelLastName.ForeColor = Color.FromArgb(68, 68, 68);
            labelLastName.Location = new Point(31, 113);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(86, 20);
            labelLastName.TabIndex = 1;
            labelLastName.Text = "Last Name :";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 11F);
            labelFirstName.ForeColor = Color.FromArgb(68, 68, 68);
            labelFirstName.Location = new Point(30, 57);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(87, 20);
            labelFirstName.TabIndex = 0;
            labelFirstName.Text = "First Name :";
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.Controls.Add(buttonClear);
            panelButtons.Controls.Add(buttonSave);
            panelButtons.Location = new Point(508, 732);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(650, 80);
            panelButtons.TabIndex = 1;
            // 
            // buttonClear
            // 
            buttonClear.AccessibleName = "Button";
            buttonClear.BackColor = Color.FromArgb(255, 128, 128);
            buttonClear.Font = new Font("Segoe UI", 12F);
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(330, 20);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(150, 40);
            buttonClear.Style.BackColor = Color.FromArgb(255, 128, 128);
            buttonClear.Style.FocusedBackColor = Color.FromArgb(255, 100, 100);
            buttonClear.Style.FocusedForeColor = Color.White;
            buttonClear.Style.ForeColor = Color.White;
            buttonClear.Style.HoverBackColor = Color.FromArgb(255, 100, 100);
            buttonClear.Style.HoverForeColor = Color.White;
            buttonClear.Style.PressedBackColor = Color.FromArgb(200, 80, 80);
            buttonClear.Style.PressedForeColor = Color.White;
            buttonClear.TabIndex = 1;
            buttonClear.Text = "Clear";
            buttonClear.ThemeName = "Default";
            buttonClear.UseVisualStyleBackColor = false;
            buttonClear.Click += ButtonClear_Click;
            // 
            // buttonSave
            // 
            buttonSave.AccessibleName = "Button";
            buttonSave.BackColor = Color.FromArgb(0, 120, 215);
            buttonSave.Font = new Font("Segoe UI", 12F);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(170, 20);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(150, 40);
            buttonSave.Style.BackColor = Color.FromArgb(0, 120, 215);
            buttonSave.Style.FocusedBackColor = Color.FromArgb(0, 100, 180);
            buttonSave.Style.FocusedForeColor = Color.White;
            buttonSave.Style.ForeColor = Color.White;
            buttonSave.Style.HoverBackColor = Color.FromArgb(0, 100, 180);
            buttonSave.Style.HoverForeColor = Color.White;
            buttonSave.Style.PressedBackColor = Color.FromArgb(0, 80, 140);
            buttonSave.Style.PressedForeColor = Color.White;
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save";
            buttonSave.ThemeName = "Default";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
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
            ((System.ComponentModel.ISupportInitialize)sfDataGridStaff).EndInit();
            tabPageStaffAdd.ResumeLayout(false);
            panelStaffInfo.ResumeLayout(false);
            panelStaffInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)checkBoxActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxBranch).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxRole).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxUsername).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxLastName).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxFirstName).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlStaff;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageStaffList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageStaffAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridStaff;
        private System.Windows.Forms.Panel panelStaffInfo;
        private System.Windows.Forms.Label labelStaffInfo;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelBranch;
        private System.Windows.Forms.Label labelActive;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxFirstName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxLastName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxUsername;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxPhone;
        private Syncfusion.WinForms.ListView.SfComboBox comboBoxRole;
        private Syncfusion.WinForms.ListView.SfComboBox comboBoxBranch;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv checkBoxActive;
        private System.Windows.Forms.Panel panelButtons;
        private Syncfusion.WinForms.Controls.SfButton buttonSave;
        private Syncfusion.WinForms.Controls.SfButton buttonClear;
    }
}