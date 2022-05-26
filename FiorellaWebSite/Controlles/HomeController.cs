using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorellaWebSite.DAL;
using FiorellaWebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorellaWebSite.Controlles
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

            HomeVM homeVM = new HomeVM();
            homeVM.Slider = _context.Sliders.ToList();
            homeVM.PageIntro = _context.PageIntros.FirstOrDefault();
            homeVM.Products = _context.Products.Include(p => p.Category).ToList();
            homeVM.Categories = _context.Categories.ToList();
            return View(homeVM);
        }
    }
}