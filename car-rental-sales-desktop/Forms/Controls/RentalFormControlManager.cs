using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using Syncfusion.WinForms.DataGrid;

namespace car_rental_sales_desktop.Forms.Controls
{
    public class RentalFormControlManager
    {
        private RentalsControl _rentalsControl;

        public RentalFormControlManager(RentalsControl rentalsControl)
        {
            _rentalsControl = rentalsControl ?? throw new ArgumentNullException(nameof(rentalsControl));
        }

        public void LoadCustomerInfo(Customer customer)
        {
            if (customer == null) return;

            _rentalsControl.txtBoxCustomerFullName.Text = $"{customer.CustomerFirstName} {customer.CustomerLastName}";
            _rentalsControl.tctBoxNationalID.Text = customer.CustomerNationalID;
            _rentalsControl.txtBoxPhoneNo.Text = customer.CustomerPhone;
            _rentalsControl.txtBoxEmail.Text = customer.CustomerEmail;
            _rentalsControl.txtBoxAddress.Text = customer.CustomerAddress;
            _rentalsControl.txtBoxLicenseNo.Text = customer.CustomerLicenseNumber;
            _rentalsControl.txtBoxLicenseClass.Text = customer.CustomerLicenseClass;

            _rentalsControl.dtpLicenseDate.Value = customer.CustomerLicenseDate.HasValue ? customer.CustomerLicenseDate.Value : _rentalsControl.dtpLicenseDate.MinDate;
            _rentalsControl.dtpDateOfBirth.Value = customer.CustomerDateOfBirth.HasValue ? customer.CustomerDateOfBirth.Value : _rentalsControl.dtpDateOfBirth.MinDate;
        }

        public void LoadVehicleInfo(Vehicle vehicle, Action calculateRentalAmountCallback)
        {
            if (vehicle == null) return;

            _rentalsControl.txtBoxVehiclePlate.Text = vehicle.VehiclePlateNumber;
            _rentalsControl.txtBoxVehicleBrand.Text = vehicle.VehicleBrand;
            _rentalsControl.txtBoxVehicleModel.Text = vehicle.VehicleModel;
            _rentalsControl.txtBoxVehicleYear.Text = vehicle.VehicleYear.ToString();
            _rentalsControl.txtBoxVehicleColor.Text = vehicle.VehicleColor;
            _rentalsControl.txtBoxVehicleFuelType.Text = vehicle.VehicleFuelType;
            _rentalsControl.txtBoxVehicleTransmission.Text = vehicle.VehicleTransmissionType;
            _rentalsControl.txtBoxVehicleMileage.Text = $"{vehicle.VehicleMileage} KM";
            _rentalsControl.txtBoxVehicleLocation.Text = vehicle.Branch?.BranchName ?? "Belirsiz";
            _rentalsControl.txtBoxVehicleStatus.Text = vehicle.VehicleStatus?.VehicleStatusName ?? "Belirsiz";

            _rentalsControl.dtpRentalStartDate.Value = DateTime.Now;
            _rentalsControl.dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            _rentalsControl.txtBoxRentalStartMileage.Text = vehicle.VehicleMileage.ToString();

            calculateRentalAmountCallback?.Invoke();
        }

        public void ClearFormInputs()
        {
            _rentalsControl.txtBoxSearchCustomer.Text = string.Empty;
            _rentalsControl.txtBoxCustomerFullName.Text = string.Empty;
            _rentalsControl.tctBoxNationalID.Text = string.Empty;
            _rentalsControl.txtBoxPhoneNo.Text = string.Empty;
            _rentalsControl.txtBoxEmail.Text = string.Empty;
            _rentalsControl.txtBoxAddress.Text = string.Empty;
            _rentalsControl.txtBoxLicenseNo.Text = string.Empty;
            _rentalsControl.txtBoxLicenseClass.Text = string.Empty;
            _rentalsControl.dtpLicenseDate.Value = _rentalsControl.dtpLicenseDate.MinDate;
            _rentalsControl.dtpDateOfBirth.Value = _rentalsControl.dtpDateOfBirth.MinDate;

            _rentalsControl.textBoxSearchVehicle.Text = string.Empty;
            _rentalsControl.txtBoxVehiclePlate.Text = string.Empty;
            _rentalsControl.txtBoxVehicleBrand.Text = string.Empty;
            _rentalsControl.txtBoxVehicleModel.Text = string.Empty;
            _rentalsControl.txtBoxVehicleYear.Text = string.Empty;
            _rentalsControl.txtBoxVehicleColor.Text = string.Empty;
            _rentalsControl.txtBoxVehicleFuelType.Text = string.Empty;
            _rentalsControl.txtBoxVehicleTransmission.Text = string.Empty;
            _rentalsControl.txtBoxVehicleMileage.Text = string.Empty;
            _rentalsControl.txtBoxVehicleLocation.Text = string.Empty;
            _rentalsControl.txtBoxVehicleStatus.Text = string.Empty;

            _rentalsControl.dtpRentalStartDate.Value = DateTime.Now;
            _rentalsControl.dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            _rentalsControl.txtBoxRentalStartMileage.Text = string.Empty;
            _rentalsControl.textBox8.Text = string.Empty; // txtBoxRentalEndMileage
            _rentalsControl.txtBoxRentalPaymentType.Text = "Nakit";
            _rentalsControl.txtBoxRentalAmount.Text = string.Empty;
            _rentalsControl.txtBoxRentalDeposit.Text = string.Empty;
            _rentalsControl.txtBoxRentalNote.Text = string.Empty;

            try
            {
                ClearGridSelections(_rentalsControl.sfDataGridRentals);
                ClearGridSelections(_rentalsControl.sfDataGridLastRentals);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Selection clearing failed in FormManager: {ex.Message}");
            }
        }

