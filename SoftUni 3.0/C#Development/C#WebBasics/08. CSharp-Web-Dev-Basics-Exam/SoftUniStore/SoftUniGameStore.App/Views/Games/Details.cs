namespace SoftUniGameStore.App.Views.Games
{
    using SimpleMVC.Interfaces.Generic;

    using ViewModels.Games;

    using static Utilities.HtmlProvider;

    public class Details : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

        public string Render()
        {
            string layout = ProvideLayout(this.Model.Email);
            string content = 
                string.Format(
                ProvideGamesDetails(),
                this.Model.VideoUrl,
                this.Model.Title,
                this.Model.Description,
                this.Model.Price,
                this.Model.Size,
                this.Model.ReleaseDate,
                this.Model.Id);

            return string.Format(layout, content);
        }
    }
}
