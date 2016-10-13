--- DDL
CREATE TABLE DepositTypes
(
DepositTypeID INT,
Name VARCHAR(20)
CONSTRAINT PK_DepositTypeID PRIMARY KEY (DepositTypeID)
)

CREATE TABLE Deposits
(
DepositID INT IDENTITY,
Amount DECIMAL(10,2),
StartDate DATE,
EndDate DATE,
DepositTypeID INT,
CustomerID INT
CONSTRAINT PK_DepositID PRIMARY KEY (DepositID),
CONSTRAINT FK_Deposits_DepositTypeID FOREIGN KEY (DepositTypeID) REFERENCES DepositTypes(DepositTypeID),
CONSTRAINT FK_Deposits_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE EmployeesDeposits
(
EmployeeID INT,
DepositID INT
CONSTRAINT PK_EmployeeDeposits PRIMARY KEY (EmployeeID,DepositID)
CONSTRAINT FK_EmployeeDeposits_EmployeeID FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EmployeeDeposits_DepositID FOREIGN KEY (DepositID) REFERENCES Deposits(DepositID)
)

CREATE TABLE CreditHistory
(
CreditHistoryID INT,
Mark CHAR(1),
StartDate DATE,
EndDate DATE,
CustomerID INT
CONSTRAINT PK_CreditHistory PRIMARY KEY (CreditHistoryID),
CONSTRAINT FK_CrediHistory_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE Payments
(
PaymentID INT,
Date DATE,
Amount DECIMAL(10,2),
LoanID INT
CONSTRAINT PK_PaymentID PRIMARY KEY (PaymentID)
CONSTRAINT FK_Payments_LoanID FOREIGN KEY (LoanID) REFERENCES Loans(LoanID)
)

CREATE Table Users
(
UserID INT,
UserName VARCHAR(20),
Password VARCHAR(20),
CustomerID INT UNIQUE,
CONSTRAINT PK_Users PRIMARY KEY (UserID),
CONSTRAINT FK_Users_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

ALTER TABLE Employees
ADD ManagerID INT
CONSTRAINT FK_Employees_ManagerID FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID)

-- DML
INSERT INTO DepositTypes(DepositTypeID,Name) VALUES
(1, 'Time Deposit'),
(2, 'Call Deposit'),
(3, 'Free Deposit')

-- 01. Insert data
INSERT INTO Deposits (Amount, StartDate, EndDate, CustomerID, DepositTypeID)
SELECT CASE 
	WHEN c.DateOfBirth > '01-01-1980 ' AND c.Gender = 'm' THEN 1100
	WHEN c.DateOfBirth > '01-01-1980 ' AND c.Gender = 'f' THEN 1200
	WHEN c.DateOfBirth <= '01-01-1980 ' AND c.Gender = 'm' THEN 1600
	ELSE 1700
END AS Amount,
GETDATE() AS StartDate,
NULL AS EndDate,
c.CustomerID,
CASE
	WHEN c.CustomerID > 15 THEN 3
	WHEN c.CustomerID % 2 = 1 THEN 1
	ELSE 2
END AS DepositTypeID
 FROM Customers AS c
WHERE c.CustomerID < 20

INSERT INTO EmployeesDeposits (EmployeeID, DepositID) VALUES 
(15, 4),
(20, 15),
(8,	7),
(4,	8),
(3,	13),
(3,	8),
(4,	10),
(10, 1),
(13, 4),
(14, 9)

-- 02. Update Employees
UPDATE Employees
SET ManagerID = 
	CASE 
	WHEN EmployeeID BETWEEN 2 AND 10 THEN 1
	WHEN EmployeeID BETWEEN 12 AND 20 THEN 11
	WHEN EmployeeID BETWEEN 22 AND 30 THEN 21
	WHEN EmployeeID IN (11, 21) THEN 1
	END
-- 03. Delete records
DELETE FROM EmployeesDeposits
WHERE EmployeeID = 3 OR DepositID = 9

--- Querying
-- 01. Employees' salary
SELECT e.EmployeeID, e.HireDate, e.Salary, e.BranchID FROM Employees AS e
WHERE e.Salary > 2000 AND e.HireDate  > '15/06/2009' 

-- 02. Customer age
SELECT FirstName, DateOfBirth, DATEDIFF(YEAR, DateOfBirth, '2016-10-01') AS Age FROM Customers
WHERE  2016 - YEAR(DateOfBirth) BETWEEN 40 AND 50

-- 03. Customer city
SELECT cu.CustomerID, cu.FirstName, cu.LastName, cu.Gender, ci.CityName FROM Customers AS cu
	INNER JOIN Cities AS ci ON ci.CityID = cu.CityID
	WHERE (FirstName LIKE '%a' OR LastName LIKE 'Bu%') AND
	LEN(ci.CityName) >= 8
	ORDER BY cu.CustomerID

-- 04. Employee accounts
SELECT TOP 5 e.EmployeeID, e.FirstName, a.AccountNumber FROM Employees AS e
	INNER JOIN EmployeesAccounts AS ea ON ea.EmployeeID = e.EmployeeID
	INNER JOIN Accounts AS a ON a.AccountID = ea.AccountID
	WHERE YEAR(a.StartDate) > 2012
	ORDER BY e.FirstName DESC

-- 05. Count cities
SELECT c.CityName, b.Name, COUNT(*) as EmployeesCount FROM Cities AS c
	INNER JOIN Branches AS b ON b.CityID = c.CityID AND 
		c.CityID NOT IN (4, 5)
	INNER JOIN Employees AS e ON e.BranchID = b.BranchID
	GROUP BY c.CityName, b.Name
	HAVING COUNT(*) >= 3

-- 06. Loan statistics
SELECT SUM(l.Amount) AS TotalLoanAMount, 
 MAX(l.Interest) AS MaxInterest, 
 MIN (e. Salary) AS MinEmployeeSalary FROM Loans AS l
	INNER JOIN EmployeesLoans AS el ON el.LoanID = l.LoanID
	INNER JOIN Employees AS e ON e.EmployeeID = el.EmployeeID

-- 07. Unite people
	SELECT TOP 3 e.FirstName, c.CityName FROM Employees AS e
		INNER JOIN Branches AS b ON b.BranchID = e.BranchID
		INNER JOIN Cities AS c ON c.CityID = b.CityID
UNION ALL
	SELECT TOP 3 cu.FirstName, ci.CityName FROM Customers AS cu
		INNER JOIN Cities AS ci ON ci.CityID = cu.CityID

-- 08. Customer without accounts
SELECT c.CustomerID, c.Height FROM Customers AS c
	LEFT JOIN Accounts AS a ON a.CustomerID = c.CustomerID
	WHERE a.CustomerID IS NULL AND c.Height BETWEEN 1.74 AND 2.04

-- 09. Average loans
SELECT TOP 5 c.CustomerID, l.Amount FROM Customers AS c
	INNER JOIN Loans AS l ON l.CustomerID = c.CustomerID
	WHERE l.Amount > (SELECT AVG(l.Amount) FROM Loans AS l
						INNER JOIN Customers AS c ON c.CustomerID = l.CustomerID
						WHERE c.Gender = 'M')
	ORDER BY c.LastName

-- 10. Oldest Account
SELECT TOP 1 c.CustomerID, c.FirstName, a.StartDate FROM Customers AS c
	INNER JOIN Accounts AS a ON a.CustomerID = c.CustomerID
	ORDER BY a.StartDate

--- 04. Programmability

-- 01. String joiner function
CREATE FUNCTION udf_ConcatString(@firstString VARCHAR(MAX), @secondString VARCHAR(MAX))
RETURNS VARCHAR(MAX)
BEGIN
RETURN CONCAT(REVERSE(@firstString), REVERSE(@secondString))
END

-- 02. Unexpired loans procedure
CREATE PROCEDURE usp_CustomersWithUnexpiredLoans (@CustomerID INT)
AS
BEGIN
	SELECT c.CustomerID, c.FirstName, l.LoanID FROM Customers AS c
		INNER JOIN Loans AS l ON c.CustomerID = l.CustomerID
		WHERE l.ExpirationDate IS NULL AND c.CustomerID = @CustomerID
END

-- 03. Take loan procedure
CREATE PROCEDURE usp_TakeLoan (@customerID INT, @loanAmount DECIMAL(18,2), @interest DECIMAL(4,2), @startDate DATE)
AS
BEGIN
	BEGIN TRAN
	INSERT INTO Loans (CustomerID, Amount, Interest, StartDate) 
	VALUES (@customerID, @loanAmount, @interest, @startDate)

	IF(@loanAmount NOT BETWEEN 0.01 AND 100000)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Loan Amount.',16,1)
		RETURN
	END

	COMMIT
END

-- 04. Trigger hire Employee
CREATE TRIGGER AfterInsert ON Employees
AFTER INSERT
AS
BEGIN 
		UPDATE EmployeesLoans
		SET EmployeeID = i.EmployeeID FROM inserted AS i
		WHERE [EmployeesLoans].EmployeeID + 1 = i.EmployeeID 
END

--- Bonus
-- 01. After delete
CREATE TRIGGER OnDelete ON Accounts
INSTEAD OF DELETE
AS
BEGIN
	INSERT INTO AccountLogs (AccountID, AccountNumber, CustomerID, StartDate)
	SELECT  deleted.AccountID, deleted.AccountNumber, deleted.CustomerID, deleted.StartDate FROM deleted

	DELETE EmployeesAccounts
	WHERE AccountID in (SELECT d.AccountID FROM deleted AS d)

	DELETE Accounts
	WHERE AccountID in (SELECT d.AccountID FROM deleted AS d)
END