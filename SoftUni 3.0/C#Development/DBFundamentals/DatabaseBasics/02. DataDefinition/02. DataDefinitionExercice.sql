--Problem 05. Truncate table Minions
TRUNCATE TABLE [Minions].[dbo].[Minions]

--Problem 06. Drop all tables
DROP TABLE Minions.dbo.Minions
DROP TABLE Minions.dbo.Towns

--Problem 07. Create table People
CREATE TABLE People
(
 Id int IDENTITY,
 Name NVARCHAR(200) NOT NULL,
 Picture VARBINARY(MAX),
 Height NUMERIC(10,2),
 Weight NUMERIC(10,2),
 Gender  VARCHAR(1) NOT NULL CHECK (Gender IN('f', 'm')),
 Birthdate DATE NOT NULL,
 Biography NVARCHAR(MAX)
 CONSTRAINT PK_People PRIMARY KEY (Id)
)

INSERT intO People(Name, Picture, Height, Weight, Gender, Birthdate) 
VALUES 
('Pesho', NULL, 170.3, 90.873, 'm', '01/02/1991'), 
('Gosho', NULL, 165.3, 87.73, 'm', '03/12/1996'),
('Tosho', NULL, 165.3, 87.73, 'm', '11/19/1987'),
('Toshka', NULL, 165.3, 50.73, 'f', '03/11/1997'),
('Maria', NULL, 158.3, 87.73, 'f', '08/24/1998')

--Problem 08. Create table Users
CREATE TABLE Users
(
 Id BIGint IDENTITY,
 Username VARCHAR(30) NOT NULL,
 Password VARCHAR(26) NOT NULL,
 ProfilePicture VARBINARY(900),
 LastLogintime DATE,
 IsDeleted TINYint  
 CONSTRAINT PK_USER PRIMARY KEY (Id)
)

INSERT intO Users(Username, Password, ProfilePicture, LastLogintime, IsDeleted) 
VALUES 
('Pesho', 'Incorrect', NULL, '01/02/1991', 0), 
('Gosho', 'Incorrect', NULL, '03/12/1996', 1),
('Tosho', 'Incorrect', NULL, '11/19/1987', 1),
('Toshka', 'Incorrect',NULL, '03/11/1997', 1),
('Maria', 'Incorrect', NULL, '08/24/1998', 0)

--Problem 09. Change Primary key
ALTER TABLE dbo.Users
    DROP CONSTRAINT PK__Users__77222459BE7A2D66

ALTER TABLE dbo.Users
	ADD CONSTRAINT PK_User PRIMARY KEY (Id, Username)

--Problem 10. Add check CONSTRAINT
ALTER TABLE dbo.Users
	ADD CONSTRAINT [PasswordMinLengthCONSTRAINT] CHECK (DATALENGTH([Password]) >= 5)

--Problem 11. Set default value of a field
ALTER TABLE dbo.Users
	ADD CONSTRAINT [LastLogintimeDefaultValueCONSTRAINT]
	DEFAULT GETDATE() FOR LastLogintime

--Problem 12. Set unique field
ALTER TABLE dbo.Users
	DROP CONSTRAINT PK_User

ALTER TABLE dbo.Users
	ADD CONSTRAINT PK_User PRIMARY KEY (Id)

ALTER TABLE dbo.Users
	ADD CONSTRAINT [UsernameUniqueCONSTRAINT]
	UNIQUE (Username)

ALTER TABLE dbo.Users
	ADD CONSTRAINT [UsernameMinLengthCONSTRAINT]
	CHECK (DATALENGTH([Username]) >= 3)
-- Why the CONSTRAINT is not add in the CONSTRAINT table view ?

--Problem 13. Movies database
CREATE DATABASE Movies

CREATE TABLE Movies.dbo.Directors
(
Id int IDENTITY,
Name NVARCHAR(50) NOT NULL UNIQUE,
Notes NVARCHAR(200)
CONSTRAINT PK_Director PRIMARY KEY (Id)
)

CREATE TABLE Movies.dbo.Genres
(
Id int IDENTITY,
Name NVARCHAR(50) NOT NULL UNIQUE,
Notes NVARCHAR(200)
CONSTRAINT PK_Genre PRIMARY KEY (Id)
)

CREATE TABLE Movies.dbo.Categories
(
Id int IDENTITY,
Name NVARCHAR(50) NOT NULL UNIQUE,
Notes NVARCHAR(200)
CONSTRAINT PK_Category PRIMARY KEY (Id)
)

CREATE TABLE Movies.dbo.Movies
(
Id int IDENTITY,
Name NVARCHAR(50) NOT NULL UNIQUE,
DirectorId int FOREIGN KEY REFERENCES Movies.dbo.Directors(Id),
CopyrightYear int,
Length int,
GenreId int FOREIGN KEY REFERENCES Movies.dbo.Genres(Id),
CategoryId int FOREIGN KEY REFERENCES Movies.dbo.Categories(Id),
Rating int,
Notes NVARCHAR(200)
CONSTRAINT PK_Movie PRIMARY KEY (Id)
)

INSERT INTO [Movies].[dbo].[Directors](Name, Notes) 
VALUES 
('Pesho', 'notes'), 
('Gosho', 'notes'),
('Tosho', 'notes'),
('Toshka', 'notes'),
('Maria', 'notes')

INSERT INTO [Movies].[dbo].[Genres](Name, Notes) 
VALUES 
('Action', 'sample notes'), 
('Thriller', 'notes'),
('Drama', 'notes'),
('Comedy', 'sample notes'),
('Musical', 'sample notes')

INSERT INTO [Movies].[dbo].[Categories](Name, Notes) 
VALUES 
('Vintage', 'sample notes'), 
('Black and white', 'notes only'),
('Real story', 'notes'),
('Authobiographical', 'sample notes'),
('Most watched', 'no notes')

INSERT INTO [Movies].[dbo].[Movies](Name, CopyrightYear, Notes) 
VALUES 
('Terminator', 1999,'sample notes'), 
('Beverly hills Cop', 1998, 'notes only'),
('Undercover', 2004,'notes'),
('Undisputed', 2007,'sample notes'),
('Born', 2016, 'no notes')