
-- CREATE DATABASE IF NOT EXISTS `car_rental_sales` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci;
-- USE `car_rental_sales`;

-- --------------------------------------------------------

--
-- Table structure for table `Banks`
--

CREATE TABLE `Banks` (
  `BankID` int(11) NOT NULL,
  `BankName` varchar(100) NOT NULL,
  `BankDescription` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Branches`
--

CREATE TABLE `Branches` (
  `BranchID` int(11) NOT NULL,
  `BranchName` varchar(100) NOT NULL,
  `BranchAddress` varchar(255) NOT NULL,
  `BranchPhone` varchar(12) NOT NULL,
  `BranchEmail` varchar(100) DEFAULT NULL,
  `BranchActive` tinyint(1) DEFAULT 1,
  `BranchCreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Contracts`
--

CREATE TABLE `Contracts` (
  `ContractID` int(11) NOT NULL,
  `ContractType` varchar(20) NOT NULL,
  `ContractCreatedAt` datetime DEFAULT current_timestamp(),
  `ContractText` text DEFAULT NULL,
  `ContractFilePath` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Customers`
--

CREATE TABLE `Customers` (
  `CustomerID` int(11) NOT NULL,
  `CustomerFirstName` varchar(50) NOT NULL,
  `CustomerLastName` varchar(50) NOT NULL,
  `CustomerNationalID` varchar(11) DEFAULT NULL,
  `CustomerDateOfBirth` date DEFAULT NULL,
  `CustomerLicenseNumber` varchar(20) DEFAULT NULL,
  `CustomerLicenseClass` varchar(10) DEFAULT NULL,
  `CustomerLicenseDate` date DEFAULT NULL,
  `CustomerPhone` varchar(12) NOT NULL,
  `CustomerEmail` varchar(100) DEFAULT NULL,
  `CustomerAddress` varchar(255) DEFAULT NULL,
  `CustomerRegistrationDate` datetime DEFAULT current_timestamp(),
  `CustomerAvailable` tinyint(1) DEFAULT 1,
  `CustomerType` varchar(20) DEFAULT 'Individual',
  `CustomerUpdatedAt` datetime DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Documents`
--

CREATE TABLE `Documents` (
  `DocumentID` int(11) NOT NULL,
  `DocumentTransactionType` varchar(20) NOT NULL,
  `DocumentTransactionID` int(11) NOT NULL,
  `DocumentType` varchar(50) NOT NULL,
  `DocumentFilePath` varchar(255) NOT NULL,
  `DocumentUploadDate` datetime DEFAULT current_timestamp(),
  `DocumentUserID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ErrorLogs`
--

CREATE TABLE `ErrorLogs` (
  `ID` int(11) NOT NULL,
  `ErrorID` varchar(50) NOT NULL,
  `ErrorDate` datetime NOT NULL,
  `ErrorSeverity` varchar(20) NOT NULL,
  `ErrorSource` varchar(50) NOT NULL,
  `ErrorContent` varchar(255) NOT NULL,
  `ErrorUsername` varchar(100) DEFAULT NULL,
  `ErrorExceptionType` varchar(255) DEFAULT NULL,
  `ErrorMessage` text NOT NULL,
  `ErrorInnerException` text DEFAULT NULL,
  `ErrorStackTrace` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Maintenances`
--

CREATE TABLE `Maintenances` (
  `MaintenanceID` int(11) NOT NULL,
  `MaintenanceVehicleID` int(11) NOT NULL,
  `MaintenanceStartDate` datetime NOT NULL,
  `MaintenanceEndDate` datetime DEFAULT NULL,
  `MaintenanceType` varchar(50) NOT NULL,
  `MaintenanceNote` text DEFAULT NULL,
  `MaintenanceCost` decimal(10,2) NOT NULL,
  `MaintenanceServiceID` int(11) DEFAULT NULL,
  `MaintenanceUserID` int(11) NOT NULL,
  `MaintenanceCreatedAt` datetime DEFAULT current_timestamp(),
  `MaintenanceUpdatedAt` datetime DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Payments`
--

CREATE TABLE `Payments` (
  `PaymentID` int(11) NOT NULL,
  `PaymentTransactionType` varchar(20) NOT NULL,
  `PaymentTransactionID` int(11) NOT NULL,
  `PaymentCustomerID` int(11) NOT NULL,
  `PaymentAmount` decimal(12,2) NOT NULL,
  `PaymentDate` datetime NOT NULL,
  `PaymentType` varchar(20) NOT NULL,
  `PaymentBankID` int(11) DEFAULT NULL,
  `PaymentNote` varchar(255) DEFAULT NULL,
  `PaymentUserID` int(11) NOT NULL,
  `PaymentCreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `RentalNotes`
--

CREATE TABLE `RentalNotes` (
  `RentalNoteID` int(11) NOT NULL,
  `RentalID` int(11) NOT NULL,
  `RentalNoteText` text NOT NULL,
  `RentalNoteCreatedAt` datetime DEFAULT current_timestamp(),
  `RentalNoteUserID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `RentalPrices`
--

CREATE TABLE `RentalPrices` (
  `RentalPriceID` int(11) NOT NULL,
  `VehicleClassID` int(11) NOT NULL,
  `RentalType` enum('Hourly','Daily','Weekly','Monthly') NOT NULL,
  `RentalPrice` decimal(10,2) NOT NULL,
  `RentalPriceCreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Rentals`
--

CREATE TABLE `Rentals` (
  `RentalID` int(11) NOT NULL,
  `RentalCustomerID` int(11) NOT NULL,
  `RentalVehicleID` int(11) NOT NULL,
  `RentalStartDate` datetime NOT NULL,
  `RentalEndDate` datetime NOT NULL,
  `RentalReturnDate` datetime DEFAULT NULL,
  `RentalStartKm` int(11) NOT NULL,
  `RentalEndKm` int(11) DEFAULT NULL,
  `RentalAmount` decimal(12,2) NOT NULL,
  `RentalDepositAmount` decimal(12,2) DEFAULT NULL,
  `RentalPaymentType` varchar(20) NOT NULL,
  `RentalNoteID` int(11) DEFAULT NULL,
  `RentalContractID` int(11) DEFAULT NULL,
  `RentalUserID` int(11) NOT NULL,
  `RentalCreatedAt` datetime DEFAULT current_timestamp(),
  `RentalUpdatedAt` datetime DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Roles`
--

CREATE TABLE `Roles` (
  `RoleID` int(11) NOT NULL,
  `RoleName` varchar(50) NOT NULL,
  `RoleDescription` varchar(255) DEFAULT NULL,
  `RoleCreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Sales`
--

CREATE TABLE `Sales` (
  `SaleID` int(11) NOT NULL,
  `SaleCustomerID` int(11) NOT NULL,
  `SaleVehicleID` int(11) NOT NULL,
  `SaleDate` datetime NOT NULL,
  `SaleAmount` decimal(12,2) NOT NULL,
  `SalePaymentType` varchar(20) NOT NULL,
  `SaleInstallmentCount` int(11) DEFAULT 0,
  `SaleNotaryDate` date DEFAULT NULL,
  `SaleContractID` int(11) DEFAULT NULL,
  `SaleUserID` int(11) NOT NULL,
  `SaleCreatedAt` datetime DEFAULT current_timestamp(),
  `SaleUpdatedAt` datetime DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Services`
--

CREATE TABLE `Services` (
  `ServiceID` int(11) NOT NULL,
  `ServiceName` varchar(100) NOT NULL,
  `ServiceAddress` varchar(255) DEFAULT NULL,
  `ServicePhone` varchar(12) NOT NULL,
  `ServiceEmail` varchar(100) DEFAULT NULL,
  `ServiceAuthorizedPersonID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Users`
--

CREATE TABLE `Users` (
  `UserID` int(11) NOT NULL,
  `UserFirstName` varchar(50) NOT NULL,
  `UserLastName` varchar(50) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `UserPassword` varchar(20) NOT NULL,
  `UserEmail` varchar(100) NOT NULL,
  `UserPhone` varchar(12) NOT NULL,
  `UserRoleID` int(11) NOT NULL,
  `UserBranchID` int(11) DEFAULT NULL,
  `UserLastLogin` datetime DEFAULT NULL,
  `UserActive` tinyint(1) DEFAULT 1,
  `UserCreatedAt` datetime DEFAULT current_timestamp(),
  `UserUpdatedAt` datetime DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `VehicleClasses`
--

CREATE TABLE `VehicleClasses` (
  `VehicleClassID` int(11) NOT NULL,
  `VehicleClassName` varchar(30) NOT NULL,
  `VehicleClassDescription` varchar(255) DEFAULT NULL,
  `VehicleClassCreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Vehicles`
--

CREATE TABLE `Vehicles` (
  `VehicleID` int(11) NOT NULL,
  `VehiclePlateNumber` varchar(15) NOT NULL,
  `VehicleBrand` varchar(50) NOT NULL,
  `VehicleModel` varchar(50) NOT NULL,
  `VehicleYear` int(11) NOT NULL,
  `VehicleEngineNumber` varchar(50) DEFAULT NULL,
  `VehicleChassisNumber` varchar(50) NOT NULL,
  `VehicleColor` varchar(30) DEFAULT NULL,
  `VehicleMileage` int(11) NOT NULL DEFAULT 0,
  `VehicleFuelType` varchar(20) NOT NULL,
  `VehicleTransmissionType` varchar(20) NOT NULL,
  `VehicleStatusID` int(11) NOT NULL,
  `VehicleAcquisitionDate` date DEFAULT NULL,
  `VehiclePurchasePrice` decimal(12,2) DEFAULT NULL,
  `VehicleSalePrice` decimal(12,2) DEFAULT NULL,
  `VehicleBranchID` int(11) DEFAULT NULL,
  `VehicleClassID` int(11) DEFAULT NULL,
  `VehicleCreatedAt` datetime DEFAULT current_timestamp(),
  `VehicleUpdatedAt` datetime DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `VehicleStatuses`
--

CREATE TABLE `VehicleStatuses` (
  `VehicleStatusID` int(11) NOT NULL,
  `VehicleStatusName` varchar(50) NOT NULL DEFAULT 'Available',
  `VehicleStatusDescription` varchar(255) DEFAULT NULL,
  `VehicleStatusCreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Banks`
--
ALTER TABLE `Banks`
  ADD PRIMARY KEY (`BankID`);

--
-- Indexes for table `Branches`
--
ALTER TABLE `Branches`
  ADD PRIMARY KEY (`BranchID`);

--
-- Indexes for table `Contracts`
--
ALTER TABLE `Contracts`
  ADD PRIMARY KEY (`ContractID`);

--
-- Indexes for table `Customers`
--
ALTER TABLE `Customers`
  ADD PRIMARY KEY (`CustomerID`),
  ADD UNIQUE KEY `CustomerNationalID` (`CustomerNationalID`),
  ADD KEY `idx_nationalid` (`CustomerNationalID`),
  ADD KEY `idx_phone` (`CustomerPhone`);

--
-- Indexes for table `Documents`
--
ALTER TABLE `Documents`
  ADD PRIMARY KEY (`DocumentID`),
  ADD KEY `DocumentUserID` (`DocumentUserID`),
  ADD KEY `idx_transaction` (`DocumentTransactionType`,`DocumentTransactionID`);

--
-- Indexes for table `ErrorLogs`
--
ALTER TABLE `ErrorLogs`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Maintenances`
--
ALTER TABLE `Maintenances`
  ADD PRIMARY KEY (`MaintenanceID`),
  ADD KEY `MaintenanceVehicleID` (`MaintenanceVehicleID`),
  ADD KEY `MaintenanceServiceID` (`MaintenanceServiceID`),
  ADD KEY `MaintenanceUserID` (`MaintenanceUserID`);

--
-- Indexes for table `Payments`
--
ALTER TABLE `Payments`
  ADD PRIMARY KEY (`PaymentID`),
  ADD KEY `PaymentCustomerID` (`PaymentCustomerID`),
  ADD KEY `PaymentBankID` (`PaymentBankID`),
  ADD KEY `PaymentUserID` (`PaymentUserID`),
  ADD KEY `idx_transaction` (`PaymentTransactionType`,`PaymentTransactionID`);

--
-- Indexes for table `RentalNotes`
--
ALTER TABLE `RentalNotes`
  ADD PRIMARY KEY (`RentalNoteID`),
  ADD KEY `RentalID` (`RentalID`),
  ADD KEY `RentalNoteUserID` (`RentalNoteUserID`);

--
-- Indexes for table `RentalPrices`
--
ALTER TABLE `RentalPrices`
  ADD PRIMARY KEY (`RentalPriceID`),
  ADD KEY `VehicleClassID` (`VehicleClassID`);

--
-- Indexes for table `Rentals`
--
ALTER TABLE `Rentals`
  ADD PRIMARY KEY (`RentalID`),
  ADD KEY `RentalCustomerID` (`RentalCustomerID`),
  ADD KEY `RentalVehicleID` (`RentalVehicleID`),
  ADD KEY `RentalContractID` (`RentalContractID`),
  ADD KEY `RentalUserID` (`RentalUserID`),
  ADD KEY `idx_dates` (`RentalStartDate`,`RentalEndDate`),
  ADD KEY `fk_rentals_note` (`RentalNoteID`);

--
-- Indexes for table `Roles`
--
ALTER TABLE `Roles`
  ADD PRIMARY KEY (`RoleID`);

--
-- Indexes for table `Sales`
--
ALTER TABLE `Sales`
  ADD PRIMARY KEY (`SaleID`),
  ADD KEY `SaleCustomerID` (`SaleCustomerID`),
  ADD KEY `SaleVehicleID` (`SaleVehicleID`),
  ADD KEY `SaleContractID` (`SaleContractID`),
  ADD KEY `SaleUserID` (`SaleUserID`);

--
-- Indexes for table `Services`
--
ALTER TABLE `Services`
  ADD PRIMARY KEY (`ServiceID`),
  ADD KEY `ServiceAuthorizedPersonID` (`ServiceAuthorizedPersonID`);

--
-- Indexes for table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD UNIQUE KEY `UserEmail` (`UserEmail`),
  ADD KEY `UserRoleID` (`UserRoleID`),
  ADD KEY `UserBranchID` (`UserBranchID`);

--
-- Indexes for table `VehicleClasses`
--
ALTER TABLE `VehicleClasses`
  ADD PRIMARY KEY (`VehicleClassID`),
  ADD UNIQUE KEY `VehicleClassName` (`VehicleClassName`);

--
-- Indexes for table `Vehicles`
--
ALTER TABLE `Vehicles`
  ADD PRIMARY KEY (`VehicleID`),
  ADD UNIQUE KEY `VehiclePlateNumber` (`VehiclePlateNumber`),
  ADD UNIQUE KEY `VehicleChassisNumber` (`VehicleChassisNumber`),
  ADD KEY `VehicleStatusID` (`VehicleStatusID`),
  ADD KEY `VehicleBranchID` (`VehicleBranchID`),
  ADD KEY `VehicleClassID` (`VehicleClassID`);

--
-- Indexes for table `VehicleStatuses`
--
ALTER TABLE `VehicleStatuses`
  ADD PRIMARY KEY (`VehicleStatusID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Banks`
--
ALTER TABLE `Banks`
  MODIFY `BankID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Branches`
--
ALTER TABLE `Branches`
  MODIFY `BranchID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Contracts`
--
ALTER TABLE `Contracts`
  MODIFY `ContractID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Customers`
--
ALTER TABLE `Customers`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Documents`
--
ALTER TABLE `Documents`
  MODIFY `DocumentID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ErrorLogs`
--
ALTER TABLE `ErrorLogs`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Maintenances`
--
ALTER TABLE `Maintenances`
  MODIFY `MaintenanceID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Payments`
--
ALTER TABLE `Payments`
  MODIFY `PaymentID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `RentalNotes`
--
ALTER TABLE `RentalNotes`
  MODIFY `RentalNoteID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `RentalPrices`
--
ALTER TABLE `RentalPrices`
  MODIFY `RentalPriceID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Rentals`
--
ALTER TABLE `Rentals`
  MODIFY `RentalID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Roles`
--
ALTER TABLE `Roles`
  MODIFY `RoleID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Sales`
--
ALTER TABLE `Sales`
  MODIFY `SaleID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Services`
--
ALTER TABLE `Services`
  MODIFY `ServiceID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Users`
--
ALTER TABLE `Users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `VehicleClasses`
--
ALTER TABLE `VehicleClasses`
  MODIFY `VehicleClassID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Vehicles`
--
ALTER TABLE `Vehicles`
  MODIFY `VehicleID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `VehicleStatuses`
--
ALTER TABLE `VehicleStatuses`
  MODIFY `VehicleStatusID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Documents`
--
ALTER TABLE `Documents`
  ADD CONSTRAINT `Documents_ibfk_1` FOREIGN KEY (`DocumentUserID`) REFERENCES `Users` (`UserID`);

--
-- Constraints for table `Maintenances`
--
ALTER TABLE `Maintenances`
  ADD CONSTRAINT `Maintenances_ibfk_1` FOREIGN KEY (`MaintenanceVehicleID`) REFERENCES `Vehicles` (`VehicleID`),
  ADD CONSTRAINT `Maintenances_ibfk_2` FOREIGN KEY (`MaintenanceServiceID`) REFERENCES `Services` (`ServiceID`),
  ADD CONSTRAINT `Maintenances_ibfk_3` FOREIGN KEY (`MaintenanceUserID`) REFERENCES `Users` (`UserID`);

--
-- Constraints for table `Payments`
--
ALTER TABLE `Payments`
  ADD CONSTRAINT `Payments_ibfk_1` FOREIGN KEY (`PaymentCustomerID`) REFERENCES `Customers` (`CustomerID`),
  ADD CONSTRAINT `Payments_ibfk_2` FOREIGN KEY (`PaymentBankID`) REFERENCES `Banks` (`BankID`),
  ADD CONSTRAINT `Payments_ibfk_3` FOREIGN KEY (`PaymentUserID`) REFERENCES `Users` (`UserID`);

--
-- Constraints for table `RentalNotes`
--
ALTER TABLE `RentalNotes`
  ADD CONSTRAINT `RentalNotes_ibfk_1` FOREIGN KEY (`RentalID`) REFERENCES `Rentals` (`RentalID`),
  ADD CONSTRAINT `RentalNotes_ibfk_2` FOREIGN KEY (`RentalNoteUserID`) REFERENCES `Users` (`UserID`);

--
-- Constraints for table `RentalPrices`
--
ALTER TABLE `RentalPrices`
  ADD CONSTRAINT `RentalPrices_ibfk_1` FOREIGN KEY (`VehicleClassID`) REFERENCES `VehicleClasses` (`VehicleClassID`);

--
-- Constraints for table `Rentals`
--
ALTER TABLE `Rentals`
  ADD CONSTRAINT `Rentals_ibfk_1` FOREIGN KEY (`RentalCustomerID`) REFERENCES `Customers` (`CustomerID`),
  ADD CONSTRAINT `Rentals_ibfk_2` FOREIGN KEY (`RentalVehicleID`) REFERENCES `Vehicles` (`VehicleID`),
  ADD CONSTRAINT `Rentals_ibfk_3` FOREIGN KEY (`RentalContractID`) REFERENCES `Contracts` (`ContractID`),
  ADD CONSTRAINT `Rentals_ibfk_4` FOREIGN KEY (`RentalUserID`) REFERENCES `Users` (`UserID`),
  ADD CONSTRAINT `fk_rentals_note` FOREIGN KEY (`RentalNoteID`) REFERENCES `RentalNotes` (`RentalNoteID`);

--
-- Constraints for table `Sales`
--
ALTER TABLE `Sales`
  ADD CONSTRAINT `Sales_ibfk_1` FOREIGN KEY (`SaleCustomerID`) REFERENCES `Customers` (`CustomerID`),
  ADD CONSTRAINT `Sales_ibfk_2` FOREIGN KEY (`SaleVehicleID`) REFERENCES `Vehicles` (`VehicleID`),
  ADD CONSTRAINT `Sales_ibfk_3` FOREIGN KEY (`SaleContractID`) REFERENCES `Contracts` (`ContractID`),
  ADD CONSTRAINT `Sales_ibfk_4` FOREIGN KEY (`SaleUserID`) REFERENCES `Users` (`UserID`);

--
-- Constraints for table `Services`
--
ALTER TABLE `Services`
  ADD CONSTRAINT `Services_ibfk_1` FOREIGN KEY (`ServiceAuthorizedPersonID`) REFERENCES `Users` (`UserID`);

--
-- Constraints for table `Users`
--
ALTER TABLE `Users`
  ADD CONSTRAINT `Users_ibfk_1` FOREIGN KEY (`UserRoleID`) REFERENCES `Roles` (`RoleID`),
  ADD CONSTRAINT `Users_ibfk_2` FOREIGN KEY (`UserBranchID`) REFERENCES `Branches` (`BranchID`);

--
-- Constraints for table `Vehicles`
--
ALTER TABLE `Vehicles`
  ADD CONSTRAINT `Vehicles_ibfk_1` FOREIGN KEY (`VehicleStatusID`) REFERENCES `VehicleStatuses` (`VehicleStatusID`),
  ADD CONSTRAINT `Vehicles_ibfk_2` FOREIGN KEY (`VehicleBranchID`) REFERENCES `Branches` (`BranchID`),
  ADD CONSTRAINT `Vehicles_ibfk_3` FOREIGN KEY (`VehicleClassID`) REFERENCES `VehicleClasses` (`VehicleClassID`);