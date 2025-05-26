using System.Xml.Linq;

namespace car_rental_sales_desktop.Forms.Controls
{
    partial class BranchesControl
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridCheckBoxColumn gridCheckBoxColumn1 = new Syncfusion.WinForms.DataGrid.GridCheckBoxColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            tabControlBranch = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageBranchList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            sfDataGridBranch = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageBranchAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panelBranchForm = new Panel();
            btnCancelBranch = new Syncfusion.Windows.Forms.ButtonAdv();
            btnSaveBranch = new Syncfusion.Windows.Forms.ButtonAdv();
            chkBranchActive = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtBranchEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtBranchPhone = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtBranchAddress = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtBranchName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblBranchEmail = new Label();
            lblBranchPhone = new Label();
            lblBranchAddress = new Label();
            lblBranchName = new Label();
            lblBranchFormTitle = new Label();
            panelBranchActions = new Panel();
            btnEditBranch = new Syncfusion.Windows.Forms.ButtonAdv();
            btnDeleteBranch = new Syncfusion.Windows.Forms.ButtonAdv();
            btnToggleStatus = new Syncfusion.Windows.Forms.ButtonAdv();
            btnRefreshBranch = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)tabControlBranch).BeginInit();
            tabControlBranch.SuspendLayout();
            tabPageBranchList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridBranch).BeginInit();
            tabPageBranchAdd.SuspendLayout();
            panelBranchForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkBranchActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBranchEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBranchPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBranchAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBranchName).BeginInit();
            panelBranchActions.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlBranch
            // 
            tabControlBranch.BeforeTouchSize = new Size(1670, 1000);
            tabControlBranch.Controls.Add(tabPageBranchList);
            tabControlBranch.Controls.Add(tabPageBranchAdd);
            tabControlBranch.Dock = DockStyle.Fill;
            tabControlBranch.Location = new Point(0, 0);
            tabControlBranch.Name = "tabControlBranch";
            tabControlBranch.Size = new Size(1670, 1000);
            tabControlBranch.TabIndex = 0;
            // 
            // tabPageBranchList
            // 
            tabPageBranchList.Controls.Add(panelBranchActions);
            tabPageBranchList.Controls.Add(sfDataGridBranch);
            tabPageBranchList.Image = null;
            tabPageBranchList.ImageSize = new Size(16, 16);
            tabPageBranchList.Location = new Point(1, 33);
            tabPageBranchList.Name = "tabPageBranchList";
            tabPageBranchList.Padding = new Padding(20);
            tabPageBranchList.ShowCloseButton = true;
            tabPageBranchList.Size = new Size(1667, 965);
            tabPageBranchList.TabFont = new Font("Segoe UI", 12F);
            tabPageBranchList.TabIndex = 1;
            tabPageBranchList.Text = "Branch List";
            tabPageBranchList.ThemesEnabled = false;
            // 
            // sfDataGridBranch
            // 
            sfDataGridBranch.AccessibleName = "Table";
            sfDataGridBranch.AllowEditing = false;
            sfDataGridBranch.AutoGenerateColumns = false;
            gridNumericColumn1.AllowEditing = false;
            gridNumericColumn1.AllowResizing = true;
            gridNumericColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridNumericColumn1.Format = "0";
            gridNumericColumn1.HeaderText = "ID";
            gridNumericColumn1.MappingName = "BranchID";
            gridNumericColumn1.Width = 60D;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.HeaderText = "Branch Name";
            gridTextColumn1.MappingName = "BranchName";
            gridTextColumn1.Width = 200D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Address";
            gridTextColumn2.MappingName = "BranchAddress";
            gridTextColumn2.Width = 350D;
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridTextColumn3.HeaderText = "Phone";
            gridTextColumn3.MappingName = "BranchPhone";
            gridTextColumn3.Width = 150D;
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowResizing = true;
            gridTextColumn4.HeaderText = "Email";
            gridTextColumn4.MappingName = "BranchEmail";
            gridTextColumn4.Width = 250D;
            gridCheckBoxColumn1.AllowEditing = false;
            gridCheckBoxColumn1.AllowResizing = true;
            gridCheckBoxColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridCheckBoxColumn1.HeaderText = "Active";
            gridCheckBoxColumn1.MappingName = "BranchActive";
            gridCheckBoxColumn1.Width = 80D;
            gridDateTimeColumn1.AllowEditing = false;
            gridDateTimeColumn1.AllowResizing = true;
            gridDateTimeColumn1.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            gridDateTimeColumn1.Format = "dd.MM.yyyy - HH:mm:ss";
            gridDateTimeColumn1.HeaderText = "Created At";
            gridDateTimeColumn1.MappingName = "BranchCreatedAt";
            gridDateTimeColumn1.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn1.Width = 180D;
            sfDataGridBranch.Columns.Add(gridNumericColumn1);
            sfDataGridBranch.Columns.Add(gridTextColumn1);
            sfDataGridBranch.Columns.Add(gridTextColumn2);
            sfDataGridBranch.Columns.Add(gridTextColumn3);
            sfDataGridBranch.Columns.Add(gridTextColumn4);
            sfDataGridBranch.Columns.Add(gridCheckBoxColumn1);
            sfDataGridBranch.Columns.Add(gridDateTimeColumn1);
            sfDataGridBranch.Dock = DockStyle.Bottom;
            sfDataGridBranch.Location = new Point(20, 80);
            sfDataGridBranch.Name = "sfDataGridBranch";
            sfDataGridBranch.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            sfDataGridBranch.Size = new Size(1627, 865);
            sfDataGridBranch.Style.AddNewRowStyle.BackColor = Color.Transparent;
            sfDataGridBranch.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGridBranch.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGridBranch.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridBranch.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridBranch.Style.CurrentCellStyle.BackColor = Color.FromArgb(166, 216, 255);
            sfDataGridBranch.Style.CurrentCellStyle.BorderColor = Color.FromArgb(166, 216, 255);
            sfDataGridBranch.Style.CurrentCellStyle.BorderThickness = Syncfusion.WinForms.DataGrid.Styles.GridBorderWeight.ExtraThin;
            sfDataGridBranch.Style.CurrentCellStyle.TextColor = Color.Black;
            sfDataGridBranch.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGridBranch.Style.SelectionStyle.TextColor = Color.Black;
            sfDataGridBranch.TabIndex = 0;
            sfDataGridBranch.QueryRowStyle += SfDataGridBranch_QueryRowStyle;
            // 
            // tabPageBranchAdd
            // 
            tabPageBranchAdd.Controls.Add(panelBranchForm);
            tabPageBranchAdd.Image = null;
            tabPageBranchAdd.ImageSize = new Size(16, 16);
            tabPageBranchAdd.Location = new Point(1, 33);
            tabPageBranchAdd.Name = "tabPageBranchAdd";
            tabPageBranchAdd.Padding = new Padding(20);
            tabPageBranchAdd.ShowCloseButton = true;
            tabPageBranchAdd.Size = new Size(1667, 965);
            tabPageBranchAdd.TabFont = new Font("Segoe UI", 12F);
            tabPageBranchAdd.TabIndex = 2;
            tabPageBranchAdd.Text = "Branch Add/Edit";
            tabPageBranchAdd.ThemesEnabled = false;
            // 
            // panelBranchForm
            // 
            panelBranchForm.AutoScroll = true;
            panelBranchForm.Controls.Add(btnCancelBranch);
            panelBranchForm.Controls.Add(btnSaveBranch);
            panelBranchForm.Controls.Add(chkBranchActive);
            panelBranchForm.Controls.Add(txtBranchEmail);
            panelBranchForm.Controls.Add(txtBranchPhone);
            panelBranchForm.Controls.Add(txtBranchAddress);
            panelBranchForm.Controls.Add(txtBranchName);
            panelBranchForm.Controls.Add(lblBranchEmail);
            panelBranchForm.Controls.Add(lblBranchPhone);
            panelBranchForm.Controls.Add(lblBranchAddress);
            panelBranchForm.Controls.Add(lblBranchName);
            panelBranchForm.Controls.Add(lblBranchFormTitle);
            panelBranchForm.Dock = DockStyle.Fill;
            panelBranchForm.Location = new Point(20, 20);
            panelBranchForm.Name = "panelBranchForm";
            panelBranchForm.Size = new Size(1627, 925);
            panelBranchForm.TabIndex = 0;
            // 
            // btnCancelBranch
            // 
            btnCancelBranch.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnCancelBranch.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelBranch.BeforeTouchSize = new Size(150, 45);
            btnCancelBranch.FlatStyle = FlatStyle.Flat;
            btnCancelBranch.Font = new Font("Segoe UI Semibold", 12F);
            btnCancelBranch.ForeColor = Color.White;
            btnCancelBranch.Location = new Point(818, 574);
            btnCancelBranch.Name = "btnCancelBranch";
            btnCancelBranch.Size = new Size(150, 45);
            btnCancelBranch.TabIndex = 11;
            btnCancelBranch.Text = "Cancel";
            btnCancelBranch.ThemeName = "Metro";
            btnCancelBranch.UseVisualStyleBackColor = false;
            btnCancelBranch.Click += BtnCancelBranch_Click;
            // 
            // btnSaveBranch
            // 
            btnSaveBranch.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnSaveBranch.BackColor = Color.FromArgb(40, 167, 69);
            btnSaveBranch.BeforeTouchSize = new Size(150, 45);
            btnSaveBranch.FlatStyle = FlatStyle.Flat;
            btnSaveBranch.Font = new Font("Segoe UI Semibold", 12F);
            btnSaveBranch.ForeColor = Color.White;
            btnSaveBranch.Location = new Point(658, 574);
            btnSaveBranch.Name = "btnSaveBranch";
            btnSaveBranch.Size = new Size(150, 45);
            btnSaveBranch.TabIndex = 10;
            btnSaveBranch.Text = "Save Branch";
            btnSaveBranch.ThemeName = "Metro";
            btnSaveBranch.UseVisualStyleBackColor = false;
            btnSaveBranch.Click += BtnSaveBranch_Click;
            // 
            // chkBranchActive
            // 
            chkBranchActive.AccessibilityEnabled = true;
            chkBranchActive.BeforeTouchSize = new Size(166, 21);
            chkBranchActive.Checked = true;
            chkBranchActive.CheckState = CheckState.Checked;
            chkBranchActive.Font = new Font("Segoe UI Semibold", 11F);
            chkBranchActive.Location = new Point(537, 505);
            chkBranchActive.Name = "chkBranchActive";
            chkBranchActive.Size = new Size(166, 21);
            chkBranchActive.TabIndex = 9;
            chkBranchActive.Text = "Branch is Active";
            // 
            // txtBranchEmail
            // 
            txtBranchEmail.BeforeTouchSize = new Size(310, 100);
            txtBranchEmail.BorderStyle = BorderStyle.FixedSingle;
            txtBranchEmail.Font = new Font("Segoe UI", 11F);
            txtBranchEmail.Location = new Point(707, 455);
            txtBranchEmail.Name = "txtBranchEmail";
            txtBranchEmail.Size = new Size(310, 27);
            txtBranchEmail.TabIndex = 8;
            // 
            // txtBranchPhone
            // 
            txtBranchPhone.BeforeTouchSize = new Size(310, 100);
            txtBranchPhone.BorderStyle = BorderStyle.FixedSingle;
            txtBranchPhone.Font = new Font("Segoe UI", 11F);
            txtBranchPhone.Location = new Point(707, 405);
            txtBranchPhone.Name = "txtBranchPhone";
            txtBranchPhone.Size = new Size(310, 27);
            txtBranchPhone.TabIndex = 7;
            // 
            // txtBranchAddress
            // 
            txtBranchAddress.BeforeTouchSize = new Size(310, 100);
            txtBranchAddress.BorderStyle = BorderStyle.FixedSingle;
            txtBranchAddress.Font = new Font("Segoe UI", 11F);
            txtBranchAddress.Location = new Point(707, 275);
            txtBranchAddress.Multiline = true;
            txtBranchAddress.Name = "txtBranchAddress";
            txtBranchAddress.ScrollBars = ScrollBars.Vertical;
            txtBranchAddress.Size = new Size(310, 100);
            txtBranchAddress.TabIndex = 6;
            // 
            // txtBranchName
            // 
            txtBranchName.BeforeTouchSize = new Size(310, 100);
            txtBranchName.BorderStyle = BorderStyle.FixedSingle;
            txtBranchName.Font = new Font("Segoe UI", 11F);
            txtBranchName.Location = new Point(707, 225);
            txtBranchName.Name = "txtBranchName";
            txtBranchName.Size = new Size(310, 27);
            txtBranchName.TabIndex = 5;
            // 
            // lblBranchEmail
            // 
            lblBranchEmail.AutoSize = true;
            lblBranchEmail.Font = new Font("Segoe UI Semibold", 11F);
            lblBranchEmail.Location = new Point(537, 465);
            lblBranchEmail.Name = "lblBranchEmail";
            lblBranchEmail.Size = new Size(50, 20);
            lblBranchEmail.TabIndex = 4;
            lblBranchEmail.Text = "Email:";
            // 
            // lblBranchPhone
            // 
            lblBranchPhone.AutoSize = true;
            lblBranchPhone.Font = new Font("Segoe UI Semibold", 11F);
            lblBranchPhone.Location = new Point(537, 415);
            lblBranchPhone.Name = "lblBranchPhone";
            lblBranchPhone.Size = new Size(57, 20);
            lblBranchPhone.TabIndex = 3;
            lblBranchPhone.Text = "Phone:";
            // 
            // lblBranchAddress
            // 
            lblBranchAddress.AutoSize = true;
            lblBranchAddress.Font = new Font("Segoe UI Semibold", 11F);
            lblBranchAddress.Location = new Point(537, 285);
            lblBranchAddress.Name = "lblBranchAddress";
            lblBranchAddress.Size = new Size(67, 20);
            lblBranchAddress.TabIndex = 2;
            lblBranchAddress.Text = "Address:";
            // 
            // lblBranchName
            // 
            lblBranchName.AutoSize = true;
            lblBranchName.Font = new Font("Segoe UI Semibold", 11F);
            lblBranchName.Location = new Point(537, 235);
            lblBranchName.Name = "lblBranchName";
            lblBranchName.Size = new Size(106, 20);
            lblBranchName.TabIndex = 1;
            lblBranchName.Text = "Branch Name:";
            // 
            // lblBranchFormTitle
            // 
            lblBranchFormTitle.AutoSize = true;
            lblBranchFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBranchFormTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblBranchFormTitle.Location = new Point(720, 126);
            lblBranchFormTitle.Name = "lblBranchFormTitle";
            lblBranchFormTitle.Size = new Size(205, 32);
            lblBranchFormTitle.TabIndex = 0;
            lblBranchFormTitle.Text = "Add New Branch";
            // 
            // panelBranchActions
            // 
            panelBranchActions.Controls.Add(btnEditBranch);
            panelBranchActions.Controls.Add(btnDeleteBranch);
            panelBranchActions.Controls.Add(btnToggleStatus);
            panelBranchActions.Controls.Add(btnRefreshBranch);
            panelBranchActions.Dock = DockStyle.Top;
            panelBranchActions.Location = new Point(20, 20);
            panelBranchActions.Name = "panelBranchActions";
            panelBranchActions.Size = new Size(1627, 60);
            panelBranchActions.TabIndex = 2;
            // 
            // btnEditBranch
            // 
            btnEditBranch.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnEditBranch.BackColor = Color.FromArgb(0, 120, 215);
            btnEditBranch.BeforeTouchSize = new Size(120, 35);
            btnEditBranch.FlatStyle = FlatStyle.Flat;
            btnEditBranch.Font = new Font("Segoe UI Semibold", 10F);
            btnEditBranch.ForeColor = Color.White;
            btnEditBranch.Location = new Point(10, 15);
            btnEditBranch.Name = "btnEditBranch";
            btnEditBranch.Size = new Size(120, 35);
            btnEditBranch.TabIndex = 0;
            btnEditBranch.Text = "Edit Branch";
            btnEditBranch.ThemeName = "Metro";
            btnEditBranch.UseVisualStyleBackColor = false;
            btnEditBranch.Click += BtnEditBranch_Click;
            // 
            // btnDeleteBranch
            // 
            btnDeleteBranch.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnDeleteBranch.BackColor = Color.FromArgb(215, 55, 55);
            btnDeleteBranch.BeforeTouchSize = new Size(120, 35);
            btnDeleteBranch.FlatStyle = FlatStyle.Flat;
            btnDeleteBranch.Font = new Font("Segoe UI Semibold", 10F);
            btnDeleteBranch.ForeColor = Color.White;
            btnDeleteBranch.Location = new Point(140, 15);
            btnDeleteBranch.Name = "btnDeleteBranch";
            btnDeleteBranch.Size = new Size(120, 35);
            btnDeleteBranch.TabIndex = 1;
            btnDeleteBranch.Text = "Delete Branch";
            btnDeleteBranch.ThemeName = "Metro";
            btnDeleteBranch.UseVisualStyleBackColor = false;
            btnDeleteBranch.Click += BtnDeleteBranch_Click;
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
            // btnRefreshBranch
            // 
            btnRefreshBranch.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            btnRefreshBranch.BackColor = Color.FromArgb(34, 139, 34);
            btnRefreshBranch.BeforeTouchSize = new Size(120, 35);
            btnRefreshBranch.FlatStyle = FlatStyle.Flat;
            btnRefreshBranch.Font = new Font("Segoe UI Semibold", 10F);
            btnRefreshBranch.ForeColor = Color.White;
            btnRefreshBranch.Location = new Point(420, 15);
            btnRefreshBranch.Name = "btnRefreshBranch";
            btnRefreshBranch.Size = new Size(120, 35);
            btnRefreshBranch.TabIndex = 3;
            btnRefreshBranch.Text = "Refresh";
            btnRefreshBranch.ThemeName = "Metro";
            btnRefreshBranch.UseVisualStyleBackColor = false;
            btnRefreshBranch.Click += BtnRefreshBranch_Click;
            // 
            // BranchesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlBranch);
            Name = "BranchesControl";
            Size = new Size(1670, 1000);
            ((System.ComponentModel.ISupportInitialize)tabControlBranch).EndInit();
            tabControlBranch.ResumeLayout(false);
            tabPageBranchList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDataGridBranch).EndInit();
            tabPageBranchAdd.ResumeLayout(false);
            panelBranchForm.ResumeLayout(false);
            panelBranchForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chkBranchActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBranchEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBranchPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBranchAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBranchName).EndInit();
            panelBranchActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlBranch;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageBranchList;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageBranchAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridBranch;
        private System.Windows.Forms.Panel panelBranchForm;
        private System.Windows.Forms.Label lblBranchFormTitle;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label lblBranchAddress;
        private System.Windows.Forms.Label lblBranchPhone;
        private System.Windows.Forms.Label lblBranchEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtBranchName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtBranchAddress;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtBranchPhone;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtBranchEmail;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkBranchActive;
        private Syncfusion.Windows.Forms.ButtonAdv btnSaveBranch;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancelBranch;
        private Panel panelBranchActions;
        private Syncfusion.Windows.Forms.ButtonAdv btnEditBranch;
        private Syncfusion.Windows.Forms.ButtonAdv btnDeleteBranch;
        private Syncfusion.Windows.Forms.ButtonAdv btnToggleStatus;
        private Syncfusion.Windows.Forms.ButtonAdv btnRefreshBranch;
    }
}