-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 25, 2016 at 05:38 PM
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
('admin', 'admin', 'manager'),
('cashier', 'cashier', 'cashier');

-- --------------------------------------------------------

--
-- Table structure for table `tblcustomers`
--

CREATE TABLE `tblcustomers` (
  `cus_no` varchar(10) NOT NULL,
  `cus_name` varchar(25) NOT NULL,
  `cus_since` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `cus_loadwallet` int(6) NOT NULL,
  `cus_points` int(6) NOT NULL,
  `status` varchar(10) NOT NULL DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblcustomers`
--

INSERT INTO `tblcustomers` (`cus_no`, `cus_name`, `cus_since`, `cus_loadwallet`, `cus_points`, `status`) VALUES
('tbc1', 'testing', '2016-10-21 20:38:23', 134, 3, 'Active'),
('tbc123', 'BETATESTER', '2016-10-21 20:45:28', 9007, 20, 'Active'),
('tbc70555', 'test', '2016-10-13 03:33:04', 0, 0, 'Active');

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
('DSG_SS', 51),
('DSH_BB', 50),
('DSH_C', 50),
('DSH_CB', 50),
('DSH_CC', 50),
('DSH_CP', 50),
('DSH_CS', 50),
('DSH_ES', 50),
('DSH_FB', 49),
('DSH_HS', 50),
('DSH_IB', 50),
('DSH_LS', 50),
('DSH_N', 50),
('DSH_PP', 50),
('DSH_SB', 50),
('DSH_SS', 46),
('DSH_TD', 50),
('DSH_TE', 36),
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

-- --------------------------------------------------------

--
-- Table structure for table `tblinventory_trans`
--

CREATE TABLE `tblinventory_trans` (
  `ord_code_trans` varchar(15) NOT NULL,
  `ord_trans_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblinventory_trans`
--

INSERT INTO `tblinventory_trans` (`ord_code_trans`, `ord_trans_date`) VALUES
('DSG_SS', '2016-10-21 20:13:12');

-- --------------------------------------------------------

--
-- Table structure for table `tblorders`
--

CREATE TABLE `tblorders` (
  `ord_code` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `ord_change` double NOT NULL,
  `ord_tendered` double NOT NULL,
  `ord_date` date NOT NULL,
  `ord_rload_change` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblorders`
--

INSERT INTO `tblorders` (`ord_code`, `total`, `ord_change`, `ord_tendered`, `ord_date`, `ord_rload_change`) VALUES
('131016090325-60', 55, 0, 0, '2016-10-13', 0),
('131016114411-70', 639, 0, 0, '2016-10-13', 0),
('131016114901-99', 1490, 0, 1490, '2016-10-13', 0),
('221016043823-63', 129, 0, 0, '0000-00-00', 3),
('221016043943-17', 149, 0, 0, '0000-00-00', 18),
('221016044146-11', 298, 0, 0, '0000-00-00', 9265),
('221016044528-81', 258, 0, 0, '2016-10-22', 9007);

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
('131016090325-60', 'D_TT', 'Taro Treat Grande', 1, 55),
('131016114411-70', 'DSH_C', 'Churros', 10, 49),
('131016114411-70', 'DSH_TE', 'Tofu Express', 1, 149),
('131016114901-99', 'DSH_TE', 'Tofu Express', 10, 149),
('221016043823-63', 'DSH_SS', 'Sizzling Sisig', 1, 129),
('221016043943-17', 'DSH_TE', 'Tofu Express', 1, 149),
('221016044146-11', 'DSH_TE', 'Tofu Express', 2, 149),
('221016044528-81', 'DSH_SS', 'Sizzling Sisig', 2, 129);

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
('test', '2016-10-12 08:54:15', 'in'),
('test', '2016-10-12 08:54:30', 'out'),
('test', '2016-10-12 08:55:38', 'in'),
('test', '2016-10-12 08:56:58', 'in'),
('admin', '2016-10-12 09:04:44', 'in'),
('admin', '2016-10-12 09:05:54', 'out'),
('admin', '2016-10-13 00:49:38', 'in'),
('admin', '2016-10-13 01:02:19', 'in'),
('admin', '2016-10-13 01:04:16', 'out'),
('admin', '2016-10-13 02:57:35', 'in'),
('admin', '2016-10-13 03:30:57', 'in'),
('admin', '2016-10-13 03:41:15', 'out'),
('cashier', '2016-10-13 03:41:39', 'in'),
('cashier', '2016-10-13 03:45:17', 'out'),
('cashier', '2016-10-13 03:45:43', 'in'),
('cashier', '2016-10-13 03:53:47', 'in'),
('admin', '2016-10-18 14:54:44', 'in'),
('admin', '2016-10-21 18:16:09', 'in'),
('admin', '2016-10-21 18:16:21', 'out'),
('admin', '2016-10-21 18:21:06', 'in'),
('admin', '2016-10-21 18:22:21', 'in'),
('admin', '2016-10-21 19:01:51', 'in'),
('admin', '2016-10-21 19:04:45', 'out'),
('admin', '2016-10-21 19:15:21', 'in'),
('admin', '2016-10-21 19:18:47', 'in'),
('admin', '2016-10-21 19:19:22', 'out'),
('cashier', '2016-10-21 19:25:45', 'in'),
('cashier', '2016-10-21 19:26:33', 'out'),
('admin', '2016-10-21 19:52:55', 'in'),
('admin', '2016-10-21 19:53:16', 'out'),
('admin', '2016-10-21 19:56:30', 'in'),
('admin', '2016-10-21 19:56:52', 'out'),
('admin', '2016-10-21 20:13:04', 'in'),
('admin', '2016-10-21 20:13:16', 'out'),
('admin', '2016-10-21 20:30:44', 'in'),
('admin', '2016-10-21 20:32:59', 'in'),
('admin', '2016-10-21 20:38:04', 'in'),
('admin', '2016-10-21 20:39:27', 'in'),
('admin', '2016-10-21 20:41:23', 'in'),
('admin', '2016-10-21 20:45:10', 'in'),
('admin', '2016-10-22 14:44:47', 'in');

-- --------------------------------------------------------

--
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
(1, 'tbc123');

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
