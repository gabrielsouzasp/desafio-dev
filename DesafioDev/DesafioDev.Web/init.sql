CREATE TABLE `transactions` (
  `Type` int(11) NOT NULL,
  `Date` varchar(10) NOT NULL,
  `Amount` decimal(13,2) NOT NULL,
  `Document` varchar(14) NOT NULL,
  `Card` varchar(12) NOT NULL,
  `Hour` varchar(6) NOT NULL,
  `StoreOwner` varchar(14) NOT NULL,
  `StoreName` varchar(19) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

