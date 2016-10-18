-- Problem 1. Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
 SELECT FirstName, LastName FROM [dbo].[Employees] AS e 
	WHERE e.Salary > 35000
END

-- Problem 2. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@LowerBound MONEY)
AS
BEGIN
 SELECT FirstName, LastName FROM [dbo].[Employees] AS e 
	WHERE e.Salary >= @LowerBound
END

-- Problem 3. Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith (@prefix VARCHAR(MAX))
AS
BEGIN
 SELECT Name FROM [dbo].Towns AS e 
	WHERE Name LIKE CONCAT(@prefix, '%')
END

-- Problem 4. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown  (@TownName VARCHAR(MAX))
AS
BEGIN
 SELECT e.FirstName, e.LastName FROM Employees AS e 
	LEFT JOIN Addresses AS a ON a.AddressID = e.AddressID
	LEFT JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.Name = @TownName
END

-- Problem 5.	Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @Result VARCHAR(10)
	IF (@salary < 30000)
	BEGIN
		SET @Result = 'Low'
	END
	ELSE IF (@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @Result = 'Average'
	END
	ELSE 
	BEGIN
		SET @Result = 'High'
	END

	RETURN @Result
END

-- Problem 6.	E mployees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(10))
AS
BEGIN
	SELECT e.FirstName, e.LastName FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END

-- Problem 7. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS TINYINT
AS
BEGIN
	DECLARE @result TINYINT = 0;
	IF (@word LIKE CONCAT(CONCAT('[',@setOfLetters),']'))
	BEGIN
	 SET @result = 1
	END
	ELSE
	BEGIN
	 SET @result = -1
	END

	RETURN @result
END

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS TINYINT
AS
BEGIN
	DECLARE @result TINYINT = 1;
	DECLARE @length INT = LEN(@word)
	DECLARE @index INT = 1
	DECLARE @char CHAR(1)

	WHILE @index <= @length
	BEGIN 
	SET @char = SUBSTRING(@word, @index, 1)
	IF(CHARINDEX(@char, @setOfLetters, 0) < 1)
		BEGIN 
			SET	@result = 0
		END

	SET @index = @index + 1
	END
	RETURN @result
END

-- Problem 9. Find Full Name
CREATE PROCEDURE usp_GetHoldersFullName 
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS FullName FROM AccountHolders
END

-- Problem 10.	People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@amount MONEY)
AS
BEGIN
	SELECT FirstName, LastName FROM AccountHolders AS ac 
	LEFT JOIN Accounts AS a ON a.AccountHolderId = ac.Id 
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @amount
END

-- Problem 11.	Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @interestRate FLOAT, @years FLOAT)
RETURNS MONEY
AS
BEGIN
	DECLARE @totalMoney MONEY = @sum

	SET @totalMoney = @totalMoney *  POWER((1 + @interestRate), @years)
	RETURN @totalMoney
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
-- Problem 12. Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@accountId FLOAT, @interestRate FLOAT)
AS
BEGIN
SELECT a.AccountId, ac.FirstName, ac.LastName, a.CurrentBalance, dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS BalanceIn5years FROM AccountHolders AS ac 
		LEFT JOIN Accounts AS a ON a.AccountHolderId = ac.Id 
		WHERE a.AccountHolderId = @accountId
END

-- Problem 13.	Deposit Money
CREATE PROCEDURE usp_DepositMoney (@accountId INT, @moneyAmount MONEY)
AS
BEGIN
	UPDATE Accounts
	SET Balance = Balance + @moneyAmount
	WHERE Id = @accountId
END

-- Problem 14.	Withdraw Money
CREATE PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount MONEY)
AS
BEGIN
	UPDATE Accounts
	SET Balance = Balance - @moneyAmount
	WHERE Id = @accountId
END

-- Problem 19. Trigger
CREATE TRIGGER tr_OnBuy ON UserGameItems
INSTEAD OF INSERT
AS 
BEGIN
	IF (inserted.ItemId IN)

 SELECT gtfi.ItemId, UserGameId, g.GameTypeId FROM UserGameItems AS ugi 
	LEFT JOIN Games AS g ON g.Id = ugi.UserGameId
	LEFT JOIN GameTypeForbiddenItems as gtfi ON gtfi.GameTypeId = g.GameTypeId
