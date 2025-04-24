-- Şube verileri
INSERT INTO Branches (BranchName, BranchAddress, BranchPhone, BranchEmail, BranchActive) VALUES 
('Main Branch İstanbul', 'Bağdat Caddesi No:42, Kadıköy, İstanbul', '05321234566', 'istanbul@carrentalsales.com', TRUE),
('Rize Branch', 'Fırtına Caddesi No:53, Ardeşen, Rize', '05321234567', 'rize@carrentalsales.com', TRUE),
('Bursa Branch', 'Üniversite Caddesi No:16, Nilüfer, Bursa', '05321234568', 'bursa@carrentalsales.com', TRUE),
('İzmir Branch', 'Alsancak Caddesi No:24, Konak, İzmir', '05321234569', 'izmir@carrentalsales.com', TRUE);

-- Rol verileri
INSERT INTO Roles (RoleName, RoleDescription) 
VALUES 
  ('Administrator', 'User with full authority in the system. Can manage users, vehicles, branches, and personnel.'),
  ('Branch Manager', 'Can manage operations and personnel within their own branch.'),
  ('Staff', 'Handles vehicle operations, reservation, and rental processes.'),
  ('Customer', 'System user who can rent or purchase vehicles.'),
  ('Technician', 'Handles the status of vehicles in service and updates technical records.'),
  ('Maintenance Staff', 'Performs pre/post-rental and sales maintenance (cleaning, general check, etc.) of vehicles.'),
  ('Guest', 'User with limited system access, can create an account.');


-- Araç durumu verileri
INSERT INTO VehicleStatuses (VehicleStatusName, VehicleStatusDescription)
VALUES 
('Available', 'Suitable for rental or sale.'),
('For Sale', 'The vehicle is offered for sale.'),
('Sold', 'The vehicle has been sold and can no longer be used.'),
('For Rent', 'Suitable for rental.'),
('Rented', 'The vehicle is currently rented by a customer.'),
('Reserved', 'The vehicle has been reserved by a customer.'),
('Reservation Expired', 'Reserved but not picked up.'),
('In Service', 'The vehicle is in service for maintenance or repair.'),
('Faulty', 'The vehicle is faulty and cannot be used.'),
('Under Maintenance', 'The vehicle is being cleaned and is temporarily unavailable.'),
('In Transfer', 'The vehicle is being transferred between branches.'),
('Awaiting Return', 'The rented vehicle has not yet been returned.');


-- Araç sınıfı verileri
INSERT INTO VehicleClasses (VehicleClassName, VehicleClassDescription) VALUES 
('Economy', 'Affordable, fuel-efficient small vehicles.'),
('Standart', 'Comfortable, spacious family vehicles.'),
('Luxury', 'High-end, premium-class vehicles.');

-- Kiralama fiyat verileri
INSERT INTO RentalPrices (VehicleClassID, RentalType, RentalPrice) VALUES
(1, 'Hourly', 100.00), (1, 'Daily', 1000.00), (1, 'Weekly', 5000.00), (1, 'Monthly', 20000.00),
(2, 'Hourly', 150.00), (2, 'Daily', 1500.00), (2, 'Weekly', 7500.00), (2, 'Monthly', 30000.00),
(3, 'Hourly', 250.00), (3, 'Daily', 2500.00), (3, 'Weekly', 12500.00), (3, 'Monthly', 50000.00);

-- Araç verileri
INSERT INTO Vehicles (VehiclePlateNumber, VehicleBrand, VehicleModel, VehicleYear, VehicleEngineNumber, VehicleChassisNumber, VehicleColor, VehicleMileage, VehicleFuelType, VehicleTransmissionType, VehicleStatusID, VehicleAcquisitionDate, VehiclePurchasePrice, VehicleSalePrice, VehicleBranchID, VehicleClassID) VALUES 
('34ABC123', 'Renault', 'Clio', 2022, 'ENG123456', 'CHS123456', 'White', 15000, 'Diesel', 'Manual', 1, '2022-01-15', 350000.00, 600000.00, 1, 2),
('34DEF456', 'Ford', 'Focus', 2021, 'ENG234567', 'CHS234567', 'Blue', 25000, 'Diesel', 'Automatic', 1, '2021-06-20', 400000.00, 550000.00, 1, 2),
('06GHI789', 'Toyota', 'Corolla', 2023, 'ENG345678', 'CHS345678', 'Black', 8000, 'Hybrid', 'Automatic', 1, '2023-03-10', 550000.00, 700000.00, 2, 2),
('06JKL012', 'Volkswagen', 'Passat', 2022, 'ENG456789', 'CHS456789', 'Silver', 18000, 'Diesel', 'Automatic', 2, '2022-05-15', 700000.00, 1500000.00, 2, 3),
('35MNO345', 'Hyundai', 'Tucson', 2021, 'ENG567890', 'CHS567890', 'Red', 30000, 'Diesel', 'Automatic', 1, '2021-09-22', 600000.00, 1000000.00, 3, 3),
('07PQR678', 'Mercedes', 'E200', 2023, 'ENG678901', 'CHS678901', 'Black', 12000, 'Diesel', 'Automatic', 1, '2023-01-05', 1000000.00, 17000000.00, 3, 3),
('48STU901', 'Fiat', 'Doblo', 2022, 'ENG789012', 'CHS789012', 'White', 22000, 'Gasoline', 'Manual', 1, '2022-08-18', 300000.00, 480000.00, 2, 1);

