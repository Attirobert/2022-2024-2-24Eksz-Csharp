DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UserInsert`(IN `pNev` VARCHAR(20) CHARSET utf8, IN `pJelszo` VARCHAR(10) CHARSET utf8, IN `pAdmin` TINYINT(1))
    READS SQL DATA
INSERT INTO `users`(`Nev`, `Jelszo`, `Admin`) VALUES (pNev, pJelszo, pAdmin)$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UserTeljesLista`()
    READS SQL DATA
SELECT * FROM `users`$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UserUpdate`(IN `pID` INT(11), IN `pNev` VARCHAR(20) CHARSET utf8, IN `pJelszo` VARCHAR(10) CHARSET utf8, IN `pAdmin` TINYINT(1))
    MODIFIES SQL DATA
UPDATE `users` SET `Nev`=pNev,`Jelszo`=pJelszo,`Admin`=pAdmin WHERE `ID`=pID$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UserDelete`(IN `pID` INT(11))
DELETE FROM `users` WHERE `ID` = pID$$
DELIMITER ;
