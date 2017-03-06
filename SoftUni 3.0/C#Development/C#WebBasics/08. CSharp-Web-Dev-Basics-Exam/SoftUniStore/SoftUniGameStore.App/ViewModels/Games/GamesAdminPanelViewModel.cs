namespace SoftUniGameStore.App.ViewModels.Games
{
    using System.Collections.Generic;

    using Users;

    public class GamesAdminPanelViewModel : EmailViewModel
    {
        public IEnumerable<SimpleGameViewModel> Games { get; set; }
    }
}
