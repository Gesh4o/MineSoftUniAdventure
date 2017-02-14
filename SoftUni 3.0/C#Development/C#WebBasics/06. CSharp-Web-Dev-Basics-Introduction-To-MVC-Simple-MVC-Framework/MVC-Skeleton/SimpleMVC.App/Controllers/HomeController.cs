namespace SimpleMVC.App.Controllers
{
    using MVC.Interfaces;
    using MVC.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
