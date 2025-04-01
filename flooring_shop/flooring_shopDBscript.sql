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

-- Создание таблицы ProdCategory (Категории товаров)
CREATE TABLE `ProdCategory` (
  `ProdCategoryID` int NOT NULL AUTO_INCREMENT,
  `ProdCategoryName` varchar(100) NOT NULL,
  PRIMARY KEY (`ProdCategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;


-- Создание таблицы Role (Роли пользователей)
CREATE TABLE `Role` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(20) NOT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

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
