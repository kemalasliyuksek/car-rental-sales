using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;
using car_rental_sales_desktop.Models;

namespace car_rental_sales_desktop.Forms.Pages
{
    // Kullanıcı giriş formunu temsil eden sınıf.
    public partial class LoginPage : Form
    {
        // LoginPage sınıfının yapıcı metodu. Form başlatıldığında çağrılır.
        public LoginPage()
        {
            // Formun bileşenlerini başlatan metot. Tasarımcı tarafından otomatik oluşturulur.
            InitializeComponent();

            // Şifre gösterme/gizleme butonu (btnEye) için olayları tanımlar.
            // Fare butonuna basıldığında BtnEye_MouseDown metodu çağrılır.
            btnEye.MouseDown += BtnEye_MouseDown;
            // Fare butonu bırakıldığında BtnEye_MouseUp metodu çağrılır.
            btnEye.MouseUp += BtnEye_MouseUp;

            // Şifre giriş kutusu (txtPassword) için başlangıç ayarları ve olayları tanımlar.
            // Başlangıçta şifre karakterini göstermez (boş karakter).
            txtPassword.PasswordChar = '\0';
            // Şifre kutusuna odaklanıldığında TxtBoxPassword_Enter metodu çağrılır.
            txtPassword.Enter += TxtBoxPassword_Enter;
            // Şifre kutusundan odak çıkıldığında TxtBoxPassword_Leave metodu çağrılır.
            txtPassword.Leave += TxtBoxPassword_Leave;
            // Şifre kutusunda bir tuşa basıldığında TextBox_KeyDown metodu çağrılır.
            txtPassword.KeyDown += TextBox_KeyDown;

            // Kullanıcı adı giriş kutusu (txtUsername) için olayları tanımlar.
            // Kullanıcı adı kutusuna odaklanıldığında TxtBoxUsername_Enter metodu çağrılır.
            txtUsername.Enter += TxtBoxUsername_Enter;
            // Kullanıcı adı kutusundan odak çıkıldığında TxtBoxUsername_Leave metodu çağrılır.
            txtUsername.Leave += TxtBoxUsername_Leave;
            // Kullanıcı adı kutusunda bir tuşa basıldığında TextBox_KeyDown metodu çağrılır.
            txtUsername.KeyDown += TextBox_KeyDown;

            // Form üzerinde Enter tuşuna basıldığında btnLogin butonunun tıklanma olayını tetikler.
            this.AcceptButton = btnLogin;
        }

        // Giriş butonu (btnLogin) tıklandığında çağrılan metot.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı, şifre ve mevcut form örneği ile giriş işlemini gerçekleştirir.
            HandleLogin(txtUsername, txtPassword, this);
        }

        // Simge durumuna küçültme butonu (iconMinimize) tıklandığında çağrılan metot.
        private void iconMinimize_Click(object sender, EventArgs e)
        {
            // Formun pencere durumunu simge durumuna küçültür.
            this.WindowState = FormWindowState.Minimized;
        }

