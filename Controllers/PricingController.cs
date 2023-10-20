using Microsoft.AspNetCore.Mvc;
using PetShopFinal.DAL;

namespace PetShopFinal.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PricingController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
