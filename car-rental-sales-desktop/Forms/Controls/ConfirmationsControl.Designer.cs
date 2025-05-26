namespace car_rental_sales_desktop.Forms.Controls
{
    partial class ConfirmationsControl
    {
        private System.ComponentModel.IContainer components = null;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridPending;
        private Panel pnlTop;
        private Panel pnlStats;
        private Panel pnlActions;
        private Label lblTitle;
        private Label lblPendingCount;
        private Label lblTodayCount;
        private Button btnApprove;
        private Button btnReject;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.sfDataGridPending = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.pnlTop = new Panel();
            this.pnlStats = new Panel();
            this.pnlActions = new Panel();
            this.lblTitle = new Label();
            this.lblPendingCount = new Label();
            this.lblTodayCount = new Label();
            this.btnApprove = new Button();
            this.btnReject = new Button();
            this.btnRefresh = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridPending)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = Color.White;
            this.pnlTop.Controls.Add(this.pnlActions);
            this.pnlTop.Controls.Add(this.pnlStats);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(20, 20);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(1160, 120);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(49, 76, 143);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(250, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Rental Confirmations";

            // pnlStats
            this.pnlStats.Dock = DockStyle.Right;
            this.pnlStats.Location = new Point(800, 0);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new Size(360, 120);
            this.pnlStats.TabIndex = 1;

            // lblPendingCount
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Font = new Font("Segoe UI", 12F);
            this.lblPendingCount.Location = new Point(20, 30);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new Size(120, 21);
            this.lblPendingCount.TabIndex = 0;
            this.lblPendingCount.Text = "Onay Bekleyen: 0";

            // lblTodayCount
            this.lblTodayCount.AutoSize = true;
            this.lblTodayCount.Font = new Font("Segoe UI", 12F);
            this.lblTodayCount.Location = new Point(20, 60);
            this.lblTodayCount.Name = "lblTodayCount";
            this.lblTodayCount.Size = new Size(140, 21);
            this.lblTodayCount.TabIndex = 1;
            this.lblTodayCount.Text = "Bugün Oluşturulan: 0";

            this.pnlStats.Controls.Add(this.lblPendingCount);
            this.pnlStats.Controls.Add(this.lblTodayCount);

            // pnlActions
            this.pnlActions.Location = new Point(20, 70);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new Size(500, 40);
            this.pnlActions.TabIndex = 2;

            // btnApprove
            this.btnApprove.BackColor = Color.ForestGreen;
            this.btnApprove.FlatStyle = FlatStyle.Flat;
            this.btnApprove.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnApprove.ForeColor = Color.White;
            this.btnApprove.Location = new Point(0, 0);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new Size(120, 35);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new EventHandler(this.btnApprove_Click);

            // btnReject
            this.btnReject.BackColor = Color.Crimson;
            this.btnReject.FlatStyle = FlatStyle.Flat;
            this.btnReject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnReject.ForeColor = Color.White;
            this.btnReject.Location = new Point(130, 0);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new Size(120, 35);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new EventHandler(this.btnReject_Click);

            // btnRefresh
            this.btnRefresh.BackColor = Color.DodgerBlue;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(260, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(120, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            this.pnlActions.Controls.Add(this.btnApprove);
            this.pnlActions.Controls.Add(this.btnReject);
            this.pnlActions.Controls.Add(this.btnRefresh);

            // sfDataGridPending
            this.sfDataGridPending.AccessibleName = "Table";
            this.sfDataGridPending.AllowEditing = false;
            this.sfDataGridPending.Dock = DockStyle.Fill;
            this.sfDataGridPending.Location = new Point(20, 140);
            this.sfDataGridPending.Name = "sfDataGridPending";
            this.sfDataGridPending.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            this.sfDataGridPending.Size = new Size(1160, 540);
            this.sfDataGridPending.TabIndex = 1;
            this.sfDataGridPending.QueryRowStyle += new Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventHandler(this.sfDataGridPending_QueryRowStyle);

            // ConfirmationsControl
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 250);
            this.Controls.Add(this.sfDataGridPending);
            this.Controls.Add(this.pnlTop);
            this.Name = "ConfirmationsControl";
            this.Padding = new Padding(20);
            this.Size = new Size(1200, 700);

            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridPending)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}