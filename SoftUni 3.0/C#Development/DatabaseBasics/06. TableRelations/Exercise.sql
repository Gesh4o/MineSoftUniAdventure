-- Problem 1. One-To-One Relationshop
CREATE TABLE Passports
(
PassportID INT IDENTITY(1,1),
Passport VARCHAR(10)
CONSTRAINT PK_PassportId PRIMARY KEY (PassportId)
)

CREATE TABLE Persons
(
PersonID INT IDENTITY(1,1),
FirstName VARCHAR(50),
Salary DECIMAL(10,2),
PassportID INT
)

ALTER TABLE Persons 
  ADD 
	CONSTRAINT PK_PersonId PRIMARY KEY (PersonID),
	CONSTRAINT FK_PassportId FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

-- Problem 2. One-To-Many Relationshop
CREATE TABLE Manufacturers
(
ManufacturerID INT IDENTITY(1,1),
Name VARCHAR(30),
EstablishedOn DATE
CONSTRAINT PK_ManufacturerID PRIMARY KEY (ManufacturerID)
)

CREATE TABLE Models
(
ModelID INT IDENTITY(1,1),
Name VARCHAR(20),
ManufacturerID INT
CONSTRAINT PK_ModelID PRIMARY KEY (ModelID),
CONSTRAINT FK_ManufactyrerID FOREIGN KEY (ManufacturerID) 
  REFERENCES Manufacturers(ManufacturerID)
)

-- Problem 3. One-To-Many Relationshop
CREATE TABLE Students
(
StudentID INT IDENTITY(1,1),
Name VARCHAR(20),
CONSTRAINT PK_StudentID PRIMARY KEY (StudentID)
)

CREATE TABLE Exams
(
ExamID INT IDENTITY(1,1),
Name VARCHAR(25)
CONSTRAINT PK_ExamID PRIMARY KEY (ExamID)
)

