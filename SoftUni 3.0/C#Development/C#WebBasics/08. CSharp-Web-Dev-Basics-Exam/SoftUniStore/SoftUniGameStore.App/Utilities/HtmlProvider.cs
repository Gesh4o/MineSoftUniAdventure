namespace SoftUniGameStore.App.Utilities
{
    using System.IO;

    public class HtmlProvider
    {
        private static readonly string Layout = File.ReadAllText($"{Constants.WorkDirectory}Views/Shared/layout.html");

        private static readonly string NavbarLoggedIn = File.ReadAllText($"{Constants.WorkDirectory}Views/Shared/nav-logged.html");

        private static readonly string NavbarNotLoggedIn = File.ReadAllText($"{Constants.WorkDirectory}Views/Shared/nav-not-logged.html");

        private static readonly string LoginForm = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/User/login.html");

        private static readonly string RegisterForm = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/User/register.html");

        private static readonly string CreateGameForm = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Game/game-add.html");

        private static readonly string ListGamesTable = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Game/games-all.html");

        private static readonly string EditGameForm = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Game/game-edit.html");

        private static readonly string DeleteGameForm = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Game/game-delete.html");

        private static readonly string DetailsGame = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Game/game-details.html");

        private static readonly string HomePage = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Home/home.html");

        private static readonly string GameHomePagePartialView = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Home/game-home-page-partial.html");

        private static readonly string Cart = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Home/cart.html");

        private static readonly string GameCartPartialView = File.ReadAllText($"{Constants.WorkDirectory}Views/Html/Home/game-cart-partial.html");


        public static string ProvideLayout(string email = "")
        {
            if (string.IsNullOrEmpty(email))
            {
                return string.Format(Layout, NavbarNotLoggedIn, "{0}");
            }

            return string.Format(Layout, string.Format(NavbarLoggedIn, email), "{0}");
        }

        public static string ProvideLoginForm()
        {
            return LoginForm;
        }

        public static string ProvideRegisterForm()
        {
            return RegisterForm;
        }

        public static string ProvideAddGameForm()
        {
            return CreateGameForm;
        }

        public static string ProvideGamesTable()
        {
            return ListGamesTable;
        }

        public static string ProvideGamesEditForm()
        {
            return EditGameForm;
        }

        public static string ProvideGamesDeleteForm()
        {
            return DeleteGameForm;
        }

        public static string ProvideHomePage()
        {
            return HomePage;
        }

        public static string ProvideGamesHomePagePartialView()
        {
            return GameHomePagePartialView;
        }

        public static string ProvideGamesDetails()
        {
            return DetailsGame;
        }

        public static string ProvideCart()
        {
            return Cart;
        }

        public static string ProvideCartGamePartial()
        {
            return GameCartPartialView;
        }
    }
}
