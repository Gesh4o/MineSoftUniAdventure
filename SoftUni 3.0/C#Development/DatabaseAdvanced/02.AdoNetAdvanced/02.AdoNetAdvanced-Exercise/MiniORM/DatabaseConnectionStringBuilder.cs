namespace MiniORM
{
    using System.Data.SqlClient;

    class DatabaseConnectionStringBuilder
    {
        private SqlConnectionStringBuilder connectionBuilder;

        private string connectionString;

        public DatabaseConnectionStringBuilder(string databaseName)
        {
            this.connectionBuilder = new SqlConnectionStringBuilder();
            this.connectionBuilder["Data source"] = "(local)";
            this.connectionBuilder["Integrated Security"] = true;
            this.connectionBuilder["Connect Timeot"] = 1000;
            this.connectionBuilder["Trusted Connection"] = true;
            this.connectionString = this.connectionBuilder.ToString();
        }

        public string ConnectionString => this.connectionString;
    }
}
