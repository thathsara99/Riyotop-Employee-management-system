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
-- Dumping data for table `employeeadd`
--

LOCK TABLES `employeeadd` WRITE;
/*!40000 ALTER TABLE `employeeadd` DISABLE KEYS */;
INSERT INTO `employeeadd` VALUES (21,'samal','Cleaner','0112345','18 April 2021',1000),(22,'kamal','Acountant','0111864333','18 April 2021',800),(23,'nimal','Machanic','1111111','19 April 2021',500),(25,'MALITH DESHAN','Security','8743287','2021-05-01',1200),(26,'DIMUTHU MADHUDHAN','Security','827346','2021-05-01',200);
/*!40000 ALTER TABLE `employeeadd` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `invoice`
--

LOCK TABLES `invoice` WRITE;
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
INSERT INTO `invoice` VALUES (1001);
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('AAA-001','BAJAJ 4ST CARD',100,200,-6,5),('AAA-002','INNER CLUUCH LIVE 4ST',150,200,0,8),('ABC-002','CAL BEAM TEST',200,250,-3,5),('ACC-001','INNER CLUTCH LIVER 4ST',250,300,0,3),('OIL-002','20-40W AADB CLATEX ENGINE OIL MART',200,300,0,500);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `purchase`
--

LOCK TABLES `purchase` WRITE;
/*!40000 ALTER TABLE `purchase` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `purchase_temp`
--

LOCK TABLES `purchase_temp` WRITE;
/*!40000 ALTER TABLE `purchase_temp` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchase_temp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `register`
--

LOCK TABLES `register` WRITE;
/*!40000 ALTER TABLE `register` DISABLE KEYS */;
INSERT INTO `register` VALUES (1,21,'kamal',1000,'2021-05-01'),(2,22,'kamal',800,'2021-05-01'),(3,23,'nimal',500,'2021-05-01'),(4,26,'DIMUTHU MADHUDHAN',200,'2021-05-01'),(5,22,'kamal',800,'2021-05-02'),(6,23,'nimal',500,'2021-05-02'),(7,25,'MALITH DESHAN',1200,'2021-05-02'),(8,22,'kamal',800,'2021-05-03'),(9,23,'nimal',500,'2021-05-03'),(10,22,'kamal',800,'2021-05-04'),(11,23,'nimal',500,'2021-05-04'),(12,21,'samal',1000,'2021-05-04'),(13,22,'kamal',800,'2021-05-16'),(14,23,'nimal',500,'2021-05-16'),(15,25,'MALITH DESHAN',1200,'2021-05-16'),(16,22,'kamal',800,'2021-05-15'),(17,23,'nimal',500,'2021-05-15'),(18,25,'MALITH DESHAN',1200,'2021-05-15'),(19,25,'MALITH DESHAN',1200,'2021-05-07'),(20,23,'nimal',500,'2021-05-07'),(21,22,'kamal',800,'2021-05-07'),(22,25,'MALITH DESHAN',1200,'2021-05-12'),(23,23,'nimal',500,'2021-05-12');
/*!40000 ALTER TABLE `register` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `retailsale2`
--

LOCK TABLES `retailsale2` WRITE;
/*!40000 ALTER TABLE `retailsale2` DISABLE KEYS */;
/*!40000 ALTER TABLE `retailsale2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `retailselling`
--

LOCK TABLES `retailselling` WRITE;
/*!40000 ALTER TABLE `retailselling` DISABLE KEYS */;
INSERT INTO `retailselling` VALUES (5098,'1000','Cash','ABC-002','CAL BEAM TEST',3,250,NULL,500,700,0,0,700,'2021-05-02 05:25:12'),(5099,'1000','Cash','AAA-001','BAJAJ 4ST CARD',6,200,NULL,200,700,0,0,700,'2021-05-02 05:25:12');
/*!40000 ALTER TABLE `retailselling` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `salary`
--

LOCK TABLES `salary` WRITE;
/*!40000 ALTER TABLE `salary` DISABLE KEYS */;
INSERT INTO `salary` VALUES (9,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-02'),(10,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-16'),(11,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-15'),(12,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-07'),(13,25,'MALITH DESHAN',1200,1,1,6000,'2021-05-12');
/*!40000 ALTER TABLE `salary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `service`
--

LOCK TABLES `service` WRITE;
/*!40000 ALTER TABLE `service` DISABLE KEYS */;
/*!40000 ALTER TABLE `service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `service_category`
--

LOCK TABLES `service_category` WRITE;
/*!40000 ALTER TABLE `service_category` DISABLE KEYS */;
INSERT INTO `service_category` VALUES (''),('BIKE'),('HEAVY VEHICLE'),('MOTOR CAR');
/*!40000 ALTER TABLE `service_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `service_subcategory`
--

LOCK TABLES `service_subcategory` WRITE;
/*!40000 ALTER TABLE `service_subcategory` DISABLE KEYS */;
INSERT INTO `service_subcategory` VALUES (3,'BIKE','DISCOVER'),(4,'BIKE','PULSER'),(5,'HEAVY VEHICLE','JCB'),(6,'HEAVY VEHICLE','LOADER');
/*!40000 ALTER TABLE `service_subcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `service_type`
--

LOCK TABLES `service_type` WRITE;
/*!40000 ALTER TABLE `service_type` DISABLE KEYS */;
INSERT INTO `service_type` VALUES ('CHANGE OIL AND FILTER'),('FULL SERVICE'),('NORMAL SERVICE'),('UNDER CLEAN'),('WASH ONLY');
/*!40000 ALTER TABLE `service_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `userlog`
--

LOCK TABLES `userlog` WRITE;
/*!40000 ALTER TABLE `userlog` DISABLE KEYS */;
INSERT INTO `userlog` VALUES (1,'admin','d033e22ae348aeb5660fc2140aec35850c4da997'),(2,'admin','5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),(3,'admin','6216f8a75fd5bb3d5f22b6f9958cdede3fc086c2');
/*!40000 ALTER TABLE `userlog` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-02 19:13:23
