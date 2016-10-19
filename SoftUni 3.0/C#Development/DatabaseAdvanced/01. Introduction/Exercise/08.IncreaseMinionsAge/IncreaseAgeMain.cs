namespace _08.IncreaseMinionsAge
{
    using System;
    using System.Data.SqlClient;
    using System.Globalization;

    class IncreaseAgeMain
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; Database=MinionsDB; Integrated Security=true;");
            connection.Open();

            using (connection)
            {
                TextInfo textInfo = new CultureInfo("en-US").TextInfo;

                string[] minionNames = Console.ReadLine().Split();
                for (int i = 0; i < minionNames.Length; i++)
                {
                    SqlParameter minionName = new SqlParameter($"@minionName", minionNames[i]);
                    SqlParameter titleCasedMinionName = new SqlParameter($"@titleCasedName", textInfo.ToTitleCase(minionNames[i]));
                    SqlCommand updateMinions = new SqlCommand(
                    $"UPDATE Minions SET Age += 1, Name = @titleCasedName WHERE Minions.Name = @minionName",
                    connection);

                    updateMinions.Parameters.Add(minionName);
                    updateMinions.Parameters.Add(titleCasedMinionName);

                    updateMinions.ExecuteNonQuery();
                }

                SqlCommand getMinions = new SqlCommand(@"SELECT Name, Age FROM Minions", connection);
                SqlDataReader minionsReader = getMinions.ExecuteReader();

                while (minionsReader.Read())
                {
                    string name = (string)minionsReader["Name"];
                    int age = (int)minionsReader["Age"];
                    Console.WriteLine($"{name} {age}");
                }
            }
        }
    }
}
