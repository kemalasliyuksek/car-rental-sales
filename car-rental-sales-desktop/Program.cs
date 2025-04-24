using car_rental_sales_desktop.Forms.Pages;

namespace car_rental_sales_desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmpCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXtcdHVURmNeUEVyW0RWYUA=");
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPage());
        }
    }
}