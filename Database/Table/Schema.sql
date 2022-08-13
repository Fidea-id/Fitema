-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.16-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.0.0.6468
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for fitema
CREATE DATABASE IF NOT EXISTS `fitema` /*!40100 DEFAULT CHARACTER SET armscii8 COLLATE armscii8_bin */;
USE `fitema`;

-- Dumping structure for table fitema.bills
CREATE TABLE IF NOT EXISTS `bills` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrgId` int(11) DEFAULT NULL,
  `PlanId` int(11) DEFAULT NULL,
  `VoucherCode` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `TotalPayment` int(11) DEFAULT NULL,
  `Status` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Organizations_Bills` (`OrgId`),
  KEY `FK_Plans_Bills` (`PlanId`),
  CONSTRAINT `FK_Organizations_Bills` FOREIGN KEY (`OrgId`) REFERENCES `organizations` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Plans_Bills` FOREIGN KEY (`PlanId`) REFERENCES `plans` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.customers
CREATE TABLE IF NOT EXISTS `customers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrgId` int(11) DEFAULT NULL,
  `Name` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Email` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `PhoneNumber` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Organization_Customers` (`OrgId`),
  CONSTRAINT `FK_Organization_Customers` FOREIGN KEY (`OrgId`) REFERENCES `organizations` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.fitemadata
CREATE TABLE IF NOT EXISTS `fitemadata` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Key` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Value` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Type` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.organizations
CREATE TABLE IF NOT EXISTS `organizations` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Address` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Description` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `StatusId` int(11) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Organizations_Status` (`StatusId`),
  CONSTRAINT `FK_Organizations_Status` FOREIGN KEY (`StatusId`) REFERENCES `status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.orgoptions
CREATE TABLE IF NOT EXISTS `orgoptions` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrgId` int(11) DEFAULT NULL,
  `Key` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Value` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Type` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Organizations_OrgOptions` (`OrgId`),
  CONSTRAINT `FK_Organizations_OrgOptions` FOREIGN KEY (`OrgId`) REFERENCES `organizations` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.plans
CREATE TABLE IF NOT EXISTS `plans` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Description` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Price` int(11) DEFAULT NULL,
  `Promo` int(11) DEFAULT NULL,
  `StatusId` int(11) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Plans_Status` (`StatusId`),
  CONSTRAINT `FK_Plans_Status` FOREIGN KEY (`StatusId`) REFERENCES `status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.products
CREATE TABLE IF NOT EXISTS `products` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrgId` int(11) DEFAULT NULL,
  `Name` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Price` int(11) DEFAULT NULL,
  `Promo` int(11) DEFAULT NULL,
  `Period` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Products_Organizations` (`OrgId`),
  CONSTRAINT `FK_Products_Organizations` FOREIGN KEY (`OrgId`) REFERENCES `organizations` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.status
CREATE TABLE IF NOT EXISTS `status` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE armscii8_bin DEFAULT NULL,
  `Type` varchar(50) COLLATE armscii8_bin DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.systemlog
CREATE TABLE IF NOT EXISTS `systemlog` (
  `Id` int(11) NOT NULL,
  `Status` varchar(50) COLLATE armscii8_bin DEFAULT NULL,
  `Type` varchar(50) COLLATE armscii8_bin DEFAULT NULL,
  `Detail` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.transactions
CREATE TABLE IF NOT EXISTS `transactions` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerId` int(11) DEFAULT NULL,
  `ProductId` int(11) DEFAULT NULL,
  `OrgId` int(11) DEFAULT NULL,
  `OrderFrom` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `Duration` int(11) DEFAULT NULL,
  `DurationType` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `StatusId` int(11) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Transactions_Customers` (`CustomerId`),
  KEY `FK_Transactions_Products` (`ProductId`),
  KEY `FK_Transactions_Status` (`StatusId`),
  KEY `FK_Transactions_Organizations` (`OrgId`),
  CONSTRAINT `FK_Transactions_Customers` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Transactions_Organizations` FOREIGN KEY (`OrgId`) REFERENCES `organizations` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Transactions_Products` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Transactions_Status` FOREIGN KEY (`StatusId`) REFERENCES `status` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.users
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FullName` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Email` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Password` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `Role` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `OrgId` int(11) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Email` (`Email`),
  KEY `FK_Users_Organizations` (`OrgId`),
  CONSTRAINT `FK_Users_Organizations` FOREIGN KEY (`OrgId`) REFERENCES `organizations` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table fitema.vouchers
CREATE TABLE IF NOT EXISTS `vouchers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Code` varchar(255) COLLATE armscii8_bin DEFAULT NULL,
  `PlanId` int(11) DEFAULT NULL,
  `Promo` int(11) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Code` (`Code`),
  KEY `FK_Vouchers_Plans` (`PlanId`),
  CONSTRAINT `FK_Vouchers_Plans` FOREIGN KEY (`PlanId`) REFERENCES `plans` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
