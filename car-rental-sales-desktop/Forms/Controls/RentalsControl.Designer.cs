namespace car_rental_sales_desktop.Forms.Controls
{
    partial class RentalsControl
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
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn2 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn2 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn3 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn3 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn4 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn5 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn6 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn4 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn5 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            tabControlRentals = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageRentalsList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            sfDataGridRentals = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageRentalAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)tabControlRentals).BeginInit();
            tabControlRentals.SuspendLayout();
            tabPageRentalsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridRentals).BeginInit();
            tabPageRentalAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            SuspendLayout();
            // 
            // tabControlRentals
            // 
            tabControlRentals.BeforeTouchSize = new Size(1670, 1000);
            tabControlRentals.Controls.Add(tabPageRentalsList);
            tabControlRentals.Controls.Add(tabPageRentalAdd);
            tabControlRentals.Dock = DockStyle.Fill;
            tabControlRentals.Location = new Point(0, 0);
            tabControlRentals.Name = "tabControlRentals";
            tabControlRentals.Size = new Size(1670, 1000);
            tabControlRentals.TabIndex = 0;
            // 
            // tabPageRentalsList
            // 
            tabPageRentalsList.Controls.Add(sfDataGridRentals);
            tabPageRentalsList.Image = null;
            tabPageRentalsList.ImageSize = new Size(16, 16);
            tabPageRentalsList.Location = new Point(1, 33);
            tabPageRentalsList.Name = "tabPageRentalsList";
            tabPageRentalsList.Padding = new Padding(20);
            tabPageRentalsList.ShowCloseButton = true;
            tabPageRentalsList.Size = new Size(1667, 965);
            tabPageRentalsList.TabFont = new Font("Segoe UI", 12F);
            tabPageRentalsList.TabIndex = 1;
            tabPageRentalsList.Text = "Rentals List";
            tabPageRentalsList.ThemesEnabled = false;
            // 
            // sfDataGridRentals
            // 
            sfDataGridRentals.AccessibleName = "Table";
            sfDataGridRentals.AllowEditing = false;
            sfDataGridRentals.AutoGenerateColumns = false;
            gridNumericColumn1.AllowEditing = false;
            gridNumericColumn1.AllowResizing = true;
            gridNumericColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn1.Format = "0";
            gridNumericColumn1.HeaderText = "ID";
            gridNumericColumn1.MappingName = "RentalID";
            gridNumericColumn1.Width = 50D;
            gridNumericColumn2.AllowEditing = false;
            gridNumericColumn2.AllowResizing = true;
            gridNumericColumn2.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn2.Format = "0";
            gridNumericColumn2.HeaderText = "C. ID";
            gridNumericColumn2.MappingName = "RentalCustomerID";
            gridNumericColumn2.Width = 50D;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.HeaderText = "Customer Name";
            gridTextColumn1.MappingName = "Customer.FullName";
            gridTextColumn1.Width = 140D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Vehicle Plate";
            gridTextColumn2.MappingName = "Vehicle.VehiclePlateNumber";
            gridTextColumn2.Width = 111D;
            gridDateTimeColumn1.AllowEditing = false;
            gridDateTimeColumn1.AllowResizing = true;
            gridDateTimeColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn1.Format = "dd.MM.yyyy";
            gridDateTimeColumn1.HeaderText = "Start Date";
            gridDateTimeColumn1.MappingName = "RentalStartDate";
            gridDateTimeColumn1.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn1.Width = 120D;
            gridDateTimeColumn2.AllowEditing = false;
            gridDateTimeColumn2.AllowResizing = true;
            gridDateTimeColumn2.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn2.Format = "dd.MM.yyyy";
            gridDateTimeColumn2.HeaderText = "End Date";
            gridDateTimeColumn2.MappingName = "RentalEndDate";
            gridDateTimeColumn2.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn2.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn2.Width = 120D;
            gridDateTimeColumn3.AllowEditing = false;
            gridDateTimeColumn3.AllowResizing = true;
            gridDateTimeColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn3.Format = "dd.MM.yyyy";
            gridDateTimeColumn3.HeaderText = "Return Date";
            gridDateTimeColumn3.MappingName = "RentalReturnDate";
            gridDateTimeColumn3.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn3.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn3.Width = 100D;
            gridNumericColumn3.AllowEditing = false;
            gridNumericColumn3.AllowResizing = true;
            gridNumericColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn3.Format = "0 KM";
            gridNumericColumn3.HeaderText = "Start KM";
            gridNumericColumn3.MappingName = "RentalStartKm";
            gridNumericColumn3.Width = 90D;
            gridNumericColumn4.AllowEditing = false;
            gridNumericColumn4.AllowResizing = true;
            gridNumericColumn4.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn4.Format = "0 KM";
            gridNumericColumn4.HeaderText = "End KM";
            gridNumericColumn4.MappingName = "RentalEndKm";
            gridNumericColumn4.Width = 90D;
            gridNumericColumn5.AllowEditing = false;
            gridNumericColumn5.AllowResizing = true;
            gridNumericColumn5.CellStyle.HorizontalAlignment = HorizontalAlignment.Left;
            gridNumericColumn5.Format = "#,##0.00 ₺";
            gridNumericColumn5.HeaderText = "Amount";
            gridNumericColumn5.MappingName = "RentalAmount";
            gridNumericColumn5.Width = 110D;
            gridNumericColumn6.AllowEditing = false;
            gridNumericColumn6.AllowResizing = true;
            gridNumericColumn6.CellStyle.HorizontalAlignment = HorizontalAlignment.Left;
            gridNumericColumn6.Format = "#,##0.00 ₺";
            gridNumericColumn6.HeaderText = "Deposit";
            gridNumericColumn6.MappingName = "RentalDepositAmount";
            gridNumericColumn6.Width = 110D;
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn3.HeaderText = "Payment Type";
            gridTextColumn3.MappingName = "RentalPaymentType";
            gridTextColumn3.Width = 110D;
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowResizing = true;
            gridTextColumn4.HeaderText = "Created By";
            gridTextColumn4.MappingName = "User.FullName";
            gridTextColumn4.Width = 130D;
            gridDateTimeColumn4.AllowEditing = false;
            gridDateTimeColumn4.AllowResizing = true;
            gridDateTimeColumn4.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn4.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn4.HeaderText = "Created At";
            gridDateTimeColumn4.MappingName = "RentalCreatedAt";
            gridDateTimeColumn4.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn4.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn4.Width = 140D;
            gridDateTimeColumn5.AllowEditing = false;
            gridDateTimeColumn5.AllowResizing = true;
            gridDateTimeColumn5.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn5.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn5.HeaderText = "Updated At";
            gridDateTimeColumn5.MappingName = "RentalUpdatedAt";
            gridDateTimeColumn5.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn5.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn5.Width = 140D;
            sfDataGridRentals.Columns.Add(gridNumericColumn1);
            sfDataGridRentals.Columns.Add(gridNumericColumn2);
            sfDataGridRentals.Columns.Add(gridTextColumn1);
            sfDataGridRentals.Columns.Add(gridTextColumn2);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn1);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn2);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn3);
            sfDataGridRentals.Columns.Add(gridNumericColumn3);
            sfDataGridRentals.Columns.Add(gridNumericColumn4);
            sfDataGridRentals.Columns.Add(gridNumericColumn5);
            sfDataGridRentals.Columns.Add(gridNumericColumn6);
            sfDataGridRentals.Columns.Add(gridTextColumn3);
            sfDataGridRentals.Columns.Add(gridTextColumn4);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn4);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn5);
            sfDataGridRentals.Dock = DockStyle.Fill;
            sfDataGridRentals.Location = new Point(20, 20);
            sfDataGridRentals.Name = "sfDataGridRentals";
            sfDataGridRentals.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            sfDataGridRentals.Size = new Size(1627, 925);
            sfDataGridRentals.Style.AddNewRowStyle.BackColor = Color.Transparent;
            sfDataGridRentals.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGridRentals.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGridRentals.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridRentals.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridRentals.Style.CurrentCellStyle.BackColor = Color.FromArgb(166, 216, 255);
            sfDataGridRentals.Style.CurrentCellStyle.BorderColor = Color.FromArgb(166, 216, 255);
            sfDataGridRentals.Style.CurrentCellStyle.BorderThickness = Syncfusion.WinForms.DataGrid.Styles.GridBorderWeight.ExtraThin;
            sfDataGridRentals.Style.CurrentCellStyle.TextColor = Color.Black;
            sfDataGridRentals.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGridRentals.Style.SelectionStyle.TextColor = Color.Black;
            sfDataGridRentals.TabIndex = 0;
            sfDataGridRentals.QueryRowStyle += SfDataGridRentals_QueryRowStyle;
            // 
            // tabPageRentalAdd
            // 
            tabPageRentalAdd.Controls.Add(panel1);
            tabPageRentalAdd.Controls.Add(sfDataGrid1);
            tabPageRentalAdd.Image = null;
            tabPageRentalAdd.ImageSize = new Size(16, 16);
            tabPageRentalAdd.Location = new Point(1, 33);
            tabPageRentalAdd.Name = "tabPageRentalAdd";
            tabPageRentalAdd.Padding = new Padding(20);
            tabPageRentalAdd.ShowCloseButton = true;
            tabPageRentalAdd.Size = new Size(1667, 965);
            tabPageRentalAdd.TabFont = new Font("Segoe UI", 12F);
            tabPageRentalAdd.TabIndex = 2;
            tabPageRentalAdd.Text = "Rental Add";
            tabPageRentalAdd.ThemesEnabled = false;
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.Dock = DockStyle.Right;
            sfDataGrid1.Location = new Point(1047, 20);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.Size = new Size(600, 925);
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.TabIndex = 0;
            sfDataGrid1.Text = "sfDataGridLastRental";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1007, 925);
            panel1.TabIndex = 1;
            // 
            // RentalsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlRentals);
            Name = "RentalsControl";
            Size = new Size(1670, 1000);
            ((System.ComponentModel.ISupportInitialize)tabControlRentals).EndInit();
            tabControlRentals.ResumeLayout(false);
            tabPageRentalsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDataGridRentals).EndInit();
            tabPageRentalAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlRentals;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageRentalsList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageRentalAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridRentals;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private Panel panel1;
    }
}