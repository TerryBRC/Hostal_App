-- MySQL dump 10.13  Distrib 8.0.39, for Win64 (x86_64)
--
-- Host: localhost    Database: hostal_db
-- ------------------------------------------------------
-- Server version	8.0.39

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `direccion` longtext,
  `telefono` varchar(20) DEFAULT NULL,
  `identificacion` varchar(100) NOT NULL,
  `fecha_registro` datetime(6) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `identificacion_UNIQUE` (`identificacion`)
) ENGINE=InnoDB AUTO_INCREMENT=179 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Juan','Pérez','Calle 123, Ciudad A','123-4567890','1234567891','2024-07-13 10:00:00.000000'),(2,'María','González','Av. Principal 456, Ciudad B','456-7890123','345678901','2024-07-13 10:15:00.000000'),(3,'Pedro','Martínez','Av. Libertad 789, Ciudad C','789-0123456','456789012','2024-07-13 10:30:00.000000'),(4,'Ana','Sánchez','Calle Central 321, Ciudad D','012-3456789','567890123','2024-07-13 10:45:00.000000'),(5,'Luis','Rodríguez','Av. América 654, Ciudad E','987-6543210','678901234','2024-07-13 11:00:00.000000'),(6,'Laura Marisol','López','Av. Primavera 987, Ciudad F','789012345','654-3210987','2024-07-13 16:26:41.886153'),(7,'Carlos','Hernández','Calle Flores 741, Ciudad G','321-0987654','890123456','2024-07-13 11:30:00.000000'),(8,'Elena','Díaz','Av. Sur 852, Ciudad H','210-9876543','901234567','2024-07-13 11:45:00.000000'),(9,'Jorge','Gómez','Av. Norte 963, Ciudad I','543-2109876','012345678','2024-07-13 12:00:00.000000'),(10,'Sofía','Vargas','Calle Oeste 159, Ciudad J','876-5432109','123456789','2024-07-13 12:15:00.000000'),(11,'Daniel','Paz','Av. Este 357, Ciudad K','109-8765432','234567890','2024-07-13 12:30:00.000000'),(12,'Valeria','Rojas','Calle Central 753, Ciudad L','432-1098765','2345678901','2024-07-13 12:45:00.000000'),(13,'Martín','Romero','Av. 123, Ciudad M','765-4321098','356789012','2024-07-13 13:00:00.000000'),(14,'Fernanda','Molina','Av. 456, Ciudad N','098-7654321','456780123','2024-07-13 13:15:00.000000'),(15,'Gabriel','Torres','Av. 789, Ciudad O','321-0987654','567891234','2024-07-13 13:30:00.000000'),(16,'Lucía','Gutiérrez','Calle 159, Ciudad P','654-3210987','679012345','2024-07-13 13:45:00.000000'),(17,'Diego','Suárez','Av. 357, Ciudad Q','987-6543210','789012456','2024-07-13 14:00:00.000000'),(18,'Camila','Luna','Av. 753, Ciudad R','210-9876543','89123567','2024-07-13 14:15:00.000000'),(19,'Julia','Ortega','Calle Este 123, Ciudad S','543-210876','901345678','2024-07-13 14:30:00.000000'),(20,'Mateo','Castro','Av. Oeste 456, Ciudad T','876-543109','012356789','2024-07-13 14:45:00.000000');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos`
--

DROP TABLE IF EXISTS `grupos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grupos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos`
--

