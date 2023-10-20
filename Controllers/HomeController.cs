using Microsoft.AspNetCore.Mvc;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.ViewModels;
using System;

namespace PetShopFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {

            var puffles = _dbContext.Puffles.ToList();
            var featured = _dbContext.Featured.ToList();
            var offer = _dbContext.Offer.ToList();
            var hurry = _dbContext.Hurry.ToList();
            var teamlg = _dbContext.TeamLG.ToList();
            var treats = _dbContext.Treats.ToList();
            var news = _dbContext.News.ToList();
            var organiclg = _dbContext.OrganicLG.ToList();

            var homeViewModel = new HomeViewModel
            {
                Puffles = puffles,
                Featured = featured,
                Offer = offer,
                Hurry = hurry,
                TeamLG = teamlg,
                Treats = treats,
                News = news,
                OrganicLG = organiclg,
            };

            return View(homeViewModel);
        }
    }
}
