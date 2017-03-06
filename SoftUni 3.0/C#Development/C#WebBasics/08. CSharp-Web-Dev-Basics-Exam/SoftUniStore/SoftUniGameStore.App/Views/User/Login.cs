namespace SoftUniGameStore.App.Views.User
{
    using SimpleMVC.Interfaces;

    using static Utilities.HtmlProvider;

    public class Login : IRenderable
    {
        public string Render()
        {
            string layout = ProvideLayout();
            string content = ProvideLoginForm();

            return string.Format(layout, content);
        }
    }
}
