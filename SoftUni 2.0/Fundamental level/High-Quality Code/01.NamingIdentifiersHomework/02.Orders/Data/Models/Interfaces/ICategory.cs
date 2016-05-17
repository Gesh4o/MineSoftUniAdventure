namespace Orders.Models.Interfaces
{
    public interface ICategory
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}
