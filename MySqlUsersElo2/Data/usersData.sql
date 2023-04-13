-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Ápr 13. 14:14
-- Kiszolgáló verziója: 10.4.27-MariaDB
-- PHP verzió: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `iktat`
--

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`ID`, `Nev`, `Jelszo`, `Admin`) VALUES
(1, 'Akcíós Áron', '12345', 1),
(2, 'Álné Vendel', '12345', 0),
(3, 'Aloe Vera', '12345', 0),
(4, 'Am Erika', '12345', 0),
(5, 'Bac Ilus', '12345', 0),
(6, 'Bak Zoltán', '12345', 0),
(7, 'Bármi Áron', '12345', 0),
(8, 'Beka Kálmán', '12345', 0),
(9, 'Békés Csaba', '12345', 0),
(10, 'Bevíz Elek', '12345', 0),
(11, 'Bor Ivó', '12345', 0),
(12, 'Bor Virág', '12345', 0),
(13, 'Boro Zoltán', '12345', 0),
(14, 'Budipa Piroska', '12345', 0),
(15, 'Chat Elek', '12345', 0),
(16, 'Cicam Ica', '12345', 0),
(17, 'Citad Ella', '12345', 0),
(18, 'Csák Ányos', '12345', 0),
(19, 'Cserepes Virág', '12345', 0),
(20, 'Cserepesné Kis Virág', '12345', 0),
(21, 'Cset Elek', '12345', 0),
(22, 'Csin Csilla', '12345', 0),
(23, 'Csinál Tamás', '12345', 0),
(24, 'Csúf Olga', '12345', 0),
(25, 'Deb Ella', '12345', 0),
(26, 'Disz Nóra', '12345', 0),
(27, 'Diszkont Áron', '12345', 0),
(28, 'Ebéd Elek', '12345', 0),
(29, 'Elektrom Ágnes', '12345', 0),
(30, 'Ének Elek', '12345', 0),
(31, 'Es EmEsE', '12345', 0),
(32, 'Eszet Lenke', '12345', 0),
(33, 'Fejet Lenke', '12345', 0),
(34, 'Feles Elek', '12345', 0),
(35, 'Fenek Elek', '12345', 0),
(36, 'Futó Rózsa', '12345', 0),
(37, 'Gaz Ella', '12345', 0),
(38, 'Git Áron', '12345', 0),
(39, 'Gyöngy Virág', '12345', 0),
(40, 'Har Mónika', '12345', 0),
(41, 'Hát Izsák', '12345', 0),
(42, 'Hatá Sára', '12345', 0),
(43, 'Havasi Gyopárka', '12345', 0),
(44, 'Heppi Endre', '12345', 0),
(45, 'Heu Réka', '12345', 0),
(46, 'Hiszt Erika', '12345', 0),
(47, 'Hü Jenô', '12345', 0),
(48, 'Idét Lenke', '12345', 0),
(49, 'Ipsz Ilonka', '12345', 0),
(50, 'Karam Ella', '12345', 0),
(51, 'Kasza Blanka', '12345', 0),
(52, 'Major Anna', '12345', 0),
(53, 'Mangal Ica', '12345', 0),
(54, 'Para Zita', '12345', 0);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
