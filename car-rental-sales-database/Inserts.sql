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
('Service', 'The vehicle is in service for maintenance or repair.'),
('Faulty', 'The vehicle is faulty and cannot be used.'),
('Maintenance', 'The vehicle is being cleaned and is temporarily unavailable.');


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
('34 ABC 123', 'Renault', 'Clio', 2022, 'ENG123456', 'CHS123456', 'White', 15000, 'Diesel', 'Manual', 1, '2022-01-15', 350000.00, 600000.00, 1, 2),
('34 DEF 456', 'Ford', 'Focus', 2021, 'ENG234567', 'CHS234567', 'Blue', 25000, 'Diesel', 'Automatic', 1, '2021-06-20', 400000.00, 550000.00, 1, 2),
('06 GHI 789', 'Toyota', 'Corolla', 2023, 'ENG345678', 'CHS345678', 'Black', 8000, 'Hybrid', 'Automatic', 1, '2023-03-10', 550000.00, 700000.00, 2, 2),
('06 JKL 012', 'Volkswagen', 'Passat', 2022, 'ENG456789', 'CHS456789', 'Silver', 18000, 'Diesel', 'Automatic', 1, '2022-05-15', 700000.00, 1500000.00, 2, 3),
('35 MNO 345', 'Hyundai', 'Tucson', 2021, 'ENG567890', 'CHS567890', 'Red', 30000, 'Diesel', 'Automatic', 1, '2021-09-22', 600000.00, 1000000.00, 3, 3),
('07 PQR 678', 'Mercedes', 'E200', 2023, 'ENG678901', 'CHS678901', 'Black', 12000, 'Diesel', 'Automatic', 1, '2023-01-05', 1000000.00, 2300000.00, 3, 3),
('48 STU 901', 'Fiat', 'Doblo', 2022, 'ENG789012', 'CHS789012', 'White', 22000, 'Gasoline', 'Manual', 1, '2022-08-18', 300000.00, 480000.00, 2, 1),
('20 QNN 750', 'Ford', 'Mondeo', 2022, 'ENG200000', 'CHS200000', 'Red', 55121, 'Petrol', 'Manual', 1, '2021-01-01', 539373.26, 658288.43, 4, 2),
('71 QCM 302', 'Renault', 'Captur', 2023, 'ENG200001', 'CHS200001', 'Blue', 107022, 'Electric', 'Automatic', 1, '2021-07-08', 1186398.3, 1382176.55, 2, 3),
('53 NEQ 228', 'Honda', 'Jazz', 2022, 'ENG200002', 'CHS200002', 'Blue', 20411, 'Hybrid', 'Automatic', 1, '2024-12-03', 1073330.86, 1289980.81, 1, 1),
('52 TXF 717', 'Honda', 'Civic', 2018, 'ENG200003', 'CHS200003', 'Gray', 30109, 'Electric', 'Automatic', 1, '2021-02-26', 454904.77, 550933.39, 4, 2),
('10 BNK 650', 'Ford', 'Focus', 2023, 'ENG200004', 'CHS200004', 'Red', 22676, 'Petrol', 'Manual', 1, '2023-08-17', 926995.95, 1160749.09, 2, 1),
('64 THV 275', 'Volkswagen', 'Polo', 2022, 'ENG200005', 'CHS200005', 'Black', 5256, 'Diesel', 'Manual', 1, '2024-01-20', 621310.87, 652775.24, 1, 3),
('42 ZWF 771', 'Renault', 'Captur', 2018, 'ENG200006', 'CHS200006', 'Black', 95688, 'Hybrid', 'Automatic', 1, '2021-10-05', 1170048.13, 1243062.06, 3, 3),
('07 SFF 903', 'Honda', 'Accord', 2019, 'ENG200007', 'CHS200007', 'Gray', 91815, 'Diesel', 'Manual', 1, '2021-04-26', 587908.92, 711163.75, 4, 2),
('74 SQK 257', 'Ford', 'Focus', 2024, 'ENG200008', 'CHS200008', 'White', 50095, 'Diesel', 'Automatic', 1, '2022-11-21', 1087657.92, 1407817.29, 2, 1),
('52 DRL 618', 'Honda', 'Jazz', 2022, 'ENG200009', 'CHS200009', 'Gray', 117400, 'Electric', 'Automatic', 1, '2022-08-26', 526174.58, 613122.88, 4, 3),
('22 YJP 471', 'Renault', 'Clio', 2018, 'ENG200010', 'CHS200010', 'Black', 80504, 'Petrol', 'Automatic', 1, '2023-11-09', 1191245.9, 1435127.83, 3, 2),
('61 EDM 764', 'Volkswagen', 'Golf', 2019, 'ENG200011', 'CHS200011', 'Black', 70757, 'Electric', 'Manual', 1, '2024-07-10', 976306.76, 1125154.54, 1, 2),
('65 EJL 391', 'Ford', 'Focus', 2018, 'ENG200012', 'CHS200012', 'Black', 43125, 'Petrol', 'Manual', 1, '2021-09-26', 551020.29, 633896.53, 4, 2),
('31 DES 808', 'Honda', 'Jazz', 2022, 'ENG200013', 'CHS200013', 'Gray', 60002, 'Hybrid', 'Manual', 1, '2021-11-26', 573312.2, 692037.56, 4, 3),
('66 SUQ 479', 'Volkswagen', 'Polo', 2019, 'ENG200014', 'CHS200014', 'White', 39424, 'Diesel', 'Automatic', 1, '2022-10-01', 1030791.67, 1224775.88, 4, 1),
('16 XVQ 672', 'Renault', 'Captur', 2020, 'ENG200015', 'CHS200015', 'Blue', 29416, 'Diesel', 'Manual', 1, '2024-04-22', 495410.95, 598654.84, 4, 3),
('67 FUY 692', 'Renault', 'Megane', 2022, 'ENG200016', 'CHS200016', 'White', 113915, 'Petrol', 'Automatic', 1, '2022-10-16', 719948.06, 771745.09, 4, 3),
('53 ELR 793', 'Volkswagen', 'Passat', 2021, 'ENG200017', 'CHS200017', 'Gray', 5683, 'Electric', 'Automatic', 1, '2023-07-24', 950291.55, 1010527.46, 4, 2),
('20 LJR 650', 'Honda', 'Civic', 2021, 'ENG200018', 'CHS200018', 'Red', 67168, 'Hybrid', 'Manual', 1, '2024-03-26', 364031.61, 400563.65, 2, 1),
('80 WPA 971', 'Renault', 'Clio', 2019, 'ENG200019', 'CHS200019', 'Gray', 13696, 'Electric', 'Automatic', 1, '2023-05-24', 713089.31, 868192.68, 2, 3),
('01 REF 924', 'Volkswagen', 'Passat', 2022, 'ENG200020', 'CHS200020', 'Blue', 66581, 'Electric', 'Automatic', 1, '2022-09-04', 1101112.09, 1320584.47, 2, 2),
('01 WCH 887', 'Ford', 'Mondeo', 2018, 'ENG200021', 'CHS200021', 'Blue', 25493, 'Petrol', 'Automatic', 1, '2024-05-08', 979702.08, 1190066.12, 2, 2),
('68 IBE 430', 'Toyota', 'Yaris', 2024, 'ENG200022', 'CHS200022', 'Blue', 25411, 'Hybrid', 'Automatic', 1, '2024-01-21', 626618.12, 694098.84, 1, 3),
('72 SOR 752', 'Ford', 'Focus', 2020, 'ENG200023', 'CHS200023', 'White', 115441, 'Electric', 'Automatic', 1, '2024-01-17', 956014.0, 1133521.23, 1, 2),
('42 KBO 369', 'Honda', 'Civic', 2019, 'ENG200024', 'CHS200024', 'Red', 88823, 'Diesel', 'Automatic', 1, '2020-01-02', 837632.16, 939639.81, 3, 1),
('31 JTC 14', 'Ford', 'Fiesta', 2022, 'ENG200025', 'CHS200025', 'Red', 98221, 'Electric', 'Automatic', 1, '2021-09-10', 956868.61, 1072298.27, 3, 2),
('27 RYO 965', 'Volkswagen', 'Polo', 2022, 'ENG200026', 'CHS200026', 'Black', 70533, 'Electric', 'Manual', 1, '2023-02-08', 526827.56, 588968.07, 1, 1),
('07 ULF 217', 'Volkswagen', 'Polo', 2024, 'ENG200027', 'CHS200027', 'Gray', 97658, 'Diesel', 'Automatic', 1, '2024-09-28', 694771.18, 867330.14, 1, 2),
('67 TLO 966', 'Toyota', 'Corolla', 2020, 'ENG200028', 'CHS200028', 'White', 110430, 'Hybrid', 'Manual', 1, '2022-01-06', 562023.15, 633918.16, 3, 2),
('09 PHJ 528', 'Honda', 'Civic', 2021, 'ENG200029', 'CHS200029', 'Red', 84906, 'Diesel', 'Automatic', 1, '2021-06-05', 653947.05, 783828.39, 4, 2);

