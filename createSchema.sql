-- phpMyAdmin SQL Dump
-- version 4.7.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Mar 19, 2018 at 06:36 PM
-- Server version: 5.6.35
-- PHP Version: 7.1.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `kangoeroes_web`
--

-- --------------------------------------------------------

--
-- Table structure for table `leiding`
--

CREATE TABLE `leiding` (
  `id` int(10) NOT NULL,
  `naam` varchar(255) NOT NULL,
  `voornaam` varchar(255) NOT NULL,
  `auth0Id` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `takId` int(10) NOT NULL,
  `datumGestopt` date DEFAULT NULL,
  `leidingSinds` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- --------------------------------------------------------

--
-- Table structure for table `poef.drank`
--

CREATE TABLE `poef.drank` (
  `id` int(10) NOT NULL,
  `naam` varchar(255) NOT NULL,
  `imageUrl` varchar(255) DEFAULT NULL,
  `inStock` tinyint(4) NOT NULL,
  `typeId` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `poef.drankType`
--

CREATE TABLE `poef.drankType` (
  `id` int(10) NOT NULL,
  `naam` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `poef.evenement`
--

CREATE TABLE `poef.evenement` (
  `id` int(10) NOT NULL,
  `naam` varchar(255) NOT NULL,
  `start` date NOT NULL,
  `stop` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `poef.order`
--

CREATE TABLE `poef.order` (
  `id` int(10) NOT NULL,
  `orderedById` int(10) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `poef.orderline`
--

CREATE TABLE `poef.orderline` (
  `id` int(10) NOT NULL,
  `drankId` int(10) NOT NULL,
  `orderId` int(10) NOT NULL,
  `orderedForId` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `poef.periode`
--

CREATE TABLE `poef.periode` (
  `id` int(10) NOT NULL,
  `naam` varchar(255) NOT NULL,
  `start` date NOT NULL,
  `stop` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `poef.prijs`
--

CREATE TABLE `poef.prijs` (
  `id` int(10) NOT NULL,
  `datumToegevoegd` date NOT NULL,
  `prijs` decimal(19,0) NOT NULL,
  `drankId` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `schulden.transactie`
--

CREATE TABLE `schulden.transactie` (
  `id` int(10) NOT NULL,
  `titel` varchar(255) NOT NULL,
  `beschrijving` varchar(255) NOT NULL,
  `bedrag` decimal(19,0) NOT NULL,
  `datumTransactie` date NOT NULL,
  `datumToegevoegd` date NOT NULL,
  `leidingId` int(10) NOT NULL,
  `toegevoegdDoorId` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tak`
--

CREATE TABLE `tak` (
  `id` int(10) NOT NULL,
  `naam` varchar(255) NOT NULL,
  `volgorde` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- --------------------------------------------------------

--
-- Table structure for table `totems.adjectief`
--

CREATE TABLE `totems.adjectief` (
  `id` int(10) NOT NULL,
  `adjectief` varchar(255) NOT NULL,
  `createdOn` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `totems.entry`
--

CREATE TABLE `totems.entry` (
  `id` int(10) NOT NULL,
  `datumGegeven` date NOT NULL,
  `leidingId` int(10) DEFAULT NULL,
  `totemId` int(10) NOT NULL,
  `adjectiefId` int(10) NOT NULL,
  `voornaam` varchar(255) DEFAULT NULL,
  `achternaam` varchar(255) DEFAULT NULL,
  `voorouderId` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `totems.totem`
--

CREATE TABLE `totems.totem` (
  `id` int(10) NOT NULL,
  `totem` varchar(255) NOT NULL,
  `createdOn` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `leiding`
--
ALTER TABLE `leiding`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `auth0Id` (`auth0Id`),
  ADD KEY `takId` (`takId`),
  ADD KEY `FKleiding988679` (`takId`);

--
-- Indexes for table `poef.drank`
--
ALTER TABLE `poef.drank`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `FKpoef.drank807259` (`typeId`);

--
-- Indexes for table `poef.drankType`
--
ALTER TABLE `poef.drankType`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `poef.evenement`
--
ALTER TABLE `poef.evenement`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `poef.order`
--
ALTER TABLE `poef.order`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `FKpoef.order28766` (`orderedById`);

--
-- Indexes for table `poef.orderline`
--
ALTER TABLE `poef.orderline`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `FKpoef.order70246` (`orderId`),
  ADD KEY `FKpoef.order826858` (`orderedForId`),
  ADD KEY `FKpoef.order623747` (`drankId`);

--
-- Indexes for table `poef.periode`
--
ALTER TABLE `poef.periode`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `poef.prijs`
--
ALTER TABLE `poef.prijs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `FKpoef.prijs352817` (`drankId`);

--
-- Indexes for table `schulden.transactie`
--
ALTER TABLE `schulden.transactie`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `heeft schuld/vordering` (`leidingId`),
  ADD KEY `maakte schuld/vordering aan` (`toegevoegdDoorId`);

--
-- Indexes for table `tak`
--
ALTER TABLE `tak`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `totems.adjectief`
--
ALTER TABLE `totems.adjectief`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `adjectief` (`adjectief`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `totems.entry`
--
ALTER TABLE `totems.entry`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `FKtotems.ent886404` (`leidingId`),
  ADD KEY `FKtotems.ent490473` (`totemId`),
  ADD KEY `FKtotems.ent707844` (`adjectiefId`),
  ADD KEY `FKtotems.ent45315` (`voorouderId`);

--
-- Indexes for table `totems.totem`
--
ALTER TABLE `totems.totem`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `totem` (`totem`),
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `leiding`
--
ALTER TABLE `leiding`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;
--
-- AUTO_INCREMENT for table `poef.drank`
--
ALTER TABLE `poef.drank`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `poef.drankType`
--
ALTER TABLE `poef.drankType`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `poef.evenement`
--
ALTER TABLE `poef.evenement`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `poef.order`
--
ALTER TABLE `poef.order`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `poef.orderline`
--
ALTER TABLE `poef.orderline`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `poef.periode`
--
ALTER TABLE `poef.periode`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `poef.prijs`
--
ALTER TABLE `poef.prijs`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `schulden.transactie`
--
ALTER TABLE `schulden.transactie`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `tak`
--
ALTER TABLE `tak`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `totems.adjectief`
--
ALTER TABLE `totems.adjectief`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `totems.entry`
--
ALTER TABLE `totems.entry`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `totems.totem`
--
ALTER TABLE `totems.totem`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `leiding`
--
ALTER TABLE `leiding`
  ADD CONSTRAINT `FKleiding988679` FOREIGN KEY (`takId`) REFERENCES `tak` (`id`);

--
-- Constraints for table `poef.drank`
--
ALTER TABLE `poef.drank`
  ADD CONSTRAINT `FKpoef.drank807259` FOREIGN KEY (`typeId`) REFERENCES `poef.drankType` (`id`);

--
-- Constraints for table `poef.order`
--
ALTER TABLE `poef.order`
  ADD CONSTRAINT `FKpoef.order28766` FOREIGN KEY (`orderedById`) REFERENCES `leiding` (`id`);

--
-- Constraints for table `poef.orderline`
--
ALTER TABLE `poef.orderline`
  ADD CONSTRAINT `FKpoef.order623747` FOREIGN KEY (`drankId`) REFERENCES `poef.drank` (`id`),
  ADD CONSTRAINT `FKpoef.order70246` FOREIGN KEY (`orderId`) REFERENCES `poef.order` (`id`),
  ADD CONSTRAINT `FKpoef.order826858` FOREIGN KEY (`orderedForId`) REFERENCES `leiding` (`id`);

--
-- Constraints for table `poef.prijs`
--
ALTER TABLE `poef.prijs`
  ADD CONSTRAINT `FKpoef.prijs352817` FOREIGN KEY (`drankId`) REFERENCES `poef.drank` (`id`);

--
-- Constraints for table `schulden.transactie`
--
ALTER TABLE `schulden.transactie`
  ADD CONSTRAINT `heeft schuld/vordering` FOREIGN KEY (`leidingId`) REFERENCES `leiding` (`id`),
  ADD CONSTRAINT `maakte schuld/vordering aan` FOREIGN KEY (`toegevoegdDoorId`) REFERENCES `leiding` (`id`);

--
-- Constraints for table `totems.entry`
--
ALTER TABLE `totems.entry`
  ADD CONSTRAINT `FKtotems.ent45315` FOREIGN KEY (`voorouderId`) REFERENCES `totems.entry` (`id`),
  ADD CONSTRAINT `FKtotems.ent490473` FOREIGN KEY (`totemId`) REFERENCES `totems.totem` (`id`),
  ADD CONSTRAINT `FKtotems.ent707844` FOREIGN KEY (`adjectiefId`) REFERENCES `totems.adjectief` (`id`),
  ADD CONSTRAINT `FKtotems.ent886404` FOREIGN KEY (`leidingId`) REFERENCES `leiding` (`id`);
