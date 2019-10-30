using Microsoft.AspNetCore.Mvc;
using New23Try2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New23Try2.Controllers
{
    public class ProductController : Controller
    {
        ShoppContext db = new ShoppContext();
        Product _product = new Product();

        public IActionResult Index()
        {
            List<Product> products = db.Product.ToList();
            return View(db.Product.ToList());
        }

        public IActionResult Buy(int id)
        {
            Product p = db.Product.Find(id);
            if (p != null)
            {
                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }
        public IActionResult Receipt()
        {
            ViewBag.id = _product.Id;
            ViewBag.name = _product.Name;
            ViewBag.price = _product.Price;
            return View();
           
        }
    }
}
