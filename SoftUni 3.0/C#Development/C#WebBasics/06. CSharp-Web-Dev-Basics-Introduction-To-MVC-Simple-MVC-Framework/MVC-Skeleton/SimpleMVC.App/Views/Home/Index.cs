namespace SimpleMVC.App.Views.Home
{
    using System;
    using MVC.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h1>Hello, it's me!</h1>";
        }
    }
}
