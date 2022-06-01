-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: ppaproject
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `employeeadd`
--

DROP TABLE IF EXISTS `employeeadd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `employeeadd` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text,
  `position` text,
  `phone` text,
  `date` text,
  `Salary` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employeeadd`
--

LOCK TABLES `employeeadd` WRITE;
/*!40000 ALTER TABLE `employeeadd` DISABLE KEYS */;
INSERT INTO `employeeadd` VALUES (21,'samal','Cleaner','0112345','18 April 2021',1000),(22,'kamal','Acountant','0111864333','18 April 2021',800),(23,'nimal','Machanic','1111111','19 April 2021',500),(25,'MALITH DESHAN','Security','8743287','2021-05-01',1200),(26,'DIMUTHU MADHUDHAN','Security','827346','2021-05-01',200);
/*!40000 ALTER TABLE `employeeadd` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `register`
--

DROP TABLE IF EXISTS `register`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `register` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `empId` int(11) DEFAULT NULL,
  `EmpName` text,
  `Salary` double DEFAULT NULL,
  `Date` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `register`
--

LOCK TABLES `register` WRITE;
/*!40000 ALTER TABLE `register` DISABLE KEYS */;
INSERT INTO `register` VALUES (1,21,'kamal',1000,'2021-05-01'),(2,22,'kamal',800,'2021-05-01'),(3,23,'nimal',500,'2021-05-01'),(4,26,'DIMUTHU MADHUDHAN',200,'2021-05-01'),(5,22,'kamal',800,'2021-05-02'),(6,23,'nimal',500,'2021-05-02'),(7,25,'MALITH DESHAN',1200,'2021-05-02'),(8,22,'kamal',800,'2021-05-03'),(9,23,'nimal',500,'2021-05-03'),(10,22,'kamal',800,'2021-05-04'),(11,23,'nimal',500,'2021-05-04'),(12,21,'samal',1000,'2021-05-04'),(13,22,'kamal',800,'2021-05-16'),(14,23,'nimal',500,'2021-05-16'),(15,25,'MALITH DESHAN',1200,'2021-05-16'),(16,22,'kamal',800,'2021-05-15'),(17,23,'nimal',500,'2021-05-15'),(18,25,'MALITH DESHAN',1200,'2021-05-15'),(19,25,'MALITH DESHAN',1200,'2021-05-07'),(20,23,'nimal',500,'2021-05-07'),(21,22,'kamal',800,'2021-05-07'),(22,25,'MALITH DESHAN',1200,'2021-05-12'),(23,23,'nimal',500,'2021-05-12');
/*!40000 ALTER TABLE `register` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salary`
--

DROP TABLE IF EXISTS `salary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `salary` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `EmpId` int(11) DEFAULT NULL,
  `Name` text,
  `Salary` double DEFAULT NULL,
  `Bones` double DEFAULT NULL,
  `VatAndOther` double DEFAULT NULL,
  `Total` double DEFAULT NULL,
  `Adate` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salary`
--

LOCK TABLES `salary` WRITE;
/*!40000 ALTER TABLE `salary` DISABLE KEYS */;
INSERT INTO `salary` VALUES (9,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-02'),(10,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-16'),(11,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-15'),(12,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-07'),(13,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-12');
/*!40000 ALTER TABLE `salary` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-01 19:40:56
