using Microsoft.AspNetCore.Mvc;
using MSStoreWebApp.Dal;
using MSStoreWebApp.Migrations;
using MSStoreWebApp.Models;
using System.Collections.Generic;

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
