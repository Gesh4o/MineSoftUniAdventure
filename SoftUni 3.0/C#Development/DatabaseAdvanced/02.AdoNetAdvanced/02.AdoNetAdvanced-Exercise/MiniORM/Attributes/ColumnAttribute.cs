namespace MiniORM.Attribute
{
    using System;

    class ColumnAttribute : Attribute
    {
        private string name;

        public ColumnAttribute(string name)
        {
            this.name = name;
        }

        public string Name => this.name;
    }
}
