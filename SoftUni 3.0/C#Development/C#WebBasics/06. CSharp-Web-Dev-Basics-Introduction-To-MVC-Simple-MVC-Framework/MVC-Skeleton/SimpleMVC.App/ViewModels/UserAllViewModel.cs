namespace SimpleMVC.App.ViewModels
{
    using System.Collections.Generic;

    public class UserAllViewModel
    {
        public ICollection<UserSimpleViewModel> Users { get; set; }
    }
}
