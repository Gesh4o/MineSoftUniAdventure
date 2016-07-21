namespace BookLibraryWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ApplicationUser Author { get; set; }
    }
}