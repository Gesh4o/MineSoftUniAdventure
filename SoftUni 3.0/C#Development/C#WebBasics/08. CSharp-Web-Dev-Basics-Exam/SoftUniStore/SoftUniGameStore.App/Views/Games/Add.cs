namespace SoftUniGameStore.App.Views.Games
{
    using SimpleMVC.Interfaces.Generic;

    using Utilities;

    using ViewModels.Users;

    public class Add : IRenderable<EmailViewModel>
    {
        public EmailViewModel Model { get; set; }

        public string Render()
        {
            string layout = HtmlProvider.ProvideLayout(this.Model.Email);
            string content = HtmlProvider.ProvideAddGameForm();

            return string.Format(layout, content);
        }
    }
}
