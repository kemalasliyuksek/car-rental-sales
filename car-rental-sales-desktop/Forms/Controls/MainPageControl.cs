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

namespace car_rental_sales_desktop.Forms.Controls
{
    public partial class MainPageControl : UserControl
    {
        public MainPageControl()
        {
            InitializeComponent();
        }

        private void btnGoWebsite_Click(object sender, EventArgs e)
        {
            string url = "https://www.kemalasliyuksek.com";

            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Siteye yönlendirme başarısız: " + ex.Message);
            }
        }
    }
}
