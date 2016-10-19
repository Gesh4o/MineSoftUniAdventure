namespace _05.ChangeTownCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class TownCasingMain
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();
            SqlParameter countryNameParam = new SqlParameter("@countryName", countryName);
            SqlConnection connection = new SqlConnection("Server=.; " +
                            "Database=MinionsDB; " +
                            "Integrated Security=true");
            connection.Open();

            using (connection)
            {
                SqlCommand updateTowns = new SqlCommand(@"UPDATE Towns SET TownName = UPPER(TownName) WHERE CountryName = @countryName", connection);
                updateTowns.Parameters.Add(countryNameParam);

                int resultCount = updateTowns.ExecuteNonQuery();
                if (resultCount != 0)
                {
                    Console.WriteLine($"{resultCount} towns were affected.");
                    SqlParameter countryNamePara = new SqlParameter("@countryName", countryName);
                    SqlCommand getTowns = new SqlCommand("SELECT TownName FROM Towns WHERE CountryName = @countryName", connection);
                    getTowns.Parameters.Add(countryNamePara);
                    SqlDataReader townsReader = getTowns.ExecuteReader();
                    List<string> towns = new List<string>();
                    while (townsReader.Read())
                    {
                        towns.Add((string)townsReader["TownName"]);
                    }

                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }
                else
                {
                    Console.WriteLine("No towns were affected.");
                }
            }
        }
    }
}
