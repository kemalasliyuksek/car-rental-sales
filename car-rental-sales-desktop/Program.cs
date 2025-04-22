using car_rental_sales_desktop.Forms.Pages;

namespace car_rental_sales_desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPage());
        }
    }
}