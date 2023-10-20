using Microsoft.AspNetCore.Mvc;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.ViewModels;

namespace PetShopFinal.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var touch = _dbContext.Touchs.ToList();
            var contact = _dbContext.Contacts.ToList();

            var contactViewModel = new ContactViewModel
            {
                Touch = touch,
                Contact = contact,
            };
            return View(contactViewModel);
        }
    }
}
