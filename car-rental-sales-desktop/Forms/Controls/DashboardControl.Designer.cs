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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            pnlCards.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCards
            // 
            pnlCards.Controls.Add(panel5);
            pnlCards.Controls.Add(panel4);
            pnlCards.Controls.Add(panel3);
            pnlCards.Controls.Add(panel2);
            pnlCards.Controls.Add(panel1);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(50, 50);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new Size(1570, 300);
            pnlCards.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 300);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(314, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(314, 300);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(628, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(314, 300);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(942, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(314, 300);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(1256, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(314, 300);
            panel5.TabIndex = 4;
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
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
    }
}
