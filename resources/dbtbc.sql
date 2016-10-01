-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
<<<<<<< HEAD:dbtbc (2).sql
-- Generation Time: Oct 01, 2016 at 08:16 AM
=======
-- Generation Time: Sep 25, 2016 at 05:15 PM
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql
-- Server version: 10.1.16-MariaDB
-- PHP Version: 7.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbtbc`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbladministrators`
--

CREATE TABLE `tbladministrators` (
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `type` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbladministrators`
--

INSERT INTO `tbladministrators` (`username`, `password`, `type`) VALUES
<<<<<<< HEAD:dbtbc (2).sql
('admin', 'admin', 'manager'),
('test1', 'test1', 'cashier'),
('test2', 'test2', 'manager');
=======
('admin', 'admin', 'superuser'),
('z', 'mypass', 'Super User');
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql

-- --------------------------------------------------------

--
-- Table structure for table `tblcustomers`
--

CREATE TABLE `tblcustomers` (
  `cus_no` varchar(10) NOT NULL,
  `cus_name` varchar(25) NOT NULL,
  `cus_since` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `cus_loadwallet` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblcustomers`
--

INSERT INTO `tblcustomers` (`cus_no`, `cus_name`, `cus_since`, `cus_loadwallet`) VALUES
<<<<<<< HEAD:dbtbc (2).sql
('1', 'TEST', '2016-09-30 21:20:50', 100),
('tbc123', 'BETATESTER', '2016-09-30 21:20:34', 823);
=======
('tbc1', 'testtest', '2016-09-23 23:24:40', 100),
('tbc123', 'dfg', '2016-09-23 22:00:05', 200),
('tbc456', 'testing test', '2016-09-21 21:14:58', 300);
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql

-- --------------------------------------------------------

--
-- Table structure for table `tblinventory`
--

CREATE TABLE `tblinventory` (
  `inv_prod_code` varchar(6) NOT NULL DEFAULT '',
  `inv_qty` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblinventory`
--

INSERT INTO `tblinventory` (`inv_prod_code`, `inv_qty`) VALUES
<<<<<<< HEAD:dbtbc (2).sql
('DSG_SS', 50),
('DSH_BB', 50),
('DSH_C', 50),
('DSH_CB', 50),
('DSH_CC', 50),
('DSH_CP', 50),
('DSH_CS', 50),
('DSH_ES', 50),
('DSH_FB', 44),
('DSH_HS', 50),
('DSH_IB', 50),
('DSH_LS', 50),
('DSH_N', 50),
('DSH_PP', 50),
('DSH_SB', 50),
('DSH_SS', 50),
('DSH_TD', 48),
('DSH_TE', 49),
('DSH_UC', 50),
('D_BBT', 50),
('D_CK', 50),
('D_CL', 50),
('D_DP', 50),
('D_GAT', 50),
('D_HMT', 50),
('D_KT', 50),
('D_Lemo', 50),
('D_LL', 50),
('D_LT', 50),
('D_MM', 50),
('D_MMT', 50),
('D_MS', 50),
('D_MT', 50),
('D_OW', 50),
('D_PB', 50),
('D_PK', 50),
('D_PMK', 50),
('D_PT', 50),
('D_SB', 50),
('D_SMT', 50),
('D_SS', 50),
('D_ST', 50),
('D_TM', 50),
('D_TT', 48),
('D_VC', 50),
('D_WC', 50),
('D_WM', 50),
('D_ZD', 50);
=======
('DSG_SS', 31),
('DSH_BB', 30),
('DSH_C', 30),
('DSH_CB', 30),
('DSH_CC', 30),
('DSH_CP', 30),
('DSH_CS', 30),
('DSH_ES', 30),
('DSH_FB', 30),
('DSH_HS', 30),
('DSH_IB', 30),
('DSH_LS', 30),
('DSH_N', 30),
('DSH_PP', 30),
('DSH_SB', 30),
('DSH_SS', 29),
('DSH_TD', 30),
('DSH_TE', 25),
('DSH_UC', 30),
('D_BBT', 30),
('D_CK', 30),
('D_CL', 30),
('D_DP', 30),
('D_GAT', 30),
('D_HMT', 30),
('D_KT', 30),
('D_Lemo', 30),
('D_LL', 30),
('D_LT', 30),
('D_MM', 30),
('D_MMT', 30),
('D_MS', 21),
('D_MT', 30),
('D_OW', 30),
('D_PB', 30),
('D_PK', 30),
('D_PMK', 30),
('D_PT', 30),
('D_SB', 30),
('D_SMT', 30),
('D_SS', 30),
('D_ST', 30),
('D_TM', 30),
('D_TT', 28),
('D_VC', 30),
('D_WC', 30),
('D_WM', 30),
('D_ZD', 30);
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql

-- --------------------------------------------------------

--
-- Table structure for table `tblorders`
--

CREATE TABLE `tblorders` (
  `ord_code` varchar(15) NOT NULL,
  `total` double NOT NULL,
<<<<<<< HEAD:dbtbc (2).sql
  `ord_change` double NOT NULL,
  `ord_tendered` double NOT NULL,
=======
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql
  `ord_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblorders`
--

<<<<<<< HEAD:dbtbc (2).sql
INSERT INTO `tblorders` (`ord_code`, `total`, `ord_change`, `ord_tendered`, `ord_date`) VALUES
('011016011344-48', 70, 2242, 2312, '2016-10-01'),
('011016012511-44', 338, 162, 500, '2016-10-01'),
('011016013340-31', 695, 5, 700, '2016-10-01'),
('011016051639-85', 70, 0, 0, '2016-10-01'),
('011016051934-77', 149, 0, 0, '2016-10-01'),
('011016052034-70', 139, 0, 0, '2016-10-01');
=======
INSERT INTO `tblorders` (`ord_code`, `total`, `ord_date`) VALUES
('250916-12579', 147, '2016-09-25'),
('250916-19200', 110, '2016-09-25'),
('250916-25592', 98, '2016-09-25'),
('250916-32086', 350, '2016-09-25'),
('250916-70420', 129, '2016-09-25'),
('250916-80007', 745, '2016-09-25'),
('250916-89693', 220, '2016-09-25');
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql

-- --------------------------------------------------------

--
-- Table structure for table `tblorder_prod`
--

CREATE TABLE `tblorder_prod` (
  `ord_code` varchar(15) NOT NULL,
  `prod_code` varchar(6) NOT NULL,
  `prod_name` varchar(20) NOT NULL,
  `prod_qty` int(5) NOT NULL,
  `prod_price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblorder_prod`
--

INSERT INTO `tblorder_prod` (`ord_code`, `prod_code`, `prod_name`, `prod_qty`, `prod_price`) VALUES
<<<<<<< HEAD:dbtbc (2).sql
('011016011344-48', 'D_TT', 'Taro Treat Venti', 1, 70),
('011016012511-44', 'DSH_TD', 'TBC Double Decker', 2, 169),
('011016013340-31', 'DSH_FB', 'Flaming Buffalo Wing', 5, 139),
('011016051639-85', 'D_TT', 'Taro Treat Venti', 1, 70),
('011016051934-77', 'DSH_TE', 'Tofu Express', 1, 149),
('011016052034-70', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('260916022731-42', 'DSH_FB', 'Flaming Buffalo Wing', 5, 139),
('260916022731-42', 'DSH_TE', 'Tofu Express', 4, 149),
('260916023038-40', 'DSH_TE', 'Tofu Express', 5, 149),
('260916025711-75', 'DSH_SS', 'Sizzling Sisig', 5, 129),
('260916031217-32', 'DSH_SS', 'Sizzling Sisig', 5, 129),
('260916032015-72', 'DSH_CS', 'Chicksilog', 4, 59),
('260916032015-72', 'DSH_SS', 'Sizzling Sisig', 5, 129),
('260916032015-72', 'DSH_TD', 'TBC Double Decker', 4, 169),
('260916032015-72', 'DSH_TE', 'Tofu Express', 3, 149),
('260916032015-72', 'D_SB', 'Strawberry Blush Ven', 6, 70),
('260916032015-72', 'D_TT', 'Taro Treat Venti', 5, 70),
('260916032313-75', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('260916120537-90', 'D_TT', 'Taro Treat Grande', 1, 55),
('260916121322-72', 'DSH_TE', 'Tofu Express', 1, 149),
('260916121643-31', 'D_MS', 'Melon Swirl Grande', 1, 55),
('260916121650-50', 'D_MS', 'Melon Swirl Grande', 1, 55),
('270916033226-77', 'DSH_TD', 'TBC Double Decker', 1, 169),
('270916033238-41', 'DSH_TD', 'TBC Double Decker', 1, 169),
('270916033643-21', 'DSH_C', 'Churros', 5, 49),
('270916040915-66', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('270916052314-13', 'DSH_TE', 'Tofu Express', 1, 149),
('270916055347-55', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('270916055408-27', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('270916055453-81', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('270916055533-45', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('270916060011-87', 'DSH_C', 'Churros', 7, 49),
('270916060011-87', 'DSH_CC', 'Chessy Carbonara', 8, 139),
('270916060011-87', 'DSH_ES', 'Emsilog', 6, 59),
('270916060011-87', 'DSH_HS', 'Hotsilog', 13, 49),
('270916060011-87', 'DSH_SS', 'Sizzling Sisig', 5, 129),
('270916060011-87', 'DSH_TE', 'Tofu Express', 8, 149),
('270916060229-91', 'DSH_C', 'Churros', 7, 49),
('270916060229-91', 'DSH_CC', 'Chessy Carbonara', 8, 139),
('270916060229-91', 'DSH_ES', 'Emsilog', 6, 59),
('270916060229-91', 'DSH_HS', 'Hotsilog', 13, 49),
('270916060229-91', 'DSH_SS', 'Sizzling Sisig', 5, 129),
('270916060229-91', 'DSH_TE', 'Tofu Express', 8, 149),
('270916060412-59', 'DSH_C', 'Churros', 7, 49),
('270916060412-59', 'DSH_CC', 'Chessy Carbonara', 8, 139),
('270916060412-59', 'DSH_ES', 'Emsilog', 6, 59),
('270916060412-59', 'DSH_HS', 'Hotsilog', 3, 49),
('270916060412-59', 'DSH_SS', 'Sizzling Sisig', 5, 129),
('270916060412-59', 'DSH_TE', 'Tofu Express', 8, 149),
('270916121537-58', 'D_MS', 'Melon Swirl Grande', 5, 55),
('280916102707-59', 'DSH_FB', 'Flaming Buffalo Wing', 5, 139),
('280916111238-64', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('280916111238-64', 'DSH_TD', 'TBC Double Decker', 1, 169),
('290916120805-44', 'DSH_C', 'Churros', 4, 49),
('290916120831-41', 'DSH_C', 'Churros', 4, 49),
('290916121207-54', 'DSH_C', 'Churros', 5, 49),
('290916122610-75', 'DSH_BB', 'BBQ Burger', 5, 99);
=======
('250916-12579', 'DSH_C', 'Churros', 3, 49),
('250916-19200', 'D_TT', 'Taro Treat Grande', 2, 55),
('250916-25592', 'DSH_C', 'Churros', 2, 49),
('250916-32086', 'D_MS', 'Melon Swirl Venti', 5, 70),
('250916-70420', 'DSH_SS', 'Sizzling Sisig', 1, 129),
('250916-80007', 'DSH_TE', 'Tofu Express', 5, 149),
('250916-89693', 'D_MS', 'Melon Swirl Grande', 4, 55);
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql

-- --------------------------------------------------------

--
-- Table structure for table `tblproducts`
--

CREATE TABLE `tblproducts` (
  `prod_code` varchar(6) NOT NULL,
  `prod_name` varchar(20) NOT NULL,
  `prod_priceG` int(4) DEFAULT NULL,
  `prod_priceV` int(4) DEFAULT NULL,
  `prod_class` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblproducts`
--

INSERT INTO `tblproducts` (`prod_code`, `prod_name`, `prod_priceG`, `prod_priceV`, `prod_class`) VALUES
('DSG_SS', 'Spamsilog', 59, NULL, 'SILOG'),
('DSH_BB', 'BBQ Burger', 99, NULL, 'Sandwich'),
('DSH_C', 'Churros', 49, NULL, 'For sharing'),
('DSH_CB', 'Chessy Bacon Fries', 129, NULL, 'For sharing'),
('DSH_CC', 'Chessy Carbonara', 139, NULL, 'Pasta'),
('DSH_CP', 'Creamy Pesto', 149, NULL, 'Pasta'),
('DSH_CS', 'Chicksilog', 59, NULL, 'SILOG'),
('DSH_ES', 'Emsilog', 59, NULL, 'SILOG'),
('DSH_FB', 'Flaming Buffalo Wing', 139, NULL, 'For sharing'),
('DSH_HS', 'Hotsilog', 49, NULL, 'SILOG'),
('DSH_IB', 'Island Burger', 99, NULL, 'Sandwich'),
('DSH_LS', 'Longsilog', 59, NULL, 'SILOG'),
('DSH_N', 'Nachos', 149, NULL, 'For Sharing'),
('DSH_PP', 'Pizza Pasta', 149, NULL, 'Pasta'),
('DSH_SB', 'Sizzling Burger Stak', 65, NULL, 'For Sharing'),
('DSH_SS', 'Sizzling Sisig', 129, NULL, 'For sharing'),
('DSH_TD', 'TBC Double Decker', 169, NULL, 'Sandwich'),
('DSH_TE', 'Tofu Express', 149, NULL, 'For sharing'),
('DSH_UC', 'Ultimate Cheese Burg', 109, NULL, 'Sandwich'),
('D_BBT', 'BlueBerry Tea', 55, 65, 'drinks_tea'),
('D_BMT', 'Blueberry Milk Tea', 60, 75, 'drinks_milktea'),
('D_CK', 'Cookie Monster', 90, 110, 'drinks_smoothie'),
('D_CL', 'Choco Loco', 55, 70, 'drinks_icetea'),
('D_DP', 'Dandy Peach', 90, 110, 'drinks_smoothie'),
('D_GAT', 'Green Apple Tea', 55, 65, 'drinks_tea'),
('D_HMT', 'Honey Dew Milk Tea', 60, 75, 'drinks_milktea'),
('D_KT', 'Kiwi Tea', 55, 65, 'drinks_tea'),
('D_Lemo', 'Lemon Tea', 55, 65, 'drinks_tea'),
('D_LL', 'Luscious Lychee', 90, 110, 'drinks_smoothie'),
('D_LT', 'Lychee Tea', 55, 65, 'drinks_tea'),
('D_MM', 'Mango Madness', 90, 110, 'drinks_smoothie'),
('D_MMT', 'Mango Milk Tea', 60, 75, 'drinks_milktea'),
('D_MS', 'Melon Swirl', 55, 70, 'drinks_icetea'),
('D_MT', 'Mango Tea', 55, 65, 'drinks_tea'),
('D_OW', 'Oreo Wacko', 55, 70, 'drinks_icetea'),
('D_PB', 'Purple Brew', 55, 70, 'drinks_icetea'),
('D_PK', 'Peachy Keen', 55, 70, 'drinks_icetea'),
('D_PMK', 'Peach Milk Tea', 60, 75, 'drinks_milktea'),
('D_PT', 'Peach Tea', 55, 65, 'drinks_tea'),
('D_SB', 'Strawberry Blush', 55, 70, 'drinks_icetea'),
('D_SMT', 'Strawberry Milk Tea', 60, 75, 'drinks_milktea'),
('D_SS', 'Strawberrytelle', 90, 110, 'drinks_smoothie'),
('D_ST', 'Strawberry Tea', 55, 65, 'drinks_tea'),
('D_TM', 'Trophical Mango', 55, 70, 'drinks_icetea'),
('D_TT', 'Taro Treat', 55, 70, 'drinks_icetea'),
('D_VC', 'Vanilla Cloud', 55, 70, 'drinks_icetea'),
('D_WC', 'Winter Choco', 55, 70, 'drinks_icetea'),
('D_WM', 'Winter Melon', 55, 65, 'drinks_tea'),
('D_ZD', 'Zesty Dew', 55, 70, 'drinks_icetea');

-- --------------------------------------------------------

--
<<<<<<< HEAD:dbtbc (2).sql
-- Table structure for table `tbltimeintimeout`
--

CREATE TABLE `tbltimeintimeout` (
  `user` varchar(20) NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `description` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbltimeintimeout`
--

INSERT INTO `tbltimeintimeout` (`user`, `time`, `description`) VALUES
('admin', '2016-09-30 18:42:36', 'in'),
('admin', '2016-09-30 19:31:09', 'in');

-- --------------------------------------------------------

--
=======
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql
-- Table structure for table `tbltransaction`
--

CREATE TABLE `tbltransaction` (
  `id` int(1) NOT NULL,
  `cus_no` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbltransaction`
--

INSERT INTO `tbltransaction` (`id`, `cus_no`) VALUES
<<<<<<< HEAD:dbtbc (2).sql
(1, 'tbc123');
=======
(1, '0');
>>>>>>> refs/remotes/hordsmaykill/master:resources/dbtbc.sql

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbladministrators`
--
ALTER TABLE `tbladministrators`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `tblcustomers`
--
ALTER TABLE `tblcustomers`
  ADD PRIMARY KEY (`cus_no`);

--
-- Indexes for table `tblinventory`
--
ALTER TABLE `tblinventory`
  ADD PRIMARY KEY (`inv_prod_code`);

--
-- Indexes for table `tblorders`
--
ALTER TABLE `tblorders`
  ADD PRIMARY KEY (`ord_code`);

--
-- Indexes for table `tblorder_prod`
--
ALTER TABLE `tblorder_prod`
  ADD UNIQUE KEY `ordp_code` (`ord_code`,`prod_code`);

--
-- Indexes for table `tblproducts`
--
ALTER TABLE `tblproducts`
  ADD PRIMARY KEY (`prod_code`);

--
-- Indexes for table `tbltransaction`
--
ALTER TABLE `tbltransaction`
  ADD PRIMARY KEY (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
