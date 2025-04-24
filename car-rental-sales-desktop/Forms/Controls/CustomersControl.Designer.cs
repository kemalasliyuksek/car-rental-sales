namespace car_rental_sales_desktop.Forms.Controls
{
    partial class CustomersControl
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
            tabControlCustomers = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageCustomersList = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabPageCustomerAdd = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            sfDataGridCustomers = new Syncfusion.WinForms.DataGrid.SfDataGrid();
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
            tabPageCustomersList.ShowCloseButton = true;
            tabPageCustomersList.Size = new Size(1667, 965);
            tabPageCustomersList.TabFont = new Font("Segoe UI", 12F);
            tabPageCustomersList.TabIndex = 1;
            tabPageCustomersList.Text = "Customers List";
            tabPageCustomersList.ThemesEnabled = false;
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
            // sfDataGridCustomers
            // 
            sfDataGridCustomers.AccessibleName = "Table";
            sfDataGridCustomers.Dock = DockStyle.Fill;
            sfDataGridCustomers.Location = new Point(0, 0);
            sfDataGridCustomers.Name = "sfDataGridCustomers";
            sfDataGridCustomers.Size = new Size(1667, 965);
            sfDataGridCustomers.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGridCustomers.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGridCustomers.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridCustomers.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridCustomers.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGridCustomers.TabIndex = 0;
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
