namespace SoftUniGameStore.App.Views.User
{
    using SimpleMVC.Interfaces;

    using static Utilities.HtmlProvider;

    public class Register : IRenderable
    {
        public string Render()
        {
            string layout = ProvideLayout();
            string content = ProvideRegisterForm();

            return string.Format(layout, content);
        }
    }
}
