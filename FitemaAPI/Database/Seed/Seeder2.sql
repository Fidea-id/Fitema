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


-- Dumping data for table fitema.plans: ~3 rows (approximately)
INSERT IGNORE INTO `plans` (`Id`, `Name`, `Description`, `Price`, `Promo`, `StatusId`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'Free', NULL, 0, NULL, 4, '2022-08-13 13:22:18', '2022-08-13 13:22:18'),
	(2, 'Basic', NULL, 50000, NULL, 4, '2022-08-13 13:22:53', '2022-08-13 13:22:53'),
	(3, 'Premium', NULL, 100000, NULL, 4, '2022-08-20 14:06:39', '2022-08-20 14:06:40');
-- Dumping data for table fitema.status: ~7 rows (approximately)
INSERT IGNORE INTO `status` (`Id`, `Name`, `Type`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'On Going', 'Transactions', '2022-08-11 02:50:37', '2022-08-11 02:50:38'),
	(2, 'Completed', 'Transactions', '2022-08-11 02:50:49', '2022-08-11 02:50:49'),
	(3, 'Expired', 'Transactions', '2022-08-11 02:50:59', '2022-08-11 02:50:59'),
	(4, 'Active', 'Active', '2022-08-11 02:54:25', '2022-08-11 02:54:26'),
	(5, 'In Active', 'Active', '2022-08-11 02:54:39', '2022-08-11 02:54:39'),
	(6, 'Paid', 'Bills', '2022-08-11 02:54:49', '2022-08-11 02:54:50'),
	(7, 'Need Payment', 'Bills', '2022-08-11 02:55:20', '2022-08-11 02:55:21'),
	(8, 'Overdue', 'Bills', '2022-08-11 02:55:30', '2022-08-11 02:55:30');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
