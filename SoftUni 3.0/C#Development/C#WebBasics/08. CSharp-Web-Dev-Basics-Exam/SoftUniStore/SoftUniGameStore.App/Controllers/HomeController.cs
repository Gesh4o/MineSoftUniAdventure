namespace SoftUniGameStore.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Data;

    using Models;

    using Services;

    using SimpleHttpServer.Models;

    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;

    using SoftUniGameStore.App.ViewModels.Cart;

    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly SecurityService securityService;

        private readonly GameService gameService;

        private CartService cartService;

        private UnitOfWork unitOfWork;

        public HomeController()
        {
            this.unitOfWork = new UnitOfWork();
            this.securityService = new SecurityService(this.unitOfWork, this.unitOfWork.LoginRepository, this.unitOfWork.UserRepository);
            this.gameService = new GameService(this.unitOfWork, this.unitOfWork.GameRepository);
            this.cartService = new CartService(this.unitOfWork, this.unitOfWork.CartRepository);
        }

        [HttpGet]
        public IActionResult<HomepageViewModel> Index(HttpSession session, string filter)
        {
            filter = WebUtility.UrlDecode(filter);
            HomepageViewModel model = new HomepageViewModel();
            User currentUser = this.securityService.GetCurrentlyLoggedUser(session);

            if (filter == "Bought Games")
            {
                if (currentUser != null && currentUser.Games != null)
                {
                    model.Email = currentUser.Email;
                    model.Games =
                       currentUser
                       .Games
                            .Select(
                                g =>
                                    new GameHomePageViewModel
                                    {
                                        Id = g.Id,
                                        Title = g.Title,
                                        Price = g.Price,
                                        Size = g.Size,
                                        Description = g.Description,
                                        VideoUrl = g.VideoUrl,
                                        Thumbnail = g.ImageThumbnail
                                    });
                }
                else
                {
                    model.Games = new List<GameHomePageViewModel>();
                }
            }
            else if (string.IsNullOrEmpty(filter) || filter == "All Games")
            {
                if (currentUser != null)
                {
                    model.Email = currentUser.Email;
                }

                model.Games =
                    this.gameService.GetAll()
                        .Select(
                            g =>
                                new GameHomePageViewModel
                                {
                                    Id = g.Id,
                                    Title = g.Title,
                                    Price = g.Price,
                                    Size = g.Size,
                                    Description = g.Description,
                                    VideoUrl = g.VideoUrl,
                                    Thumbnail = g.ImageThumbnail
                                });
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult<CartViewModel> Cart(HttpSession session)
        {
            Cart cart = this.cartService.FindBySession(session.Id);

            if (cart == null)
            {
                cart = new Cart { SessionId = session.Id, Games = new HashSet<Game>() };
            }

            CartViewModel cartViewModel = new CartViewModel();
            cartViewModel.Games =
             cart.Games.Select(
                 g =>
                     new CartGameViewModel
                     {
                         Description = g.Description,
                         Price = g.Price,
                         Title = g.Title,
                         VideoUrl = g.VideoUrl,
                         Thumbnail = g.ImageThumbnail,
                         Id = g.Id
                     });

            cartViewModel.TotalPrice = cartViewModel.Games.Sum(cr => cr.Price);

            if (this.securityService.IsAuthenticated(session))
            {
                cartViewModel.Email = this.securityService.GetCurrentlyLoggedUser(session).Email;
            }

            return this.View(cartViewModel);
        }

        [HttpPost]
        public void Cart(HttpSession session, HttpResponse response)
        {
            Cart cart = this.cartService.FindBySession(session.Id);

            if (cart == null)
            {
                this.Redirect(response, "/home/cart");
                return;
            }

            if (!this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/user/login");
                return;
            }

            User currentUser = this.securityService.GetCurrentlyLoggedUser(session);
            foreach (Game cartGame in cart.Games)
            {
                currentUser.Games.Add(cartGame);
            }

            cart.Games.Clear();
            this.unitOfWork.Save();

            this.Redirect(response, "/home/index?filter=Bought+Games");
        }
    }
}
