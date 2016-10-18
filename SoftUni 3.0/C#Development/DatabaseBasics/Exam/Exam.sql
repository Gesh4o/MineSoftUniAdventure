-- DDL
CREATE TABLE Flights
(
FlightID INT,
DepartureTime DATETIME NOT NULL,
ArrivalTime DATETIME NOT NULL,
Status VARCHAR(9),
OriginAirportID INT,
DestinationAirportID INT,
AirlineID INT
CONSTRAINT PK_FlightID PRIMARY KEY (FlightID),
CONSTRAINT FK_Flights_OriginAirportID FOREIGN KEY (OriginAirportID) REFERENCES Airports(AirportID),
CONSTRAINT FK_Flights_DestinationAirportID FOREIGN KEY (DestinationAirportID) REFERENCES Airports(AirportID),
CONSTRAINT FK_Flights_AirlineID FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID),
CONSTRAINT Plausible_Values_Status CHECK (Status = 'Departing' OR Status = 'Delayed' OR Status = 'Arrived' OR Status = 'Cancelled')
)

CREATE TABLE Tickets
(
TicketID INT,
Price DECIMAL(8,2) NOT NULL,
Class VARCHAR(6),
Seat VARCHAR(5) NOT NULL,
CustomerID INT,
FlightID INT
CONSTRAINT PK_TicketID PRIMARY KEY (TicketID),
CONSTRAINT FK_Tickets_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
CONSTRAINT FK_Tickets_FlightID FOREIGN KEY (FlightID) REFERENCES Flights(FlightID),
CONSTRAINT Check_Class_Plausible_Values CHECK (Class = 'First' OR Class = 'Second' OR Class = 'Third')
)

--- DML
-- 01.Data insertion
INSERT INTO Towns (TownID, TownName)
VALUES (1, 'Sofia'),
		(2, 'Moscow'),
		(3, 'Los Angeles'),
		(4, 'Athene'),
		(5, 'New York')

INSERT INTO Airports (AirportID, AirportName, TownID)
VALUES
(1,'Sofia International Airport' ,1),
(2,'New York Airport',5),
(3,'Royals Airport',1),
(4,'Moscow Central Airport',2)


INSERT INTO Airlines (AirlineID, AirlineName, Nationality, Rating)
VALUES

(1,'Royal Airline', 'Bulgarian',200),
(2,'Russia Airlines','Russian',150),
(3,'USA Airlines', 'American',100),
(4,'Dubai Airlines', 'Arabian',149),
(5,'South African Airlines', 'African', 50),
(6,'Sofia Air','Bulgarian',199),
(7,'Bad Airlines','Bad',10)

INSERT INTO Flights (FlightID, DepartureTime, ArrivalTime, Status, OriginAirportID, DestinationAirportID, AirlineID)
VALUES
(1,'2016-10-13 06:00 AM', '2016-10-13 10:00 AM','Delayed', 1, 4, 1),
(2,'2016-10-12 12:00 PM','2016-10-12 12:01 PM','Departing', 1, 3, 2),
(3,'2016-10-14 03:00 PM','2016-10-20 04:00 AM','Delayed', 4, 2, 4),
(4,'2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
(5,'2016-10-12 08:11 AM', '2016-10-12 11:22 PM','Departing',4,1,1),
(6,'1995-06-21 12:30 PM','1995-06-22 08:30 PM','Arrived',2, 3, 5),
(7,'2016-10-12 11:34 PM','2016-10-13 03:00 AM','Departing',2, 4,2),
(8,'2016-11-11 01:00 PM','2016-11-12 10:00 PM','Delayed',4,3,1),
(9,'2015-10-01 12:00 PM','2015-12-01 01:00 AM','Arrived',1,2,1),
(10,'2016-10-12 07:30 PM','2016-10-13 12:30 PM','Departing',2,1,7)

INSERT INTO Customers (CustomerID, FirstName, LastName, DateOfBirth, Gender, HomeTownID)
VALUES
(1,'Cassidy','Isacc','1997-10-20','F', 1),
(2,'Jonathan','Half','1983-03-22','M', 2),
(3,'Zack','Cody','1989-08-08', 'M', 4),
(4, 'Joseph','Priboi','1950-01-01', 'M',5),
(5,'Ivy','Indigo','1993-12-31','F',1)

INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID,FlightID)
VALUES
(1,3000.00,'First','233-A',3, 8),
(2,1799.90,'Second','123-D', 1,1),
(3,1200.50,'Second','12-Z',2,5),
(4,410.68, 'Third','45-Q',2,8),
(5,560.00,'Third', '201-R',4,6),
(6,2100.00,'Second','13-T',1,9),
(7,5500.00,'First','98-O',2,7)

