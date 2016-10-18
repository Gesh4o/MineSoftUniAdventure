namespace _03.GetMinionsNames
{
    using System;
    using System.Data.SqlClient;

    class MinionsNamesMain
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; " +
                "Database=MinionsDB; " +
                "Integrated Security=true");

            connection.Open();
            using (connection)
            {
                SqlCommand getVillainsNames = new SqlCommand(@"SELECT Name FROM Villains AS v WHERE Name = 'Gogo' ", connection);
                SqlDataReader villainsNames = getVillainsNames.ExecuteReader();

                string villainName = "";
                using (villainsNames)
                {
                    if (villainsNames.Read())
                    {
                        villainName = (string)villainsNames["Name"];
                    }
                }

                Console.WriteLine(villainName);

                SqlCommand getMinionsByVillainMaster = new SqlCommand(@"USE MinionsDB
                        SELECT MinionName FROM VilliansMinions WHERE VillianName = @VillainName",
                connection);

                SqlParameter villainNameParam = new SqlParameter("@VillainName", villainName);
                getMinionsByVillainMaster.Parameters.Add(villainNameParam);

                SqlDataReader minionsNamesReader = getMinionsByVillainMaster.ExecuteReader();

                using (minionsNamesReader)
                {
                    int counter = 1;
                    while (minionsNamesReader.Read())
                    {
                        string minionName = (string)minionsNamesReader["MinionName"];
                        Console.WriteLine($"{counter}. {minionName}");
                        counter++;
                    }
                }
            }
        }
    }
}
