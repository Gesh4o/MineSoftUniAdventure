namespace Orders.Models
{
    using Interfaces;

    public class Category : ICategory
    {
        public Category(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
