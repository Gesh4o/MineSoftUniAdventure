
namespace MiniORM.Core
{
    using System;
    using System.Collections.Generic;
    using MiniORM.Interfaces;
    using System.Data.SqlClient;
    using System.Reflection;
    using Attribute;
    using System.Linq;
    using System.Text;

    public class EntityManager : IDbContext
    {
        private string connectionString;

        private SqlConnection sqlConnection;

        private bool isCodeFirst;

        private EntityWorker entityWorker;

        public EntityManager(string connectionString, bool isCodeFirst)
        {
            this.connectionString = connectionString;
            this.isCodeFirst = isCodeFirst;
            this.entityWorker = new EntityWorker(connectionString, isCodeFirst);
        }

        public IEnumerable<T> FindAll<T>()
        {
            return FindAll<T>(string.Empty);
        }

        public IEnumerable<T> FindAll<T>(string condition)
        {
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1 = 1";
            }

            string query = $"SELECT * FROM {GetTableName(typeof(T))} WHERE " + condition;

            using (this.sqlConnection = new SqlConnection(this.connectionString))
            {
                this.sqlConnection.Open();
                SqlCommand findByCondition = new SqlCommand(query, this.sqlConnection);
                SqlDataReader reader = findByCondition.ExecuteReader();

                if (!reader.HasRows)
                {
                    return new List<T>();
                }

                IEnumerable<T> entities = CreateEntities<T>(reader);
                return entities;
            }
        }

        public T FindById<T>(int id)
        {
            T entity = default(T);

            using (this.sqlConnection = new SqlConnection(this.connectionString))
            {
                this.sqlConnection.Open();
                SqlCommand findById = new SqlCommand(
                    $"SELECT * FROM {GetTableName(typeof(T))} WHERE Id = {id}",
                    this.sqlConnection);

                SqlDataReader reader = findById.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new InvalidOperationException($"Entity with id: {id} was not found.");
                }

                reader.Read();

                entity = CreateEntity<T>(reader);
            }

