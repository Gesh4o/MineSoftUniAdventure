using System;
using System.Data.SqlClient;

namespace _01.InitialSetup
{
    class SetupMain

    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(
                "Server=.; " +
                "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                SqlCommand createDbCommand = new SqlCommand(
                    "IF (DB_ID('MinionsDB') IS NULL) " + 
                    "BEGIN CREATE DATABASE MinionsDB END " +
                    @"USE MinionsDB

                    CREATE TABLE Towns
                    (
                    TownID INT PRIMARY KEY,
                    TownName VARCHAR(40),
                    CountryName VARCHAR(30)
                    )

                    CREATE TABLE Minions
                    (
                    Name VARCHAR(20) PRIMARY KEY,
                    Age INT,
                    TownID INT
                    CONSTRAINT FK_Minions_Town FOREIGN KEY (TownID) REFERENCES Towns(TownID)
                    )

                    CREATE TABLE Villains
                    (
                    Name VARCHAR(100) PRIMARY KEY,
                    EvilnessFactor VARCHAR(10) CHECK (Evilnessfactor = 'good' OR Evilnessfactor = 'bad' OR Evilnessfactor = 'evil' OR Evilnessfactor = 'super evil')
                    )

                    CREATE TABLE VilliansMinions
                    (
                    VillianName VARCHAR(100),
                    MinionName VARCHAR(20)
                    CONSTRAINT PK_VilliansMinions PRIMARY KEY (VillianName, MinionName)
                    )

                    INSERT INTO Towns(TownID, TownName, CountryName)
                    VALUES 
                    (1, 'Sofia', 'Bulgaria'),
                    (2, 'Plovdiv', 'Bulgaria'),
                    (3, 'Berlin', 'Germany'),
                    (4, 'Paris', 'France'),
                    (5, 'Liverpool', 'England')


                    INSERT INTO Minions (Name, Age, TownID)
                    VALUES 
                    ('Kev', 11, 1),
                    ('Bobb', 12, 2),
                    ('Stew', 5, 3),
                    ('Malk', 3, 5),
                    ('Tosh', 1, 4)

                    INSERT INTO Villains (Name, EvilnessFactor)
                    VALUES
                    ('Gosho', 'bad'),
                    ('Tosho', 'good'),
                    ('Misho', 'evil'),
                    ('Gogo', 'super evil'),
                    ('Tiho', 'bad')

                    INSERT INTO VilliansMinions(VillianName, MinionName)
                    VALUES 
                    ('Kev', 'Kev'),
                    ('Bobb','Bobb'),
                    ('Stew','Stew'),
                    ('Malk','Malk'),
                    ('Tosh','Tosh')", connection);

               int result =  createDbCommand.ExecuteNonQuery();
               Console.WriteLine(result);
            }
        }
    }
}
