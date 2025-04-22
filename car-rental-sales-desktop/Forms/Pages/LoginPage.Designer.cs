namespace car_rental_sales_desktop.Forms.Pages
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            pnlContent = new Panel();
            lblStatus = new Label();
            lblVersion = new Label();
            LnkForgotPassword = new LinkLabel();
            BtnLogin = new Button();
            lblPleaseLogin = new Label();
            lblWelcome = new Label();
            iconClose = new FontAwesome.Sharp.IconButton();
            iconMinimize = new FontAwesome.Sharp.IconButton();
            pnlPassword = new Panel();
            BtnEye = new FontAwesome.Sharp.IconButton();
            iconPassword = new FontAwesome.Sharp.IconPictureBox();
            TxtBoxPassword = new TextBox();
            pnlUsername = new Panel();
            iconUsername = new FontAwesome.Sharp.IconPictureBox();
            TxtBoxUsername = new TextBox();
            picLogin = new PictureBox();
            pnlContent.SuspendLayout();
            pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPassword).BeginInit();
            pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconUsername).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogin).BeginInit();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(lblStatus);
            pnlContent.Controls.Add(lblVersion);
            pnlContent.Controls.Add(LnkForgotPassword);
            pnlContent.Controls.Add(BtnLogin);
            pnlContent.Controls.Add(lblPleaseLogin);
            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Controls.Add(iconClose);
            pnlContent.Controls.Add(iconMinimize);
            pnlContent.Controls.Add(pnlPassword);
            pnlContent.Controls.Add(pnlUsername);
            pnlContent.Dock = DockStyle.Right;
            pnlContent.Location = new Point(350, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(450, 600);
            pnlContent.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(220, 53, 69);
            lblStatus.Location = new Point(50, 513);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(350, 20);
            lblStatus.TabIndex = 11;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(266, 581);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(180, 15);
            lblVersion.TabIndex = 10;
            lblVersion.Text = "Car Rental and Sales - Version 1.0";
            // 
            // LnkForgotPassword
            // 
            LnkForgotPassword.ActiveLinkColor = Color.FromArgb(26, 115, 232);
            LnkForgotPassword.AutoSize = true;
            LnkForgotPassword.Font = new Font("Segoe UI", 10F);
            LnkForgotPassword.LinkColor = Color.FromArgb(49, 76, 143);
            LnkForgotPassword.Location = new Point(285, 378);
            LnkForgotPassword.Name = "LnkForgotPassword";
            LnkForgotPassword.Size = new Size(112, 19);
            LnkForgotPassword.TabIndex = 5;
            LnkForgotPassword.TabStop = true;
            LnkForgotPassword.Text = "Forgot Password";
            LnkForgotPassword.TextAlign = ContentAlignment.MiddleRight;
            LnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.FromArgb(49, 76, 143);
            BtnLogin.FlatAppearance.BorderSize = 0;
            BtnLogin.FlatStyle = FlatStyle.Flat;
            BtnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnLogin.ForeColor = Color.White;
            BtnLogin.Location = new Point(50, 449);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(350, 50);
            BtnLogin.TabIndex = 6;
            BtnLogin.Text = "Login";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += btnLogin_Click;
            // 
            // lblPleaseLogin
            // 
            lblPleaseLogin.AutoSize = true;
            lblPleaseLogin.Font = new Font("Segoe UI", 12F);
            lblPleaseLogin.ForeColor = Color.Gray;
            lblPleaseLogin.Location = new Point(37, 216);
            lblPleaseLogin.Name = "lblPleaseLogin";
            lblPleaseLogin.Size = new Size(377, 21);
            lblPleaseLogin.TabIndex = 5;
            lblPleaseLogin.Text = "Please enter your information to log in to the system.";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(49, 76, 143);
            lblWelcome.Location = new Point(127, 102);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(197, 54);
            lblWelcome.TabIndex = 4;
            lblWelcome.Text = "Welcome";
            // 
            // iconClose
            // 
            iconClose.BackColor = Color.Transparent;
            iconClose.FlatAppearance.BorderSize = 0;
            iconClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            iconClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            iconClose.FlatStyle = FlatStyle.Flat;
            iconClose.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            iconClose.IconColor = Color.FromArgb(49, 76, 143);
            iconClose.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconClose.IconSize = 30;
            iconClose.Location = new Point(417, 3);
            iconClose.Name = "iconClose";
            iconClose.Size = new Size(30, 30);
            iconClose.TabIndex = 8;
            iconClose.UseVisualStyleBackColor = false;
            iconClose.Click += iconClose_Click;
            // 
            // iconMinimize
            // 
            iconMinimize.BackColor = Color.Transparent;
            iconMinimize.FlatAppearance.BorderSize = 0;
            iconMinimize.FlatAppearance.MouseDownBackColor = Color.Transparent;
            iconMinimize.FlatAppearance.MouseOverBackColor = Color.Transparent;
            iconMinimize.FlatStyle = FlatStyle.Flat;
            iconMinimize.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            iconMinimize.IconColor = Color.FromArgb(49, 76, 143);
            iconMinimize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconMinimize.IconSize = 30;
            iconMinimize.Location = new Point(381, 3);
            iconMinimize.Name = "iconMinimize";
            iconMinimize.Size = new Size(30, 30);
            iconMinimize.TabIndex = 7;
            iconMinimize.UseVisualStyleBackColor = false;
            iconMinimize.Click += iconMinimize_Click;
            // 
            // pnlPassword
            // 
            pnlPassword.BorderStyle = BorderStyle.FixedSingle;
            pnlPassword.Controls.Add(BtnEye);
            pnlPassword.Controls.Add(iconPassword);
            pnlPassword.Controls.Add(TxtBoxPassword);
            pnlPassword.Location = new Point(51, 319);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(348, 43);
            pnlPassword.TabIndex = 1;
            // 
            // BtnEye
            // 
            BtnEye.Anchor = AnchorStyles.None;
            BtnEye.BackColor = Color.Transparent;
            BtnEye.FlatAppearance.BorderSize = 0;
            BtnEye.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnEye.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnEye.FlatStyle = FlatStyle.Flat;
            BtnEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            BtnEye.IconColor = Color.Black;
            BtnEye.IconFont = FontAwesome.Sharp.IconFont.Regular;
            BtnEye.IconSize = 32;
            BtnEye.Location = new Point(311, 4);
            BtnEye.Name = "BtnEye";
            BtnEye.Size = new Size(32, 32);
            BtnEye.TabIndex = 3;
            BtnEye.TabStop = false;
            BtnEye.UseVisualStyleBackColor = false;
            // 
            // iconPassword
            // 
            iconPassword.Anchor = AnchorStyles.None;
            iconPassword.BackColor = Color.Transparent;
            iconPassword.ForeColor = Color.FromArgb(64, 64, 64);
            iconPassword.IconChar = FontAwesome.Sharp.IconChar.Key;
            iconPassword.IconColor = Color.FromArgb(64, 64, 64);
            iconPassword.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconPassword.Location = new Point(5, 4);
            iconPassword.Name = "iconPassword";
            iconPassword.Size = new Size(32, 32);
            iconPassword.SizeMode = PictureBoxSizeMode.AutoSize;
            iconPassword.TabIndex = 2;
            iconPassword.TabStop = false;
            // 
            // TxtBoxPassword
            // 
            TxtBoxPassword.BackColor = SystemColors.Control;
            TxtBoxPassword.BorderStyle = BorderStyle.None;
            TxtBoxPassword.Font = new Font("Segoe UI", 12F);
            TxtBoxPassword.ForeColor = Color.FromArgb(64, 64, 64);
            TxtBoxPassword.Location = new Point(43, 9);
            TxtBoxPassword.Name = "TxtBoxPassword";
            TxtBoxPassword.PasswordChar = '*';
            TxtBoxPassword.Size = new Size(265, 22);
            TxtBoxPassword.TabIndex = 2;
            TxtBoxPassword.Text = "Enter your password";
            // 
            // pnlUsername
            // 
            pnlUsername.BorderStyle = BorderStyle.FixedSingle;
            pnlUsername.Controls.Add(iconUsername);
            pnlUsername.Controls.Add(TxtBoxUsername);
            pnlUsername.Location = new Point(51, 255);
            pnlUsername.Name = "pnlUsername";
            pnlUsername.Size = new Size(348, 43);
            pnlUsername.TabIndex = 0;
            // 
            // iconUsername
            // 
            iconUsername.Anchor = AnchorStyles.None;
            iconUsername.BackColor = Color.Transparent;
            iconUsername.ForeColor = Color.FromArgb(64, 64, 64);
            iconUsername.IconChar = FontAwesome.Sharp.IconChar.User;
            iconUsername.IconColor = Color.FromArgb(64, 64, 64);
            iconUsername.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconUsername.Location = new Point(5, 4);
            iconUsername.Name = "iconUsername";
            iconUsername.Size = new Size(32, 32);
            iconUsername.SizeMode = PictureBoxSizeMode.AutoSize;
            iconUsername.TabIndex = 2;
            iconUsername.TabStop = false;
            // 
            // TxtBoxUsername
            // 
            TxtBoxUsername.BackColor = SystemColors.Control;
            TxtBoxUsername.BorderStyle = BorderStyle.None;
            TxtBoxUsername.Font = new Font("Segoe UI", 12F);
            TxtBoxUsername.ForeColor = Color.FromArgb(64, 64, 64);
            TxtBoxUsername.Location = new Point(43, 9);
            TxtBoxUsername.Name = "TxtBoxUsername";
            TxtBoxUsername.Size = new Size(300, 22);
            TxtBoxUsername.TabIndex = 1;
            TxtBoxUsername.Text = "Enter your username";
            // 
            // picLogin
            // 
            picLogin.Dock = DockStyle.Left;
            picLogin.Image = (Image)resources.GetObject("picLogin.Image");
            picLogin.Location = new Point(0, 0);
            picLogin.Name = "picLogin";
            picLogin.Size = new Size(350, 600);
            picLogin.TabIndex = 1;
            picLogin.TabStop = false;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(picLogin);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Page";
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPassword).EndInit();
            pnlUsername.ResumeLayout(false);
            pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconUsername).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContent;
        private PictureBox picLogin;
        private Panel pnlPassword;
        private Panel pnlUsername;
        private TextBox TxtBoxUsername;
        private TextBox TxtBoxPassword;
        private FontAwesome.Sharp.IconPictureBox iconUsername;
        private FontAwesome.Sharp.IconPictureBox iconPassword;
        private FontAwesome.Sharp.IconButton BtnEye;
        private FontAwesome.Sharp.IconButton iconMinimize;
        private FontAwesome.Sharp.IconButton iconClose;
        private Label lblPleaseLogin;
        private Label lblWelcome;
        private LinkLabel LnkForgotPassword;
        private Button BtnLogin;
        private Label lblVersion;
        private Label lblStatus;
    }
}