            return entity;
        }

        public T FindFirst<T>()
        {
            return FindFirst<T>(string.Empty);
        }

        public T FindFirst<T>(string condition)
        {
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1 = 1";
            }

            T entity = default(T);
            string query = $"SELECT * FROM {GetTableName(typeof(T))} WHERE @condition";

            using (this.sqlConnection = new SqlConnection(this.connectionString))
            {
                SqlCommand findByCondition = new SqlCommand(query, this.sqlConnection);
                findByCondition.Parameters.AddWithValue("@condition", condition);
                SqlDataReader reader = findByCondition.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    entity = CreateEntity<T>(reader);
                }
            }

            return entity;
        }

        public bool Persist<T>(object entity)
        {
            if (entity == null)
            {
                return false;
            }

            if (this.isCodeFirst && !IsTableExisting(entity.GetType()))
            {
                this.entityWorker.CreateTable(entity.GetType());
            }

            FieldInfo idFieldInfo = GetId(entity.GetType());
            object value = idFieldInfo.GetValue(entity);

            if (value == null || (int)value <= 0)
            {
                return this.entityWorker.Insert(entity);
            }

            return this.entityWorker.Update(entity, idFieldInfo);
        }

        /// <summary>
        /// Gets the Id property of Id attribute.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static FieldInfo GetId(Type type)
        {
            ValidateForNull(type, type.Name);

            FieldInfo fieldId = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsDefined(typeof(IdAttribute)));

            ValidateForNull(fieldId, fieldId.Name);

            return fieldId;
        }

        /// <summary>
        /// Gets table Name property of Entity attribute.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetTableName(Type type)
        {
            ValidateForNull(type, type.Name);

            if (!type.IsDefined(typeof(EntityAttribute)))
            {
                throw new ArgumentException("Cannot get table!");
            }

            string tableName = type.GetCustomAttribute<EntityAttribute>().TableName;

            ValidateForNull(tableName, "tableName");

            return tableName;
        }

        /// <summary>
        /// Gets the value of the Name property of Column attribute.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private static string GetFieldName(FieldInfo field)
        {
            ValidateForNull(field, field.Name);

            if (!field.IsDefined(typeof(ColumnAttribute)))
            {
                return field.Name;
            }

            string columnName = field.GetCustomAttribute<ColumnAttribute>().Name;

            return columnName;
        }

        private static void ValidateForNull(object obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        private IEnumerable<T> CreateEntities<T>(SqlDataReader reader)
        {
            List<T> entities = new List<T>();

            while (reader.Read())
            {
                T entity = CreateEntity<T>(reader);
                entities.Add(entity);
            }

            return entities;
        }

        private T CreateEntity<T>(SqlDataReader reader)
        {
            object[] paramaters = new object[reader.FieldCount];
            reader.GetValues(paramaters);

            object[] values = new object[reader.FieldCount - 1];
            Array.Copy(paramaters, 1, values, 0, paramaters.Length - 1);
            Type[] types = new Type[values.Length];
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = values[i].GetType();
            }

            // Instantiate new entity.
            T entity = (T)typeof(T).GetConstructor(types).Invoke(values);

            // Set it's Id.
            typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.IsDefined(typeof(IdAttribute))).SetValue(entity, paramaters[0]);

            return entity;
        }

        private bool IsTableExisting(Type type)
        {
            string query = $"SELECT COUNT(*) FROM sys.sysobjects  WHERE Name = N'{GetTableName(type)}' AND xtype = N'U'";

            using (this.sqlConnection = new SqlConnection(this.connectionString))
            {
                this.sqlConnection.Open();

                SqlCommand checkTable = new SqlCommand(query, this.sqlConnection);

                int tableCount = (int)checkTable.ExecuteScalar();

                bool isExisting = tableCount > 0;

                return isExisting;
            }
        }

        private class EntityWorker
        {
            private string connectionString;

            private bool isCodeFirst;

            private SqlConnection sqlConnection;

            public EntityWorker(string connectionString, bool isCodeFirst)
            {
                this.connectionString = connectionString;
                this.isCodeFirst = isCodeFirst;
            }

            public bool Update(object entity, FieldInfo idFieldInfo)
            {
                if (entity == null)
                {
                    return false;
                }

                int rowsAffected = 0;
                using (this.sqlConnection = new SqlConnection(this.connectionString))
                {
                    this.sqlConnection.Open();
                    string updateQuery = GetUpdateQueryWithParams(entity, idFieldInfo);
                    SqlCommand updateEntity = new SqlCommand(updateQuery, this.sqlConnection);
                    AppendParameters(entity, updateEntity.Parameters);

                    rowsAffected = updateEntity.ExecuteNonQuery();
                }

                return rowsAffected > 0;
            }

            private string GetUpdateQuery(object entity, FieldInfo idFieldInfo)
            {
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"UPDATE {GetTableName(entity.GetType())} SET ");

                FieldInfo[] fields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.IsDefined(typeof(ColumnAttribute)))
                    .ToArray();

                foreach (FieldInfo field in fields)
                {
                    updateQuery.Append($"{field.Name} = '{field.GetValue(entity)}', ");
                }

                updateQuery
                    .Remove(updateQuery.Length - 2, 2)
                    .Append($" WHERE Id = {idFieldInfo.GetValue(entity)}");


                return updateQuery.ToString();
            }

            private string GetUpdateQueryWithParams(object entity, FieldInfo idFieldInfo)
            {
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"UPDATE {GetTableName(entity.GetType())} SET ");

                FieldInfo[] fields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.IsDefined(typeof(ColumnAttribute)))
                    .ToArray();

                foreach (FieldInfo field in fields)
                {
                    updateQuery.Append($"{field.Name} = @{field.Name}, ");
                }

                updateQuery
                    .Remove(updateQuery.Length - 2, 2)
                    .Append($" WHERE Id = {idFieldInfo.GetValue(entity)}");


                return updateQuery.ToString();
            }

            public bool Insert(object entity)
            {
                if (entity == null)
                {
                    return false;
                }

                int rowsAffected = 0;
                using (this.sqlConnection = new SqlConnection(this.connectionString))
                {
                    this.sqlConnection.Open();
                    string insertQuery = GetInsertQueryWithParams(entity);
                    SqlCommand insertEntity = new SqlCommand(insertQuery, this.sqlConnection);
                    AppendParameters(entity, insertEntity.Parameters);

                    rowsAffected = insertEntity.ExecuteNonQuery();

                    SqlCommand findId = new SqlCommand($"SELECT Max(Id) FROM {GetTableName(entity.GetType())}", this.sqlConnection);
                    int id = (int)findId.ExecuteScalar();

                    FieldInfo idFieldInfo = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.IsDefined(typeof(IdAttribute)));
                    idFieldInfo.SetValue(entity, id);
                }

                return rowsAffected > 0;
            }

            private string GetInsertQuery(object entity)
            {
                StringBuilder insertQuery = new StringBuilder();
                StringBuilder columnNames = new StringBuilder();
                StringBuilder columnValues = new StringBuilder();

                FieldInfo[] fields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.IsDefined(typeof(ColumnAttribute)))
                    .ToArray();

                foreach (FieldInfo field in fields)
                {
                    columnNames.Append($"{field.Name}, ");
                    columnValues.Append($"'{field.GetValue(entity)}', ");
                }

                columnNames.Remove(columnNames.Length - 2, 2);
                columnValues.Remove(columnValues.Length - 2, 2);

                insertQuery.AppendLine(
                    $"INSERT INTO {GetTableName(entity.GetType())} ({columnNames}) VALUES ({columnValues})");

                return insertQuery.ToString().Trim();
            }

            private string GetInsertQueryWithParams(object entity)
            {
                StringBuilder insertQuery = new StringBuilder();
                StringBuilder columnNames = new StringBuilder();
                StringBuilder columnValues = new StringBuilder();

                FieldInfo[] fields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.IsDefined(typeof(ColumnAttribute)))
                    .ToArray();

                foreach (FieldInfo field in fields)
                {
                    string fieldName = field.Name;
                    columnNames.Append($"{fieldName}, ");
                    columnValues.Append($"@{fieldName}, ");
                }

                columnNames.Remove(columnNames.Length - 2, 2);
                columnValues.Remove(columnValues.Length - 2, 2);

                insertQuery.AppendLine(
                    $"INSERT INTO {GetTableName(entity.GetType())} ({columnNames}) VALUES ({columnValues})");

                return insertQuery.ToString().Trim();
            }

            private void AppendParameters(object entity, SqlParameterCollection parameters)
            {
                FieldInfo[] fields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.IsDefined(typeof(ColumnAttribute)))
                    .ToArray();

                foreach (FieldInfo field in fields)
                {
                    parameters.AddWithValue($"@{field.Name}", field.GetValue(entity) ?? DBNull.Value);
                }
            }

            public void CreateTable(Type type)
            {
                string createTableQuery = GetCreateTableQuery(type);

                using (this.sqlConnection = new SqlConnection(this.connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand createTable = new SqlCommand(createTableQuery, this.sqlConnection);
                    createTable.ExecuteNonQuery();
                }
            }

            private string GetCreateTableQuery(Type type)
            {
                StringBuilder createTableQuery = new StringBuilder();
                createTableQuery
                    .AppendLine($"CREATE TABLE {GetTableName(type)} (")
                    .AppendLine($"Id INT IDENTITY PRIMARY KEY, ");

                FieldInfo[] columnNames = type
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.IsDefined(typeof(ColumnAttribute)))
                    .ToArray();

                foreach (FieldInfo column in columnNames)
                {
                    createTableQuery
                        .AppendLine($"{GetFieldName(column)} {GetSqlType(column.FieldType)}, ");
                }

                createTableQuery.Remove(createTableQuery.Length - 2, 2);
                createTableQuery.AppendLine(")");

                return createTableQuery.ToString();
            }

            private string GetSqlType(Type type)
            {
                switch (type.Name)
                {
                    case "Int32":
                        return "INT";
                    case "Double":
                        return "DECIMAL(10,2)";
                    case "String":
                        return "VARCHAR(MAX)";
                    case "Character":
                        return "CHAR";
                    case "DateTime":
                        return "DATETIME";
                    case "Boolean":
                        return "BIT";
                    default:
                        throw new ArgumentException($"Invalid type to convert to: {type.Name} !");
                }
            }
        }
    }
}
