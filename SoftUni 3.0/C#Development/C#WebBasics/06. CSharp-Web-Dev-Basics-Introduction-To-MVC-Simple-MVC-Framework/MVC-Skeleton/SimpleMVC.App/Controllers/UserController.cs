namespace SimpleMVC.App.Controllers
{
    using BindingModels;
    using Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using System.Linq;
    using ViewModels;

    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterBindingModel model)
        {
            using (NoteAppContext context = new NoteAppContext())
            {
                context.Users.Add(new User() { Username = model.Username, Password = $"SECRET{model.Password}" });
                context.SaveChanges();
            }

            return this.View("Home", "Index");
        }

        [HttpGet]
        public IActionResult<UserAllViewModel> All()
        {
            UserAllViewModel vm = null;
            using (NoteAppContext context = new NoteAppContext())
            {
                vm = new UserAllViewModel() { Users = context.Users.Select(u => new UserSimpleViewModel() { Id = u.Id, Username = u.Username }).ToList() };
            }

            return this.View(vm);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            UserProfileViewModel vm = null;

            using (NoteAppContext context = new NoteAppContext())
            {
                User user = context.Users.Include("Notes").SingleOrDefault(u => u.Id == id);
                vm = new UserProfileViewModel()
                {
                    UserId = id,
                    Username = user.Username,
                    Notes = user.Notes.Select(n => new NoteViewModel() { Title = n.Title, Content = n.Content }).ToArray(),
                };
            }

            return this.View(vm);
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(NoteAddBindingModel noteBindingModel)
        {
            UserProfileViewModel vm = null;

            using (NoteAppContext context = new NoteAppContext())
            {
                User user = context.Users.Include("Notes").SingleOrDefault(u => u.Id == noteBindingModel.UserId);
                user.Notes.Add(new Note() { Title = noteBindingModel.Title, Content = noteBindingModel.Content });

                context.SaveChanges();

                vm = new UserProfileViewModel()
                {
                    UserId = noteBindingModel.UserId,
                    Username = user.Username,
                    Notes = user.Notes.Select(n => new NoteViewModel() { Title = n.Title, Content = n.Content }).ToArray(),
                };
            }

            return this.View(vm);
        }
    }
}