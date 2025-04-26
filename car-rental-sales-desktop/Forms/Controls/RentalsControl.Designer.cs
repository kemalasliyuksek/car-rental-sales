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
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn7 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn8 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn6 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn7 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn8 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn9 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn10 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn11 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn12 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn9 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn10 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            tabControlRentals = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageRentalsList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            sfDataGridRentals = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageRentalAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panel1 = new Panel();
            pnlLastRentals = new Panel();
            ((System.ComponentModel.ISupportInitialize)tabControlRentals).BeginInit();
            tabControlRentals.SuspendLayout();
            tabPageRentalsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridRentals).BeginInit();
            tabPageRentalAdd.SuspendLayout();
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
            gridNumericColumn7.AllowEditing = false;
            gridNumericColumn7.AllowResizing = true;
            gridNumericColumn7.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn7.Format = "0";
            gridNumericColumn7.HeaderText = "ID";
            gridNumericColumn7.MappingName = "RentalID";
            gridNumericColumn7.Width = 50D;
            gridNumericColumn8.AllowEditing = false;
            gridNumericColumn8.AllowResizing = true;
            gridNumericColumn8.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn8.Format = "0";
            gridNumericColumn8.HeaderText = "C. ID";
            gridNumericColumn8.MappingName = "RentalCustomerID";
            gridNumericColumn8.Width = 50D;
            gridTextColumn5.AllowEditing = false;
            gridTextColumn5.AllowResizing = true;
            gridTextColumn5.HeaderText = "Customer Name";
            gridTextColumn5.MappingName = "Customer.FullName";
            gridTextColumn5.Width = 140D;
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.AllowResizing = true;
            gridTextColumn6.HeaderText = "Vehicle Plate";
            gridTextColumn6.MappingName = "Vehicle.VehiclePlateNumber";
            gridTextColumn6.Width = 111D;
            gridDateTimeColumn6.AllowEditing = false;
            gridDateTimeColumn6.AllowResizing = true;
            gridDateTimeColumn6.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn6.Format = "dd.MM.yyyy";
            gridDateTimeColumn6.HeaderText = "Start Date";
            gridDateTimeColumn6.MappingName = "RentalStartDate";
            gridDateTimeColumn6.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn6.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn6.Width = 120D;
            gridDateTimeColumn7.AllowEditing = false;
            gridDateTimeColumn7.AllowResizing = true;
            gridDateTimeColumn7.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn7.Format = "dd.MM.yyyy";
            gridDateTimeColumn7.HeaderText = "End Date";
            gridDateTimeColumn7.MappingName = "RentalEndDate";
            gridDateTimeColumn7.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn7.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn7.Width = 120D;
            gridDateTimeColumn8.AllowEditing = false;
            gridDateTimeColumn8.AllowResizing = true;
            gridDateTimeColumn8.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn8.Format = "dd.MM.yyyy";
            gridDateTimeColumn8.HeaderText = "Return Date";
            gridDateTimeColumn8.MappingName = "RentalReturnDate";
            gridDateTimeColumn8.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn8.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn8.Width = 100D;
            gridNumericColumn9.AllowEditing = false;
            gridNumericColumn9.AllowResizing = true;
            gridNumericColumn9.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn9.Format = "0 KM";
            gridNumericColumn9.HeaderText = "Start KM";
            gridNumericColumn9.MappingName = "RentalStartKm";
            gridNumericColumn9.Width = 90D;
            gridNumericColumn10.AllowEditing = false;
            gridNumericColumn10.AllowResizing = true;
            gridNumericColumn10.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn10.Format = "0 KM";
            gridNumericColumn10.HeaderText = "End KM";
            gridNumericColumn10.MappingName = "RentalEndKm";
            gridNumericColumn10.Width = 90D;
            gridNumericColumn11.AllowEditing = false;
            gridNumericColumn11.AllowResizing = true;
            gridNumericColumn11.CellStyle.HorizontalAlignment = HorizontalAlignment.Left;
            gridNumericColumn11.Format = "#,##0.00 ₺";
            gridNumericColumn11.HeaderText = "Amount";
            gridNumericColumn11.MappingName = "RentalAmount";
            gridNumericColumn11.Width = 110D;
            gridNumericColumn12.AllowEditing = false;
            gridNumericColumn12.AllowResizing = true;
            gridNumericColumn12.CellStyle.HorizontalAlignment = HorizontalAlignment.Left;
            gridNumericColumn12.Format = "#,##0.00 ₺";
            gridNumericColumn12.HeaderText = "Deposit";
            gridNumericColumn12.MappingName = "RentalDepositAmount";
            gridNumericColumn12.Width = 110D;
            gridTextColumn7.AllowEditing = false;
            gridTextColumn7.AllowResizing = true;
            gridTextColumn7.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn7.HeaderText = "Payment Type";
            gridTextColumn7.MappingName = "RentalPaymentType";
            gridTextColumn7.Width = 110D;
            gridTextColumn8.AllowEditing = false;
            gridTextColumn8.AllowResizing = true;
            gridTextColumn8.HeaderText = "Created By";
            gridTextColumn8.MappingName = "User.FullName";
            gridTextColumn8.Width = 130D;
            gridDateTimeColumn9.AllowEditing = false;
            gridDateTimeColumn9.AllowResizing = true;
            gridDateTimeColumn9.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn9.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn9.HeaderText = "Created At";
            gridDateTimeColumn9.MappingName = "RentalCreatedAt";
            gridDateTimeColumn9.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn9.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn9.Width = 140D;
            gridDateTimeColumn10.AllowEditing = false;
            gridDateTimeColumn10.AllowResizing = true;
            gridDateTimeColumn10.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn10.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn10.HeaderText = "Updated At";
            gridDateTimeColumn10.MappingName = "RentalUpdatedAt";
            gridDateTimeColumn10.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn10.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn10.Width = 140D;
            sfDataGridRentals.Columns.Add(gridNumericColumn7);
            sfDataGridRentals.Columns.Add(gridNumericColumn8);
            sfDataGridRentals.Columns.Add(gridTextColumn5);
            sfDataGridRentals.Columns.Add(gridTextColumn6);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn6);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn7);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn8);
            sfDataGridRentals.Columns.Add(gridNumericColumn9);
            sfDataGridRentals.Columns.Add(gridNumericColumn10);
            sfDataGridRentals.Columns.Add(gridNumericColumn11);
            sfDataGridRentals.Columns.Add(gridNumericColumn12);
            sfDataGridRentals.Columns.Add(gridTextColumn7);
            sfDataGridRentals.Columns.Add(gridTextColumn8);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn9);
            sfDataGridRentals.Columns.Add(gridDateTimeColumn10);
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
            tabPageRentalAdd.Controls.Add(pnlLastRentals);
            tabPageRentalAdd.Controls.Add(panel1);
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
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1007, 925);
            panel1.TabIndex = 1;
            // 
            // pnlLastRentals
            // 
            pnlLastRentals.Dock = DockStyle.Right;
            pnlLastRentals.Location = new Point(1047, 20);
            pnlLastRentals.Name = "pnlLastRentals";
            pnlLastRentals.Size = new Size(600, 925);
            pnlLastRentals.TabIndex = 2;
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
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlRentals;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageRentalsList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageRentalAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridRentals;
        private Panel panel1;
        private Panel pnlLastRentals;
    }
}