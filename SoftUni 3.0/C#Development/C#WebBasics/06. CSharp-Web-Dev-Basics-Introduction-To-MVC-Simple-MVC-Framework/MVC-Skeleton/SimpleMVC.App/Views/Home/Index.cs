namespace SimpleMVC.App.Views.Home
{
    using MVC.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h1>NotesApp</h1><a  href=\"/user/all\">All Users </a> <a  href=\"/user/register\">Register User</a>";
        }
    }
}