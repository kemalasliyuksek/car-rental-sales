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

    }
}
