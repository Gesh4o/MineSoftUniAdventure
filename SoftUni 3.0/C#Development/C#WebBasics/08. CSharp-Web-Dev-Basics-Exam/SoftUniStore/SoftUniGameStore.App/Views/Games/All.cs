namespace SoftUniGameStore.App.Views.Games
{
    using System.Text;

    using SimpleMVC.Interfaces.Generic;

    using Utilities;

    using ViewModels;
    using ViewModels.Games;

    public class All : IRenderable<GamesAdminPanelViewModel>
    {
        public GamesAdminPanelViewModel Model { get; set; }

        public string Render()
        {
            string layout = HtmlProvider.ProvideLayout(this.Model.Email);
            StringBuilder view = new StringBuilder();
            int count = 1;
            foreach (SimpleGameViewModel game in this.Model.Games)
            {
                string cssClass = count % 2 == 1 ? "class=\"table-warning\"" : string.Empty;
                view.Append(
                    $"<tr {cssClass}>"
                    + $"<th scope=\"row\">{count}</th>"
                    + $"<td>{game.Title}</td>"
                    + $"<td>{game.Size} GB</td>"
                    + $"<td>{game.Price} &euro;</td>"
                    + "<td>"
                    + $"<a href=\"/games/edit?id={game.Id}\" class=\"btn btn-warning btn-sm\">Edit</a>"
                    + $"<a href=\"/games/delete?id={game.Id}\" class=\"btn btn-danger btn-sm\">Delete</a>"
                    + "</td>");

                count++;
            }

            string content = string.Format(HtmlProvider.ProvideGamesTable(), view);

            return string.Format(layout, content);
        }
    }
}
