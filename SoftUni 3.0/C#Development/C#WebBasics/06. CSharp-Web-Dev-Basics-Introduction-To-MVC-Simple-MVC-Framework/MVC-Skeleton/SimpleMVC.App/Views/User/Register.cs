namespace SimpleMVC.App.Views.User
{
    using System;
    using MVC.Interfaces;

    public class Register : IRenderable
    {
        public string Render()
        {
            string view = @"<a  href=""/home/index"">&lt; Home</a>
                            <h1>Register</h1>
                            <form method=""POST"">
                            <label for= ""username""> Username: </label>
                            <input name = ""username"" type = ""text"" id = ""username"" />
                            <label for= ""password"" > Password: </label>
                            <input name = ""password"" type = ""password"" id = ""password"" />
                            <input type = ""submit"" value = ""Register"" />
                            </form>";

            return view;
        }
    }
}