END

-- Problem 19.
CREATE TRIGGER tr_OnBuy ON UserGameItems
INSTEAD OF INSERT
AS 
BEGIN

	INSERT INTO UserGameItems SELECT ItemId, UserGameId FROM inserted
	WHERE ItemId IN (
		SELECT Id FROM Items 
		WHERE MinLevel <= (
			SELECT ug.Level FROM UsersGames as ug
				WHERE ug.GameId = UserGameId))
END

SELECT MinLevel FROM Items WHERE Id = 2

-- Problem 20. Massive Shopping
BEGIN TRAN
DECLARE @totalItemSum MONEY = (SELECT SUM(Price) AS TotalPrice FROM Items AS i 
		WHERE i.MinLevel BETWEEN 11 AND 12)

DECLARE @currentBalance MONEY = (SELECT ug.Cash FROM Users AS u 
		LEFT JOIN UsersGames AS ug ON ug.UserId = u.Id
		LEFT JOIN Games AS g ON g.Id = ug.GameId
		WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower')

BEGIN TRY 
	UPDATE UsersGames SET
	Cash -= @totalItemSum
	WHERE UserId = (SELECT Id FROM Users WHERE FirstName = 'Stamat') AND
	 GameId = (SELECT Id FROM Games WHERE Name = 'Safflower')

	INSERT INTO UserGameItems SELECT i.Id, ug.Id FROM UsersGames AS ug CROSS JOIN Items AS i 
		LEFT JOIN Games AS g ON g.Id = ug.GameId
		LEFT JOIN Users AS u ON u.Id = ug.UserId
		WHERE i.MinLevel BETWEEN 11 AND 12 AND u.FirstName = 'Stamat' AND g.Name = 'Safflower'

	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH

BEGIN TRAN
SET @totalItemSum = (SELECT SUM(Price) AS TotalPrice FROM Items AS i 
		WHERE i.MinLevel BETWEEN 19 AND 21)

SET @currentBalance = (SELECT ug.Cash FROM Users AS u 
		LEFT JOIN UsersGames AS ug ON ug.UserId = u.Id
		LEFT JOIN Games AS g ON g.Id = ug.GameId
		WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower')

BEGIN TRY 
	UPDATE UsersGames SET
	Cash -= @totalItemSum
	WHERE UserId = (SELECT Id FROM Users WHERE FirstName = 'Stamat') AND
	 GameId = (SELECT Id FROM Games WHERE Name = 'Safflower')

	INSERT INTO UserGameItems SELECT i.Id, ug.Id FROM UsersGames AS ug CROSS JOIN Items AS i 
		LEFT JOIN Games AS g ON g.Id = ug.GameId
		LEFT JOIN Users AS u ON u.Id = ug.UserId
		WHERE i.MinLevel BETWEEN 19 AND 21 AND u.FirstName = 'Stamat' AND g.Name = 'Safflower'
	
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH

SELECT Name AS 'Item Name' FROM Items 
	WHERE Id IN (
		SELECT ugi.ItemId FROM UserGameItems AS ugi 
			WHERE ugi.UserGameId = (
				SELECT ug.Id FROM UsersGames AS ug 
					LEFT JOIN Games AS g ON g.Id = ug.GameId
					LEFT JOIN Users AS u ON u.Id = ug.UserId
					WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower'))
	ORDER BY Name ASC

SELECT * FROM UserGameItems AS ugi
	LEFT JOIN Items AS i ON i.Id = ugi.ItemId
	WHERE ugi.UserGameId = (SELECT ug.Id FROM UsersGames AS ug
								LEFT JOIN Games AS g ON g.Id = ug.GameId
								LEFT JOIN Users AS u ON u.Id = ug.UserId
									WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower')

-- Problem 21. Number of Users for Email Provider
SELECT SUBSTRING(u.Email,CHARINDEX('@', u.Email, 0) + 1, LEN(u.Email)) AS 'Email Provider', COUNT(*) AS 'Number Of Users' FROM Users as u
GROUP BY SUBSTRING(u.Email,CHARINDEX('@', u.Email, 0) + 1, LEN(u.Email))
ORDER BY COUNT(*) DESC, 'Email Provider' ASC

-- Problem 22. All User in Games
SELECT g.Name AS Game, gt.Name AS 'Game Type', u.Username, ug.Level, ug.Cash, c.Name AS Character FROM Users AS u
	INNER JOIN UsersGames AS ug ON ug.UserId = u.Id
	LEFT JOIN Games AS g ON g.Id = ug.GameId
	LEFT JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
	LEFT JOIN Characters AS c ON c.Id = ug.CharacterId
	ORDER BY ug.Level DESC, u.Username ASC, Game ASC

-- Problem 23. Users in Games with Their Items
SELECT u.Username, g.Name AS Game, COUNT(*) AS 'Items Count', SUM(i.Price) AS 'Items Price'
		FROM Users AS u
	INNER JOIN UsersGames AS ug ON ug.UserId = u.Id
	INNER JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	INNER JOIN Games AS g ON g.Id = ug.GameId
	INNER JOIN Items AS i ON i.Id = ugi.ItemId
	GROUP BY u.Username, g.Name
	HAVING COUNT(*) >= 10
	ORDER BY COUNT(*) DESC, SUM(i.Price) DESC, u.Username ASC

-- Problem 24. * User in Games with Their Statistics
SELECT u.Username, g.Name AS Game,c.Name AS Character,  s.Strength , s.Defence, s.Speed, s.Mind, s.Luck FROM Users AS u
	INNER JOIN UsersGames AS ug ON ug.UserId = u.Id
	LEFT JOIN Games AS g ON g.Id = ug.GameId
	LEFT JOIN Characters AS c ON c.Id = ug.CharacterId
	LEFT JOIN [dbo].[Statistics] AS s ON s.Id = c.StatisticId
	ORDER BY s.Strength DESC, s.Defence DESC, s.Speed DESC, s.Mind DESC, s.Luck DESC

-- Problem 25.	All Items with Greater than Average Statistics
SELECT i.Name, i.Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind FROM Items AS i
	INNER JOIN [dbo].[Statistics] AS s ON s.Id = i.StatisticId
	WHERE s.Mind > (SELECT AVG(st.Mind) FROM [dbo].[Statistics] AS st) AND
		s.Luck > (SELECT AVG(st.Luck) FROM [dbo].[Statistics] AS st) AND
		s.Speed > (SELECT AVG(st.Speed) FROM [dbo].[Statistics] AS st)
	ORDER BY i.Name

-- Problem 26.	Display All Items with information about Forbidden Game Type
SELECT i.Name, i.Price, i.MinLevel, gt.Name AS 'Forbidden Game Type' FROM Items AS i
	LEFT JOIN GameTypeForbiddenItems AS gtfi ON gtfi.ItemId = i.Id
	LEFT JOIN GameTypes AS gt ON gt.Id = gtfi.GameTypeId
 ORDER BY gt.Name DESC, i.Name ASC

 -- Problem 27. 
DECLARE @alexId INT = (SELECT Id FROM Users WHERE Username = 'Alex')
DECLARE @gameId INT = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
DECLARE @userGameID INT = (SELECT Id FROM UsersGames WHERE UserId = @alexId AND GameId = @gameId)
DECLARE @itemSUM MONEY = (SELECT SUM(p.Price) FROM (SELECT i.Id, i.Price FROM Items AS i
	WHERE i.Name IN ('Blackguard', 'Bottomless Potion of Amplification', 
	'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 
	'Golden Gorget of Leoric', 'Hellfire Amulet'))
	AS p)

INSERT INTO UserGameItems SELECT p.ItemId, p.UserGameId FROM (SELECT i.Id As ItemId, ug.Id AS UserGameId FROM Items AS i
	CROSS JOIN UsersGames  AS ug
	WHERE ug.Id = @userGameID
	AND i.Name IN ('Blackguard', 'Bottomless Potion of Amplification', 
	'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 
	'Golden Gorget of Leoric', 'Hellfire Amulet')) AS p

UPDATE UsersGames
SET Cash -= @itemSUM
WHERE Id = @userGameID

SELECT u.Username, g.Name, ug.Cash, i.Name AS 'Item Name' FROM Users AS u
	INNER JOIN UsersGames AS ug ON ug.UserId = u.Id
	LEFT JOIN Games AS g ON g.Id = ug.GameId
	LEFT JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	LEFT JOIN Items AS i ON i.Id = ugi.ItemId
	WHERE g.Id = 221
	ORDER BY i.Name

-- Problem 28.
SELECT p.PeakName, m.MountainRange, p.Elevation FROM Peaks AS p
	INNER JOIN Mountains AS m ON m.Id = p.MountainId
	ORDER BY p.Elevation DESC, p.PeakName ASC

-- Problem 29.
SELECT p.PeakName, m.MountainRange AS Mountain, c.CountryName, con.ContinentName  FROM Peaks AS p
	INNER JOIN Mountains AS m ON m.Id = p.MountainId
	INNER JOIN MountainsCountries AS mc on mc.MountainId = m.Id
	INNER JOIN Countries AS c ON c.CountryCode = mc.CountryCode
	INNER JOIN Continents AS con ON con.ContinentCode = c.ContinentCode
	ORDER BY p.PeakName ASC, c.CountryName ASC

-- Problem 30.
SELECT co.CountryName, con.ContinentName,
CASE
	WHEN COUNT(r.Id) IS NULL THEN 0
	ELSE COUNT(r.Id)
END
AS RiversCount, 
CASE
	WHEN SUM(r.Length) IS NULL THEN 0
	ELSE SUM(r.Length)
END
AS TotalLength
FROM Countries AS co
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = co.CountryCode
	LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	LEFT JOIN Continents AS con ON con.ContinentCode = co.ContinentCode
	GROUP BY co.CountryName, con.ContinentName
	ORDER BY RiversCount DESC, TotalLength DESC, co.CountryName ASC

-- Problem 31.
SELECT cu.CurrencyCode, cu.Description AS Currency, COUNT(co.CountryName) AS NumberOfCountries FROM Currencies AS cu 
 LEFT JOIN Countries AS co ON co.CurrencyCode = cu.CurrencyCode
 GROUP BY cu.CurrencyCode, cu.Description
 ORDER BY COUNT(co.CountryName) DESC, cu.Description ASC

-- Problem 32.
SELECT con.ContinentName, SUM(cou.AreaInSqKm) AS CountriesArea, SUM(CAST(cou.Population AS BIGINT)) AS CountriesPopulation FROM Continents AS con
	INNER JOIN Countries AS cou ON cou.ContinentCode = con.ContinentCode
	GROUP BY con.ContinentName
	ORDER BY SUM(CAST(cou.Population AS BIGINT)) DESC

-- Problem 33.
CREATE TABLE Monasteries
(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50),
CountryCode CHAR(2),
IsDeleted TINYINT
CONSTRAINT FK_Monasteries_CountryCode FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

UPDATE Countries
	SET IsDeleted = 0
WHERE CountryCode IN (SELECT cou.CountryCode FROM Countries AS cou 
					LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = cou.CountryCode
					LEFT JOIN Rivers AS r ON r.Id = cr.RiverId 
					GROUP BY cou.CountryCode
					HAVING (COUNT(r.Id)) <= 3)

SELECT m.Name, cou.CountryName FROM [dbo].[Monasteries] AS m 
	LEFT JOIN Countries AS cou ON cou.CountryCode = m.CountryCode
	WHERE m.IsDeleted = 0
	ORDER BY m.Name

ALTER TABLE Countries
ADD IsDeleted TINYINT
CONSTRAINT D_Value DEFAULT 0

-- Problem 34.
