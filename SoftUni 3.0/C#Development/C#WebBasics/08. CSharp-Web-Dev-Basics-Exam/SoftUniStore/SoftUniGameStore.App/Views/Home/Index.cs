namespace SoftUniGameStore.App.Views.Home
{
    using System.Text;

    using SimpleMVC.Interfaces.Generic;

    using ViewModels.Home;

    using static Utilities.HtmlProvider;

    public class Index : IRenderable<HomepageViewModel>
    {
        public HomepageViewModel Model { get; set; }

        public string Render()
        {
            string layout = ProvideLayout(this.Model.Email);
            string content = ProvideHomePage();

            StringBuilder gameStringBuilder = new StringBuilder();
            int count = 0;
            foreach (GameHomePageViewModel game in this.Model.Games)
            {
                if (count % 3 == 0)
                {
                    gameStringBuilder.Append("<div class=\"card-group\">");
                }

                gameStringBuilder.Append(
                    string.Format(
                        ProvideGamesHomePagePartialView(),
                        game.VideoUrl,
                        game.Thumbnail,
                        game.Title,
                        game.Price,
                        game.Size,
                        game.Description.Substring(0, 160),
                        game.Id));

                if (count % 3 == 0)
                {
                    gameStringBuilder.Append("</div>");
                }

                count++;
            }

            content = string.Format(content, gameStringBuilder);

            return string.Format(layout, content);
        }
    }
}
