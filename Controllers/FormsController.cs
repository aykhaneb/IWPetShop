using Microsoft.AspNetCore.Mvc;
using PetShopFinal.DAL;
using PetShopFinal.ViewModels;

namespace PetShopFinal.Controllers
{
    public class FormsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public FormsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var contactform = _dbContext.ContactForms.ToList();
            var lform = _dbContext.LForms.ToList();

            var formsViewModel = new FormsViewModel
            {
                ContactForm = contactform,
                LForm = lform,
            };
            return View(formsViewModel);
        }
    }
}
