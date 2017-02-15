namespace SimpleMVC.App.ViewModels
{
    using System.Collections.Generic;

    public class UserProfileViewModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public ICollection<NoteViewModel> Notes { get; set; }

    }
}
