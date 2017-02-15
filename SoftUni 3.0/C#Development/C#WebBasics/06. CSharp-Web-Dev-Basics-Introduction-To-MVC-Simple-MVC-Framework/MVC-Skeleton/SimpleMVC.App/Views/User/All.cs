namespace SimpleMVC.App.Views.User
{
    using ViewModels;
    using MVC.Interfaces.Generic;
    using System.Text;

    public class All : IRenderable<UserAllViewModel>
    {
        public UserAllViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder view = new StringBuilder();
            view.AppendLine("<a  href=\"/home/index\">&lt; Home</a>");
            view.AppendLine("<ul>");
            foreach (UserSimpleViewModel user in Model.Users)
            {
                view.AppendLine($"<li><a href=\"/user/profile?id={user.Id}\">{user.Username}</li>");
            }
            view.AppendLine("</ul>");

            return view.ToString();
        }
    }
}
