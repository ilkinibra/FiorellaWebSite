using System;
using System.Collections.Generic;
using FiorellaWebSite.Models;

namespace FiorellaWebSite.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Slider { get; set; }
        public PageIntro PageIntro { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}