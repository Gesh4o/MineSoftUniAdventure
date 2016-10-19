namespace _07.PrintAllMinionsNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class PrintMain
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; Database=MinionsDB; Integrated Security=true");

            connection.Open();
            List<string> minions = new List<string>();
            using (connection)
            {
                SqlCommand minionsNames = new SqlCommand("SELECT Name FROM Minions", connection);
                SqlDataReader minionsReader = minionsNames.ExecuteReader();

                while (minionsReader.Read())
                {
                    minions.Add((string)minionsReader["Name"]);
                }
            }

            for (int i = 0; i <= minions.Count / 2; i++)
            {
                Console.WriteLine(minions[i]);

                if (i != minions.Count - i - 1)
                {
                    Console.WriteLine(minions[minions.Count - 1 - i]);
                }
            }
        }
    }
}
