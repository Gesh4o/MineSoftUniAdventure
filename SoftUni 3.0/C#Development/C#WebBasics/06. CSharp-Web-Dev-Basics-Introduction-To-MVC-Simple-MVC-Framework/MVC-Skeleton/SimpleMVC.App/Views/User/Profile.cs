namespace SimpleMVC.App.Views.User
{
    using System.Text;

    using MVC.Interfaces.Generic;
    using ViewModels;

    public class Profile : IRenderable<UserProfileViewModel>
    {
        public UserProfileViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder view = new StringBuilder();
            view.AppendLine("<a  href=\"/home/index\">&lt; Home</a>");
            view.AppendLine($"<h2>User: {Model.Username}</h2>");

            view.AppendLine("<form method=\"POST\">");
            view.AppendLine($"<input type=\"hidden\" name=\"userId\" value=\"{Model.UserId}\"/>");
            view.AppendLine("<label for=\"title\">Title: </label>");
            view.AppendLine("<input type=\"text\" name=\"title\" id=\"title\" />");
            view.AppendLine("<label for=\"content\">Content: </label>");
            view.AppendLine("<input type=\"text\" name=\"content\" id=\"content\" />");
            view.AppendLine("<input type=\"submit\" value=\"Submit Note\" />");
            view.AppendLine("</form>");
            view.AppendLine("</br>");

            view.AppendLine("<h5>List of notes: </h5>");
            view.AppendLine("<ul>");
            foreach (NoteViewModel note in Model.Notes)
            {
                view.AppendLine($"<li><strong>{note.Title}</strong> - {note.Content}</li>");
            }
            view.AppendLine("</ul>");


            return view.ToString();
        }
    }
}
