-- Problem 14. Car rental database
CREATE DATABASE CarRental

CREATE TABLE [CarRental].[dbo].Categories
(
Id INT IDENTITY,
Category VARCHAR(20) NOT NULL,
DailyRate NUMERIC (10,2),
WeeklyRate NUMERIC(10,2),
MonthlyRate NUMERIC(10,2),
WeekendRate NUMERIC(10,2)
CONSTRAINT PK_Category PRIMARY KEY (ID)
)

CREATE TABLE [CarRental].[dbo].Cars
(
Id INT IDENTITY,
Category VARCHAR(20) NOT NULL,
PlateNumber VARCHAR(8),
Make VARCHAR(25) NOT NULL,
Model VARCHAR(20) NOT NULL,
Year INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES [CarRental].[dbo].[Categories](Id),
Doors VARCHAR(20),
Picture VARBINARY(8000),
Condition VARCHAR(15)  CHECK (Condition IN('New', 'Used', 'For parts')),
Available TINYINT NOT NULL
CONSTRAINT PK_Car PRIMARY KEY (Id)
)

CREATE TABLE [CarRental].[dbo].Employees
(
Id INT IDENTITY,
FirstName VARCHAR(25) NOT NULL,
LastName VARCHAR(25) NOT NULL,
Title VARCHAR(20) NOT NULL,
Notes VARCHAR(200)
CONSTRAINT PK_Employee PRIMARY KEY (Id)
)

CREATE TABLE [CarRental].[dbo].Customers
(
Id INT IDENTITY,
DriverLicenseNumber VARCHAR(20) UNIQUE NOT NULL,
FullName VARCHAR(50) UNIQUE NOT NULL,
Address VARCHAR(70),
City VARCHAR(25),
ZIPCode VARCHAR(10),
Notes VARCHAR(200)
CONSTRAINT PK_Customer PRIMARY KEY (Id)
)

CREATE TABLE [CarRental].[dbo].RentalOrders
(
Id INT IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES [CarRental].[dbo].Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES [CarRental].[dbo].Customers(Id),
CarId INT FOREIGN KEY REFERENCES [CarRental].[dbo].Cars(Id),
CarCondition VARCHAR(15), --FOREIGN KEY REFERENCES [CarRental].[dbo].Cars(Condition),-- Why it cant be set to this?
TankLevel VARCHAR(15),
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL,
StartDate DATE,
EndDate DATE,
TotalDays INT NOT NULL,
RateApplied NUMERIC(10,2),
TaxRate NUMERIC(10,2),
OrderStatus VARCHAR(15) CHECK (OrderStatus IN('Done', 'In process..', 'Interupted'))
CONSTRAINT PK_RentalOrder PRIMARY KEY (Id)
)

INSERT INTO [CarRental].[dbo].Categories(Category)
VALUES('Hatch-back'),
('Sedan'),
('Combi')

INSERT INTO [CarRental].[dbo].Cars(Category, Make, Model, Year, Available, CategoryId)
VALUES ('Sedan', 'BMW', 'i5', 1999, 0, 1),
('Combi', 'BMW', 'i15', 1999, 0, 2),
('Sedan', 'BMW', 'i5', 2009, 0, 1)

INSERT INTO [CarRental].[dbo].Customers(DriverLicenseNumber, FullName)
VALUES('a14d35ad', 'Pesho'),
('a144d35ad', 'Gosho'),
('a1114d35ad', 'Tosho')

INSERT INTO [CarRental].[dbo].Employees( FirstName, LastName, Title)
VALUES
('Pesho', 'Peshev', 'Miqch'),
('Gosho', 'Georgiev', 'Mehanik'),
('Maria', 'Todorova', 'Higienist')

INSERT INTO [CarRental].[dbo].RentalOrders(KilometrageStart, KilometrageEnd, TotalKilometrage, TotalDays)
VALUES
(1000,1000,2000,10),
(3000,10,3010,20),
(4000,1000,5000, 3)

-- Problem 16. Hotel database

CREATE DATABASE Hotel

CREATE TABLE Employees
(
Id INT IDENTITY  NOT NULL,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Title VARCHAR(20) NOT NULL,
Notes VARCHAR(200)
CONSTRAINT PK_Employee PRIMARY KEY (Id)
)

