using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IList<string> items = (List<string>)Session["items"] ?? new List<string>(); 
            return View(items);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddItem(string newItem)
        {
            IList<string> items = (List<string>)Session["items"] ?? new List<string>();
            items.Add(newItem);
            this.Session["items"] = items;
            return this.RedirectToAction("Index");
        }

        public ActionResult RemoveItem(int index)
        {
            IList<string> items = (List<string>)Session["items"] ?? new List<string>();

            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
                this.Session["items"] = items;
            }
            return this.RedirectToAction("Index");
        }
    }
}