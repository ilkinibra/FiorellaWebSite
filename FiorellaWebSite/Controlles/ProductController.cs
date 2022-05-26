using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorellaWebSite.DAL;
using FiorellaWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorellaWebSite.Controlles
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.Products.Count();
            List<Product> products = _context.Products.Include(p => p.Category).OrderByDescending(p => p.Id).Take(4).ToList();
            return View(products);

        }
        public IActionResult LoadMore(int skip)
        {
            List<Product> product = _context.Products.Include(p => p.Category).Skip(skip).Take(4).ToList();
            return PartialView("_ProductPartial", product);
        }
    }
}