CREATE TABLE StudentsExams
(
StudentID INT IDENTITY(1,1),
ExamID INT
CONSTRAINT PK_StudentID_ExamID PRIMARY KEY (StudentID, ExamID),
CONSTRAINT FK_StudentID FOREIGN KEY (ExamID) REFERENCES Exams(ExamID),
CONSTRAINT FK_ExamID FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

-- Problem 4. Self-Referencing
CREATE TABLE Teachers
(
TeacherID INT,
Name VARCHAR(20),
ManagerID INT
CONSTRAINT PK_TeacherID PRIMARY KEY (TeacherID),
CONSTRAINT FK_ManagerID FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers (TeacherID, Name, ManagerID) VALUES 
(101, 'John', NULL),
(102, 'Maya',	106),
(103, 'Silvia',106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

-- Problem 5. Online Store Database
CREATE TABLE Cities
(
CityID INT IDENTITY,
Name VARCHAR(50)
CONSTRAINT PK_CityID PRIMARY KEY (CityID)
)

CREATE TABLE Customers
(
CustomerID INT IDENTITY,
Name VARCHAR(50),
Birthday DATE,
CityID INT
CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID)
CONSTRAINT FK_CityID FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
OrderID INT IDENTITY,
CustomerID INT
CONSTRAINT PK_OrderID PRIMARY KEY (OrderID)
CONSTRAINT FK_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
ItemTypeID INT IDENTITY,
Name VARCHAR(50)
CONSTRAINT PK_ItemTypeID PRIMARY KEY (ItemTypeID)
)

CREATE TABLE Items
(
ItemID INT IDENTITY,
Name VARCHAR(50),
ItemTypeID INT
CONSTRAINT PK_ItemID PRIMARY KEY (ItemID)
CONSTRAINT FK_ItemTypeID FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
OrderID INT,
ItemID INT
CONSTRAINT PK_OrderID_ItemID PRIMARY KEY (OrderID, ItemID),
CONSTRAINT FK_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
CONSTRAINT FK_ItemID FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)

-- Problem 6. University Database
CREATE TABLE Majors
(
MajorID INT IDENTITY,
Name VARCHAR(30)
CONSTRAINT PK_MajorID PRIMARY KEY (MajorID)
)

CREATE TABLE Students
(
StudentID INT IDENTITY,
StudentNumber VARCHAR(10),
StudentName VARCHAR(50),
MajorID INT
CONSTRAINT PK_StudentID PRIMARY KEY (StudentID),
CONSTRAINT FK_MajorID FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Subjects
(
SubjectID INT IDENTITY,
SubjectName VARCHAR(30)
CONSTRAINT PK_SubjectID PRIMARY KEY (SubjectID)
)

CREATE TABLE Agenda
(
StudentID INT,
SubjectID INT
CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY (StudentID, SubjectID)
CONSTRAINT FK_Agenda_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_SubjectID FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

CREATE TABLE Payments
(
PaymentID INT IDENTITY,
PaymentDate DATE,
PaymentAmount DECIMAL(10,2),
StudentID INT
CONSTRAINT PK_PaymentID PRIMARY KEY (PaymentID),
CONSTRAINT FK_Payment_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)


-- Problem 9.Employee Address
SELECT TOP 5 e.EmployeeId, e.JobTitle, e.AddressID, a.AddressText
 FROM Employees AS e INNER JOIN Addresses AS a 
   ON e.AddressID = a.AddressID
   ORDER BY e.AddressID 

-- Problem 10. Employee Departments
SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.Name FROM Employees AS e
  INNER JOIN Departments AS d 
  ON  e.DepartmentID = d.DepartmentID
 WHERE e.Salary > 15000
 ORDER BY d.DepartmentID

 -- Problem 11.Employees Without Project
 SELECT TOP 3 * FROM Employees as e 
   LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
   WHERE ep.ProjectID IS NULL
 ORDER BY e.EmployeeID

 -- Problem 12. Employees With Project
  SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name AS ProjectName FROM Employees as e 
   INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
   INNER JOIN Projects AS p ON p.ProjectID = ep.ProjectID
   WHERE (ep.ProjectID IS NOT NULL)  AND (p.StartDate > '08.13.2002') AND (p.EndDate IS NULL  OR p.EndDate = '')
 ORDER BY e.EmployeeID ASC

  -- Problem 13. Employee 24
 SELECT pr.EmployeeID, pr.FirstName, 
	CASE 
		WHEN YEAR(pr.StartDate) >= 2005 THEN NULL 
		ELSE pr.ProjectName
	END AS ProjectName FROM
(SELECT e.EmployeeID, e.FirstName, p.Name AS ProjectName, p.StartDate FROM
	Employees AS e 
		INNER JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
		INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE  e.EmployeeID = 24) AS pr

-- Problem 14. Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName 
 FROM Employees AS e INNER JOIN Employees AS em 
  ON e.ManagerID = em.EmployeeID
 WHERE e.ManagerID IN (3,7)
 ORDER BY e.EmployeeID

-- Problem 15. Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM  Countries AS c
	INNER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	INNER JOIN Mountains AS m ON mc.MountainId = m.Id
	INNER JOIN Peaks AS p ON p.MountainId = m.Id
 WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

-- Problem 16. Count Mountain Ranges
SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges FROM Countries AS c 
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
  WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
  GROUP BY c.CountryCode

-- Problem 17. Countris with or without rivers
SELECT TOP 5 c.CountryName, r.RiverName FROM Countries AS c
  LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
 WHERE c.ContinentCode = 'AF'
 ORDER BY c.CountryName

-- Problem 18. Continents and Countries 
SELECT allCodes.ContinentCode, allcodes.CurrencyCode, allCodes.CurrencyUsage FROM
(SELECT c.ContinentCode, c.CurrencyCode, COUNT(*) AS CurrencyUsage FROM Countries AS c
  GROUP BY c.ContinentCode, c.CurrencyCode) AS allCodes
INNER JOIN 
(SELECT res.ContinentCode, MAX(res.CurrencyUsage) AS MaxCurrencyUsage FROM 
	(SELECT c.ContinentCode, c.CurrencyCode,  COUNT(*) AS CurrencyUsage FROM Countries AS c
		GROUP BY c.ContinentCode, c.CurrencyCode 
		HAVING COUNT(*) > 1 ) AS res
		GROUP BY res.ContinentCode ) AS result
		ON result.ContinentCode = allCodes.ContinentCode AND 
		result.MaxCurrencyUsage = allCodes.CurrencyUsage
ORDER BY allCodes.ContinentCode
	 

-- Problem 19. Countries without any Mountains
 SELECT COUNT(*) FROM Countries AS c LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL

-- Problem 20. Highest Peak and Longest River by Country
SELECT TOP 
	5 c.CountryName, 
	MAX(p.Elevation) AS Elevation, 
	MAX(r.Length) AS Length
		FROM Countries AS c 
			LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
			LEFT JOIN Peaks  AS p ON p.MountainId = mc.MountainId
			LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
			LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	GROUP BY c.CountryName
	ORDER BY Elevation DESC, Length DESC, c.CountryName