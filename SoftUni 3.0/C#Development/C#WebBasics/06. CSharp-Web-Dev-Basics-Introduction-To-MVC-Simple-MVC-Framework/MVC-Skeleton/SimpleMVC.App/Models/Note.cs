namespace SimpleMVC.App.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }
    }
}
