DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `userDelete`(IN `pID` INT(11))
    MODIFIES SQL DATA
DELETE FROM `users` WHERE `ID` = `pID`$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `userInsert`(IN `pNev` VARCHAR(20) CHARSET utf8, IN `pJelszo` VARCHAR(10), IN `pAdmin` TINYINT(1))
    MODIFIES SQL DATA
    COMMENT 'Valami'
INSERT INTO `users`(`Nev`, `Jelszo`, `Admin`) VALUES (pNev,pJelszo,pAdmin)$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `userUpdate`(INOUT `pID` INT(11), INOUT `pNev` VARCHAR(20), INOUT `pJelszo` VARCHAR(10), INOUT `pAdmin` TINYINT(1))
UPDATE `users` SET `ID`=pID,`Nev`=pNev,`Jelszo`=pJelszo,`Admin`=pAdmin$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usersTeljesLista`()
    READS SQL DATA
Select * FROM users$$
DELIMITER ;
