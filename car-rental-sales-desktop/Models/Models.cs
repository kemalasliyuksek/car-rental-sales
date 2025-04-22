using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CityCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<User> Users { get; set; }
    }

    public class VehicleStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }

    public class VehicleClass
    {
        public int VehicleClassID { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public decimal AverageRentalPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<RentalPrice> RentalPrices { get; set; }
    }

    public class RentalPrice
    {
        public int RentalPriceID { get; set; }
        public int VehicleClassID { get; set; }
        public string RentalType { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual VehicleClass VehicleClass { get; set; }
    }

    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public int StatusID { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int? BranchID { get; set; }
        public int? VehicleClassID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual VehicleStatus Status { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual VehicleClass VehicleClass { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseClass { get; set; }
        public DateTime? LicenseDate { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsAvailable { get; set; }
        public string CustomerType { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }

    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleID { get; set; }
        public int? BranchID { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Role Role { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<RentalNote> RentalNotes { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }

    public class Contract
    {
        public int ContractID { get; set; }
        public string ContractType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ContractText { get; set; }
        public string ContractFilePath { get; set; }

        // Navigation properties
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }

    public class Rental
    {
        public int RentalID { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int StartKm { get; set; }
        public int? EndKm { get; set; }
        public decimal RentalAmount { get; set; }
        public decimal? DepositAmount { get; set; }
        public string PaymentType { get; set; }
        public int? RentalNoteID { get; set; }
        public int? ContractID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual User User { get; set; }
        public virtual RentalNote RentalNote { get; set; }
        public virtual ICollection<RentalNote> RentalNotes { get; set; }
    }

    public class RentalNote
    {
        public int RentalNoteID { get; set; }
        public int RentalID { get; set; }
        public string NoteText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserID { get; set; }

        // Navigation properties
        public virtual Rental Rental { get; set; }
        public virtual User User { get; set; }
    }

    public class Sale
    {
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SaleAmount { get; set; }
        public string PaymentType { get; set; }
        public int InstallmentCount { get; set; }
        public DateTime? NotaryDate { get; set; }
        public int? ContractID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual User User { get; set; }
    }

    public class Bank
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<Payment> Payments { get; set; }
    }

    public class Payment
    {
        public int PaymentID { get; set; }
        public string TransactionType { get; set; }
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public int? BankID { get; set; }
        public string PaymentNote { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual User User { get; set; }
    }

    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string Address { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AuthorizedPerson { get; set; }

        // Navigation properties
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }

    public class Maintenance
    {
        public int MaintenanceID { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string MaintenanceType { get; set; }
        public string MaintenanceNote { get; set; }
        public decimal Cost { get; set; }
        public int? ServiceID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Vehicle Vehicle { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }

    public class Document
    {
        public int DocumentID { get; set; }
        public string TransactionType { get; set; }
        public int TransactionID { get; set; }
        public string DocumentType { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserID { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
    }

    public class ErrorLog
    {
        public int ID { get; set; }
        public string ErrorID { get; set; }
        public DateTime Date { get; set; }
        public string Severity { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public string ExceptionType { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
    }
}