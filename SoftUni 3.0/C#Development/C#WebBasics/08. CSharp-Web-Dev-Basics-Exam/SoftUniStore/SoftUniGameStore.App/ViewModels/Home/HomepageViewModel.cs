namespace SoftUniGameStore.App.ViewModels.Home
{
    using System.Collections.Generic;

    public class HomepageViewModel
    {
        public string Email { get; set; }

        public IEnumerable<GameHomePageViewModel> Games { get; set; }
    }
}
