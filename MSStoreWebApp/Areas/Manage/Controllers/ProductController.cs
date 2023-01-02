using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSStoreWebApp.Dal;
using MSStoreWebApp.Models;
using MSStoreWebApp.Utilites;
using MSStoreWebApp.Vm;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MSStoreWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            ProductCatagoryGenderVm productCatagoryGenderVm = new ProductCatagoryGenderVm()
            {
                Catagories = _context.catagories.ToList(),
                Genders = _context.genders.ToList(),
                Products = _context.products.ToList(),
                ColorProducts = _context.colorProducts.ToList()
            };
            return View(productCatagoryGenderVm);
        }
        public IActionResult Create()
        {
            ViewBag.catagory = new SelectList(_context.catagories.ToList(), "Id", "Name");
            ViewBag.gender = new SelectList(_context.genders.ToList(), "Id", "Name");
            ViewBag.color = new SelectList(_context.colors.ToList(), "Id", "Name");
            ViewBag.best = new SelectList(_context.bests.ToList(), "Id", "Name");


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.catagory = new SelectList(_context.catagories.ToList(), "Id", "Name");
            ViewBag.gender = new SelectList(_context.genders.ToList(), "Id", "Name");
            ViewBag.color = new SelectList(_context.colors.ToList(), "Id", "Name");
            ViewBag.best = new SelectList(_context.bests.ToList(), "Id", "Name");

            if (!ModelState.IsValid)
            {
                return View();

            }
            if (product.Photo != null)
            {
                if (!(product.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(product.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }


                product.ImgUrl = await product.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Assest","image"));
                if (product.ImgUrl==null)
                {
                    ModelState.AddModelError("Photo", "xeta burdadir");
                    return View();

                }


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }

          
            List<ColorProduct> pc = new List<ColorProduct> ();
         
                Color clr = _context.colors.Find(product.ColorrId);
                if (clr == null) NotFound();
                pc.Add(new ColorProduct
                {
                    Color = clr,
                    Product = product
                });
            
                        product.Products = pc;

            _context.products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int Id)
        {
            ViewBag.catagoryy =_context.catagories.ToList();
            ViewBag.genderr = _context.genders.ToList();
            ViewBag.colorr = _context.colors.ToList();
            ViewBag.bestt = _context.bests.ToList();

            Product product = _context.products.Find(Id);
            if (product==null)
            {
                return BadRequest();

            }

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult >Update(int Id,Product product)
        {
            Product product1 =await _context.products.FindAsync(Id);
            if (product1 == null)
            {
                return BadRequest();

            }
        

            product1.Description = product.Description;
            product1.Price = product.Price;
            product1.Name = product.Name;
          
            product1.ColorrId = product1.ColorrId;
            product1.GenderId = product.GenderId;
            product1.CatagoryId=product.CatagoryId;
            product1.BestId=product.BestId;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            Product product = _context.products.Find(Id);
            _context.products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
