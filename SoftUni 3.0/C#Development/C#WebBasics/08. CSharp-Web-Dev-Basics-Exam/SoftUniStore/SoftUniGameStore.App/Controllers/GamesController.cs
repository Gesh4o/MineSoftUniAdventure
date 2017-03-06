namespace SoftUniGameStore.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using BindingModels.Game;

    using Data;

    using Services;

    using SimpleHttpServer.Models;

    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;

    using SoftUniGameStore.Models;

    using ViewModels.Games;
    using ViewModels.Users;

    public class GamesController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        private readonly GameService gameService;

        private readonly SecurityService securityService;

        public GamesController()
        {
            this.unitOfWork = new UnitOfWork();
            this.gameService = new GameService(this.unitOfWork, this.unitOfWork.GameRepository);
            this.securityService = new SecurityService(this.unitOfWork, this.unitOfWork.LoginRepository, this.unitOfWork.UserRepository);
        }

        [HttpGet]
        public IActionResult<GamesAdminPanelViewModel> All(HttpSession session, HttpResponse response)
        {
            if (!this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            if (!this.securityService.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            string email = this.securityService.GetCurrentlyLoggedUser(session).Email;
            IEnumerable<SimpleGameViewModel> games = this.gameService
                .GetAll()
                .Select(g => new SimpleGameViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Price = g.Price,
                    Size = g.Size
                });

            return this.View(new GamesAdminPanelViewModel { Email = email, Games = games });
        }

        [HttpGet]
        public IActionResult<EmailViewModel> Add(HttpSession session, HttpResponse response)
        {
            if (!this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            if (!this.securityService.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            string email = this.securityService.GetCurrentlyLoggedUser(session).Email;

            return this.View(new EmailViewModel() { Email = email });
        }

        [HttpPost]
        public void Add(HttpSession session, HttpResponse response, GameAdditionBindingModel gameBindingModel)
        {
            if (!this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/user/login");
                return;
            }

            if (!this.securityService.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return;
            }

            if (!gameBindingModel.IsValid())
            {
                this.Redirect(response, "/games/add");
                return;
            }

            this.gameService.Insert(gameBindingModel);

            this.Redirect(response, "/games/all");
        }

        [HttpGet]
        public IActionResult<AdminGameUpdateViewModel> Edit(HttpSession session, HttpResponse response, int id)
        {
            if (!this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            if (!this.securityService.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            Game game = this.gameService.Find(id);
            GameUpdateViewModel model = new GameUpdateViewModel
            {
                Id = game.Id,
                Title = game.Title,
                ImageThumbnail = game.ImageThumbnail,
                Price = game.Price,
                ReleaseDate =
                                                    game.ReleaseDate.ToString("yyyy-MM-dd"),
                Size = game.Size,
                Description = game.Description,
                VideoUrl = game.VideoUrl
            };
            return
                       this.View(
                           new AdminGameUpdateViewModel
                           {
                               GameUpdateViewModel = model,
                               EmailViewModel =
                                       new EmailViewModel
                                       {
                                           Email =
                                                   this.securityService
                                                       .GetCurrentlyLoggedUser(session)
                                                       .Email
                                       }
                           });
        }

        [HttpPost]
        public void Edit(HttpSession session, HttpResponse response, GameUpdateBindingModel game)
        {
            if (!this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/user/login");
                return;
            }

            if (!this.securityService.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return;
            }

            if (!game.IsValid())
            {
                this.Redirect(response, $"/games/edit?id={game.Id}");
                return;
            }

            this.gameService.Update(game);
            this.Redirect(response, "/games/all");
        }

        [HttpGet]
        public IActionResult<AdminGameUpdateViewModel> Delete(HttpSession session, HttpResponse response, int id)
        {
            if (!this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            if (!this.securityService.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            Game game = this.gameService.Find(id);
            GameUpdateViewModel model = new GameUpdateViewModel
            {
                Id = game.Id,
                Title = game.Title,
                ImageThumbnail = game.ImageThumbnail,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate.ToString("yyyy-MM-dd"),
                Size = game.Size,
                Description = game.Description,
                VideoUrl = game.VideoUrl
            };

            return
                this.View(
                    new AdminGameUpdateViewModel
                    {
                        GameUpdateViewModel = model,
                        EmailViewModel =
                                new EmailViewModel
                                {
                                    Email =
                                            this.securityService
                                                .GetCurrentlyLoggedUser(session)
                                                .Email
                                }
                    });
        }

        [HttpPost]
        public void Delete(HttpSession session, HttpResponse response, GameDeleteBindingModel game)
        {
            if (!this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/user/login");
                return;
            }

            if (!this.securityService.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return;
            }

            this.gameService.Delete(game.Id);
            this.Redirect(response, "/games/all");
        }

        public IActionResult<GameDetailsViewModel> Details(HttpSession session, int id)
        {
            Game game = this.gameService.Find(id);
            GameDetailsViewModel model = new GameDetailsViewModel();
            if (game != null)
            {
                model.Id = game.Id;
                model.Title = game.Title;
                model.Price = game.Price;
                model.ReleaseDate = game.ReleaseDate.ToString("dd/MM/yyyy");
                model.Size = game.Size;
                model.Description = game.Description;
                model.VideoUrl = game.VideoUrl;
            }

            if (this.securityService.IsAuthenticated(session))
            {
                model.Email = this.securityService.GetCurrentlyLoggedUser(session).Email;
                model.IsAdmin = this.securityService.IsAdmin(session);
            }

            return this.View(model);
        }
    }
}
