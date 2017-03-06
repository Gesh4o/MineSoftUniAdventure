namespace SoftUniGameStore.App.Views.Games
{
    using SimpleMVC.Interfaces.Generic;

    using ViewModels.Games;

    using static Utilities.HtmlProvider;

    public class Delete : IRenderable<AdminGameUpdateViewModel>
    {
        public AdminGameUpdateViewModel Model { get; set; }

        public string Render()
        {
            string layout = ProvideLayout(this.Model.EmailViewModel.Email);
            string content = string.Format(
                ProvideGamesDeleteForm(),
                this.Model.GameUpdateViewModel.Id,
                this.Model.GameUpdateViewModel.Title);

            return string.Format(layout, content);
        }
    }
}