-- Müşteri verileri
INSERT INTO Customers (CustomerFirstName, CustomerLastName, CustomerNationalID, CustomerDateOfBirth, CustomerLicenseNumber, CustomerLicenseClass, CustomerLicenseDate, CustomerPhone, CustomerEmail, CustomerAddress, CustomerType) VALUES 
('Ahmet', 'Yılmaz', '12345678901', '1985-05-10', 'LIC123456', 'B', '2010-06-15', '05551234567', 'ahmet@email.com', 'Atatürk Caddesi No:15, Beşiktaş, İstanbul', 'Individual'),
('Ayşe', 'Kaya', '23456789012', '1990-08-22', 'LIC234567', 'B', '2012-09-30', '05552345678', 'ayse@email.com', 'Cumhuriyet Caddesi No:8, Çankaya, Ankara', 'Individual'),
('Mehmet', 'Demir', '34567890123', '1978-03-15', 'LIC345678', 'B,E', '2005-04-20', '05553456789', 'mehmet@email.com', 'İnönü Caddesi No:42, Konak, İzmir', 'Individual'),
('Zeynep', 'Çelik', '45678901234', '1995-11-30', 'LIC456789', 'B', '2018-12-05', '05554567890', 'zeynep@email.com', 'Lara Caddesi No:24, Muratpaşa, Antalya', 'Individual'),
('Mustafa', 'Öztürk', '56789012345', '1982-07-18', 'LIC567890', 'B,C', '2008-08-22', '05555678901', 'mustafa@email.com', 'Meydan Sokak No:7, Bodrum, Muğla', 'Individual'),
('Anadolu', 'Lojistik', '67890123456', NULL, NULL, NULL, NULL, '08502345678', 'info@anadolulojistik.com', 'Organize Sanayi Bölgesi, No:15, Kocaeli', 'Corporate');

-- Kullanıcı verileri
INSERT INTO Users (UserFirstName, UserLastName, Username, UserPassword, UserEmail, UserPhone, UserRoleID, UserBranchID) VALUES 
-- Administrator
('Kemal', 'Aslıyüksek', 'kasliyuksek', '123456', 'kemal@carrentalsales.com', '905301112233', 1, 1),
-- Branch Managers
('Nur', 'Kumbasar', 'nkumbasar', '123456', 'nur.kumbasar@carrentalsales.com', '905312223344', 2, 4),
('Salih', 'Zenginal', 'szenginal', '123456', 'salih.zenginal@carrentalsales.com', '905323334455', 2, 3),
('Ensar', 'Bayraktar', 'ebayraktar', '123456', 'ensar.bayraktar@carrentalsales.com', '905334445566', 2, 1),
('Ali', 'Aslıyüksek', 'aasliyuksek', '123456', 'ali.asliyuksek@carrentalsales.com', '905345556677', 2, 2),
-- General Staff
('Ayşe', 'Sönmez', 'asonmez', '123456', 'ayse.sonmez@carrentalsales.com', '905356667788', 3, 2),
('Murat', 'Bucan', 'mbucan', '123456', 'murat.bucan@carrentalsales.com', '905356667788', 3, 2),
-- Technician
('Taha', 'Uluşahin', 'tulusahin', '123456', 'taha.ulusahin@carrentalsales.com', '905389990011', 5, 1),
-- Maintenance Staff
('Fatih', 'Turan', 'fturan', '123456', 'fatih.turan@carrentalsales.com', '905367778899', 6, 1),
('Gül', 'Koç', 'gkoc', '123456', 'gul.koc@carrentalsales.com', '905378889900', 6, 1);

-- Banka verileri
INSERT INTO Banks (BankName, BankDescription) VALUES 
('Ziraat Bankası', 'Primary banking partner'),
('İş Bankası', 'Secondary banking partner'),
('Akbank', 'Corporate accounts partner'),
('Garanti Bankası', 'Staff banking partner');

-- Servis verileri
INSERT INTO Services (ServiceName, ServiceAddress, ServicePhone, ServiceEmail, ServiceAuthorizedPersonID) VALUES 
('Teknik Oto', 'Sanayi Sitesi No:45, Kadıköy, İstanbul', '02161234567', 'info@teknikoto.com', 8);