        private void ClearGridSelections(SfDataGrid grid)
        {
            if (grid != null)
            {
                grid.ClearSelection();
                grid.SelectedItem = null;
                grid.SelectedIndex = -1;
            }
        }


        public void SetFormReadOnly(bool isReadOnly)
        {
            _rentalsControl.txtBoxSearchCustomer.ReadOnly = isReadOnly;
            _rentalsControl.btnCustomerLoad.Enabled = !isReadOnly;

            _rentalsControl.textBoxSearchVehicle.ReadOnly = isReadOnly;
            _rentalsControl.btnVehicleLoad.Enabled = !isReadOnly;

            _rentalsControl.dtpRentalStartDate.Enabled = !isReadOnly;
            _rentalsControl.dtpRentalEndDate.Enabled = !isReadOnly;

            _rentalsControl.txtBoxRentalPaymentType.Enabled = !isReadOnly;
            _rentalsControl.txtBoxRentalNote.ReadOnly = isReadOnly;

            _rentalsControl.btnAddRental.Enabled = !isReadOnly;

            if (isReadOnly)
            {
                _rentalsControl.btnAddRental.BackColor = Color.Gray;
            }
            else
            {
                _rentalsControl.btnAddRental.BackColor = SystemColors.HotTrack;
            }
        }

        public void PopulateSelectedRentalDetails(Rental rental, List<RentalNote> notes, Action calculateRentalAmountCallback)
        {
            if (rental.Customer != null)
            {
                LoadCustomerInfo(rental.Customer);
                _rentalsControl.txtBoxSearchCustomer.Text = $"{rental.Customer.CustomerFirstName} {rental.Customer.CustomerLastName}";
            }

            if (rental.Vehicle != null)
            {
                LoadVehicleInfo(rental.Vehicle, calculateRentalAmountCallback);
                _rentalsControl.textBoxSearchVehicle.Text = rental.Vehicle.VehiclePlateNumber;
            }

            _rentalsControl.dtpRentalStartDate.Value = rental.RentalStartDate;
            _rentalsControl.dtpRentalEndDate.Value = rental.RentalEndDate;


            _rentalsControl.txtBoxRentalStartMileage.Text = rental.RentalStartKm.ToString();
            _rentalsControl.textBox8.Text = rental.RentalEndKm.HasValue ? rental.RentalEndKm.Value.ToString() : string.Empty;
            _rentalsControl.txtBoxRentalPaymentType.Text = rental.RentalPaymentType;
            _rentalsControl.txtBoxRentalAmount.Text = rental.RentalAmount.ToString("N2") + " ₺";
            _rentalsControl.txtBoxRentalDeposit.Text = rental.RentalDepositAmount.HasValue ? rental.RentalDepositAmount.Value.ToString("N2") + " ₺" : string.Empty;

            if (notes != null && notes.Any())
            {
                _rentalsControl.txtBoxRentalNote.Text = string.Join(Environment.NewLine, notes.Select(n => n.RentalNoteText));
            }
        }

        public void UpdateProgressWarning(string message, Color color)
        {
            if (_rentalsControl.lblProgressWarning != null)
            {
                _rentalsControl.lblProgressWarning.Text = message;
                _rentalsControl.lblProgressWarning.ForeColor = color;
            }
        }

        public void InitializeFormDefaults()
        {
            _rentalsControl.dtpLicenseDate.Value = _rentalsControl.dtpLicenseDate.MinDate;
            _rentalsControl.dtpDateOfBirth.Value = _rentalsControl.dtpDateOfBirth.MinDate;
            _rentalsControl.dtpRentalStartDate.Value = DateTime.Now;
            _rentalsControl.dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            _rentalsControl.txtBoxRentalPaymentType.Text = "Nakit";
        }
    }
}
