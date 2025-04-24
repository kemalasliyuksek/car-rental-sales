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
    public partial class VehiclesControl : UserControl
    {
        private VehicleRepository _vehicleRepository;

        public VehiclesControl()
        {
            InitializeComponent();
            _vehicleRepository = new VehicleRepository();

            this.Load += VehiclesControl_Load;
        }

        private void VehiclesControl_Load(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        // TR: Bu metot, araç verilerini yüklemek için kullanılır.
        // EN: This method is used to load vehicle data.
        private void LoadVehicles()
        {
            try
            {
                List<Vehicle> vehicles = _vehicleRepository.GetAll();
                sfDataGridVehicles.DataSource = vehicles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araç verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, araç verileri tablosunda gösterilirken satır stillerini ayarlamak için kullanılır.
        // EN: This method is used to set row styles when displaying vehicle data in the table.
        private void SfDataGridVehicles_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
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