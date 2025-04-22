namespace car_rental_sales_desktop.Forms.Pages
{
    partial class LoginPage
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            pnlContent = new Panel();
            lblStatus = new Label();
            lblVersion = new Label();
            lnkForgotPassword = new LinkLabel();
            btnLogin = new Button();
            lblLoginRequest = new Label();
            lblWelcome = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            pnlPassword = new Panel();
            btnEye = new FontAwesome.Sharp.IconButton();
            iconPassword = new FontAwesome.Sharp.IconPictureBox();
            txtPassword = new TextBox();
            pnlUsername = new Panel();
            iconUsername = new FontAwesome.Sharp.IconPictureBox();
            txtUsername = new TextBox();
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
            pnlContent.Controls.Add(lnkForgotPassword);
            pnlContent.Controls.Add(btnLogin);
            pnlContent.Controls.Add(lblLoginRequest);
            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Controls.Add(btnClose);
            pnlContent.Controls.Add(btnMinimize);
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
            // lnkForgotPassword
            // 
            lnkForgotPassword.ActiveLinkColor = Color.FromArgb(26, 115, 232);
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Segoe UI", 10F);
            lnkForgotPassword.LinkColor = Color.FromArgb(49, 76, 143);
            lnkForgotPassword.Location = new Point(285, 378);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(112, 19);
            lnkForgotPassword.TabIndex = 5;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Forgot Password";
            lnkForgotPassword.TextAlign = ContentAlignment.MiddleRight;
            lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(49, 76, 143);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 449);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(350, 50);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblLoginRequest
            // 
            lblLoginRequest.AutoSize = true;
            lblLoginRequest.Font = new Font("Segoe UI", 12F);
            lblLoginRequest.ForeColor = Color.Gray;
            lblLoginRequest.Location = new Point(37, 216);
            lblLoginRequest.Name = "lblLoginRequest";
            lblLoginRequest.Size = new Size(377, 21);
            lblLoginRequest.TabIndex = 5;
            lblLoginRequest.Text = "Please enter your information to log in to the system.";
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
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnClose.IconColor = Color.FromArgb(49, 76, 143);
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnClose.IconSize = 30;
            btnClose.Location = new Point(417, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.TabIndex = 8;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += iconClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            btnMinimize.IconColor = Color.FromArgb(49, 76, 143);
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnMinimize.IconSize = 30;
            btnMinimize.Location = new Point(381, 3);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(30, 30);
            btnMinimize.TabIndex = 7;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += iconMinimize_Click;
            // 
            // pnlPassword
            // 
            pnlPassword.BorderStyle = BorderStyle.FixedSingle;
            pnlPassword.Controls.Add(btnEye);
            pnlPassword.Controls.Add(iconPassword);
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Location = new Point(51, 319);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(348, 43);
            pnlPassword.TabIndex = 1;
            // 
            // btnEye
            // 
            btnEye.Anchor = AnchorStyles.None;
            btnEye.BackColor = Color.Transparent;
            btnEye.FlatAppearance.BorderSize = 0;
            btnEye.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEye.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEye.FlatStyle = FlatStyle.Flat;
            btnEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            btnEye.IconColor = Color.Black;
            btnEye.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnEye.IconSize = 32;
            btnEye.Location = new Point(311, 4);
            btnEye.Name = "btnEye";
            btnEye.Size = new Size(32, 32);
            btnEye.TabIndex = 3;
            btnEye.TabStop = false;
            btnEye.UseVisualStyleBackColor = false;
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
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Control;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
            txtPassword.Location = new Point(43, 9);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(265, 22);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Enter your password";
            // 
            // pnlUsername
            // 
            pnlUsername.BorderStyle = BorderStyle.FixedSingle;
            pnlUsername.Controls.Add(iconUsername);
            pnlUsername.Controls.Add(txtUsername);
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
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.Control;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.ForeColor = Color.FromArgb(64, 64, 64);
            txtUsername.Location = new Point(43, 9);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 22);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "Enter your username";
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
        private TextBox txtUsername;
        private TextBox txtPassword;
        private FontAwesome.Sharp.IconPictureBox iconUsername;
        private FontAwesome.Sharp.IconPictureBox iconPassword;
        private FontAwesome.Sharp.IconButton btnEye;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnClose;
        private Label lblLoginRequest;
        private Label lblWelcome;
        private LinkLabel lnkForgotPassword;
        private Button btnLogin;
        private Label lblVersion;
        private Label lblStatus;
    }
}