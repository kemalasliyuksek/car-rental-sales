using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;

namespace car_rental_sales_desktop.Methods
{
    public static class RentalMethods
    {
        public enum RentalStatus
        {
            Active,
            CompletedOnTime,
            CompletedLate,
            Overdue
        }

        public static RentalStatus GetRentalStatus(Rental rental)
        {
            DateTime today = DateTime.Today;

            if (!rental.RentalReturnDate.HasValue)
            {
                if (rental.RentalEndDate.Date < today)
                {
                    return RentalStatus.Overdue;
                }
                return RentalStatus.Active;
            }

            if (rental.RentalReturnDate.Value.Date <= rental.RentalEndDate.Date)
            {
                return RentalStatus.CompletedOnTime;
            }
            else
            {
                return RentalStatus.CompletedLate;
            }
        }

        public static Color GetStatusColor(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return Color.LightBlue;
                case RentalStatus.CompletedOnTime:
                    return Color.LightGreen;
                case RentalStatus.CompletedLate:
                    return Color.Orange;
                case RentalStatus.Overdue:
                    return Color.Crimson;
                default:
                    return Color.White;
            }
        }

        public static string GetStatusDescription(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return "Aktif Kiralama";
                case RentalStatus.CompletedOnTime:
                    return "Zamanında Tamamlandı";
                case RentalStatus.CompletedLate:
                    return "Geç Tamamlandı (Cezalı)";
                case RentalStatus.Overdue:
                    return "Süresi Geçmiş";
                default:
                    return "Belirsiz";
            }
        }

        public static Color GetStatusTextColor(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return Color.Blue;
                case RentalStatus.CompletedOnTime:
                    return Color.Green;
                case RentalStatus.CompletedLate:
                    return Color.OrangeRed;
                case RentalStatus.Overdue:
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }

        public static Customer FindCustomerByFullName(string fullName, List<Customer> customers)
        {
            if (string.IsNullOrWhiteSpace(fullName) || customers == null)
                return null;

            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length < 2)
                return null;

            string firstName = nameParts[0];
            string lastName = string.Join(" ", nameParts, 1, nameParts.Length - 1);

            return customers.Find(c =>
                c.CustomerFirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                c.CustomerLastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public static List<Rental> CheckCustomerActiveRentals(int customerId, RentalRepository rentalRepository, VehicleRepository vehicleRepository)
        {
            try
            {
                var activeRentals = rentalRepository.GetActiveRentals();
                var customerActiveRentals = activeRentals.Where(r => r.RentalCustomerID == customerId).ToList();

                foreach (var rental in customerActiveRentals)
                {
                    if (rental.Vehicle == null && rental.RentalVehicleID > 0)
                    {
                        rental.Vehicle = vehicleRepository.GetById(rental.RentalVehicleID);
                    }
                }
                return customerActiveRentals;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in CheckCustomerActiveRentals: {ex.Message}");
                return new List<Rental>();
            }
        }

        public static Vehicle FindVehicleByPlate(string plateNumber, List<Vehicle> vehicles)
        {
            if (string.IsNullOrWhiteSpace(plateNumber) || vehicles == null)
                return null;

            return vehicles.Find(v =>
                v.VehiclePlateNumber.Equals(plateNumber, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsVehicleAvailableForRental(Vehicle vehicle, RentalRepository rentalRepository)
        {
            try
            {
                if (vehicle == null) return false;

                if (vehicle.VehicleStatusID != 1 && vehicle.VehicleStatusID != 4)
                {
                    return false;
                }

                var activeRentals = rentalRepository.GetActiveRentals();
                bool isCurrentlyRented = activeRentals.Any(r => r.RentalVehicleID == vehicle.VehicleID);

                return !isCurrentlyRented;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in IsVehicleAvailableForRental: {ex.Message}");
                return false;
            }
        }
    }
}
