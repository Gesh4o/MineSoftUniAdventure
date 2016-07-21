namespace WebApp.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Numbers()
        {
            ViewBag.Message = "Numbers: ";

            return View();
        }

        public ActionResult Files(string path = @"C:\")
        {
            ViewBag.Path = path;
            var files = Directory
              .GetDirectories(path)
              .ToList();

            files.AddRange(Directory.GetFiles(path));

            return View(files);
        }
    }
}