-- Branches
CREATE TABLE Branches (
    BranchID INT AUTO_INCREMENT PRIMARY KEY,
    BranchName VARCHAR(100) NOT NULL,
    BranchAddress VARCHAR(255) NOT NULL,
    BranchPhone VARCHAR(12) NOT NULL,
    BranchEmail VARCHAR(100),
    BranchActive BOOLEAN DEFAULT TRUE,
    BranchCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Roles
CREATE TABLE Roles (
    RoleID INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL,
    RoleDescription VARCHAR(255),
    RoleCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Vehicle Statuses
CREATE TABLE VehicleStatuses (
    VehicleStatusID INT AUTO_INCREMENT PRIMARY KEY,
    VehicleStatusName VARCHAR(50) NOT NULL DEFAULT 'Available',
    VehicleStatusDescription VARCHAR(255),
    VehicleStatusCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Vehicle Classes
CREATE TABLE VehicleClasses (
    VehicleClassID INT AUTO_INCREMENT PRIMARY KEY,
    VehicleClassName VARCHAR(30) NOT NULL UNIQUE,
    VehicleClassDescription VARCHAR(255),
    VehicleClassCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Rental Prices
CREATE TABLE RentalPrices (
    RentalPriceID INT AUTO_INCREMENT PRIMARY KEY,
    VehicleClassID INT NOT NULL,
    RentalType ENUM('Hourly', 'Daily', 'Weekly', 'Monthly') NOT NULL,
    RentalPrice DECIMAL(10, 2) NOT NULL,
    RentalPriceCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (VehicleClassID) REFERENCES VehicleClasses(VehicleClassID)
);

-- Vehicles
CREATE TABLE Vehicles (
    VehicleID INT AUTO_INCREMENT PRIMARY KEY,
    VehiclePlateNumber VARCHAR(15) NOT NULL UNIQUE,
    VehicleBrand VARCHAR(50) NOT NULL,
    VehicleModel VARCHAR(50) NOT NULL,
    VehicleYear INT NOT NULL,
    VehicleEngineNumber VARCHAR(50),
    VehicleChassisNumber VARCHAR(50) NOT NULL UNIQUE,
    VehicleColor VARCHAR(30),
    VehicleMileage INT NOT NULL DEFAULT 0,
    VehicleFuelType VARCHAR(20) NOT NULL,
    VehicleTransmissionType VARCHAR(20) NOT NULL,
    VehicleStatusID INT NOT NULL,
    VehicleAcquisitionDate DATE,
    VehiclePurchasePrice DECIMAL(12, 2),
    VehicleSalePrice DECIMAL(12, 2),
    VehicleBranchID INT,
    VehicleClassID INT,
    VehicleCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    VehicleUpdatedAt DATETIME ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (VehicleStatusID) REFERENCES VehicleStatuses(VehicleStatusID),
    FOREIGN KEY (VehicleBranchID) REFERENCES Branches(BranchID),
    FOREIGN KEY (VehicleClassID) REFERENCES VehicleClasses(VehicleClassID)
);

-- Customers
CREATE TABLE Customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerFirstName VARCHAR(50) NOT NULL,
    CustomerLastName VARCHAR(50) NOT NULL,
    CustomerNationalID VARCHAR(11) UNIQUE,
    CustomerDateOfBirth DATE,
    CustomerLicenseNumber VARCHAR(20),
    CustomerLicenseClass VARCHAR(10),
    CustomerLicenseDate DATE,
    CustomerPhone VARCHAR(12) NOT NULL,
    CustomerEmail VARCHAR(100),
    CustomerAddress VARCHAR(255),
    CustomerRegistrationDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    CustomerAvailable BOOLEAN DEFAULT TRUE,
    CustomerType VARCHAR(20) DEFAULT 'Individual',
    CustomerUpdatedAt DATETIME ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_nationalid (CustomerNationalID),
    INDEX idx_phone (CustomerPhone)
);

-- Users
CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    UserFirstName VARCHAR(50) NOT NULL,
    UserLastName VARCHAR(50) NOT NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    UserPassword VARCHAR(20) NOT NULL,
    UserEmail VARCHAR(100) NOT NULL UNIQUE,
    UserPhone VARCHAR(12) NOT NULL,
    UserRoleID INT NOT NULL,
    UserBranchID INT,
    UserLastLogin DATETIME,
    UserActive BOOLEAN DEFAULT TRUE,
    UserCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UserUpdatedAt DATETIME ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (UserRoleID) REFERENCES Roles(RoleID),
    FOREIGN KEY (UserBranchID) REFERENCES Branches(BranchID)
);

-- Contracts
CREATE TABLE Contracts (
    ContractID INT AUTO_INCREMENT PRIMARY KEY,
    ContractType VARCHAR(20) NOT NULL,
    ContractCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    ContractText TEXT,
    ContractFilePath VARCHAR(255)
);

-- Rentals
CREATE TABLE Rentals (
    RentalID INT AUTO_INCREMENT PRIMARY KEY,
    RentalCustomerID INT NOT NULL,
    RentalVehicleID INT NOT NULL,
    RentalStartDate DATETIME NOT NULL,
    RentalEndDate DATETIME NOT NULL,
    RentalReturnDate DATETIME,
    RentalStartKm INT NOT NULL,
    RentalEndKm INT,
    RentalAmount DECIMAL(12, 2) NOT NULL,
    RentalDepositAmount DECIMAL(12, 2),
    RentalPaymentType VARCHAR(20) NOT NULL,
    RentalNoteID INT,
    RentalContractID INT,
    RentalUserID INT NOT NULL,
    RentalCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    RentalUpdatedAt DATETIME ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (RentalCustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (RentalVehicleID) REFERENCES Vehicles(VehicleID),
    FOREIGN KEY (RentalContractID) REFERENCES Contracts(ContractID),
    FOREIGN KEY (RentalUserID) REFERENCES Users(UserID),
    INDEX idx_dates (RentalStartDate, RentalEndDate)
);

-- Rental Notes
CREATE TABLE RentalNotes (
    RentalNoteID INT AUTO_INCREMENT PRIMARY KEY,
    RentalID INT NOT NULL,
    RentalNoteText TEXT NOT NULL,
    RentalNoteCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    RentalNoteUserID INT NOT NULL,
    FOREIGN KEY (RentalID) REFERENCES Rentals(RentalID),
    FOREIGN KEY (RentalNoteUserID) REFERENCES Users(UserID)
);

-- FK Update
ALTER TABLE Rentals
ADD CONSTRAINT fk_rentals_note
FOREIGN KEY (RentalNoteID) REFERENCES RentalNotes(RentalNoteID);

-- Sales
CREATE TABLE Sales (
    SaleID INT AUTO_INCREMENT PRIMARY KEY,
    SaleCustomerID INT NOT NULL,
    SaleVehicleID INT NOT NULL,
    SaleDate DATETIME NOT NULL,
    SaleAmount DECIMAL(12, 2) NOT NULL,
    SalePaymentType VARCHAR(20) NOT NULL,
    SaleInstallmentCount INT DEFAULT 0,
    SaleNotaryDate DATE,
    SaleContractID INT,
    SaleUserID INT NOT NULL,
    SaleCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    SaleUpdatedAt DATETIME ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (SaleCustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (SaleVehicleID) REFERENCES Vehicles(VehicleID),
    FOREIGN KEY (SaleContractID) REFERENCES Contracts(ContractID),
    FOREIGN KEY (SaleUserID) REFERENCES Users(UserID)
);

-- Banks
CREATE TABLE Banks (
    BankID INT AUTO_INCREMENT PRIMARY KEY,
    BankName VARCHAR(100) NOT NULL,
    BankDescription VARCHAR(255)
);

-- Payments
CREATE TABLE Payments (
    PaymentID INT AUTO_INCREMENT PRIMARY KEY,
    PaymentTransactionType VARCHAR(20) NOT NULL,
    PaymentTransactionID INT NOT NULL,
    PaymentCustomerID INT NOT NULL,
    PaymentAmount DECIMAL(12, 2) NOT NULL,
    PaymentDate DATETIME NOT NULL,
    PaymentType VARCHAR(20) NOT NULL,
    PaymentBankID INT,
    PaymentNote VARCHAR(255),
    PaymentUserID INT NOT NULL,
    PaymentCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (PaymentCustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (PaymentBankID) REFERENCES Banks(BankID),
    FOREIGN KEY (PaymentUserID) REFERENCES Users(UserID),
    INDEX idx_transaction (PaymentTransactionType, PaymentTransactionID)
);

-- Services
CREATE TABLE Services (
    ServiceID INT AUTO_INCREMENT PRIMARY KEY,
    ServiceName VARCHAR(100) NOT NULL,
    ServiceAddress VARCHAR(255),
    ServicePhone VARCHAR(12) NOT NULL,
    ServiceEmail VARCHAR(100),
    ServiceAuthorizedPersonID INT NOT NULL,
    FOREIGN KEY (ServiceAuthorizedPersonID) REFERENCES Users(UserID)
);

-- Maintenances
CREATE TABLE Maintenances (
    MaintenanceID INT AUTO_INCREMENT PRIMARY KEY,
    MaintenanceVehicleID INT NOT NULL,
    MaintenanceStartDate DATETIME NOT NULL,
    MaintenanceEndDate DATETIME,
    MaintenanceType VARCHAR(50) NOT NULL,
    MaintenanceNote TEXT,
    MaintenanceCost DECIMAL(10, 2) NOT NULL,
    MaintenanceServiceID INT,
    MaintenanceUserID INT NOT NULL,
    MaintenanceCreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    MaintenanceUpdatedAt DATETIME ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (MaintenanceVehicleID) REFERENCES Vehicles(VehicleID),
    FOREIGN KEY (MaintenanceServiceID) REFERENCES Services(ServiceID),
    FOREIGN KEY (MaintenanceUserID) REFERENCES Users(UserID)
);

-- Documents
CREATE TABLE Documents (
    DocumentID INT AUTO_INCREMENT PRIMARY KEY,
    DocumentTransactionType VARCHAR(20) NOT NULL,
    DocumentTransactionID INT NOT NULL,
    DocumentType VARCHAR(50) NOT NULL,
    DocumentFilePath VARCHAR(255) NOT NULL,
    DocumentUploadDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    DocumentUserID INT NOT NULL,
    FOREIGN KEY (DocumentUserID) REFERENCES Users(UserID),
    INDEX idx_transaction (DocumentTransactionType, DocumentTransactionID)
);

-- Error Logs
CREATE TABLE IF NOT EXISTS ErrorLogs (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    ErrorID VARCHAR(50) NOT NULL,
    ErrorDate DATETIME NOT NULL,
    ErrorSeverity VARCHAR(20) NOT NULL,
    ErrorSource VARCHAR(50) NOT NULL,
    ErrorContent VARCHAR(255) NOT NULL,
    ErrorUsername VARCHAR(100),
    ErrorExceptionType VARCHAR(255),
    ErrorMessage TEXT NOT NULL,
    ErrorInnerException TEXT,
    ErrorStackTrace TEXT
);
