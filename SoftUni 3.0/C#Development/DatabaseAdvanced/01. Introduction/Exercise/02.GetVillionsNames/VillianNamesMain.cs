namespace _02.GetVillionsNames
{
    using System;
    using System.Data.SqlClient;

    class VillianNamesMain
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; " +
                "Integrated Security=true");

            connection.Open();
            using (connection)
            {
                SqlCommand getVillainsNames = new SqlCommand(
                @" USE MinionsDB
                   SELECT Name, COUNT(*) AS MinionsCount FROM Villains AS v LEFT JOIN VilliansMinions AS vm ON vm.VillianName = v.Name
	                   GROUP BY Name", 
                connection);

                SqlDataReader reader = getVillainsNames.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        int minionsCount = (int)reader["MinionsCount"];
                        Console.WriteLine($"{name} - {minionsCount}");
                    }
                }
            }
        }
    }
}