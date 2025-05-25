namespace car_rental_sales_desktop.Forms
{
    partial class RentalOperationsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            pnlRentalInfo = new Panel();
            lblVehicleInfo = new Label();
            lblCustomerName = new Label();
            lblAmount = new Label();
            lblStartMileage = new Label();
            lblEndDate = new Label();
            lblStartDate = new Label();
            lblRentalID = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pnlReturnInfo = new Panel();
            lblReturnMileageInfo = new Label();
            lblReturnDateInfo = new Label();
            label13 = new Label();
            label12 = new Label();
            numReturnMileage = new NumericUpDown();
            dtpReturnDate = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            lblStatus = new Label();
            pnlRentalNote = new Panel();
            txtRentalNote = new TextBox();
            label17 = new Label();
            panel1 = new Panel();
            lblTotalAmount = new Label();
            label16 = new Label();
            lblMileageInfo = new Label();
            pnlLateFee = new Panel();
            lblLateDays = new Label();
            lblLateFee = new Label();
            label15 = new Label();
            btnCompleteReturn = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            pnlRentalInfo.SuspendLayout();
            pnlReturnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numReturnMileage).BeginInit();
            pnlRentalNote.SuspendLayout();
            panel1.SuspendLayout();
            pnlLateFee.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(49, 76, 143);
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(584, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.Dock = DockStyle.Fill;
            lblFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(0, 0);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(584, 60);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Rental Return Operations";
            lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRentalInfo
            // 
            pnlRentalInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlRentalInfo.Controls.Add(lblVehicleInfo);
            pnlRentalInfo.Controls.Add(lblCustomerName);
            pnlRentalInfo.Controls.Add(lblAmount);
            pnlRentalInfo.Controls.Add(lblStartMileage);
            pnlRentalInfo.Controls.Add(lblEndDate);
            pnlRentalInfo.Controls.Add(lblStartDate);
            pnlRentalInfo.Controls.Add(lblRentalID);
            pnlRentalInfo.Controls.Add(label7);
            pnlRentalInfo.Controls.Add(label6);
            pnlRentalInfo.Controls.Add(label5);
            pnlRentalInfo.Controls.Add(label4);
            pnlRentalInfo.Controls.Add(label3);
            pnlRentalInfo.Controls.Add(label2);
            pnlRentalInfo.Controls.Add(label1);
            pnlRentalInfo.Location = new Point(12, 75);
            pnlRentalInfo.Name = "pnlRentalInfo";
            pnlRentalInfo.Size = new Size(560, 160);
            pnlRentalInfo.TabIndex = 1;
            // 
            // lblVehicleInfo
            // 
            lblVehicleInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblVehicleInfo.Location = new Point(378, 28);
            lblVehicleInfo.Name = "lblVehicleInfo";
            lblVehicleInfo.Size = new Size(167, 17);
            lblVehicleInfo.TabIndex = 13;
            lblVehicleInfo.Text = "-";
            // 
            // lblCustomerName
            // 
            lblCustomerName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblCustomerName.Location = new Point(378, 3);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(167, 17);
            lblCustomerName.TabIndex = 12;
            lblCustomerName.Text = "-";
            // 
            // lblAmount
            // 
            lblAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblAmount.Location = new Point(378, 130);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(167, 17);
            lblAmount.TabIndex = 11;
            lblAmount.Text = "-";
            // 
            // lblStartMileage
            // 
            lblStartMileage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblStartMileage.Location = new Point(127, 130);
            lblStartMileage.Name = "lblStartMileage";
            lblStartMileage.Size = new Size(130, 17);
            lblStartMileage.TabIndex = 10;
            lblStartMileage.Text = "-";
            // 
            // lblEndDate
            // 
            lblEndDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblEndDate.Location = new Point(127, 79);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(130, 17);
            lblEndDate.TabIndex = 9;
            lblEndDate.Text = "-";
            // 
            // lblStartDate
            // 
            lblStartDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblStartDate.Location = new Point(127, 54);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(130, 17);
            lblStartDate.TabIndex = 8;
            lblStartDate.Text = "-";
            // 
            // lblRentalID
            // 
            lblRentalID.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblRentalID.Location = new Point(127, 29);
            lblRentalID.Name = "lblRentalID";
            lblRentalID.Size = new Size(130, 17);
            lblRentalID.TabIndex = 7;
            lblRentalID.Text = "-";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(277, 130);
            label7.Name = "label7";
            label7.Size = new Size(96, 17);
            label7.TabIndex = 6;
            label7.Text = "Rental Amount:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(277, 28);
            label6.Name = "label6";
            label6.Size = new Size(91, 17);
            label6.TabIndex = 5;
            label6.Text = "Vehicle (Plate):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(277, 3);
            label5.Name = "label5";
            label5.Size = new Size(67, 17);
            label5.TabIndex = 4;
            label5.Text = "Customer:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(10, 130);
            label4.Name = "label4";
            label4.Size = new Size(89, 17);
            label4.TabIndex = 3;
            label4.Text = "Start Mileage:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(10, 79);
            label3.Name = "label3";
            label3.Size = new Size(64, 17);
            label3.TabIndex = 2;
            label3.Text = "End Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(10, 54);
            label2.Name = "label2";
            label2.Size = new Size(69, 17);
            label2.TabIndex = 1;
            label2.Text = "Start Date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(10, 29);
            label1.Name = "label1";
            label1.Size = new Size(63, 17);
            label1.TabIndex = 0;
            label1.Text = "Rental ID:";
            // 
            // pnlReturnInfo
            // 
            pnlReturnInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlReturnInfo.Controls.Add(lblReturnMileageInfo);
            pnlReturnInfo.Controls.Add(lblReturnDateInfo);
            pnlReturnInfo.Controls.Add(label13);
            pnlReturnInfo.Controls.Add(label12);
            pnlReturnInfo.Controls.Add(numReturnMileage);
            pnlReturnInfo.Controls.Add(dtpReturnDate);
            pnlReturnInfo.Controls.Add(label10);
            pnlReturnInfo.Controls.Add(label9);
            pnlReturnInfo.Controls.Add(lblStatus);
            pnlReturnInfo.Location = new Point(12, 241);
            pnlReturnInfo.Name = "pnlReturnInfo";
            pnlReturnInfo.Size = new Size(560, 100);
            pnlReturnInfo.TabIndex = 2;
            // 
            // lblReturnMileageInfo
            // 
            lblReturnMileageInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblReturnMileageInfo.ForeColor = Color.DarkBlue;
            lblReturnMileageInfo.Location = new Point(378, 68);
            lblReturnMileageInfo.Name = "lblReturnMileageInfo";
            lblReturnMileageInfo.Size = new Size(167, 17);
            lblReturnMileageInfo.TabIndex = 11;
            lblReturnMileageInfo.Text = "-";
            // 
            // lblReturnDateInfo
            // 
            lblReturnDateInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblReturnDateInfo.ForeColor = Color.DarkBlue;
            lblReturnDateInfo.Location = new Point(378, 37);
            lblReturnDateInfo.Name = "lblReturnDateInfo";
            lblReturnDateInfo.Size = new Size(167, 17);
            lblReturnDateInfo.TabIndex = 10;
            lblReturnDateInfo.Text = "-";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F);
            label13.Location = new Point(277, 68);
            label13.Name = "label13";
            label13.Size = new Size(100, 17);
            label13.TabIndex = 9;
            label13.Text = "Return Mileage:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F);
            label12.Location = new Point(277, 37);
            label12.Name = "label12";
            label12.Size = new Size(80, 17);
            label12.TabIndex = 8;
            label12.Text = "Return Date:";
            // 
            // numReturnMileage
            // 
            numReturnMileage.Font = new Font("Segoe UI", 9.75F);
            numReturnMileage.Location = new Point(127, 66);
            numReturnMileage.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numReturnMileage.Name = "numReturnMileage";
            numReturnMileage.Size = new Size(130, 25);
            numReturnMileage.TabIndex = 7;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Font = new Font("Segoe UI", 9.75F);
            dtpReturnDate.Format = DateTimePickerFormat.Short;
            dtpReturnDate.Location = new Point(127, 32);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(130, 25);
            dtpReturnDate.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F);
            label10.Location = new Point(10, 68);
            label10.Name = "label10";
            label10.Size = new Size(100, 17);
            label10.TabIndex = 5;
            label10.Text = "Return Mileage:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.Location = new Point(10, 37);
            label9.Name = "label9";
            label9.Size = new Size(80, 17);
            label9.TabIndex = 4;
            label9.Text = "Return Date:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblStatus.Location = new Point(127, 5);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(101, 17);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Rental is active";
            // 
            // pnlRentalNote
            // 
            pnlRentalNote.BorderStyle = BorderStyle.FixedSingle;
            pnlRentalNote.Controls.Add(txtRentalNote);
            pnlRentalNote.Controls.Add(label17);
            pnlRentalNote.Location = new Point(12, 347);
            pnlRentalNote.Name = "pnlRentalNote";
            pnlRentalNote.Size = new Size(560, 80);
            pnlRentalNote.TabIndex = 3;
            // 
            // txtRentalNote
            // 
            txtRentalNote.Font = new Font("Segoe UI", 9.75F);
            txtRentalNote.Location = new Point(127, 5);
            txtRentalNote.Multiline = true;
            txtRentalNote.Name = "txtRentalNote";
            txtRentalNote.Size = new Size(418, 68);
            txtRentalNote.TabIndex = 1;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9.75F);
            label17.Location = new Point(10, 8);
            label17.Name = "label17";
            label17.Size = new Size(82, 17);
            label17.TabIndex = 0;
            label17.Text = "Return Note:";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblTotalAmount);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(lblMileageInfo);
            panel1.Controls.Add(pnlLateFee);
            panel1.Location = new Point(12, 433);
            panel1.Name = "panel1";
            panel1.Size = new Size(560, 61);
            panel1.TabIndex = 4;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.DarkGreen;
            lblTotalAmount.Location = new Point(378, 29);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(167, 21);
            lblTotalAmount.TabIndex = 14;
            lblTotalAmount.Text = "0.00 ₺";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label16.Location = new Point(277, 29);
            label16.Name = "label16";
            label16.Size = new Size(52, 21);
            label16.TabIndex = 13;
            label16.Text = "Total:";
            // 
            // lblMileageInfo
            // 
            lblMileageInfo.Font = new Font("Segoe UI", 9.75F);
            lblMileageInfo.Location = new Point(10, 10);
            lblMileageInfo.Name = "lblMileageInfo";
            lblMileageInfo.Size = new Size(246, 17);
            lblMileageInfo.TabIndex = 12;
            lblMileageInfo.Text = "Driven distance: 0 KM";
            // 
            // pnlLateFee
            // 
            pnlLateFee.Controls.Add(lblLateDays);
            pnlLateFee.Controls.Add(lblLateFee);
            pnlLateFee.Controls.Add(label15);
            pnlLateFee.Location = new Point(277, 3);
            pnlLateFee.Name = "pnlLateFee";
            pnlLateFee.Size = new Size(268, 23);
            pnlLateFee.TabIndex = 0;
            pnlLateFee.Visible = false;
            // 
            // lblLateDays
            // 
            lblLateDays.AutoSize = true;
            lblLateDays.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblLateDays.ForeColor = Color.Maroon;
            lblLateDays.Location = new Point(163, 3);
            lblLateDays.Name = "lblLateDays";
            lblLateDays.Size = new Size(64, 15);
            lblLateDays.TabIndex = 2;
            lblLateDays.Text = "0 days late";
            // 
            // lblLateFee
            // 
            lblLateFee.AutoSize = true;
            lblLateFee.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLateFee.ForeColor = Color.Maroon;
            lblLateFee.Location = new Point(101, 3);
            lblLateFee.Name = "lblLateFee";
            lblLateFee.Size = new Size(41, 15);
            lblLateFee.TabIndex = 1;
            lblLateFee.Text = "0.00 ₺";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F);
            label15.Location = new Point(3, 3);
            label15.Name = "label15";
            label15.Size = new Size(91, 15);
            label15.TabIndex = 0;
            label15.Text = "Late Return Fee:";
            // 
            // btnCompleteReturn
            // 
            btnCompleteReturn.BackColor = Color.ForestGreen;
            btnCompleteReturn.FlatStyle = FlatStyle.Flat;
            btnCompleteReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCompleteReturn.ForeColor = Color.White;
            btnCompleteReturn.Location = new Point(12, 500);
            btnCompleteReturn.Name = "btnCompleteReturn";
            btnCompleteReturn.Size = new Size(214, 35);
            btnCompleteReturn.TabIndex = 5;
            btnCompleteReturn.Text = "Complete Return";
            btnCompleteReturn.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkGray;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(358, 500);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(214, 35);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // RentalOperationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 547);
            Controls.Add(btnCancel);
            Controls.Add(btnCompleteReturn);
            Controls.Add(panel1);
            Controls.Add(pnlRentalNote);
            Controls.Add(pnlReturnInfo);
            Controls.Add(pnlRentalInfo);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RentalOperationsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rental Operations";
            pnlHeader.ResumeLayout(false);
            pnlRentalInfo.ResumeLayout(false);
            pnlRentalInfo.PerformLayout();
            pnlReturnInfo.ResumeLayout(false);
            pnlReturnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numReturnMileage).EndInit();
            pnlRentalNote.ResumeLayout(false);
            pnlRentalNote.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlLateFee.ResumeLayout(false);
            pnlLateFee.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlRentalInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVehicleInfo;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblStartMileage;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblRentalID;
        private System.Windows.Forms.Panel pnlReturnInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.NumericUpDown numReturnMileage;
        private System.Windows.Forms.Label lblReturnMileageInfo;
        private System.Windows.Forms.Label lblReturnDateInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlRentalNote;
        private System.Windows.Forms.TextBox txtRentalNote;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlLateFee;
        private System.Windows.Forms.Label lblLateDays;
        private System.Windows.Forms.Label lblLateFee;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblMileageInfo;
        private System.Windows.Forms.Button btnCompleteReturn;
        private System.Windows.Forms.Button btnCancel;
    }
}