        // Kapatma butonu (iconClose) tıklandığında çağrılan metot.
        private void iconClose_Click(object sender, EventArgs e)
        {
            // Kullanıcıya uygulamadan çıkmak isteyip istemediğini soran bir onay kutusu gösterir.
            var result = MessageBox.Show("Are you sure you want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Kullanıcı "Evet" seçeneğini seçerse.
            if (result == DialogResult.Yes)
            {
                // Uygulamayı kapatır.
                Application.Exit();
            }
        }

        // "Şifremi Unuttum" bağlantısı (lnkForgotPassword) tıklandığında çağrılan metot.
        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Şifre sıfırlama talepleri için yöneticiyle iletişime geçilmesi gerektiğini belirten bir mesaj kutusu gösterir.
            MessageBox.Show("For password reset requests, please contact the administrator. (admin@carrentalsales.com)",
                          "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Başarılı bir işlem sonucunda durum etiketini (lblStatus) güncelleyen metot.
        public static void ShowSuccess(LoginPage instance, string message)
        {
            // Durum etiketinin metin rengini yeşil yapar.
            instance.lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
            // Durum etiketinin metnini verilen mesajla günceller.
            instance.lblStatus.Text = message;
        }

        // Hatalı bir işlem sonucunda durum etiketini (lblStatus) güncelleyen metot.
        public static void ShowError(LoginPage instance, string message)
        {
            // Durum etiketinin metin rengini kırmızı yapar.
            instance.lblStatus.ForeColor = Color.FromArgb(220, 53, 69);
            // Durum etiketinin metnini verilen mesajla günceller.
            instance.lblStatus.Text = message;
        }

        // Şifre gösterme/gizleme butonuna (btnEye) fare ile basıldığında çağrılan metot.
        private void BtnEye_MouseDown(object sender, MouseEventArgs e)
        {
            // Butonun ikonunu "göz" ikonu olarak değiştirir (şifre görünür).
            btnEye.IconChar = FontAwesome.Sharp.IconChar.Eye;
            // Şifre giriş kutusundaki karakterlerin görünür olmasını sağlar.
            txtPassword.PasswordChar = '\0';
        }

        // Şifre gösterme/gizleme butonundan (btnEye) fare bırakıldığında çağrılan metot.
        private void BtnEye_MouseUp(object sender, MouseEventArgs e)
        {
            // Butonun ikonunu "üzeri çizili göz" ikonu olarak değiştirir (şifre gizli).
            btnEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            // Şifre giriş kutusundaki karakterlerin '*' olarak görünmesini sağlar.
            txtPassword.PasswordChar = '*';
        }

        // Kullanıcı adı giriş kutusuna (txtUsername) odaklanıldığında çağrılan metot.
        private void TxtBoxUsername_Enter(object sender, EventArgs e)
        {
            // Eğer kullanıcı adı kutusundaki metin varsayılan metin ise ("Kullanıcı adınızı girin").
            if (txtUsername.Text == "Enter your username")
            {
                // Kullanıcı adı kutusundaki metni temizler.
                txtUsername.Text = "";
            }
        }

        // Kullanıcı adı giriş kutusundan (txtUsername) odak çıkıldığında çağrılan metot.
        private void TxtBoxUsername_Leave(object sender, EventArgs e)
        {
            // Eğer kullanıcı adı kutusundaki metin boş ise.
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                // Kullanıcı adı kutusuna varsayılan metni ("Kullanıcı adınızı girin") geri yükler.
                txtUsername.Text = "Enter your username";
            }
        }

        // Şifre giriş kutusuna (txtPassword) odaklanıldığında çağrılan metot.
        private void TxtBoxPassword_Enter(object sender, EventArgs e)
        {
            // Eğer şifre kutusundaki metin varsayılan metin ise ("Şifrenizi girin").
            if (txtPassword.Text == "Enter your password")
            {
                // Şifre kutusundaki metni temizler.
                txtPassword.Text = "";
                // Şifre karakterini '*' olarak ayarlar.
                txtPassword.PasswordChar = '*';
            }
        }

        // Şifre giriş kutusundan (txtPassword) odak çıkıldığında çağrılan metot.
        private void TxtBoxPassword_Leave(object sender, EventArgs e)
        {
            // Eğer şifre kutusundaki metin boş ise.
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                // Şifre kutusuna varsayılan metni ("Şifrenizi girin") geri yükler.
                txtPassword.Text = "Enter your password";
                // Şifre karakterini göstermez (boş karakter).
                txtPassword.PasswordChar = '\0';
            }
        }

        // Herhangi bir metin kutusunda (txtUsername veya txtPassword) bir tuşa basıldığında çağrılan metot.
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Eğer basılan tuş Enter tuşu ise.
            if (e.KeyCode == Keys.Enter)
            {
                // Giriş işlemini gerçekleştirir.
                HandleLogin(txtUsername, txtPassword, this);
                // Olayın işlendiğini belirtir, böylece başka kontroller tarafından işlenmez.
                e.Handled = true;
                // Tuşa basma olayının дальше işlenmesini engeller.
                e.SuppressKeyPress = true;
            }
        }

        // Bu metot, UserRepository sınıfını kullanarak kullanıcı adı ve şifre ile giriş yapmayı sağlar.
        public static void HandleLogin(TextBox usernameTextBox, TextBox passwordTextBox, LoginPage loginForm)
        {
            // Kullanıcı adı metin kutusundaki metni alır ve başındaki/sonundaki boşlukları temizler.
            string username = usernameTextBox.Text.Trim();
            // Şifre metin kutusundaki metni alır.
            string password = passwordTextBox.Text;

            // Kullanıcı veritabanı işlemlerini yönetmek için UserRepository sınıfından bir örnek oluşturur.
            UserRepository userRepository = new UserRepository();
            // Kullanıcı adı ve şifrenin geçerli olup olmadığını kontrol eder.
            bool success = userRepository.ValidateLogin(username, password);

            // Eğer giriş başarılı ise.
            if (success)
            {
                // Başarılı giriş mesajını gösterir.
                LoginPage.ShowSuccess(loginForm, "Login successful! Redirecting...");

                // Arayüzdeki olayların işlenmesini sağlar (mesajın görünmesi için).
                Application.DoEvents();
                // 1 saniye bekler (kullanıcının mesajı okuması için).
                System.Threading.Thread.Sleep(1000);

                // Giriş yapan kullanıcının bilgilerini alır.
                User currentUser = userRepository.GetByUsername(username);
                // Mevcut kullanıcı bilgilerini ayarlar.
                CurrentUser.SetCurrentUser(currentUser);

                // Ana sayfayı oluşturur.
                MainPage mainPage = new MainPage();
                // Ana sayfayı gösterir.
                mainPage.Show();
                // Giriş formunu gizler.
                loginForm.Hide();
            }
            // Eğer giriş başarısız ise.
            else
            {
                // Hatalı giriş mesajını gösterir.
                LoginPage.ShowError(loginForm, "Incorrect username or password!");
            }
        }
    }
}