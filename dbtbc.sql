-- phpMyAdmin SQL Dump
-- version 4.1.6
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 22, 2016 at 01:14 AM
-- Server version: 5.6.16
-- PHP Version: 5.5.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dbtbc`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbladministrators`
--

CREATE TABLE IF NOT EXISTS `tbladministrators` (
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `type` varchar(10) NOT NULL,
  PRIMARY KEY (`username`)
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

CREATE TABLE IF NOT EXISTS `tblcustomers` (
  `cus_no` varchar(10) NOT NULL,
  `cus_name` varchar(25) NOT NULL,
  `cus_since` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `cus_loadwallet` int(6) NOT NULL,
  PRIMARY KEY (`cus_no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblcustomers`
--

INSERT INTO `tblcustomers` (`cus_no`, `cus_name`, `cus_since`, `cus_loadwallet`) VALUES
('tbc123', 'dfg', '2016-09-21 22:11:07', 500),
('tbc456', 'testing test', '2016-09-21 21:14:58', 300);

-- --------------------------------------------------------

--
-- Table structure for table `tblinventory`
--

CREATE TABLE IF NOT EXISTS `tblinventory` (
  `inv_prod_code` varchar(6) NOT NULL DEFAULT '',
  `inv_qty` int(4) NOT NULL,
  PRIMARY KEY (`inv_prod_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblinventory`
--

INSERT INTO `tblinventory` (`inv_prod_code`, `inv_qty`) VALUES
('', 0);

-- --------------------------------------------------------

--
-- Table structure for table `tblorders`
--

CREATE TABLE IF NOT EXISTS `tblorders` (
  `ord_code` int(11) NOT NULL,
  `ord_date` date NOT NULL,
  PRIMARY KEY (`ord_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblorder_prod`
--

CREATE TABLE IF NOT EXISTS `tblorder_prod` (
  `ordp_code` int(11) NOT NULL,
  `ordp_prod` varchar(6) NOT NULL,
  UNIQUE KEY `ordp_code` (`ordp_code`,`ordp_prod`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblproducts`
--

CREATE TABLE IF NOT EXISTS `tblproducts` (
  `prod_code` varchar(6) NOT NULL,
  `prod_name` varchar(20) NOT NULL,
  `prod_priceG` int(4) DEFAULT NULL,
  `prod_priceV` int(4) DEFAULT NULL,
  `prod_class` varchar(15) NOT NULL,
  PRIMARY KEY (`prod_code`)
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

CREATE TABLE IF NOT EXISTS `tbltransaction` (
  `id` int(1) NOT NULL,
  `cus_no` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbltransaction`
--

INSERT INTO `tbltransaction` (`id`, `cus_no`) VALUES
(1, 'tbc123');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
