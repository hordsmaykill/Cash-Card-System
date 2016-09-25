-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 25, 2016 at 05:15 PM
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
('admin', 'admin', 'superuser'),
('z', 'mypass', 'Super User');

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
('tbc1', 'testtest', '2016-09-23 23:24:40', 100),
('tbc123', 'dfg', '2016-09-23 22:00:05', 200),
('tbc456', 'testing test', '2016-09-21 21:14:58', 300);

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

-- --------------------------------------------------------

--
-- Table structure for table `tblorders`
--

CREATE TABLE `tblorders` (
  `ord_code` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `ord_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblorders`
--

INSERT INTO `tblorders` (`ord_code`, `total`, `ord_date`) VALUES
('250916-12579', 147, '2016-09-25'),
('250916-19200', 110, '2016-09-25'),
('250916-25592', 98, '2016-09-25'),
('250916-32086', 350, '2016-09-25'),
('250916-70420', 129, '2016-09-25'),
('250916-80007', 745, '2016-09-25'),
('250916-89693', 220, '2016-09-25');

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
('250916-12579', 'DSH_C', 'Churros', 3, 49),
('250916-19200', 'D_TT', 'Taro Treat Grande', 2, 55),
('250916-25592', 'DSH_C', 'Churros', 2, 49),
('250916-32086', 'D_MS', 'Melon Swirl Venti', 5, 70),
('250916-70420', 'DSH_SS', 'Sizzling Sisig', 1, 129),
('250916-80007', 'DSH_TE', 'Tofu Express', 5, 149),
('250916-89693', 'D_MS', 'Melon Swirl Grande', 4, 55);

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
(1, '0');

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
