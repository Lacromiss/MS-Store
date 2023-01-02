using Microsoft.AspNetCore.Mvc;

namespace MSStoreWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Indexx()
        {
            return View();
        }
    }
}
