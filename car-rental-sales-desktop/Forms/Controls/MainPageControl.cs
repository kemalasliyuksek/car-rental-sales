using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Bu dosya, araba kiralama satış masaüstü uygulamasının ana sayfa kontrolünü içerir.
namespace car_rental_sales_desktop.Forms.Controls
{
    // MainPageControl, kullanıcı arayüzündeki ana sayfa bölümünü temsil eden bir kullanıcı kontrolüdür.
    public partial class MainPageControl : UserControl
    {
        // Bu, MainPageControl sınıfının yapıcı metodudur.
        // Bu kontrol oluşturulduğunda otomatik olarak çağrılır.
        public MainPageControl()
        {
            // InitializeComponent metodu, form tasarımcısında oluşturulan kontrolleri (butonlar, metin kutuları vb.) yükler ve ayarlar.
            InitializeComponent();
        }

        // Bu metod, 'btnGoWebsite' isimli butona tıklandığında çalışır.
        // 'sender' parametresi, olayı başlatan kontrolü (yani butonu) temsil eder.
        // 'e' parametresi, olayla ilgili ek bilgileri içerir.
        private void btnGoWebsite_Click(object sender, EventArgs e)
        {
            // Gidilecek web sitesinin URL'si bir string değişkeninde saklanır.
            string url = "https://www.kemalasliyuksek.com";

            // Hata yönetimi için bir try-catch bloğu kullanılır.
            // Web sitesini açma işlemi sırasında bir hata oluşursa, program çökmeden catch bloğu çalışır.
            try
            {
                // Yeni bir ProcessStartInfo nesnesi oluşturulur. Bu nesne, başlatılacak işlem hakkında bilgi içerir.
                // FileName özelliği, açılacak dosya veya URL'yi belirtir.
                // UseShellExecute özelliği true olarak ayarlandığında, işletim sistemi URL'yi varsayılan web tarayıcısında açar.
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            // Eğer try bloğundaki kod çalışırken bir Exception (hata) oluşursa, bu catch bloğu çalışır.
            // 'ex' değişkeni, oluşan hata hakkında bilgi içerir.
            catch (Exception ex)
            {
                // Kullanıcıya bir mesaj kutusu gösterilerek yönlendirmenin başarısız olduğu ve hatanın ne olduğu bildirilir.
                MessageBox.Show("Siteye yönlendirme başarısız: " + ex.Message);
            }
        }
    }
}