using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;

namespace PetShopFinal.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BasketController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
