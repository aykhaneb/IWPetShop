using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.ViewModels;

namespace PetShopFinal.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TestimonialsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            
            var firstTest = _dbContext.FirstTests.ToList();
            var thirdUser = _dbContext.ThirdUserss.ToList();

            var testimonialsViewModel = new TestimonialsViewModel
            {
                FirstTest = firstTest,
                ThirdUsers = thirdUser,
            };

            return View(testimonialsViewModel);
        }
    }
}
