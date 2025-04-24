namespace car_rental_sales_desktop.Forms.Controls
{
    partial class VehiclesControl
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
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn2 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn3 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn4 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridNumericColumn gridNumericColumn5 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn9 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn2 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn3 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            tabControlVehicles = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageVehiclesList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            sfDataGridVehicles = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageVehicleAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ((System.ComponentModel.ISupportInitialize)tabControlVehicles).BeginInit();
            tabControlVehicles.SuspendLayout();
            tabPageVehiclesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridVehicles).BeginInit();
            SuspendLayout();
            // 
            // tabControlVehicles
            // 
            tabControlVehicles.BeforeTouchSize = new Size(1670, 1000);
            tabControlVehicles.Controls.Add(tabPageVehiclesList);
            tabControlVehicles.Controls.Add(tabPageVehicleAdd);
            tabControlVehicles.Dock = DockStyle.Fill;
            tabControlVehicles.Location = new Point(0, 0);
            tabControlVehicles.Name = "tabControlVehicles";
            tabControlVehicles.Size = new Size(1670, 1000);
            tabControlVehicles.TabIndex = 0;
            // 
            // tabPageVehiclesList
            // 
            tabPageVehiclesList.Controls.Add(sfDataGridVehicles);
            tabPageVehiclesList.Image = null;
            tabPageVehiclesList.ImageSize = new Size(16, 16);
            tabPageVehiclesList.Location = new Point(1, 33);
            tabPageVehiclesList.Name = "tabPageVehiclesList";
            tabPageVehiclesList.Padding = new Padding(20);
            tabPageVehiclesList.ShowCloseButton = true;
            tabPageVehiclesList.Size = new Size(1667, 965);
            tabPageVehiclesList.TabFont = new Font("Segoe UI", 12F);
            tabPageVehiclesList.TabIndex = 1;
            tabPageVehiclesList.Text = "Vehicles List";
            tabPageVehiclesList.ThemesEnabled = false;
            // 
            // sfDataGridVehicles
            // 
            sfDataGridVehicles.AccessibleName = "Table";
            sfDataGridVehicles.AllowEditing = false;
            sfDataGridVehicles.AutoGenerateColumns = false;
            gridNumericColumn1.AllowEditing = false;
            gridNumericColumn1.AllowResizing = true;
            gridNumericColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn1.Format = "0";
            gridNumericColumn1.HeaderText = "ID";
            gridNumericColumn1.MappingName = "VehicleID";
            gridNumericColumn1.Width = 50D;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn1.HeaderText = "Plate Number";
            gridTextColumn1.MappingName = "VehiclePlateNumber";
            gridTextColumn1.Width = 90D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Brand";
            gridTextColumn2.MappingName = "VehicleBrand";
            gridTextColumn2.Width = 90D;
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.HeaderText = "Model";
            gridTextColumn3.MappingName = "VehicleModel";
            gridTextColumn3.Width = 90D;
            gridNumericColumn2.AllowEditing = false;
            gridNumericColumn2.AllowResizing = true;
            gridNumericColumn2.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn2.Format = "0";
            gridNumericColumn2.HeaderText = "Year";
            gridNumericColumn2.MappingName = "VehicleYear";
            gridNumericColumn2.Width = 60D;
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowResizing = true;
            gridTextColumn4.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn4.HeaderText = "Color";
            gridTextColumn4.MappingName = "VehicleColor";
            gridTextColumn4.Width = 70D;
            gridNumericColumn3.AllowEditing = false;
            gridNumericColumn3.AllowResizing = true;
            gridNumericColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Left;
            gridNumericColumn3.Format = "N0";
            gridNumericColumn3.HeaderText = "Mileage";
            gridNumericColumn3.MappingName = "VehicleMileage";
            gridNumericColumn3.Width = 90D;
            gridTextColumn5.AllowEditing = false;
            gridTextColumn5.AllowResizing = true;
            gridTextColumn5.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn5.HeaderText = "Fuel Type";
            gridTextColumn5.MappingName = "VehicleFuelType";
            gridTextColumn5.Width = 90D;
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.AllowResizing = true;
            gridTextColumn6.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn6.HeaderText = "Transmission";
            gridTextColumn6.MappingName = "VehicleTransmissionType";
            gridTextColumn6.Width = 90D;
            gridTextColumn7.AllowEditing = false;
            gridTextColumn7.AllowResizing = true;
            gridTextColumn7.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn7.HeaderText = "Status";
            gridTextColumn7.MappingName = "VehicleStatus.VehicleStatusName";
            gridTextColumn7.Width = 90D;
            gridDateTimeColumn1.AllowEditing = false;
            gridDateTimeColumn1.AllowResizing = true;
            gridDateTimeColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn1.Format = "dd.MM.yyyy";
            gridDateTimeColumn1.HeaderText = "Acquisition Date";
            gridDateTimeColumn1.MappingName = "VehicleAcquisitionDate";
            gridDateTimeColumn1.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn1.Width = 110D;
            gridNumericColumn4.AllowEditing = false;
            gridNumericColumn4.AllowResizing = true;
            gridNumericColumn4.CellStyle.HorizontalAlignment = HorizontalAlignment.Left;
            gridNumericColumn4.Format = "N2";
            gridNumericColumn4.HeaderText = "Purchase Price";
            gridNumericColumn4.MappingName = "VehiclePurchasePrice";
            gridNumericColumn4.Width = 100D;
            gridNumericColumn5.AllowEditing = false;
            gridNumericColumn5.AllowResizing = true;
            gridNumericColumn5.CellStyle.HorizontalAlignment = HorizontalAlignment.Left;
            gridNumericColumn5.Format = "N2";
            gridNumericColumn5.HeaderText = "Sale Price";
            gridNumericColumn5.MappingName = "VehicleSalePrice";
            gridNumericColumn5.Width = 100D;
            gridTextColumn8.AllowEditing = false;
            gridTextColumn8.AllowResizing = true;
            gridTextColumn8.HeaderText = "Branch";
            gridTextColumn8.MappingName = "Branch.BranchName";
            gridTextColumn8.Width = 141D;
            gridTextColumn9.AllowEditing = false;
            gridTextColumn9.AllowResizing = true;
            gridTextColumn9.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn9.HeaderText = "Class";
            gridTextColumn9.MappingName = "VehicleClass.VehicleClassName";
            gridTextColumn9.Width = 70D;
            gridDateTimeColumn2.AllowEditing = false;
            gridDateTimeColumn2.AllowResizing = true;
            gridDateTimeColumn2.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn2.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn2.HeaderText = "Created At";
            gridDateTimeColumn2.MappingName = "VehicleCreatedAt";
            gridDateTimeColumn2.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn2.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn2.Width = 140D;
            gridDateTimeColumn3.AllowEditing = false;
            gridDateTimeColumn3.AllowResizing = true;
            gridDateTimeColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn3.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn3.HeaderText = "Updated At";
            gridDateTimeColumn3.MappingName = "VehicleUpdatedAt";
            gridDateTimeColumn3.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn3.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn3.Width = 140D;
            sfDataGridVehicles.Columns.Add(gridNumericColumn1);
            sfDataGridVehicles.Columns.Add(gridTextColumn1);
            sfDataGridVehicles.Columns.Add(gridTextColumn2);
            sfDataGridVehicles.Columns.Add(gridTextColumn3);
            sfDataGridVehicles.Columns.Add(gridNumericColumn2);
            sfDataGridVehicles.Columns.Add(gridTextColumn4);
            sfDataGridVehicles.Columns.Add(gridNumericColumn3);
            sfDataGridVehicles.Columns.Add(gridTextColumn5);
            sfDataGridVehicles.Columns.Add(gridTextColumn6);
            sfDataGridVehicles.Columns.Add(gridTextColumn7);
            sfDataGridVehicles.Columns.Add(gridDateTimeColumn1);
            sfDataGridVehicles.Columns.Add(gridNumericColumn4);
            sfDataGridVehicles.Columns.Add(gridNumericColumn5);
            sfDataGridVehicles.Columns.Add(gridTextColumn8);
            sfDataGridVehicles.Columns.Add(gridTextColumn9);
            sfDataGridVehicles.Columns.Add(gridDateTimeColumn2);
            sfDataGridVehicles.Columns.Add(gridDateTimeColumn3);
            sfDataGridVehicles.Dock = DockStyle.Fill;
            sfDataGridVehicles.Location = new Point(20, 20);
            sfDataGridVehicles.Name = "sfDataGridVehicles";
            sfDataGridVehicles.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            sfDataGridVehicles.Size = new Size(1627, 925);
            sfDataGridVehicles.Style.AddNewRowStyle.BackColor = Color.Transparent;
            sfDataGridVehicles.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGridVehicles.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGridVehicles.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridVehicles.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridVehicles.Style.CurrentCellStyle.BackColor = Color.FromArgb(166, 216, 255);
            sfDataGridVehicles.Style.CurrentCellStyle.BorderColor = Color.FromArgb(166, 216, 255);
            sfDataGridVehicles.Style.CurrentCellStyle.BorderThickness = Syncfusion.WinForms.DataGrid.Styles.GridBorderWeight.ExtraThin;
            sfDataGridVehicles.Style.CurrentCellStyle.TextColor = Color.Black;
            sfDataGridVehicles.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGridVehicles.Style.SelectionStyle.TextColor = Color.Black;
            sfDataGridVehicles.TabIndex = 0;
            sfDataGridVehicles.QueryRowStyle += SfDataGridVehicles_QueryRowStyle;
            // 
            // tabPageVehicleAdd
            // 
            tabPageVehicleAdd.Image = null;
            tabPageVehicleAdd.ImageSize = new Size(16, 16);
            tabPageVehicleAdd.Location = new Point(1, 33);
            tabPageVehicleAdd.Name = "tabPageVehicleAdd";
            tabPageVehicleAdd.ShowCloseButton = true;
            tabPageVehicleAdd.Size = new Size(1667, 965);
            tabPageVehicleAdd.TabFont = new Font("Segoe UI", 12F);
            tabPageVehicleAdd.TabIndex = 2;
            tabPageVehicleAdd.Text = "Vehicle Add";
            tabPageVehicleAdd.ThemesEnabled = false;
            // 
            // VehiclesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlVehicles);
            Name = "VehiclesControl";
            Size = new Size(1670, 1000);
            ((System.ComponentModel.ISupportInitialize)tabControlVehicles).EndInit();
            tabControlVehicles.ResumeLayout(false);
            tabPageVehiclesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDataGridVehicles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlVehicles;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageVehiclesList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageVehicleAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridVehicles;
    }
}