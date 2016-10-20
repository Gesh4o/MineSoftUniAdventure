namespace MiniORM
{
    using System.Data.SqlClient;

    public class DatabaseConnectionStringBuilder
    {
        private SqlConnectionStringBuilder connectionBuilder;

        private string connectionString;

        public DatabaseConnectionStringBuilder(string databaseName)
        {
            this.connectionBuilder = new SqlConnectionStringBuilder();
            this.connectionBuilder["Data source"] = "(local)";
            this.connectionBuilder["Integrated Security"] = true;
            this.connectionBuilder["Connect Timeout"] = 100;
            this.connectionBuilder["Trusted_Connection"] = true;
            this.connectionBuilder["Initial Catalog"] = databaseName;
            this.connectionString = this.connectionBuilder.ToString();
        }

        public string ConnectionString => this.connectionString;
    }
}
