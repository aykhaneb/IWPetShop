using Microsoft.AspNetCore.Mvc;

namespace PetShopFinal.Areas.AdminPanel.Controllers
{
    public class DashboardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