CREATE TABLE Customers
(
AccountNumber VARCHAR(20) UNIQUE NOT NULL,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
PhoneNumber VARCHAR(15),
EmergencyName VARCHAR(20),
EmergencyNumber VARCHAR(15),
Notes VARCHAR(200)
CONSTRAINT PK_Customer PRIMARY KEY (AccountNumber)
)

CREATE TABLE RoomStatus
(
RoomStatus VARCHAR(30) UNIQUE NOT NULL,
Notes VARCHAR(200)
CONSTRAINT PK_RoomStatus PRIMARY KEY (RoomStatus)
)

CREATE TABLE RoomTypes 
(
RoomType  VARCHAR(30) UNIQUE NOT NULL,
Notes VARCHAR(200)
CONSTRAINT PK_RoomType PRIMARY KEY (RoomType)
)

CREATE TABLE BedTypes 
(
BedType  VARCHAR(30) UNIQUE NOT NULL,
Notes VARCHAR(200)
CONSTRAINT PK_BedType PRIMARY KEY (BedType)
)

CREATE TABLE Rooms 
(
RoomNumber VARCHAR(5) UNIQUE NOT NULL,
RoomType  VARCHAR(30) NOT NULL,
BedType  VARCHAR(30) NOT NULL,
RoomStatus VARCHAR(30) NOT NULL,
Rate NUMERIC(10,2) NOT NULL,
Notes VARCHAR(200)
CONSTRAINT PK_Room PRIMARY KEY (RoomNumber)
)

CREATE TABLE Payments
(
Id INT IDENTITY  NOT NULL,
EmployeeId INT,
PaymentDate DATE NOT NULL,
AccountNumber VARCHAR(20),
FirstDay DATE NOT NULL,
LastDay DATE NOT NULL,
TotalDays INT,
AmountChareged NUMERIC(10,2),
TaxRate NUMERiC(10,2) NOT NULL,
TaxAmount NUMERIC(10,2),
PaymentTotal NUMERIC(10,2),
Notes VARCHAR(200)
CONSTRAINT PK_Payment PRIMARY KEY (Id)
)

CREATE TABLE Occupancies 
(
Id INT IDENTITY  NOT NULL,
EmployeeId INT,
DateOccupied DATE NOT NULL,
AccountNumber VARCHAR(20) NOT NULL,
RoomNumber VARCHAR(5) UNIQUE NOT NULL,
RateApplied NUMERiC(10,2) NOT NULL,
PhoneCharge NUMERIC(10,2),
Notes VARCHAR(200)
CONSTRAINT PK_Occupancy  PRIMARY KEY (Id)
)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES
	('Pesho', 'Peshev', 'Cook'),
	('Gosho', 'Peshev', 'Chairman'),
	('Pesho', 'Goshov', 'Driver')

INSERT INTO Customers(AccountNumber, FirstName, LastName)
VALUES
	('1111', 'Pesho', 'Peshev'),
	('2222', 'Gosho', 'Peshev'),
	('3333', 'Pesho', 'Goshov')

INSERT INTO RoomStatus(RoomStatus)
VALUES
	('For cleaning'),
	('Free'),
	('Taken')

INSERT INTO RoomTypes(RoomType)
VALUES
	('Mansion'),
	('Penthouse'),
	('Apartment')

INSERT INTO BedTypes(BedType)
VALUES
	('Single'),
	('Double'),
	('On floors')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus)
VALUES 
	('dsaa', 'Mansion', 'Single', 10.2, 'Free'),
	('1221', 'Mansion', 'Single', 10.2, 'Free'),
	('3dsa1', 'Mansion', 'Single', 10.2, 'Free')

INSERT INTO Payments(PaymentDate, AccountNumber, FirstDay, LastDay , TaxRate)
VALUES 
	('11/11/2011', '1111', '11/11/2011', '12/11/2011', 10.2),
	('11/12/2011', '2222', '10/11/2011', '12/11/2011', 21.3),
	('12/11/2011', '3333', '09/11/2011', '09/13/2011', 13.3)

INSERT INTO Occupancies(DateOccupied, AccountNumber, RoomNumber, RateApplied)
VALUES 
	('11/11/2011', '1ддсаса', '11', 10.2),
	('10/11/2011', 'дса','333', 14.2),
	('09/11/2011', 'дсадса', '1112', 13.2)
