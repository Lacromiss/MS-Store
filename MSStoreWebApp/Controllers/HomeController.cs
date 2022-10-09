using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSStoreWebApp.Dal;
using MSStoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MSStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {

            _context = context;
        }
      

        public IActionResult Index()
        {

            ViewData["BestSteller"] = _context.products.Where(x=>x.BestId==1).ToList();
            ViewData["neww"] = _context.products.Where(x=>x.BestId==2).ToList();
            ViewData["first"] = _context.products.Where(x=>x.BestId==3).ToList();
            ViewData["kisi"] = _context.products.Where(x=>x.GenderId==1).ToList();
            ViewData["qadin"] = _context.products.Where(x=>x.GenderId==2).ToList();
            ViewData["smart"] = _context.products.Where(x=>x.CatagoryId==2).ToList();
            return View();
        }

     

     
    }
}
