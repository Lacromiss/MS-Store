using Microsoft.AspNetCore.Mvc;
using MSStoreWebApp.Dal;
using MSStoreWebApp.Migrations;
using MSStoreWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MSStoreWebApp.Controllers
{
    public class AllController : Controller
    {
        private AppDbContext _context;

        public AllController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
           List<Product> product = _context.products.Where(x=>x.GenderId==1 && x.Price<=12).ToList();
          List<Product> product2 = _context.products.Where(y => y.GenderId == 3 && y.Price<=12 ).ToList();
            List<Product> product3= _context.products.Where(y => y.GenderId == 3 && y.Price<=24 && y.Price>12).ToList();
            List<Product> product4 = _context.products.Where(y => y.GenderId == 3 && y.Price<=36 && y.Price > 24).ToList();
            List<Product> product5 = _context.products.Where(y => y.GenderId == 3 && y.ColorrId==1).ToList();
            ViewBag.qara = _context.products.Where(y => y.GenderId == 3 && y.ColorrId==2).ToList();
            ViewBag.qirmizi = _context.products.Where(y => y.GenderId == 3 && y.ColorrId==3).ToList();
            ViewBag.yasil = _context.products.Where(y => y.GenderId == 3 && y.ColorrId==4).ToList();
            ViewBag.gumus = _context.products.Where(y => y.GenderId == 3 && y.ColorrId==5).ToList();
            ViewData["kicik"] = product2;
            ViewData["orta"] = product3;
            ViewData["boyuk"] = product4;
            ViewData["ag"] = product5;

            return View(product);
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
