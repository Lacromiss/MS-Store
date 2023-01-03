using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSStoreWebApp.Dal;
using MSStoreWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MSStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        List<Product> products1;
        
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {

            _context = context;
        }

        
        public IActionResult Index()
        {

            ViewData["BestSteller"] = _context.products.Where(x => x.BestId == 1).ToList();
            ViewData["neww"] = _context.products.Where(x => x.BestId == 2).ToList();
            ViewData["first"] = _context.products.Where(x => x.BestId == 3).ToList();
            ViewData["kisi"] = _context.products.Where(x => x.GenderId == 3).ToList();
            ViewData["qadin"] = _context.products.Where(x => x.GenderId == 4).ToList();
            ViewData["smart"] = _context.products.Where(x => x.CatagoryId == 2).ToList();

            return View();
        }
        public ActionResult Filter()
        {
            ViewBag.colora = new SelectList(_context.colors.ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Filterr(string priceRange, int ColorrId)
        {
            ViewBag.colora = new SelectList(_context.colors.ToList(), "Id", "Name");

            var products = _context.products.AsQueryable();

            if (!string.IsNullOrEmpty(priceRange))
            {
                string[] range = priceRange.Split('-');
                double min = double.Parse(range[0]);
                double max = double.Parse(range[1]);
                products = products.Where(p => p.Price >= min && p.Price <= max);
            }
            if (ColorrId != 0)
            {
                int colorId = ColorrId;

             
                    products = products.Where(p => p.ColorrId == colorId);

                
            }
            string data= JsonConvert.SerializeObject(products);

            TempData["products"] = data;

            return RedirectToAction(nameof(FilterNetice));
        }

            public IActionResult FilterNetice()
        {
            ViewBag.colora = new SelectList(_context.colors.ToList(), "Id", "Name");
            if (TempData["products"] != null)
            {
                var pro = TempData["products"].ToString();
                List<Product> pro7 = JsonConvert.DeserializeObject<List<Product>>(pro);
             
                    return View(pro7);


                
            }
           
           
            else
            {
                
                return View(_context.products.ToList());
            }
        }
    }
}
