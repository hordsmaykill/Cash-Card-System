-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 02, 2016 at 05:59 PM
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
('test1', 'test1', 'cashier'),
('test2', 'test2', 'manager');

-- --------------------------------------------------------

--
-- Table structure for table `tblcustomers`
--

CREATE TABLE `tblcustomers` (
  `cus_no` varchar(10) NOT NULL,
  `cus_name` varchar(25) NOT NULL,
  `cus_since` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `cus_loadwallet` int(6) NOT NULL,
  `status` varchar(10) NOT NULL DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblcustomers`
--

INSERT INTO `tblcustomers` (`cus_no`, `cus_name`, `cus_since`, `cus_loadwallet`, `status`) VALUES
('1', 'TEST', '2016-10-02 15:58:10', 100, 'Active'),
('tbc123', 'BETATESTER', '2016-09-30 21:20:34', 823, 'Active');

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
('DSG_SS', 50),
('DSH_BB', 50),
('DSH_C', 50),
('DSH_CB', 50),
('DSH_CC', 50),
('DSH_CP', 50),
('DSH_CS', 50),
('DSH_ES', 50),
('DSH_FB', 41),
('DSH_HS', 50),
('DSH_IB', 50),
('DSH_LS', 50),
('DSH_N', 50),
('DSH_PP', 50),
('DSH_SB', 50),
('DSH_SS', 50),
('DSH_TD', 45),
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

-- --------------------------------------------------------

--
-- Table structure for table `tblorders`
--

CREATE TABLE `tblorders` (
  `ord_code` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `ord_change` double NOT NULL,
  `ord_tendered` double NOT NULL,
  `ord_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblorders`
--

INSERT INTO `tblorders` (`ord_code`, `total`, `ord_change`, `ord_tendered`, `ord_date`) VALUES
('011016011344-48', 70, 2242, 2312, '2016-10-01'),
('011016012511-44', 338, 162, 500, '2016-10-01'),
('011016013340-31', 695, 5, 700, '2016-10-01'),
('011016051639-85', 70, 0, 0, '2016-10-01'),
('011016051934-77', 149, 0, 0, '2016-10-01'),
('011016052034-70', 139, 0, 0, '2016-10-01'),
('021016122605-31', 924, 76, 1000, '2016-10-02');

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
('011016011344-48', 'D_TT', 'Taro Treat Venti', 1, 70),
('011016012511-44', 'DSH_TD', 'TBC Double Decker', 2, 169),
('011016013340-31', 'DSH_FB', 'Flaming Buffalo Wing', 5, 139),
('011016051639-85', 'D_TT', 'Taro Treat Venti', 1, 70),
('011016051934-77', 'DSH_TE', 'Tofu Express', 1, 149),
('011016052034-70', 'DSH_FB', 'Flaming Buffalo Wing', 1, 139),
('021016122605-31', 'DSH_FB', 'Flaming Buffalo Wing', 3, 139),
('021016122605-31', 'DSH_TD', 'TBC Double Decker', 3, 169),
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
('admin', '2016-09-30 18:42:36', 'in'),
('admin', '2016-09-30 19:31:09', 'in'),
('admin', '2016-10-01 14:50:56', 'in'),
('admin', '2016-10-01 15:09:46', 'in'),
('admin', '2016-10-01 15:38:40', 'in'),
('admin', '2016-10-01 15:52:43', 'in'),
('admin', '2016-10-01 15:53:36', 'in'),
('admin', '2016-10-01 16:14:39', 'in'),
('admin', '2016-10-01 16:25:42', 'in'),
('admin', '2016-10-02 07:42:31', 'in'),
('admin', '2016-10-02 10:19:29', 'in'),
('admin', '2016-10-02 10:20:32', 'out'),
('admin', '2016-10-02 11:07:19', 'in'),
('admin', '2016-10-02 11:10:10', 'out'),
('admin', '2016-10-02 11:39:46', 'in'),
('admin', '2016-10-02 15:18:18', 'in');

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
