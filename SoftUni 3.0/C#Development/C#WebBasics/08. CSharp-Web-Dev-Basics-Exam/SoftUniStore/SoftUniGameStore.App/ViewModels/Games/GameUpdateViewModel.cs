namespace SoftUniGameStore.App.ViewModels.Games
{
    public class GameUpdateViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageThumbnail { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public string ReleaseDate { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }
    }
}
