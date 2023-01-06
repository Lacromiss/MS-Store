using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
            List<Product> product = _context.products.Where(x => x.GenderId == 1 && x.Price <= 12).ToList();
            List<Product> product2 = _context.products.Where(y => y.GenderId == 3 && y.Price <= 12).ToList();
            List<Product> product3 = _context.products.Where(y => y.GenderId == 3 && y.Price <= 24 && y.Price > 12).ToList();
            List<Product> product4 = _context.products.Where(y => y.GenderId == 3 && y.Price <= 36 && y.Price > 24).ToList();
            List<Product> product5 = _context.products.Where(y => y.GenderId == 3 && y.ColorrId == 1).ToList();
            ViewBag.qara = _context.products.Where(y => y.GenderId == 3 && y.ColorrId == 2).ToList();
            ViewBag.qirmizi = _context.products.Where(y => y.GenderId == 3 && y.ColorrId == 3).ToList();
            ViewBag.yasil = _context.products.Where(y => y.GenderId == 3 && y.ColorrId == 4).ToList();
            ViewBag.gumus = _context.products.Where(y => y.GenderId == 3 && y.ColorrId == 5).ToList();
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
        public IActionResult AddToCart()
        {
            List<Product> products = _context.products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(int ProductId)
        {

            Product product = _context.products.Find(ProductId);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(Request.Cookies["cart"]) && Request.Cookies.ContainsKey("cart"))
                {


                    List<(int productId, int productCount)> Suwi = Request.Cookies["cart"].Split(',').Select(x => x.Split('-')).Select(x => (int.Parse(x[0]), int.Parse(x[1])))
                .ToList();


                    // Ürünler listesinde aradığınız ürünün indeksini bulun
                    int index = Suwi.FindIndex(x => x.productId == ProductId);

                    // Eğer ürün bulunduysa, ürün sayısını arttırın
                    if (index >= 0)
                    {
                        Suwi[index] = (ProductId, Suwi[index].productCount + 1);
                    }
                  
                    // Eğer ürün bulunamadıysa, ürünü listeye ekleyin
                    else
                    {
                        Suwi.Add((ProductId, 1));
                    }
                    // Çerezi güncelleyin
                    Response.Cookies.Append("cart", string.Join(",", Suwi.Select(x => $"{x.productId}-{x.productCount}")));




                }
                else
                {
                    // Çerez yoksa, çerez oluşturun ve ürünü ekleyin
                    Response.Cookies.Append("cart", $"{ProductId}-1");
                }


            }
            return RedirectToAction(nameof(AddToCart));

        }


        public IActionResult ViewCart()
        {
            List<Product> Musi = new List<Product>();
            if (!string.IsNullOrEmpty(Request.Cookies["cart"]))
            {



                List<(int productId, int productCount)> ProductIds = Request.Cookies["cart"].Split(',')
                .Select(x => x.Split('-'))
                .Select(x => (int.Parse(x[0]), int.Parse(x[1])))
                .ToList();

                foreach (var item in ProductIds)
                {
                    Product product = _context.products.Find(item.productId);
                    product.Count = item.productCount;
                    Musi.Add(product);
                }
                return View(Musi);
            }
            else
            {
                return View(Musi);
            }
        }

        public IActionResult Topla(int pirt)
        {
            // Ürünler listesini çerezden okuyun
            List<(int productId, int productCount)> products = Request.Cookies["cart"]
                .Split(',')
                .Select(x => x.Split('-'))
                .Select(x => (int.Parse(x[0]), int.Parse(x[1])))
                .ToList();

            // Ürünler listesinde aradığınız ürünün indeksini bulun
            int index = products.FindIndex(x => x.productId == pirt);

            // Eğer ürün bulunduysa, ürün sayısını arttırın
            if (index >= 0)
            {
                products[index] = (pirt, products[index].productCount + 1);
            }

            // Çerezi güncelleyin
            Response.Cookies.Append("cart", string.Join(",", products.Select(x => $"{x.productId}-{x.productCount}")));

            // Sepete geri yönlendirin
            return RedirectToAction(nameof(ViewCart));
        }


        public IActionResult Cix(int Id)
        {
            // Ürünler listesini çerezden okuyun
            List<(int productId, int productCount)> products = Request.Cookies["cart"]
                .Split(',')
                .Select(x => x.Split('-'))
                .Select(x => (int.Parse(x[0]), int.Parse(x[1])))
                .ToList();

            // Ürünler listesinde aradığınız ürünün indeksini bulun
            int index = products.FindIndex(x => x.productId == Id);

            // Eğer ürün bulunduysa, ürün sayısını arttırın
            if (index >= 0)
            {
                products[index] = (Id, products[index].productCount - 1);
                if ( products[index].productCount==0)
                {
                    products.Remove(products[index]);



                }
            }
            if (products==null)
            {
                return RedirectToAction(nameof(View));

            }
            // Çerezi güncelleyin
            Response.Cookies.Append("cart", string.Join(",", products.Select(x => $"{x.productId}-{x.productCount}")));

            // Sepete geri yönlendirin
            return RedirectToAction(nameof(ViewCart));
        }

    }
}
