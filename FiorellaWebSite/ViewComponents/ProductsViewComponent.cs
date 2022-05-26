using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorellaWebSite.DAL;
using FiorellaWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorellaWebSite.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private AppDbContext _context;
        public ProductsViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> IncokeAsync()
        {
            List<Product> products = _context.Products.Include(p => p.Category).Take(8).ToList();
            return View(await Task.FromResult(products));
        }
    }
}