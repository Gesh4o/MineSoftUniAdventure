namespace MiniORM.Attribute
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    class EntityAttribute : Attribute
    {
        private string tableName;

        public EntityAttribute(string tableName)
        {
            this.tableName = tableName;
        }

        public string TableName => this.tableName;
    }
}
