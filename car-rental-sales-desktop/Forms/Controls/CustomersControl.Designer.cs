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
            sfDataGridCustomers = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageCustomerAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ((System.ComponentModel.ISupportInitialize)tabControlCustomers).BeginInit();
            tabControlCustomers.SuspendLayout();
            tabPageCustomersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridCustomers).BeginInit();
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
            tabPageCustomerAdd.Image = null;
            tabPageCustomerAdd.ImageSize = new Size(16, 16);
            tabPageCustomerAdd.Location = new Point(1, 33);
            tabPageCustomerAdd.Name = "tabPageCustomerAdd";
            tabPageCustomerAdd.ShowCloseButton = true;
            tabPageCustomerAdd.Size = new Size(1667, 965);
            tabPageCustomerAdd.TabFont = new Font("Segoe UI", 12F);
            tabPageCustomerAdd.TabIndex = 2;
            tabPageCustomerAdd.Text = "Customer Add";
            tabPageCustomerAdd.ThemesEnabled = false;
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
            ((System.ComponentModel.ISupportInitialize)sfDataGridCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlCustomers;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageCustomersList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageCustomerAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridCustomers;
    }
}
