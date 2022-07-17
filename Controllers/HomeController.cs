using System.Web.Mvc;
using Gifts.Models;
using Gifts.Repository;

namespace Gifts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ItemsRepo ItemsRepo=new ItemsRepo();
            var Items=ItemsRepo.GetLists();
            ViewData["ItemsList"]=Items;    
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
    }
}