-- 02. Update arrived flights
UPDATE Flights
SET  AirlineID = 1
WHERE Status = 'Arrived'

-- 03. Update tickets
UPDATE Tickets
SET Price += (Price / 2)
WHERE FlightID IN (SELECT FlightID FROM Flights AS f
					WHERE f.AirlineID = (SELECT TOP 1 AirlineID FROM Airlines AS a
										ORDER BY a.Rating DESC))

-- 04. Table creation
CREATE TABLE CustomerReviews
(
ReviewID INT,
ReviewContent VARCHAR(255) NOT NULL,
ReviewGrade INT,
AirlineID INT,
CustomerID INT,
CONSTRAINT PK_ReviewID PRIMARY KEY (ReviewID),
CONSTRAINT Check_Grade CHECK (ReviewGrade >= 0 AND ReviewGrade <=10),
CONSTRAINT FK_CR_AirlineID FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID),
CONSTRAINT FK_CR_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts
(
AccountID INT,
AccountNumber VARCHAR(10) NOT NULL UNIQUE,
Balance DECIMAL(10,2) NOT NULL,
CustomerID INT,
CONSTRAINT PK_AccountID PRIMARY KEY (AccountID),
CONSTRAINT FK_CBA_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

-- 05. Fill the new tables with data
INSERT INTO  CustomerReviews (ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
VALUES
(1,'Me is very happy. Me likey this airline. Me good.',10,1,1),
(2,'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!',10,1,4),
(3,'Meh...',5,4,3),
(4,'Well Ive seen better, but Ive certainly seen a lot worse...',7,3,5)

INSERT INTO CustomerBankAccounts (AccountID, AccountNumber, Balance, CustomerID)
VALUES
(1,'123456790',2569.23,1),
(2,'18ABC23672',14004568.23,2),
(3,'F0RG0100N3',19345.20,5)

--- Querying
-- 01. Extract all tickets
SELECT TicketID, Price, Class, Seat FROM Tickets
ORDER BY TicketID

-- 02. Extract all customers
SELECT CustomerID, FirstName + ' ' + LastName AS FullName, Gender FROM Customers
	ORDER BY FullName, CustomerID

-- 03. Extract delayed flights
SELECT f.FlightID, f.DepartureTime, f.ArrivalTime FROM Flights AS f
WHERE f.Status = 'Delayed'
ORDER BY f.FlightID

-- 04. Extract top most highly rated airlines which have any flights
SELECT DISTINCT TOP 5 a.AirlineID, a.AirlineName, a.Nationality, a.Rating FROM Airlines AS a
	WHERE a.AirlineID IN (SELECT f.AirlineID FROM Flights AS f)
ORDER BY a.Rating DESC, a.AirlineID ASC

-- 05. Extract all tickets with price below 5000 for First Class
SELECT TicketID, a.AirportName, c.FirstName + ' ' + c.LastName AS CustomerName FROM Tickets AS tic
	INNER JOIN Flights AS f ON f.FlightID = tic.FlightID
	INNER JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
	INNER JOIN Customers AS c ON c.CustomerID = tic.CustomerID
	WHERE tic.Price < 5000 AND tic.Class = 'First'
	ORDER BY tic.TicketID

-- 06. Extract all customers which are departing from their home town
SELECT c.CustomerID , c.FirstName + ' ' + c.LastName AS FullName, TownName  FROM Customers AS c
	INNER JOIN Tickets AS t ON t.CustomerID = c.CustomerID
	INNER JOIN Flights AS f ON f.FlightID = t.FlightID
	INNER JOIN Airports AS a ON f.OriginAirportID = a.AirportID
	INNer JOIN Towns AS tow ON tow.TownID = a.TownID
	WHERE a.TownID = c.HomeTownID AND f.Status = 'Departing'
ORDER BY CustomerID

-- 07.  Extract all customers which will fly
SELECT DISTINCT c.CustomerID, c.FirstName + ' ' + c.LastName AS FullName, 2016 - YEAR(c.DateOfBirth) AS Age FROM Customers AS c
	INNER JOIN Tickets AS tic ON tic.CustomerID = c.CustomerID
	INNER JOIN Flights AS f ON f.FlightID = tic.FlightID
	WHERE f.Status = 'Departing'
	ORDER BY Age, CustomerID

-- 08. Top 3 customers delayed
SELECT TOP 3 cu.CustomerID, cu.FirstName + ' ' + cu.LastName AS FullName, tic.Price, a.AirportName FROM  Customers AS cu
	INNER JOIN Tickets AS tic ON tic.CustomerID = cu.CustomerID
	INNER JOIN Flights AS f ON f.FlightID = tic.FlightID
	INNER JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
	WHERE f.Status = 'Delayed'
	ORDER BY tic.Price DESC, cu.CustomerID

-- 09. Extract last 5 flights departing
SELECT fl.FlightID, fl.DepartureTime, fl.ArrivalTime, airp.AirportName AS Origin, airpD.AirportName AS Destination FROM (SELECT TOP 5 * FROM Flights as f  WHERE f.Status = 'Departing' ORDER BY DepartureTime DESC) AS fl
	INNER JOIN Airports AS airp ON airp.AirportID = fl.OriginAirportID
	INNER JOIN Airports AS airpD ON airpD.AirportID = fl.DestinationAirportID
ORDER BY fl.DepartureTime, FlightID

-- 10. Extract all customers below 21 years which have already flew once
SELECT cu.CustomerID, cu.FirstName + ' ' + cu.LastName AS FullName, 2016 - YEAR(cu.DateOfBirth) AS Age FROM Customers AS cu
	WHERE 2016 - YEAR(cu.DateOfBirth) < 21 AND cu.CustomerID IN (
													SELECT t.CustomerID FROM Tickets AS t
													INNER JOIN Flights AS fl ON fl.FlightID = t.FlightID
													WHERE fl.Status = 'Arrived')
	ORDER BY Age DESC, cu.CustomerID

-- 11. Extract all aiporst and the count of people departing from them
SELECT air.AirportID, air.AirportName, COUNT(t.CustomerID) AS Passengers FROM Airports AS air
	INNER JOIN Flights AS f ON f.OriginAirportID = air.AirportID
	INNER JOIN Tickets AS t ON  t.FlightID = f.FlightID
	WHERE f.Status = 'Departing'
	GROUP BY air.AirportID, air.AirportName
	ORDER BY AirportID

--- Programmability

-- 01. Submit review
CREATE PROCEDURE usp_SubmitReview (@CustomerID INT, @ReviewContent VARCHAR(255), @ReviewGrade INT, @AirlineName VARCHAR(30))
AS 
BEGIN
DECLARE @airlineId INT = (SELECT AirlineID FROM Airlines WHERE AirlineName = @airlineName)
IF (@airlineId IS NULL)
BEGIN
	RAISERROR('Airline does not exist.',16,1)
	RETURN
END
INSERT INTO CustomerReviews (ReviewID, CustomerID, ReviewContent, ReviewGrade, AirlineID) 
VALUES
	(ISNULL((SELECT TOP 1 ReviewID FROM CustomerReviews ORDER  BY ReviewID DESC),0) + 1, @CustomerID, @ReviewContent, @ReviewGrade, @airlineId)
END

-- 02. Ticket purchase
CREATE PROCEDURE usp_PurchaseTicket (@CustomerID INT, @FlightID INT,@TicketPrice DECIMAL(8,2), @Class VARCHAR(6), @Seat VARCHAR(5))
AS
BEGIN

IF (@TicketPrice > ISNULL((SELECT Balance FROM CustomerBankAccounts WHERE CustomerID = @CustomerID),0))
BEGIN
	RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
	RETURN;
END

INSERT INTO Tickets (TicketID, FlightID, Price, Class, Seat, CustomerID)
VALUES (ISNULL((SELECT TOP 1 TicketID FROM Tickets ORDER BY TicketID DESC),0) + 1, @FlightID, @TicketPrice, @Class, @Seat, @CustomerID )

UPDATE CustomerBankAccounts 
	SET Balance -= @TicketPrice
	WHERE CustomerID = @CustomerID
END

--- Bonus
CREATE TRIGGER tr_OnFlightUpdate ON Flights
AFTER UPDATE
AS
BEGIN
-- (FlightID, ArrivalTime, Origin, Destination, Passengers)
INSERT INTO [dbo].[ArrivedFlights]
		SELECT 
		i.FlightID,
		i.ArrivalTime,
		(SELECT a.AirportName FROM Airports AS a WHERE i.OriginAirportID = a.AirportID) AS Origin,
		(SELECT a.AirportName FROM Airports AS a WHERE i.DestinationAirportID = a.AirportID) AS Destination,
		(SELECT  COUNT(t.TicketID) FROM Flights AS f 
			INNER JOIN Tickets AS t ON t.FlightID = f.FlightID WHERE f.FlightID = i.FlightID)
		 FROM inserted AS i
			INNER JOIN deleted AS d ON d.FlightID = i.FlightID
			WHERE (d.Status != 'Arrived' AND i.Status = 'Arrived')
END