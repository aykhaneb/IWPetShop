using Microsoft.AspNetCore.Mvc;
using PetShopFinal.DAL;

namespace PetShopFinal.Controllers
{
    public class TabsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TabsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
