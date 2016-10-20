
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

    class EntityManager : IDbContext
    {
        private string connectionString;

        private SqlConnection sqlConnection;

        private bool isCodeFirst;

        public EntityManager(string connectionString, bool isCodeFirst)
        {
            this.connectionString = connectionString;
            this.isCodeFirst = isCodeFirst;
        }

        public IEnumerable<T> FindAll<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>(string condition)
        {
            throw new NotImplementedException();
        }

        public T FindById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public T FindFirst<T>()
        {
            throw new NotImplementedException();
        }

        public T FindFirst<T>(string condition)
        {
            throw new NotImplementedException();
        }

        public bool Persist<T>(object entity)
        {
            throw new NotImplementedException();
        }

        private void CreateTable(Type entity)
        {
            string createTableQuery = GetSqlQuery(entity);

            using (this.sqlConnection = new SqlConnection(this.connectionString))
            {
                sqlConnection.Open();
                SqlCommand createTable = new SqlCommand(createTableQuery);
                createTable.ExecuteNonQuery();
            }
        }

        private string GetSqlQuery(Type entity)
        {
            StringBuilder createTableQuery = new StringBuilder();
            createTableQuery
                .AppendLine($"CREATE TABLE {GetTableName(entity)} (")
                .AppendLine($"Id INT IDENTITY PRIMARY KEY, ");

            FieldInfo[] columnNames = entity
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsDefined(typeof(ColumnAttribute)))
                .ToArray();

            foreach (FieldInfo column in columnNames)
            {
                createTableQuery
                    .AppendLine($"{GetFieldName(column)} {GetSqlType(column.FieldType)}, ");
            }

            createTableQuery.Remove(createTableQuery.Length - 2, 2)
                .AppendLine(")");

            return createTableQuery.ToString();
        }

        private string GetSqlType(Type type)
        {
            switch (type.Name)
            {
                case "Int32":
                    return "INT";
                case "String":
                    return "VARCHAR(MAX)";
                case "Character":
                    return "CHAR";
                case "DateTime":
                    return "DATETIME";
                default:
                    throw new ArgumentException($"Invalid type to conver to: {type.Name} !");
            }
        }

        /// <summary>
        /// Gets the Id property of Id attribute.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private FieldInfo GetId(Type entity)
        {
            ValidateForNull(entity, entity.Name);

            FieldInfo fieldId = entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsDefined(typeof(IdAttribute)));

            ValidateForNull(fieldId, fieldId.Name);

            return fieldId;
        }

        /// <summary>
        /// Gets table Name property of Entity attribute.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string GetTableName(Type entity)
        {
            ValidateForNull(entity, entity.Name);

            if (!entity.IsDefined(typeof(EntityAttribute)))
            {
                throw new ArgumentException("Cannot get table!");
            }

            string tableName = entity.GetCustomAttribute<EntityAttribute>().TableName;

            ValidateForNull(tableName, "tableName");

            return tableName;
        }

        /// <summary>
        /// Gets the value of the Name property of Column attribute.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private string GetFieldName(FieldInfo field)
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
    }
}
