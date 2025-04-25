namespace car_rental_sales_desktop.Forms.Controls
{
    partial class DashboardControl
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
            pnlCards = new Panel();
            pnlRentCard1 = new Panel();
            pnlRentCard2 = new Panel();
            pnlRentCard3 = new Panel();
            pnlRentCard4 = new Panel();
            pnlRentCard5 = new Panel();
            pnlCards.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCards
            // 
            pnlCards.Controls.Add(pnlRentCard5);
            pnlCards.Controls.Add(pnlRentCard4);
            pnlCards.Controls.Add(pnlRentCard3);
            pnlCards.Controls.Add(pnlRentCard2);
            pnlCards.Controls.Add(pnlRentCard1);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(50, 50);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new Size(1570, 300);
            pnlCards.TabIndex = 0;
            // 
            // pnlRentCard1
            // 
            pnlRentCard1.Dock = DockStyle.Left;
            pnlRentCard1.Location = new Point(0, 0);
            pnlRentCard1.Name = "pnlRentCard1";
            pnlRentCard1.Size = new Size(314, 300);
            pnlRentCard1.TabIndex = 0;
            // 
            // pnlRentCard2
            // 
            pnlRentCard2.Dock = DockStyle.Left;
            pnlRentCard2.Location = new Point(314, 0);
            pnlRentCard2.Name = "pnlRentCard2";
            pnlRentCard2.Size = new Size(314, 300);
            pnlRentCard2.TabIndex = 1;
            // 
            // pnlRentCard3
            // 
            pnlRentCard3.Dock = DockStyle.Left;
            pnlRentCard3.Location = new Point(628, 0);
            pnlRentCard3.Name = "pnlRentCard3";
            pnlRentCard3.Size = new Size(314, 300);
            pnlRentCard3.TabIndex = 2;
            // 
            // pnlRentCard4
            // 
            pnlRentCard4.Dock = DockStyle.Left;
            pnlRentCard4.Location = new Point(942, 0);
            pnlRentCard4.Name = "pnlRentCard4";
            pnlRentCard4.Size = new Size(314, 300);
            pnlRentCard4.TabIndex = 3;
            // 
            // pnlRentCard5
            // 
            pnlRentCard5.Dock = DockStyle.Left;
            pnlRentCard5.Location = new Point(1256, 0);
            pnlRentCard5.Name = "pnlRentCard5";
            pnlRentCard5.Size = new Size(314, 300);
            pnlRentCard5.TabIndex = 4;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlCards);
            Name = "DashboardControl";
            Padding = new Padding(50);
            Size = new Size(1670, 1000);
            pnlCards.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCards;
        private Panel pnlRentCard5;
        private Panel pnlRentCard4;
        private Panel pnlRentCard3;
        private Panel pnlRentCard2;
        private Panel pnlRentCard1;
    }
}
