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
    public partial class RentalsControl : UserControl
    {
        private RentalRepository _rentalRepository;
        private CustomerRepository _customerRepository;
        private VehicleRepository _vehicleRepository;
        private UserRepository _userRepository;

        public RentalsControl()
        {
            InitializeComponent();

            // Initialize repositories
            _rentalRepository = new RentalRepository();
            _customerRepository = new CustomerRepository();
            _vehicleRepository = new VehicleRepository();
            _userRepository = new UserRepository();

            // Register event handlers
            this.Load += RentalsControl_Load;
        }

        private void RentalsControl_Load(object sender, EventArgs e)
        {
            LoadRentals();
        }

        // TR: Bu metot, kiralama verilerini yüklemek için kullanılır.
        // EN: This method is used to load rental data.
        private void LoadRentals()
        {
            try
            {
                // Get all rentals from the repository
                List<Rental> rentals = _rentalRepository.GetAll();

                // For each rental, load related data
                foreach (var rental in rentals)
                {
                    // Load customer data
                    if (rental.RentalCustomerID > 0)
                    {
                        rental.Customer = _customerRepository.GetById(rental.RentalCustomerID);
                    }

                    // Load vehicle data
                    if (rental.RentalVehicleID > 0)
                    {
                        rental.Vehicle = _vehicleRepository.GetById(rental.RentalVehicleID);
                    }

                    // Load user data
                    if (rental.RentalUserID > 0)
                    {
                        rental.User = _userRepository.GetById(rental.RentalUserID);
                    }
                }

                // Set the data source for the main grid
                sfDataGridRentals.DataSource = rentals;

                // Create a sorted list for the latest rentals grid (most recent first)
                var latestRentals = rentals.OrderByDescending(r => r.RentalCreatedAt).ToList();

                // Set the data source for the latest rentals grid
                sfDataGridLastRentals.DataSource = latestRentals;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kiralama verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, kiralama verileri tablosunda gösterilirken satır stillerini ayarlamak için kullanılır.
        // EN: This method is used to set row styles when displaying rental data in the table.
        private void SfDataGridRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255); // Light blue tone
            }
        }

        // TR: Bu metot, son kiralamalar tablosunda gösterilirken satır stillerini ayarlamak için kullanılır.
        // EN: This method is used to set row styles when displaying latest rentals data in the table.
        private void SfDataGridLastRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255); // Light blue tone
            }
        }
    }
}