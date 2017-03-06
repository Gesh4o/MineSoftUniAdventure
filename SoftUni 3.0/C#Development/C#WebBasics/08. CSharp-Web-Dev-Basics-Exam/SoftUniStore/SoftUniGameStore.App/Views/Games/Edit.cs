namespace SoftUniGameStore.App.Views.Games
{
    using SimpleMVC.Interfaces.Generic;

    using ViewModels.Games;

    using static Utilities.HtmlProvider;

    public class Edit : IRenderable<AdminGameUpdateViewModel>
    {
        public AdminGameUpdateViewModel Model { get; set; }

        public string Render()
        {
            string layout = ProvideLayout(this.Model.EmailViewModel.Email);
            string content = string.Format(
                ProvideGamesEditForm(),
                this.Model.GameUpdateViewModel.Id,
                this.Model.GameUpdateViewModel.Title,
                this.Model.GameUpdateViewModel.Description,
                this.Model.GameUpdateViewModel.ImageThumbnail,
                this.Model.GameUpdateViewModel.Price,
                this.Model.GameUpdateViewModel.Size,
                this.Model.GameUpdateViewModel.VideoUrl,
                this.Model.GameUpdateViewModel.ReleaseDate);

            return string.Format(layout, content);
        }
    }
}
