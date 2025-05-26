namespace car_rental_sales_desktop.Forms
{
    partial class RentalApprovalForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlInfo;
        private Label lblRentalId;
        private Label lblCustomerName;
        private Label lblVehicle;
        private Label lblAmount;
        private Label lblDates;
        private Label lblStaff;
        private Panel pnlSignatures;
        private Label lblStaffSignature;
        private TextBox txtStaffName;
        private Label lblCustomerSignature;
        private TextBox txtCustomerName;
        private Button btnConfirm;
        private Button btnCancel;

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
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlInfo = new Panel();
            this.lblRentalId = new Label();
            this.lblCustomerName = new Label();
            this.lblVehicle = new Label();
            this.lblAmount = new Label();
            this.lblDates = new Label();
            this.lblStaff = new Label();
            this.pnlSignatures = new Panel();
            this.lblStaffSignature = new Label();
            this.txtStaffName = new TextBox();
            this.lblCustomerSignature = new Label();
            this.txtCustomerName = new TextBox();
            this.btnConfirm = new Button();
            this.btnCancel = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlSignatures.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(49, 76, 143);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(500, 60);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(500, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kiralama Sözleşme Onayı";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlInfo
            this.pnlInfo.BackColor = Color.White;
            this.pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblStaff);
            this.pnlInfo.Controls.Add(this.lblDates);
            this.pnlInfo.Controls.Add(this.lblAmount);
            this.pnlInfo.Controls.Add(this.lblVehicle);
            this.pnlInfo.Controls.Add(this.lblCustomerName);
            this.pnlInfo.Controls.Add(this.lblRentalId);
            this.pnlInfo.Location = new Point(20, 80);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new Size(460, 200);
            this.pnlInfo.TabIndex = 1;

            // Labels in pnlInfo
            this.lblRentalId.AutoSize = true;
            this.lblRentalId.Font = new Font("Segoe UI", 10F);
            this.lblRentalId.Location = new Point(20, 20);
            this.lblRentalId.Name = "lblRentalId";
            this.lblRentalId.Size = new Size(80, 19);
            this.lblRentalId.TabIndex = 0;
            this.lblRentalId.Text = "Kiralama ID:";

            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new Font("Segoe UI", 10F);
            this.lblCustomerName.Location = new Point(20, 50);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new Size(60, 19);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Müşteri:";

            this.lblVehicle.AutoSize = true;
            this.lblVehicle.Font = new Font("Segoe UI", 10F);
            this.lblVehicle.Location = new Point(20, 80);
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new Size(40, 19);
            this.lblVehicle.TabIndex = 2;
            this.lblVehicle.Text = "Araç:";

            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new Font("Segoe UI", 10F);
            this.lblAmount.Location = new Point(20, 110);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new Size(45, 19);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Tutar:";

            this.lblDates.AutoSize = true;
            this.lblDates.Font = new Font("Segoe UI", 10F);
            this.lblDates.Location = new Point(20, 140);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new Size(42, 19);
            this.lblDates.TabIndex = 4;
            this.lblDates.Text = "Tarih:";

            this.lblStaff.AutoSize = true;
            this.lblStaff.Font = new Font("Segoe UI", 10F);
            this.lblStaff.Location = new Point(20, 170);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new Size(50, 19);
            this.lblStaff.TabIndex = 5;
            this.lblStaff.Text = "Yetkili:";

            // pnlSignatures
            this.pnlSignatures.BackColor = Color.White;
            this.pnlSignatures.BorderStyle = BorderStyle.FixedSingle;
            this.pnlSignatures.Controls.Add(this.txtCustomerName);
            this.pnlSignatures.Controls.Add(this.lblCustomerSignature);
            this.pnlSignatures.Controls.Add(this.txtStaffName);
            this.pnlSignatures.Controls.Add(this.lblStaffSignature);
            this.pnlSignatures.Location = new Point(20, 300);
            this.pnlSignatures.Name = "pnlSignatures";
            this.pnlSignatures.Size = new Size(460, 120);
            this.pnlSignatures.TabIndex = 2;

            // lblStaffSignature
            this.lblStaffSignature.AutoSize = true;
            this.lblStaffSignature.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStaffSignature.Location = new Point(20, 20);
            this.lblStaffSignature.Name = "lblStaffSignature";
            this.lblStaffSignature.Size = new Size(145, 19);
            this.lblStaffSignature.TabIndex = 0;
            this.lblStaffSignature.Text = "Yetkili İmza (Ad Soyad):";

            // txtStaffName
            this.txtStaffName.Font = new Font("Segoe UI", 10F);
            this.txtStaffName.Location = new Point(20, 45);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new Size(200, 25);
            this.txtStaffName.TabIndex = 1;

            // lblCustomerSignature
            this.lblCustomerSignature.AutoSize = true;
            this.lblCustomerSignature.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCustomerSignature.Location = new Point(240, 20);
            this.lblCustomerSignature.Name = "lblCustomerSignature";
            this.lblCustomerSignature.Size = new Size(151, 19);
            this.lblCustomerSignature.TabIndex = 2;
            this.lblCustomerSignature.Text = "Müşteri İmza (Ad Soyad):";

            // txtCustomerName
            this.txtCustomerName.Font = new Font("Segoe UI", 10F);
            this.txtCustomerName.Location = new Point(240, 45);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new Size(200, 25);
            this.txtCustomerName.TabIndex = 3;

            // btnConfirm
            this.btnConfirm.BackColor = Color.ForestGreen;
            this.btnConfirm.FlatStyle = FlatStyle.Flat;
            this.btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnConfirm.ForeColor = Color.White;
            this.btnConfirm.Location = new Point(150, 440);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new Size(120, 40);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Onayla";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new EventHandler(this.btnConfirm_Click);

            // btnCancel
            this.btnCancel.BackColor = Color.Gray;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(280, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(120, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // RentalApprovalForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 250);
            this.ClientSize = new Size(500, 500);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pnlSignatures);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "RentalApprovalForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Kiralama Onay";

            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlSignatures.ResumeLayout(false);
            this.pnlSignatures.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}