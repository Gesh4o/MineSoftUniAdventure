namespace SoftUniGameStore.App.Controllers
{
    using BindingModels.User;

    using Data;

    using Services;

    using SimpleHttpServer.Models;

    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UserController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        private readonly SecurityService securityService;

        public UserController()
        {
            this.unitOfWork = new UnitOfWork();
            this.securityService = new SecurityService(this.unitOfWork, this.unitOfWork.LoginRepository, this.unitOfWork.UserRepository);
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public void Login(HttpSession session, HttpResponse response, UserAuthenticationBindingModel userBindingModel)
        {
            if (this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
                return;
            }

            if (!this.securityService.HasLogin(session, userBindingModel))
            {
                this.Redirect(response, "/user/login");
                return;
            }

            this.Redirect(response, "/home/index");
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public void Register(HttpSession session, HttpResponse response, UserRegisterBindingModel userBindingModel)
        {
            if (this.securityService.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
            }

            if (!this.securityService.HasRegister(userBindingModel))
            {
                this.Redirect(response, "/user/register");
                return;
            }

            this.Redirect(response, "/user/login");
        }

        public void Logout(HttpSession session, HttpResponse response)
        {
            this.securityService.HasLogout(session);

            this.Redirect(response, "/home/index");
        }
    }
}
