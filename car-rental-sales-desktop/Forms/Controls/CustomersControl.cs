using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental_sales_desktop.Forms.Controls
{
    public partial class CustomersControl : UserControl
    {
        private CustomerRepository _customerRepository;

        public CustomersControl()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();

            this.Load += CustomersControl_Load;
        }

        private void CustomersControl_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        // TR: Bu metot, müşteri verilerini yüklemek için kullanılır.
        // EN: This method is used to load customer data.
        private void LoadCustomers()
        {
            try
            {
                List<Customer> customers = _customerRepository.GetAllCustomers();

                sfDataGridCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteri verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, müşteri verileri tablosında gösterilirken satır stillerini ayarlamak için kullanılır.
        // EN: This method is used to set row styles when displaying customer data in the table.
        private void SfDataGridCustomers_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255); 
            }
        }
    }
}
