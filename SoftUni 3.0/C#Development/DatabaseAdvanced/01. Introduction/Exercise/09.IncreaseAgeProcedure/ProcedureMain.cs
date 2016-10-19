namespace _09.IncreaseAgeProcedure
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class ProcedureMain
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; Database=MinionsDB; Integrated Security=true;");
            connection.Open();

            using (connection)
            {
                string[] names = Console.ReadLine().Split();
                foreach (string name in names)
                {
                    SqlCommand updateMinionByName = new SqlCommand("udp_GetOlder @name", connection);
                    updateMinionByName.Parameters.AddWithValue("@name", name);

                    updateMinionByName.ExecuteNonQuery();
                }

                SqlParameter[] parameters = names.Select((value, index) => new SqlParameter($"@name{index}", value)).ToArray();
                SqlCommand getMinions = new SqlCommand($"SELECT Name, Age FROM Minions WHERE Name IN ({string.Join(", ", names.Select((value, index) => $"@name{index}"))})", connection);
                getMinions.Parameters.AddRange(parameters);
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
