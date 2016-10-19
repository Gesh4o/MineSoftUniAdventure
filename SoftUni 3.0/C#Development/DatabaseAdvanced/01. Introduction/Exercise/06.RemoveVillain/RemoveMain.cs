namespace _06.RemoveVillain
{
    using System;
    using System.Data.SqlClient;

    class RemoveMain
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; Database=MinionsDB; Integrated Security = true;");
            connection.Open();

            using (connection)
            {
                string villainName = Console.ReadLine();

                SqlCommand findVillain = new SqlCommand("SELECT COUNT(*) AS Count FROM Villains WHERE Name = @vilName", connection);
                SqlParameter villainNameParam = new SqlParameter("@vilName", villainName);
                findVillain.Parameters.Add(villainNameParam);
                SqlDataReader reader = findVillain.ExecuteReader();
                int count = 0;

                if (reader.Read())
                {
                    count = (int)reader["Count"];
                }

                reader.Close();

                if (count > 0)
                {
                    SqlCommand deleteMinionsByVillain = new SqlCommand("DELETE VilliansMinions WHERE VillianName = @vilName", connection);
                    SqlParameter villainNamePara = new SqlParameter("@vilName", villainName);
                    deleteMinionsByVillain.Parameters.Add(villainNamePara);

                    int minionsCount = deleteMinionsByVillain.ExecuteNonQuery();

                    SqlCommand deleteVillainByName = new SqlCommand("DELETE Villains WHERE Name = @vilName", connection);
                    SqlParameter villainNamePar = new SqlParameter("@vilName", villainName);
                    deleteVillainByName.Parameters.Add(villainNamePar);

                    int result = deleteVillainByName.ExecuteNonQuery();
                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{minionsCount} was released.");
                }
                else
                {
                    Console.WriteLine("No such villain was found.");
                }
            }
        }
    }
}