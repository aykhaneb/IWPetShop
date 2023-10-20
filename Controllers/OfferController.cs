using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.ViewModels;

namespace PetShopFinal.Controllers
{
    public class OfferController : Controller
    {
        private readonly AppDbContext _dbContext;

        public OfferController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var offermain = _dbContext.OfferMains.ToList();
            var connected = _dbContext.Connecteds.ToList();
            var planoffer = _dbContext.PlanOffers.ToList();
            var taboffer = _dbContext.TabOffers.ToList();

            var offerViewModel = new OfferViewModel
            {
                OfferMain = offermain,
                Connected = connected,
                PlanOffer = planoffer,
                TabOffer = taboffer,
            };

            return View(offerViewModel);
        }
    }
}
