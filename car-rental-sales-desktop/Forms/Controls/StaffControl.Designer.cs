namespace car_rental_sales_desktop.Forms.Controls
{
    partial class StaffControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
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
            tabControlStaff = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageStaffList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            sfDataGridStaff = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageStaffAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ((System.ComponentModel.ISupportInitialize)tabControlStaff).BeginInit();
            tabControlStaff.SuspendLayout();
            tabPageStaffList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridStaff).BeginInit();
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
            gridNumericColumn1.AllowEditing = false;
            gridNumericColumn1.AllowResizing = true;
            gridNumericColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn1.Format = "0";
            gridNumericColumn1.HeaderText = "ID";
            gridNumericColumn1.MappingName = "UserID";
            gridNumericColumn1.Width = 50D;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.HeaderText = "First Name";
            gridTextColumn1.MappingName = "UserFirstName";
            gridTextColumn1.Width = 100D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Last Name";
            gridTextColumn2.MappingName = "UserLastName";
            gridTextColumn2.Width = 100D;
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.HeaderText = "Username";
            gridTextColumn3.MappingName = "Username";
            gridTextColumn3.Width = 120D;
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowResizing = true;
            gridTextColumn4.HeaderText = "Email";
            gridTextColumn4.MappingName = "UserEmail";
            gridTextColumn4.Width = 180D;
            gridTextColumn5.AllowEditing = false;
            gridTextColumn5.AllowResizing = true;
            gridTextColumn5.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn5.HeaderText = "Phone No";
            gridTextColumn5.MappingName = "UserPhone";
            gridTextColumn5.Width = 120D;
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.AllowResizing = true;
            gridTextColumn6.HeaderText = "Role";
            gridTextColumn6.MappingName = "Role.RoleName";
            gridTextColumn6.Width = 150D;
            gridTextColumn7.AllowEditing = false;
            gridTextColumn7.AllowResizing = true;
            gridTextColumn7.HeaderText = "Branch Name";
            gridTextColumn7.MappingName = "Branch.BranchName";
            gridTextColumn7.Width = 180D;
            gridDateTimeColumn1.AllowEditing = false;
            gridDateTimeColumn1.AllowResizing = true;
            gridDateTimeColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn1.Format = "dd.MM.yyyy HH:mm:ss";
            gridDateTimeColumn1.HeaderText = "Last Login";
            gridDateTimeColumn1.MappingName = "UserLastLogin";
            gridDateTimeColumn1.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn1.Width = 130D;
            gridCheckBoxColumn1.AllowEditing = false;
            gridCheckBoxColumn1.AllowResizing = true;
            gridCheckBoxColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridCheckBoxColumn1.HeaderText = "Active";
            gridCheckBoxColumn1.MappingName = "UserActive";
            gridCheckBoxColumn1.Width = 50D;
            gridDateTimeColumn2.AllowEditing = false;
            gridDateTimeColumn2.AllowResizing = true;
            gridDateTimeColumn2.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn2.Format = "dd.MM.yyyy HH:mm:ss";
            gridDateTimeColumn2.HeaderText = "Created At";
            gridDateTimeColumn2.MappingName = "UserCreatedAt";
            gridDateTimeColumn2.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn2.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn2.Width = 130D;
            gridDateTimeColumn3.AllowEditing = false;
            gridDateTimeColumn3.AllowResizing = true;
            gridDateTimeColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn3.Format = "dd.MM.yyyy HH:mm:ss";
            gridDateTimeColumn3.HeaderText = "Updated At";
            gridDateTimeColumn3.MappingName = "UserUpdatedAt";
            gridDateTimeColumn3.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn3.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn3.Width = 130D;
            sfDataGridStaff.Columns.Add(gridNumericColumn1);
            sfDataGridStaff.Columns.Add(gridTextColumn1);
            sfDataGridStaff.Columns.Add(gridTextColumn2);
            sfDataGridStaff.Columns.Add(gridTextColumn3);
            sfDataGridStaff.Columns.Add(gridTextColumn4);
            sfDataGridStaff.Columns.Add(gridTextColumn5);
            sfDataGridStaff.Columns.Add(gridTextColumn6);
            sfDataGridStaff.Columns.Add(gridTextColumn7);
            sfDataGridStaff.Columns.Add(gridDateTimeColumn1);
            sfDataGridStaff.Columns.Add(gridCheckBoxColumn1);
            sfDataGridStaff.Columns.Add(gridDateTimeColumn2);
            sfDataGridStaff.Columns.Add(gridDateTimeColumn3);
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
            // 
            // tabPageStaffAdd
            // 
            tabPageStaffAdd.Image = null;
            tabPageStaffAdd.ImageSize = new Size(16, 16);
            tabPageStaffAdd.Location = new Point(1, 33);
            tabPageStaffAdd.Name = "tabPageStaffAdd";
            tabPageStaffAdd.ShowCloseButton = true;
            tabPageStaffAdd.Size = new Size(1667, 965);
            tabPageStaffAdd.TabFont = new Font("Segoe UI", 12F);
            tabPageStaffAdd.TabIndex = 2;
            tabPageStaffAdd.Text = "Staff Add";
            tabPageStaffAdd.ThemesEnabled = false;
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
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlStaff;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageStaffList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageStaffAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridStaff;
    }
}