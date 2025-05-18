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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlRentalInfo = new System.Windows.Forms.Panel();
            this.lblVehicleInfo = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblStartMileage = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblRentalID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlReturnInfo = new System.Windows.Forms.Panel();
            this.lblReturnMileageInfo = new System.Windows.Forms.Label();
            this.lblReturnDateInfo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numReturnMileage = new System.Windows.Forms.NumericUpDown();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlRentalNote = new System.Windows.Forms.Panel();
            this.txtRentalNote = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblMileageInfo = new System.Windows.Forms.Label();
            this.pnlLateFee = new System.Windows.Forms.Panel();
            this.lblLateDays = new System.Windows.Forms.Label();
            this.lblLateFee = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCompleteReturn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlRentalInfo.SuspendLayout();
            this.pnlReturnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnMileage)).BeginInit();
            this.pnlRentalNote.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLateFee.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(76)))), ((int)(((byte)(143)))));
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(584, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(584, 60);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Rental Return Operations";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRentalInfo
            // 
            this.pnlRentalInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRentalInfo.Controls.Add(this.lblVehicleInfo);
            this.pnlRentalInfo.Controls.Add(this.lblCustomerName);
            this.pnlRentalInfo.Controls.Add(this.lblAmount);
            this.pnlRentalInfo.Controls.Add(this.lblStartMileage);
            this.pnlRentalInfo.Controls.Add(this.lblEndDate);
            this.pnlRentalInfo.Controls.Add(this.lblStartDate);
            this.pnlRentalInfo.Controls.Add(this.lblRentalID);
            this.pnlRentalInfo.Controls.Add(this.label7);
            this.pnlRentalInfo.Controls.Add(this.label6);
            this.pnlRentalInfo.Controls.Add(this.label5);
            this.pnlRentalInfo.Controls.Add(this.label4);
            this.pnlRentalInfo.Controls.Add(this.label3);
            this.pnlRentalInfo.Controls.Add(this.label2);
            this.pnlRentalInfo.Controls.Add(this.label1);
            this.pnlRentalInfo.Location = new System.Drawing.Point(12, 75);
            this.pnlRentalInfo.Name = "pnlRentalInfo";
            this.pnlRentalInfo.Size = new System.Drawing.Size(560, 160);
            this.pnlRentalInfo.TabIndex = 1;
            // 
            // lblVehicleInfo
            // 
            this.lblVehicleInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVehicleInfo.Location = new System.Drawing.Point(378, 28);
            this.lblVehicleInfo.Name = "lblVehicleInfo";
            this.lblVehicleInfo.Size = new System.Drawing.Size(167, 17);
            this.lblVehicleInfo.TabIndex = 13;
            this.lblVehicleInfo.Text = "-";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCustomerName.Location = new System.Drawing.Point(378, 3);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(167, 17);
            this.lblCustomerName.TabIndex = 12;
            this.lblCustomerName.Text = "-";
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAmount.Location = new System.Drawing.Point(378, 130);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(167, 17);
            this.lblAmount.TabIndex = 11;
            this.lblAmount.Text = "-";
            // 
            // lblStartMileage
            // 
            this.lblStartMileage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStartMileage.Location = new System.Drawing.Point(127, 130);
            this.lblStartMileage.Name = "lblStartMileage";
            this.lblStartMileage.Size = new System.Drawing.Size(130, 17);
            this.lblStartMileage.TabIndex = 10;
            this.lblStartMileage.Text = "-";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEndDate.Location = new System.Drawing.Point(127, 79);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(130, 17);
            this.lblEndDate.TabIndex = 9;
            this.lblEndDate.Text = "-";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStartDate.Location = new System.Drawing.Point(127, 54);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(130, 17);
            this.lblStartDate.TabIndex = 8;
            this.lblStartDate.Text = "-";
            // 
            // lblRentalID
            // 
            this.lblRentalID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRentalID.Location = new System.Drawing.Point(127, 29);
            this.lblRentalID.Name = "lblRentalID";
            this.lblRentalID.Size = new System.Drawing.Size(130, 17);
            this.lblRentalID.TabIndex = 7;
            this.lblRentalID.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(277, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Rental Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(277, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vehicle (Plate):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(277, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Customer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(10, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start Mileage:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(10, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rental ID:";
            // 
            // pnlReturnInfo
            // 
            this.pnlReturnInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReturnInfo.Controls.Add(this.lblReturnMileageInfo);
            this.pnlReturnInfo.Controls.Add(this.lblReturnDateInfo);
            this.pnlReturnInfo.Controls.Add(this.label13);
            this.pnlReturnInfo.Controls.Add(this.label12);
            this.pnlReturnInfo.Controls.Add(this.numReturnMileage);
            this.pnlReturnInfo.Controls.Add(this.dtpReturnDate);
            this.pnlReturnInfo.Controls.Add(this.label10);
            this.pnlReturnInfo.Controls.Add(this.label9);
            this.pnlReturnInfo.Controls.Add(this.lblStatus);
            this.pnlReturnInfo.Location = new System.Drawing.Point(12, 241);
            this.pnlReturnInfo.Name = "pnlReturnInfo";
            this.pnlReturnInfo.Size = new System.Drawing.Size(560, 100);
            this.pnlReturnInfo.TabIndex = 2;
            // 
            // lblReturnMileageInfo
            // 
            this.lblReturnMileageInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReturnMileageInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblReturnMileageInfo.Location = new System.Drawing.Point(378, 68);
            this.lblReturnMileageInfo.Name = "lblReturnMileageInfo";
            this.lblReturnMileageInfo.Size = new System.Drawing.Size(167, 17);
            this.lblReturnMileageInfo.TabIndex = 11;
            this.lblReturnMileageInfo.Text = "-";
            // 
            // lblReturnDateInfo
            // 
            this.lblReturnDateInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReturnDateInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblReturnDateInfo.Location = new System.Drawing.Point(378, 37);
            this.lblReturnDateInfo.Name = "lblReturnDateInfo";
            this.lblReturnDateInfo.Size = new System.Drawing.Size(167, 17);
            this.lblReturnDateInfo.TabIndex = 10;
            this.lblReturnDateInfo.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(277, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "Return Mileage:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(277, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "Return Date:";
            // 
            // numReturnMileage
            // 
            this.numReturnMileage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numReturnMileage.Location = new System.Drawing.Point(127, 66);
            this.numReturnMileage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numReturnMileage.Name = "numReturnMileage";
            this.numReturnMileage.Size = new System.Drawing.Size(130, 25);
            this.numReturnMileage.TabIndex = 7;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(127, 32);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(130, 25);
            this.dtpReturnDate.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(10, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "Return Mileage:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(10, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Return Date:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(127, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(102, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Rental is active";
            // 
            // pnlRentalNote
            // 
            this.pnlRentalNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRentalNote.Controls.Add(this.txtRentalNote);
            this.pnlRentalNote.Controls.Add(this.label17);
            this.pnlRentalNote.Location = new System.Drawing.Point(12, 347);
            this.pnlRentalNote.Name = "pnlRentalNote";
            this.pnlRentalNote.Size = new System.Drawing.Size(560, 80);
            this.pnlRentalNote.TabIndex = 3;
            // 
            // txtRentalNote
            // 
            this.txtRentalNote.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRentalNote.Location = new System.Drawing.Point(127, 5);
            this.txtRentalNote.Multiline = true;
            this.txtRentalNote.Name = "txtRentalNote";
            this.txtRentalNote.Size = new System.Drawing.Size(418, 68);
            this.txtRentalNote.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(10, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "Return Note:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblMileageInfo);
            this.panel1.Controls.Add(this.pnlLateFee);
            this.panel1.Location = new System.Drawing.Point(12, 433);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 61);
            this.panel1.TabIndex = 4;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalAmount.Location = new System.Drawing.Point(378, 29);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(167, 21);
            this.lblTotalAmount.TabIndex = 14;
            this.lblTotalAmount.Text = "0.00 ₺";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(277, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 21);
            this.label16.TabIndex = 13;
            this.label16.Text = "Total:";
            // 
            // lblMileageInfo
            // 
            this.lblMileageInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMileageInfo.Location = new System.Drawing.Point(10, 10);
            this.lblMileageInfo.Name = "lblMileageInfo";
            this.lblMileageInfo.Size = new System.Drawing.Size(246, 17);
            this.lblMileageInfo.TabIndex = 12;
            this.lblMileageInfo.Text = "Driven distance: 0 KM";
            // 
            // pnlLateFee
            // 
            this.pnlLateFee.Controls.Add(this.lblLateDays);
            this.pnlLateFee.Controls.Add(this.lblLateFee);
            this.pnlLateFee.Controls.Add(this.label15);
            this.pnlLateFee.Location = new System.Drawing.Point(277, 3);
            this.pnlLateFee.Name = "pnlLateFee";
            this.pnlLateFee.Size = new System.Drawing.Size(268, 23);
            this.pnlLateFee.TabIndex = 0;
            this.pnlLateFee.Visible = false;
            // 
            // lblLateDays
            // 
            this.lblLateDays.AutoSize = true;
            this.lblLateDays.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblLateDays.ForeColor = System.Drawing.Color.Maroon;
            this.lblLateDays.Location = new System.Drawing.Point(163, 3);
            this.lblLateDays.Name = "lblLateDays";
            this.lblLateDays.Size = new System.Drawing.Size(68, 15);
            this.lblLateDays.TabIndex = 2;
            this.lblLateDays.Text = "0 days late";
            // 
            // lblLateFee
            // 
            this.lblLateFee.AutoSize = true;
            this.lblLateFee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLateFee.ForeColor = System.Drawing.Color.Maroon;
            this.lblLateFee.Location = new System.Drawing.Point(101, 3);
            this.lblLateFee.Name = "lblLateFee";
            this.lblLateFee.Size = new System.Drawing.Size(38, 15);
            this.lblLateFee.TabIndex = 1;
            this.lblLateFee.Text = "0.00 ₺";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(3, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Late Return Fee:";
            // 
            // btnCompleteReturn
            // 
            this.btnCompleteReturn.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCompleteReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteReturn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCompleteReturn.ForeColor = System.Drawing.Color.White;
            this.btnCompleteReturn.Location = new System.Drawing.Point(12, 500);
            this.btnCompleteReturn.Name = "btnCompleteReturn";
            this.btnCompleteReturn.Size = new System.Drawing.Size(214, 35);
            this.btnCompleteReturn.TabIndex = 5;
            this.btnCompleteReturn.Text = "Complete Return";
            this.btnCompleteReturn.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(358, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // RentalOperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 547);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCompleteReturn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlRentalNote);
            this.Controls.Add(this.pnlReturnInfo);
            this.Controls.Add(this.pnlRentalInfo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RentalOperationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rental Operations";
            this.pnlHeader.ResumeLayout(false);
            this.pnlRentalInfo.ResumeLayout(false);
            this.pnlRentalInfo.PerformLayout();
            this.pnlReturnInfo.ResumeLayout(false);
            this.pnlReturnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnMileage)).EndInit();
            this.pnlRentalNote.ResumeLayout(false);
            this.pnlRentalNote.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLateFee.ResumeLayout(false);
            this.pnlLateFee.PerformLayout();
            this.ResumeLayout(false);

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