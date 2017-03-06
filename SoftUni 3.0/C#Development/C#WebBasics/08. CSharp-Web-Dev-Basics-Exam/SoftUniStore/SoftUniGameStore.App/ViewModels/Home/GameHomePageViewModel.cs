namespace SoftUniGameStore.App.ViewModels.Home
{
    using Games;

    public class GameHomePageViewModel : SimpleGameViewModel
    {
        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public string Thumbnail { get; set; }
    }
}
