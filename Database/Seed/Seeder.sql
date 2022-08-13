-- Dumping database structure for fitema
USE `fitema`;

-- Dumping data for table fitema.plans: ~2 rows (approximately)
INSERT IGNORE INTO `plans` (`Id`, `Name`, `Description`, `Price`, `Promo`, `StatusId`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'Regular', NULL, 50000, NULL, 4, '2022-08-13 13:22:18', '2022-08-13 13:22:18'),
	(2, 'Pro', NULL, 100000, NULL, 5, '2022-08-13 13:22:53', '2022-08-13 13:22:53');

-- Dumping data for table fitema.status: ~8 rows (approximately)
INSERT IGNORE INTO `status` (`Id`, `Name`, `Type`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'On Going', 'Transactions', '2022-08-11 02:50:37', '2022-08-11 02:50:38'),
	(2, 'Completed', 'Transactions', '2022-08-11 02:50:49', '2022-08-11 02:50:49'),
	(3, 'Expired', 'Transactions', '2022-08-11 02:50:59', '2022-08-11 02:50:59'),
	(4, 'Active', 'Active', '2022-08-11 02:54:25', '2022-08-11 02:54:26'),
	(5, 'In Active', 'Active', '2022-08-11 02:54:39', '2022-08-11 02:54:39'),
	(6, 'Paid', 'Plans', '2022-08-11 02:54:49', '2022-08-11 02:54:50'),
	(7, 'Need Payment', 'Plans', '2022-08-11 02:55:20', '2022-08-11 02:55:21'),
	(8, 'Overdue', 'Plans', '2022-08-11 02:55:30', '2022-08-11 02:55:30');
