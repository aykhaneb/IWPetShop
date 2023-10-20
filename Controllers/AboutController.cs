using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.ViewModels;

namespace PetShopFinal.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var tabtext = _dbContext.TabText.Include(x => x.TabCategory).ToList();
            var tabcategory = _dbContext.TabCategories.ToList();
            var teamabout = _dbContext.TeamAbout.ToList();
            var organicabout = _dbContext.OrganicAbout.ToList();
            var number = _dbContext.Numbers.ToList();

            var aboutViewModel = new AboutViewModel
            {
                TabCategory = tabcategory,
                TabText = tabtext,
                TeamAbout = teamabout,
                OrganicAbout = organicabout,
                Numbers = number,
            };

            return View(aboutViewModel);
        }
    }
}