LOCK TABLES `grupos` WRITE;
/*!40000 ALTER TABLE `grupos` DISABLE KEYS */;
INSERT INTO `grupos` VALUES (1,'Administrador'),(4,'Gerente'),(3,'Limpieza'),(2,'Recepcionista');
/*!40000 ALTER TABLE `grupos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos_permisos`
--

DROP TABLE IF EXISTS `grupos_permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grupos_permisos` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `grupo_id` int NOT NULL,
  `permiso_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `grupos_permisos_permiso_id_fk_auth_perm` (`permiso_id`),
  KEY `grupos_permisos_grupo_id_fk_grupos_id` (`grupo_id`),
  CONSTRAINT `grupos_permisos_grupo_id_fk_grupos_id` FOREIGN KEY (`grupo_id`) REFERENCES `grupos` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `grupos_permisos_permiso_id_fk_auth_perm` FOREIGN KEY (`permiso_id`) REFERENCES `permisos` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=95 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos_permisos`
--

LOCK TABLES `grupos_permisos` WRITE;
/*!40000 ALTER TABLE `grupos_permisos` DISABLE KEYS */;
INSERT INTO `grupos_permisos` VALUES (1,1,1),(2,1,2),(3,1,3),(4,1,4),(5,1,5),(6,1,6),(7,1,7),(8,1,8),(9,1,9),(10,1,10),(11,1,11),(12,1,12),(13,1,13),(14,1,14),(15,1,15),(16,1,16),(17,1,17),(18,1,18),(19,1,19),(20,1,20),(21,1,21),(22,1,22),(23,1,23),(24,1,24),(25,1,25),(26,1,26),(27,1,27),(28,1,28),(64,2,13),(65,2,14),(66,2,15),(67,2,22),(68,2,25),(69,2,26),(70,2,27),(71,2,28),(79,3,22),(80,4,14),(81,4,22),(82,4,26),(87,1,37),(88,1,38),(89,1,39),(90,1,40);
/*!40000 ALTER TABLE `grupos_permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habitacion`
--

DROP TABLE IF EXISTS `habitacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `habitacion` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `numero` varchar(10) NOT NULL,
  `capacidad_maxima` int NOT NULL,
  `precio_por_noche` decimal(10,2) NOT NULL,
  `disponible` tinyint(1) NOT NULL,
  `tipo_habitacion_id` bigint NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `numero_UNIQUE` (`numero`),
  KEY `habitacion_tipo_habitacion_id_fk_tipo_habitacion_id` (`tipo_habitacion_id`),
  CONSTRAINT `habitacion_tipo_habitacion_id_fk_tipo_habitacion_id` FOREIGN KEY (`tipo_habitacion_id`) REFERENCES `tipo_habitacion` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habitacion`
--

LOCK TABLES `habitacion` WRITE;
/*!40000 ALTER TABLE `habitacion` DISABLE KEYS */;
INSERT INTO `habitacion` VALUES (1,'101',1,50.00,1,1),(2,'102',2,80.00,1,2),(3,'103',2,100.00,1,2),(4,'201',4,150.00,1,3),(5,'202',4,180.00,1,3),(6,'203',4,200.00,1,3),(7,'301',6,200.00,1,4),(8,'302',6,220.00,1,4),(9,'303',6,250.00,1,4),(10,'401',2,300.00,0,5);
/*!40000 ALTER TABLE `habitacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisos`
--

DROP TABLE IF EXISTS `permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permisos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(75) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisos`
--

LOCK TABLES `permisos` WRITE;
/*!40000 ALTER TABLE `permisos` DISABLE KEYS */;
INSERT INTO `permisos` VALUES (1,'c permiso','Agregar Permiso'),(2,'r permiso','Leer Permiso'),(3,'u permiso','Actualizar Permiso'),(4,'d permiso','Eliminar Permiso'),(5,'c grupo','Agregar Grupo'),(6,'r grupo','Leer Grupo'),(7,'u grupo','Actualizar Grupo'),(8,'d grupo','Eliminar Grupo'),(9,'c usuario','Agregar Usuario'),(10,'r usuario','Leer Usuario'),(11,'u usuario','Actualizar Usuario'),(12,'d usuario','Eliminar Usuario'),(13,'c cliente','Agregar Cliente'),(14,'r cliente','Leer Cliente'),(15,'u cliente','Actualizar Cliente'),(16,'d cliente','Eliminar Cliente'),(17,'c tipohabitacion','Agregar TipoHabitacion'),(18,'r tipohabitacion','Leer TipoHabitacion'),(19,'u tipohabitacion','Actualizar TipoHabitacion'),(20,'d tipohabitacion','Eliminar TipoHabitacion'),(21,'c habitacion','Agregar Habitacion'),(22,'r habitacion','Leer Habitacion'),(23,'u habitacion','Actualizar Habitacion'),(24,'d habitacion','Eliminar Habitacion'),(25,'c reserva','Agregar Reserva'),(26,'r reserva','Leer Reserva'),(27,'u reserva','Actualizar Reserva'),(28,'d reserva','Eliminar Reserva'),(37,'c grupospermisos','Agregar GruposPermisos'),(38,'r grupospermisos','Leer GruposPermisos'),(39,'u grupospermisos','Actualizar GruposPermisos'),(40,'d grupospermisos','Eliminar GruposPermisos');
/*!40000 ALTER TABLE `permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `fecha_entrada` date NOT NULL,
  `fecha_salida` date NOT NULL,
  `numero_huespedes` int NOT NULL,
  `estado` enum('Activo','Cancelado','Pendiente','Finalizado','No Presentado','En Proceso') DEFAULT 'Activo',
  `fecha_creacion` datetime(6) NOT NULL,
  `fecha_modificacion` datetime(6) NOT NULL,
  `cliente_id` bigint NOT NULL,
  `habitacion_id` bigint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `reserva_cliente_id_fk_cliente_id` (`cliente_id`),
  KEY `reserva_habitacion_id_fk_habitacion_id` (`habitacion_id`),
  CONSTRAINT `reserva_cliente_id_fk_cliente_id` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reserva_habitacion_id_fk_habitacion_id` FOREIGN KEY (`habitacion_id`) REFERENCES `habitacion` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=247 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
INSERT INTO `reserva` VALUES (216,'2024-07-10','2024-07-14',2,'Activo','2024-07-13 10:00:00.000000','2024-07-15 02:20:00.000000',1,1),(217,'2024-08-02','2024-08-06',1,'Finalizado','2024-07-13 10:15:00.000000','2024-07-15 02:26:39.000000',2,2),(218,'2024-08-03','2024-08-07',4,'En Proceso','2024-07-13 10:30:00.000000','2024-07-15 02:26:45.000000',3,3),(219,'2024-08-04','2024-08-08',2,'No Presentado','2024-07-13 10:45:00.000000','2024-07-15 02:26:49.000000',4,4),(220,'2024-08-05','2024-08-09',3,'Cancelado','2024-07-13 11:00:00.000000','2024-07-15 02:26:58.000000',5,5),(221,'2024-08-06','2024-08-10',2,'Activo','2024-07-13 11:15:00.000000','2024-07-13 11:15:00.000000',6,6),(222,'2024-08-07','2024-08-11',1,'Activo','2024-07-13 11:30:00.000000','2024-07-13 11:30:00.000000',7,7),(223,'2024-08-08','2024-08-12',5,'Activo','2024-07-13 11:45:00.000000','2024-07-13 11:45:00.000000',8,8),(224,'2024-08-09','2024-08-13',2,'Activo','2024-07-13 12:00:00.000000','2024-07-13 12:00:00.000000',9,9),(225,'2024-08-10','2024-08-14',3,'Activo','2024-07-13 12:15:00.000000','2024-07-13 12:15:00.000000',10,10),(226,'2024-08-21','2024-08-25',1,'Activo','2024-07-13 15:00:00.000000','2024-07-13 15:00:00.000000',11,1),(227,'2024-08-22','2024-08-26',4,'Activo','2024-07-13 15:15:00.000000','2024-07-13 15:15:00.000000',12,2),(228,'2024-08-23','2024-08-27',2,'Activo','2024-07-13 15:30:00.000000','2024-07-13 15:30:00.000000',13,3),(229,'2024-08-24','2024-08-28',3,'Activo','2024-07-13 15:45:00.000000','2024-07-13 15:45:00.000000',14,4),(230,'2024-08-25','2024-08-29',2,'Activo','2024-07-13 16:00:00.000000','2024-07-13 16:00:00.000000',15,5),(231,'2024-08-26','2024-08-30',5,'Activo','2024-07-13 16:15:00.000000','2024-07-13 16:15:00.000000',16,6),(232,'2024-08-27','2024-08-31',2,'Activo','2024-07-13 16:30:00.000000','2024-07-13 16:30:00.000000',17,7),(233,'2024-08-28','2024-09-01',3,'Activo','2024-07-13 16:45:00.000000','2024-07-13 16:45:00.000000',18,8),(234,'2024-08-29','2024-09-02',2,'Activo','2024-07-13 17:00:00.000000','2024-07-13 17:00:00.000000',19,9),(235,'2024-08-30','2024-09-03',1,'Activo','2024-07-13 17:15:00.000000','2024-07-13 17:15:00.000000',20,10),(236,'2024-09-10','2024-09-14',2,'Activo','2024-07-13 20:00:00.000000','2024-07-13 20:00:00.000000',1,1),(237,'2024-09-11','2024-09-15',3,'Activo','2024-07-13 20:15:00.000000','2024-07-13 20:15:00.000000',2,2),(238,'2024-09-12','2024-09-16',2,'Activo','2024-07-13 20:30:00.000000','2024-07-13 20:30:00.000000',3,3),(239,'2024-09-13','2024-09-17',1,'Activo','2024-07-13 20:45:00.000000','2024-07-13 20:45:00.000000',4,4),(240,'2024-09-14','2024-09-18',5,'Activo','2024-07-13 21:00:00.000000','2024-07-13 21:00:00.000000',5,5),(241,'2024-09-15','2024-09-19',2,'Activo','2024-07-13 21:15:00.000000','2024-07-13 21:15:00.000000',6,6),(242,'2024-09-16','2024-09-20',3,'Activo','2024-07-13 21:30:00.000000','2024-07-13 21:30:00.000000',7,7),(243,'2024-09-17','2024-09-21',2,'Activo','2024-07-13 21:45:00.000000','2024-07-13 21:45:00.000000',8,8),(244,'2024-09-18','2024-09-22',4,'Activo','2024-07-13 22:00:00.000000','2024-07-13 22:00:00.000000',9,9),(245,'2024-09-19','2024-09-23',2,'Cancelado','2024-07-13 22:15:00.000000','2024-07-15 02:15:26.000000',10,10),(246,'2024-07-15','2024-07-20',3,'Pendiente','2024-07-15 01:25:24.000000','2024-07-15 01:25:35.000000',20,10);
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_habitacion`
--

DROP TABLE IF EXISTS `tipo_habitacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipo_habitacion` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `tipo` varchar(30) NOT NULL,
  `descripcion` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_habitacion`
--

LOCK TABLES `tipo_habitacion` WRITE;
/*!40000 ALTER TABLE `tipo_habitacion` DISABLE KEYS */;
INSERT INTO `tipo_habitacion` VALUES (1,'Individual','Habitación diseñada para una sola persona.'),(2,'Doble','Habitación con espacio para dos personas, generalmente con una cama matrimonial o dos camas individuales.'),(3,'Suite','Habitación más amplia y lujosa, con área de estar separada.'),(4,'Familiar','Habitación diseñada para familias, con espacio para varios miembros.'),(5,'VIP','Habitación con servicios exclusivos y comodidades especiales para huéspedes VIP.');
/*!40000 ALTER TABLE `tipo_habitacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `password` varchar(128) NOT NULL,
  `usuario` varchar(150) NOT NULL,
  `nombre` varchar(150) NOT NULL,
  `apellido` varchar(150) NOT NULL,
  `email` varchar(254) NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `grupo_id` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `usuario` (`usuario`),
  KEY `fk_grupo_grupo_id_idx` (`grupo_id`),
  CONSTRAINT `fk_grupo_grupo_id` FOREIGN KEY (`grupo_id`) REFERENCES `grupos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','admin','John','Doe','johndoe@example.com',1,1),(4,'9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08','test','test','test','test@test.com',1,4),(5,'abbce88bd1788accc2ec66a738003efbe2342dea1c3e60c1459583289cbb3fed','recep','recep','recep','recep@recep.com',1,2),(6,'33d36d1f5e9a0989e3c875ca0654c9708fd2bb857f08686448901c9852b957c2','limpi','limpi','limpi','limpi@limpi.com',1,3);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-02  1:54:31
