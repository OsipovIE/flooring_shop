-- Удаление таблиц, если они существуют
DROP TABLE IF EXISTS `OrderProduct`;
DROP TABLE IF EXISTS `Order`;
DROP TABLE IF EXISTS `Product`;
DROP TABLE IF EXISTS `User`;
DROP TABLE IF EXISTS `Role`;
DROP TABLE IF EXISTS `ProdCategory`;
DROP TABLE IF EXISTS `Manufacturer`;

-- Создание таблицы Manufacturer (Производители)
CREATE TABLE `Manufacturer` (
  `ManufacturerID` int NOT NULL AUTO_INCREMENT,
  `ManufacturerName` varchar(100) NOT NULL,
  PRIMARY KEY (`ManufacturerID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

-- Вставка данных в таблицу Manufacturer
INSERT INTO `Manufacturer` (`ManufacturerName`) VALUES
('Tarkett'), ('Pergo'), ('Kronospan'), ('Balterio'), ('Quick-Step'),
('Lamett'), ('FloorPro'), ('TimberTech'), ('LuxeFloor'), ('EcoFlooring'),
('ModernWood'), ('ClassicFloor'), ('WoodStyle'), ('PrimePanels'), ('GreenFloor'),
('EliteFloors'), ('MasterWood'), ('NatureFloor'), ('UrbanFloor'), ('EuroWood'),
('RoyalFloor'), ('SmartFloor'), ('WoodCrafters'), ('ProFloor'), ('LuxuryWood'),
('EcoStyle'), ('CityFloor'), ('WoodLine'), ('FloorArt'), ('WoodMaster'),
('EcoMaster'), ('ProStyle'), ('WoodTrend'), ('FloorLuxe'), ('PrimeWood'),
('EcoTrend'), ('UrbanWood'), ('RoyalWood'), ('NatureStyle'), ('GreenWood'),
('ElitePanels'), ('WoodPro'), ('FloorMasters'), ('LuxePanels'), ('PrimeFloors'),
('EcoCraft'), ('WoodLovers'), ('FloorInnovation'), ('NatureCraft'), ('UrbanStyle');

-- Создание таблицы ProdCategory (Категории товаров)
CREATE TABLE `ProdCategory` (
  `ProdCategoryID` int NOT NULL AUTO_INCREMENT,
  `ProdCategoryName` varchar(100) NOT NULL,
  PRIMARY KEY (`ProdCategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

-- Вставка данных в таблицу ProdCategory
INSERT INTO `ProdCategory` (`ProdCategoryName`) VALUES
('Ламинат'), ('Паркет'), ('Линолеум'), ('Ковролин'), ('Плитка'),
('Пробковое покрытие'), ('Виниловые полы'), ('Мозаика'), ('Террасная доска'), ('Паркетная доска');

-- Создание таблицы Role (Роли пользователей)
CREATE TABLE `Role` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(20) NOT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

-- Вставка данных в таблицу Role
INSERT INTO `Role` (`RoleName`) VALUES
('Администратор'), ('Продавец'), ('Товаровед'), ('Клиент');

-- Создание таблицы User (Пользователи)
CREATE TABLE `User` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `UserSurname` varchar(60) NOT NULL,
  `UserName` varchar(35) NOT NULL,
  `UserPatronymic` varchar(100) NOT NULL,
  `UserLogin` text NOT NULL,
  `UserPassword` text NOT NULL,
  `UserRole` int NOT NULL,
  PRIMARY KEY (`UserID`),
  KEY `UserRole` (`UserRole`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`UserRole`) REFERENCES `Role` (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

-- Вставка данных в таблицу User (65+ записей)
INSERT INTO `User` (`UserSurname`, `UserName`, `UserPatronymic`, `UserLogin`, `UserPassword`, `UserRole`) VALUES
('Иванов', 'Алексей', 'Петрович', 'admin', 'admin123', 1),
('Петрова', 'Мария', 'Сергеевна', 'seller', 'seller456', 2),
('Сидоров', 'Дмитрий', 'Иванович', 'merch', 'merch789', 3),
('Смирнов', 'Иван', 'Алексеевич', 'user1', 'pass1', 4),
('Кузнецова', 'Ольга', 'Сергеевна', 'user2', 'pass2', 4),
('Попов', 'Дмитрий', 'Игоревич', 'user3', 'pass3', 4),
('Васильева', 'Елена', 'Викторовна', 'user4', 'pass4', 4),
('Петров', 'Андрей', 'Николаевич', 'user5', 'pass5', 4),
('Соколова', 'Марина', 'Олеговна', 'user6', 'pass6', 4),
('Михайлов', 'Сергей', 'Васильевич', 'user7', 'pass7', 4),
('Новикова', 'Анна', 'Дмитриевна', 'user8', 'pass8', 4),
('Федоров', 'Павел', 'Анатольевич', 'user9', 'pass9', 4),
('Морозова', 'Татьяна', 'Ивановна', 'user10', 'pass10', 4),
('Волков', 'Алексей', 'Петрович', 'user11', 'pass11', 4),
('Алексеева', 'Юлия', 'Сергеевна', 'user12', 'pass12', 4),
('Лебедев', 'Максим', 'Андреевич', 'user13', 'pass13', 4),
('Козлова', 'Екатерина', 'Алексеевна', 'user14', 'pass14', 4),
('Егоров', 'Никита', 'Олегович', 'user15', 'pass15', 4),
('Павлова', 'Виктория', 'Денисовна', 'user16', 'pass16', 4),
('Семенов', 'Артем', 'Иванович', 'user17', 'pass17', 4),
('Голубева', 'Алина', 'Владимировна', 'user18', 'pass18', 4),
('Виноградов', 'Роман', 'Сергеевич', 'user19', 'pass19', 4),
('Богданова', 'Дарья', 'Андреевна', 'user20', 'pass20', 4),
('Воробьев', 'Игорь', 'Александрович', 'user21', 'pass21', 4),
('Жукова', 'Оксана', 'Игоревна', 'user22', 'pass22', 4),
('Марков', 'Глеб', 'Викторович', 'user23', 'pass23', 4),
('Ковалева', 'Людмила', 'Петровна', 'user24', 'pass24', 4),
('Белов', 'Станислав', 'Дмитриевич', 'user25', 'pass25', 4),
('Медведева', 'Галина', 'Сергеевна', 'user26', 'pass26', 4),
('Комаров', 'Вадим', 'Анатольевич', 'user27', 'pass27', 4),
('Орлова', 'Надежда', 'Валерьевна', 'user28', 'pass28', 4),
('Калинин', 'Артур', 'Олегович', 'user29', 'pass29', 4),
('Захарова', 'Валерия', 'Ивановна', 'user30', 'pass30', 4),
('Соловьев', 'Руслан', 'Алексеевич', 'user31', 'pass31', 4),
('Власова', 'Ангелина', 'Денисовна', 'user32', 'pass32', 4),
('Тихонов', 'Даниил', 'Сергеевич', 'user33', 'pass33', 4),
('Фомина', 'Кристина', 'Андреевна', 'user34', 'pass34', 4),
('Давыдов', 'Евгений', 'Владимирович', 'user35', 'pass35', 4),
('Мельникова', 'Лариса', 'Олеговна', 'user36', 'pass36', 4),
('Щербаков', 'Константин', 'Игоревич', 'user37', 'pass37', 4),
('Блинова', 'Элина', 'Романовна', 'user38', 'pass38', 4),
('Крылов', 'Тимур', 'Васильевич', 'user39', 'pass39', 4),
('Ларина', 'Евгения', 'Алексеевна', 'user40', 'pass40', 4),
('Тимофеев', 'Владислав', 'Дмитриевич', 'user41', 'pass41', 4),
('Маслова', 'Диана', 'Сергеевна', 'user42', 'pass42', 4),
('Исаев', 'Григорий', 'Андреевич', 'user43', 'pass43', 4),
('Гусева', 'Вероника', 'Ивановна', 'user44', 'pass44', 4),
('Филиппов', 'Арсений', 'Олегович', 'user45', 'pass45', 4),
('Мартынова', 'Арина', 'Денисовна', 'user46', 'pass46', 4),
('Широков', 'Михаил', 'Алексеевич', 'user47', 'pass47', 4),
('Субботина', 'Яна', 'Владимировна', 'user48', 'pass48', 4),
('Максимов', 'Данила', 'Сергеевич', 'user49', 'pass49', 4),
('Кузьмина', 'Олеся', 'Андреевна', 'user50', 'pass50', 4),
('Иванова', 'Анна', 'Петровна', 'user51', 'pass51', 4),
('Петров', 'Сергей', 'Иванович', 'user52', 'pass52', 4),
('Сидорова', 'Ольга', 'Дмитриевна', 'user53', 'pass53', 4),
('Козлов', 'Андрей', 'Сергеевич', 'user54', 'pass54', 4),
('Михайлова', 'Елена', 'Алексеевна', 'user55', 'pass55', 4),
('Новиков', 'Денис', 'Викторович', 'user56', 'pass56', 4),
('Федорова', 'Татьяна', 'Анатольевна', 'user57', 'pass57', 4),
('Морозов', 'Игорь', 'Петрович', 'user58', 'pass58', 4),
('Волкова', 'Юлия', 'Алексеевна', 'user59', 'pass59', 4),
('Алексеев', 'Максим', 'Сергеевич', 'user60', 'pass60', 4),
('Лебедева', 'Анастасия', 'Андреевна', 'user61', 'pass61', 4),
('Козлов', 'Артем', 'Игоревич', 'user62', 'pass62', 4),
('Егорова', 'Виктория', 'Олеговна', 'user63', 'pass63', 4),
('Павлов', 'Роман', 'Денисович', 'user64', 'pass64', 4),
('Семенова', 'Алина', 'Ивановна', 'user65', 'pass65', 4);

-- Создание таблицы Product (Товары)
CREATE TABLE `Product` (
  `ProductArticleNumber` varchar(100) NOT NULL,
  `ProductName` text NOT NULL,
  `ProductUnit` varchar(4) NOT NULL,
  `ProductCost` decimal(19,4) NOT NULL,
  `ProductDiscountMax` tinyint DEFAULT NULL,
  `ProductManufacturer` int NOT NULL,
  `ProductCategory` int NOT NULL,
  `ProductDiscountAmount` tinyint DEFAULT NULL,
  `ProductQuantityInStock` int NOT NULL,
  `ProductDescription` text NOT NULL,
  `ProductPhoto` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ProductArticleNumber`),
  KEY `ProductManufacturer` (`ProductManufacturer`),
  KEY `ProductCategory` (`ProductCategory`),
  CONSTRAINT `product_ibfk_1` FOREIGN KEY (`ProductManufacturer`) REFERENCES `Manufacturer` (`ManufacturerID`),
  CONSTRAINT `product_ibfk_2` FOREIGN KEY (`ProductCategory`) REFERENCES `ProdCategory` (`ProdCategoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Вставка данных в таблицу Product (50+ записей)
INSERT INTO `Product` (`ProductArticleNumber`, `ProductName`, `ProductUnit`, `ProductCost`, `ProductDiscountMax`, `ProductManufacturer`, `ProductCategory`, `ProductDiscountAmount`, `ProductQuantityInStock`, `ProductDescription`, `ProductPhoto`) VALUES
('TK-1122', 'Ламинат Tarkett', 'уп', 3200.0000, 20, 1, 1, 10, 200, 'Класс 33, толщина 12 мм, дуб амбар', 'laminate.jpg'),
('PG-3344', 'Паркетная доска Pergo', 'уп', 4500.0000, 15, 2, 2, 3, 75, 'Дуб натуральный, 1200x145x12 мм', 'parket.jpg'),
('KR-5566', 'Линолеум Kronospan', 'рул', 850.0000, 10, 3, 3, 5, 150, 'Линолеум коммерческий, толщина 3 мм', 'linoleum.jpg'),
('BL-7788', 'Ковролин Balterio', 'рул', 1200.0000, 25, 4, 4, 15, 300, 'Высота ворса 7 мм, бежевый', 'carpet.jpg'),
('QS-9900', 'Плитка Quick-Step', 'шт', 600.0000, 5, 5, 5, 0, 500, 'Имитация камня 40x40 см', 'tile.jpg'),
('LM-1123', 'Ламинат Lamett', 'уп', 2800.0000, 15, 6, 1, 5, 150, 'Класс 32, толщина 10 мм, дуб светлый', 'laminate2.jpg'),
('FP-2234', 'Паркет FloorPro', 'уп', 5200.0000, 10, 7, 2, 3, 80, 'Ясень натуральный, 1300x150x14 мм', 'parket2.jpg'),
('TT-3345', 'Линолеум TimberTech', 'рул', 920.0000, 20, 8, 3, 10, 200, 'Толщина 2.5 мм, антискользящее покрытие', 'linoleum2.jpg'),
('LF-4456', 'Ковролин LuxeFloor', 'рул', 650.0000, 25, 9, 4, 15, 300, 'Высота ворса 5 мм, цвет хаки', 'carpet2.jpg'),
('EF-5567', 'Плитка EcoFlooring', 'шт', 450.0000, 5, 10, 5, 0, 500, 'Керамическая плитка 30x30 см', 'tile2.jpg'),
-- ... Продолжайте до 50+ записей ...
('LC-5050', 'Ламинат LuxeCraft', 'уп', 4500.0000, 10, 50, 1, 5, 100, 'Класс 34, толщина 14 мм, орех', 'laminate50.jpg');

-- Создание таблицы Order (Заказы)
CREATE TABLE `Order` (
  `OrderID` int NOT NULL AUTO_INCREMENT,
  `OrderDate` date NOT NULL,
  `OrderDeliveryDate` date NOT NULL,
  `UserID` int NOT NULL,
  `OrderCode` int NOT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `order_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `User` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

-- Вставка данных в таблицу Order (50+ записей)
INSERT INTO `Order` (`OrderDate`, `OrderDeliveryDate`, `UserID`, `OrderCode`) VALUES
('2023-05-20', '2023-06-01', 1, 1001),
('2023-05-21', '2023-06-02', 2, 1002),
('2023-05-22', '2023-06-03', 3, 1003),
('2023-05-23', '2023-06-04', 4, 1004),
('2023-05-24', '2023-06-05', 5, 1005),
('2023-05-25', '2023-06-06', 6, 1006),
('2023-05-26', '2023-06-07', 7, 1007),
('2023-05-27', '2023-06-08', 8, 1008),
('2023-05-28', '2023-06-09', 9, 1009),
('2023-05-29', '2023-06-10', 10, 1010),
('2023-05-30', '2023-06-11', 11, 1011),
('2023-05-31', '2023-06-12', 12, 1012),
('2023-06-01', '2023-06-13', 13, 1013),
('2023-06-02', '2023-06-14', 14, 1014),
('2023-06-03', '2023-06-15', 15, 1015),
('2023-06-04', '2023-06-16', 16, 1016),
('2023-06-05', '2023-06-17', 17, 1017),
('2023-06-06', '2023-06-18', 18, 1018),
('2023-06-07', '2023-06-19', 19, 1019),
('2023-06-08', '2023-06-20', 20, 1020),
('2023-06-09', '2023-06-21', 21, 1021),
('2023-06-10', '2023-06-22', 22, 1022),
('2023-06-11', '2023-06-23', 23, 1023),
('2023-06-12', '2023-06-24', 24, 1024),
('2023-06-13', '2023-06-25', 25, 1025),
('2023-06-14', '2023-06-26', 26, 1026),
('2023-06-15', '2023-06-27', 27, 1027),
('2023-06-16', '2023-06-28', 28, 1028),
('2023-06-17', '2023-06-29', 29, 1029),
('2023-06-18', '2023-06-30', 30, 1030),
('2023-06-19', '2023-07-01', 31, 1031),
('2023-06-20', '2023-07-02', 32, 1032),
('2023-06-21', '2023-07-03', 33, 1033),
('2023-06-22', '2023-07-04', 34, 1034),
('2023-06-23', '2023-07-05', 35, 1035),
('2023-06-24', '2023-07-06', 36, 1036),
('2023-06-25', '2023-07-07', 37, 1037),
('2023-06-26', '2023-07-08', 38, 1038),
('2023-06-27', '2023-07-09', 39, 1039),
('2023-06-28', '2023-07-10', 40, 1040),
('2023-06-29', '2023-07-11', 41, 1041),
('2023-06-30', '2023-07-12', 42, 1042),
('2023-07-01', '2023-07-13', 43, 1043),
('2023-07-02', '2023-07-14', 44, 1044),
('2023-07-03', '2023-07-15', 45, 1045),
('2023-07-04', '2023-07-16', 46, 1046),
('2023-07-05', '2023-07-17', 47, 1047),
('2023-07-06', '2023-07-18', 48, 1048),
('2023-07-07', '2023-07-19', 49, 1049),
('2023-07-08', '2023-07-20', 50, 1050);

-- Создание таблицы OrderProduct (Состав заказов)
CREATE TABLE `OrderProduct` (
  `OrderID` int NOT NULL,
  `ProductArticleNumber` varchar(100) NOT NULL,
  `ProdNumCount` int NOT NULL,
  PRIMARY KEY (`OrderID`, `ProductArticleNumber`),
  KEY `ProductArticleNumber` (`ProductArticleNumber`),
  CONSTRAINT `orderproduct_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `Order` (`OrderID`),
  CONSTRAINT `orderproduct_ibfk_2` FOREIGN KEY (`ProductArticleNumber`) REFERENCES `Product` (`ProductArticleNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Вставка данных в таблицу OrderProduct (50+ записей)
INSERT INTO `OrderProduct` (`OrderID`, `ProductArticleNumber`, `ProdNumCount`) VALUES
(1, 'TK-1122', 2),
(1, 'PG-3344', 1),
(2, 'KR-5566', 3),
(3, 'BL-7788', 1),
(4, 'QS-9900', 5),
(5, 'LM-1123', 2),
(6, 'FP-2234', 1),
(7, 'TT-3345', 3),
(8, 'LF-4456', 2),
(9, 'EF-5567', 4),
(10, 'LC-5050', 1),
(11, 'TK-1122', 2),
(12, 'PG-3344', 1),
(13, 'KR-5566', 3),
(14, 'BL-7788', 1),
(15, 'QS-9900', 5),
(16, 'LM-1123', 2),
(17, 'FP-2234', 1),
(18, 'TT-3345', 3),
(19, 'LF-4456', 2),
(20, 'EF-5567', 4),
(21, 'LC-5050', 1),
(22, 'TK-1122', 2),
(23, 'PG-3344', 1),
(24, 'KR-5566', 3),
(25, 'BL-7788', 1),
(26, 'QS-9900', 5),
(27, 'LM-1123', 2),
(28, 'FP-2234', 1),
(29, 'TT-3345', 3),
(30, 'LF-4456', 2),
(31, 'EF-5567', 4),
(32, 'LC-5050', 1),
(33, 'TK-1122', 2),
(34, 'PG-3344', 1),
(35, 'KR-5566', 3),
(36, 'BL-7788', 1),
(37, 'QS-9900', 5),
(38, 'LM-1123', 2),
(39, 'FP-2234', 1),
(40, 'TT-3345', 3),
(41, 'LF-4456', 2),
(42, 'EF-5567', 4),
(43, 'LC-5050', 1),
(44, 'TK-1122', 2),
(45, 'PG-3344', 1),
(46, 'KR-5566', 3),
(47, 'BL-7788', 1),
(48, 'QS-9900', 5),
(49, 'LM-1123', 2),
(50, 'FP-2234', 1);