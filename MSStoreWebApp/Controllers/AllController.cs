using Microsoft.AspNetCore.Mvc;

namespace MSStoreWebApp.Controllers
{
    public class AllController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Smart()
        {
            return View();
        } 
        public IActionResult Girl()
        {
            return View();
        }
    }
}
