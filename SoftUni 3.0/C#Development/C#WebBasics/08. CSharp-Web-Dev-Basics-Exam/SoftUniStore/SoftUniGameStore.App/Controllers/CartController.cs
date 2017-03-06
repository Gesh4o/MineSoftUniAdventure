namespace SoftUniGameStore.App.Controllers
{
    using System.Linq;

    using Data;

    using Models;

    using Services;

    using SimpleHttpServer.Models;

    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;

    public class CartController : Controller
    {
        private readonly CartService cartService;

        private readonly GameService gameService;

        private readonly UnitOfWork unitOfWork;

        public CartController()
        {
            this.unitOfWork = new UnitOfWork();
            this.gameService = new GameService(this.unitOfWork, this.unitOfWork.GameRepository);
            this.cartService = new CartService(this.unitOfWork, this.unitOfWork.CartRepository);
        }

        [HttpGet]
        public void Add(HttpSession session, HttpResponse response, int id)
        {
            Cart cart = this.cartService.FindBySession(session.Id);

            if (cart == null)
            {
                this.Redirect(response, "/home/cart");
                return;
            }

            Game game = this.gameService.Find(id);

            if (game == null)
            {
                this.Redirect(response, "/home/index");
                return;
            }

            if (cart.Games.All(g => g.Id != id))
            {
                cart.Games.Add(game);
                this.unitOfWork.Save();
            }

            this.Redirect(response, "/home/cart");
        }

        [HttpGet]
        public void Remove(HttpSession session, HttpResponse response, int id)
        {
            Cart cart = this.cartService.FindBySession(session.Id);

            if (cart == null)
            {
                this.Redirect(response, "/home/cart");
                return;
            }

            Game game = this.gameService.Find(id);

            if (game == null)
            {
                this.Redirect(response, "/home/index");
                return;
            }

            cart.Games.Remove(game);
            this.unitOfWork.Save();

            this.Redirect(response, "/home/cart");
        }
    }
}