-- Müşteri verileri
INSERT INTO Customers (CustomerFirstName, CustomerLastName, CustomerNationalID, CustomerDateOfBirth, CustomerLicenseNumber, CustomerLicenseClass, CustomerLicenseDate, CustomerPhone, CustomerEmail, CustomerAddress, CustomerType) VALUES 
('Ahmet', 'Yılmaz', '12345678901', '1985-05-10', 'LIC123456', 'B', '2010-06-15', '905551234567', 'ahmet@email.com', 'Atatürk Caddesi No:15, Beşiktaş, İstanbul', 'Individual'),
('Ayşe', 'Kaya', '23456789012', '1990-08-22', 'LIC234567', 'B', '2012-09-30', '905552345678', 'ayse@email.com', 'Cumhuriyet Caddesi No:8, Çankaya, Ankara', 'Individual'),
('Mehmet', 'Demir', '34567890123', '1978-03-15', 'LIC345678', 'B,E', '2005-04-20', '905553456789', 'mehmet@email.com', 'İnönü Caddesi No:42, Konak, İzmir', 'Individual'),
('Zeynep', 'Çelik', '45678901234', '1995-11-30', 'LIC456789', 'B', '2018-12-05', '905554567890', 'zeynep@email.com', 'Lara Caddesi No:24, Muratpaşa, Antalya', 'Individual'),
('Mustafa', 'Öztürk', '56789012345', '1982-07-18', 'LIC567890', 'B,C', '2008-08-22', '905555678901', 'mustafa@email.com', 'Meydan Sokak No:7, Bodrum, Muğla', 'Individual'),
('Anadolu', 'Lojistik', '67890123456', '2002-01-20', 'LIC5657891', 'B,C,E', '2004-07-12', '908502345678', 'info@anadolulojistik.com', 'Organize Sanayi Bölgesi, No:15, Kocaeli', 'Corporate'),
('Sadiye', 'Demir', '04332181960', '1961-05-03', 'LIC1338908', 'C,E', '2007-01-29', '903794026542', 'wsakarya@tevetoglu.info', 'İnönü Caddesi No:78, Muratpaşa, Antalya', 'Individual'),
('Güngören', 'Demir', '61849593103', '1979-01-01', 'LIC1316475', 'C,E', '2005-11-05', '905341928327', 'baltas30@gulen.com', 'Atatürk Caddesi No:88, Onikişubat, Kahramanmaraş', 'Individual'),
('Laika', 'Akgündüz', '53767242388', '1977-03-10', 'LIC9696532', 'B,C', '2017-08-25', '901012269166', 'tarhanilper@gmail.com', 'İnönü Caddesi No:187, Tepebaşı, Eskişehir', 'Individual'),
('Türknur', 'Akgündüz', '84514627048', '1971-06-20', 'LIC8148932', 'B', '2013-01-12', '908809570154', 'guldivan@inonu.com', 'İnönü Caddesi No:129, Karşıyaka, İzmir', 'Individual'),
('Erinçer', 'Ülker', '78248963834', '1986-06-18', 'LIC5787133', 'B', '2002-06-28', '900983930103', 'sagcanulker@bilir.org', 'Gazi Mustafa Kemal Bulvarı No:99, Çankaya, Ankara', 'Individual'),
('Mehrigül', 'Güçlü', '37631165667', '1962-12-30', 'LIC1065133', 'B,C,E', '2006-10-13', '902624731781', 'gucluerseven@guclu.com', 'İstiklal Caddesi No:142, Kadıköy, İstanbul', 'Individual'),
('Gürelcem', 'Kısakürek', '06474687234', '1974-02-14', 'LIC0980500', 'B', '2020-03-09', '908820812191', 'mansizbulunc@ulker.net', 'Atatürk Caddesi No:61, Konak, İzmir', 'Individual'),
('Temirhan', 'İhsanoğlu', '43534624751', '1959-12-11', 'LIC7991183', 'B,C', '2017-07-10', '902513542784', 'akcaeryildiz@yahoo.com', 'Cumhuriyet Caddesi No:145, Üsküdar, İstanbul', 'Individual'),
('Ekber', 'Akgündüz', '18244935348', '1992-07-21', 'LIC4016400', 'B,C,E', '2011-08-30', '904278680112', 'cyaman@arsoy.com', 'Mevlana Caddesi No:125, Bornova, İzmir', 'Individual'),
('Mahir', 'Tarhan', '31586923226', '1960-12-30', 'LIC2563421', 'B,C,E', '2013-04-30', '907337543303', 'yadigar86@havelsan.net', 'Gazi Mustafa Kemal Bulvarı No:127, Yenimahalle, Ankara', 'Individual'),
('Törel', 'Akça', '01429401965', '1980-08-27', 'LIC6981693', 'C,E', '2008-12-23', '906088356159', 'zhayrioglu@hotmail.com', 'İnönü Caddesi No:164, Onikişubat, Kahramanmaraş', 'Individual'),
('Sudi', 'Durmuş', '23662994680', '1979-12-27', 'LIC4369957', 'C,E', '2015-05-06', '903872148951', 'aliabbasturk@guclu.com', 'İstiklal Caddesi No:140, Selçuklu, Konya', 'Individual'),
('Ayşenur', 'Seven', '93676320163', '1971-04-12', 'LIC8708317', 'B,C,E', '2004-11-06', '908895798687', 'rifkiyeaslan@hotmail.com', 'Yavuz Sultan Selim Caddesi No:90, Tepebaşı, Eskişehir', 'Individual'),
('Dilhuş', 'Şener', '34714345581', '1968-09-22', 'LIC2362316', 'B', '2014-03-07', '908760366909', 'ozalpsan68@hotmail.com', 'Gazi Mustafa Kemal Bulvarı No:104, Onikişubat, Kahramanmaraş', 'Individual'),
('Şeyda', 'Duran', '93734670656', '1970-07-17', 'LIC7298069', 'B,C', '2019-07-08', '901627204653', 'sanli41@yahoo.com', 'Cumhuriyet Caddesi No:87, Çankaya, Ankara', 'Individual'),
('Akver', 'Korutürk', '80531003309', '1969-09-05', 'LIC3271937', 'B,E', '2024-02-10', '905299124190', 'binisikzengin@hotmail.com', 'Gazi Mustafa Kemal Bulvarı No:159, Selçuklu, Konya', 'Individual'),
('Pesent', 'Yüksel', '14919058651', '1993-09-27', 'LIC5067165', 'B,E', '2021-12-08', '902628498776', 'aslanaysema@inonu.org', 'Cumhuriyet Caddesi No:194, Bornova, İzmir', 'Individual'),
('Nezengül', 'Ülker', '65075273545', '1978-05-04', 'LIC9480831', 'B,C,E', '2008-07-10', '907837770143', 'hdurmus@yahoo.com', 'Adnan Menderes Bulvarı No:67, Onikişubat, Kahramanmaraş', 'Individual'),
('Şerafeddin', 'Korutürk', '85574443135', '1967-06-12', 'LIC8233749', 'C,E', '2018-02-28', '901343524082', 'sabihebilge@yahoo.com', 'Mevlana Caddesi No:14, Osmangazi, Bursa', 'Individual'),
('Diken', 'Bilge', '09477752047', '1967-01-27', 'LIC1671902', 'B,C,E', '2005-05-22', '901318699938', 'khancer@hotmail.com', 'Yavuz Sultan Selim Caddesi No:142, Keçiören, Ankara', 'Individual'),
('Baykan', 'Mansız', '13341232812', '1959-06-29', 'LIC6797403', 'B,C,E', '2010-02-11', '907134936183', 'aksutanyolac@petkim.org', 'Barbaros Bulvarı No:163, Tepebaşı, Eskişehir', 'Individual'),
('Seyfullah', 'Dumanlı', '17464887719', '1962-01-08', 'LIC6594013', 'C', '2023-04-03', '904902787429', 'idiris55@hotmail.com', 'İstiklal Caddesi No:42, Odunpazarı, Eskişehir', 'Individual'),
('Dinçsü', 'Akdeniz', '25674680715', '1976-06-26', 'LIC5168087', 'B', '2014-05-16', '903859770348', 'yildirimrakide@hotmail.com', 'Yavuz Sultan Selim Caddesi No:179, Atakum, Samsun', 'Individual'),
('Nihai', 'Demirel', '24808613171', '2003-05-21', 'LIC2748467', 'B,C', '2016-05-18', '907826398214', 'arslansadiman@yahoo.com', 'Barbaros Bulvarı No:60, Karşıyaka, İzmir', 'Individual'),
('Muarra', 'Zengin', '72787558867', '1981-03-16', 'LIC3396360', 'B,C', '2011-02-20', '906627028951', 'gulfersan@yahoo.com', 'Yavuz Sultan Selim Caddesi No:10, Odunpazarı, Eskişehir', 'Individual'),
('Sernur', 'Manço', '17459615865', '2001-12-18', 'LIC7809134', 'B,C,E', '2008-01-20', '906117240050', 'odkanlifirat@yahoo.com', 'İstiklal Caddesi No:68, Keçiören, Ankara', 'Corporate'),
('Kübran', 'Tarhan', '22219693792', '1975-02-10', 'LIC7474074', 'B,C', '2023-05-15', '901759464743', 'wdurdu@oyak.com', 'Mevlana Caddesi No:60, Karatay, Konya', 'Corporate'),
('Alaaddin', 'Karadeniz', '64090974395', '1974-03-19', 'LIC3942104', 'B,E', '2015-04-24', '909521456232', 'oguzmancamurcuoglu@yahoo.com', 'Adnan Menderes Bulvarı No:196, Osmangazi, Bursa', 'Corporate'),
('Suat', 'Korutürk', '51712368516', '1960-04-03', 'LIC4817549', 'C,E', '2013-04-11', '901370985931', 'ayboraakca@hancer.com', 'Mevlana Caddesi No:197, Karşıyaka, İzmir', 'Corporate'),
('Dağistan', 'Yüksel', '82675869261', '1992-08-10', 'LIC9640537', 'B,C,E', '2015-06-11', '905158506431', 'cetinturkalp@yaman.com', 'Yavuz Sultan Selim Caddesi No:73, Atakum, Samsun', 'Corporate');


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
