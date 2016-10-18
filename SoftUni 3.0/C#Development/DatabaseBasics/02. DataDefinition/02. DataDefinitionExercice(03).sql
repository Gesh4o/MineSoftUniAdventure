CREATE TABLE Towns
(
Id INT IDENTITY(1,1),
Name VARCHAR(30) NOT NULL
CONSTRAINT PK_Town PRIMARY KEY (Id)
)

CREATE TABLE Addresses
(
Id INT IDENTITY(1,1),
AddressText VARCHAR(30) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
CONSTRAINT PK_Address PRIMARY KEY (Id)
)

CREATE TABLE Departments
(
Id INT IDENTITY(1,1),
Name VARCHAR(30) NOT NULL
CONSTRAINT PK_Department PRIMARY KEY (Id)
)

CREATE TABLE Employees
(
Id INT IDENTITY(1,1),
FirstName VARCHAR(30) NOT NULL,
MiddleName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
JobTitle VARCHAR(20),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE,
Salary NUMERIC(10,2),
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
CONSTRAINT PK_Employee PRIMARY KEY (Id)
)

INSERT INTO Towns(Name)
VALUES 
	('Sofia'),
	('Plovdiv'),
	('Varna'),
    ('Burgas')

INSERT INTO Departments(Name)
VALUES 
	('Engineering'),
	('Sales'),
	('Marketing'),
    ('Software Development'),
    ('Quality Assurance')

	INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES 
	('Ivan', 'Ivanov', 'Ivanov','.NET Developer', 4, '01/02/2013',	'3500.00'),
	('Petar ', 'Petrov ', 'Petrov ','Senior Engineer', 1, '02/03/2004','4000.00'),
	('Maria ', 'Petrova', 'Ivanova','Intern', 5, '28/08/2016', '525.25'),
	('Georgi ', 'Teziev ', 'Ivanov','CEO', 2, '09/12/2007',	'3000.00'),
	('Peter', 'Pan', 'Pan','Intern', 3,	'28/08/2016',	'599.88')


SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees
