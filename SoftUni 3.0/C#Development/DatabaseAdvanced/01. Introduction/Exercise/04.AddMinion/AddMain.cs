namespace _04.AddMinion
{
    using System;
    using System.Data.SqlClient;

    class AddMain
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection("Server=.; " +
                                                    "Database=MinionsDB; " +
                                                    "Integrated Security=true");

            connection.Open();

            using (connection)
            {
                string[] args = Console.ReadLine().Split(' ');
                SqlParameter minionName = new SqlParameter("@minionName", args[0]);
                SqlParameter age = new SqlParameter("@age", int.Parse(args[1]));
                SqlParameter townId = new SqlParameter("@townId", int.Parse(args[2]));
                SqlParameter villianName = new SqlParameter("@villainName", args[3]);
             
                SqlCommand insertMinions = new SqlCommand("INSERT INTO Minions (Name, Age, TownID) VALUES (@minionName, @age, @townId) ", connection);
                insertMinions.Parameters.AddRange(new SqlParameter[] { minionName, age, townId});

                insertMinions.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {args[0]} to database!");

                SqlParameter minionNameAgain = new SqlParameter("@minionName", args[0]);
                SqlCommand insertMinionsVillain = new SqlCommand("INSERT INTO VilliansMinions (MinionName, VillianName) VALUES (@minionName, @villainName)", connection);
                insertMinionsVillain.Parameters.AddRange(new SqlParameter[] { minionNameAgain, villianName });

                insertMinionsVillain.ExecuteNonQuery();
                Console.WriteLine($"Successfully add minion {args[0]} to villain: {args[3]}");
            }
        }
    }
}
