using Microsoft.AspNetCore.Mvc;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.ViewModels;
using System;

namespace PetShopFinal.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ShopController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var product = _dbContext.Products.ToList();
            var popularproduct = _dbContext.PopularProducts.ToList();
            var popproduct = _dbContext.PopProductss.ToList();
            var mainproduct = _dbContext.MainProductss.ToList();

            var shopViewModel = new ShopViewModel
            {
                Product = product,
                PopularProduct = popularproduct,
                PopProducts = popproduct,
                MainProducts = mainproduct,
            };

            return View(shopViewModel);
        }

        //private IQueryable<MainProducts> FilterByTitle(string? Name)
        //{
        //    var mainproducts = !string.IsNullOrEmpty(Name) ? _dbContext.MainProductss.Where(p => p.Name.Contains(Name)) : _dbContext.MainProductss.Where(p => !p.IsDeleted);
        //    return mainproducts;
        //}
    }
}
