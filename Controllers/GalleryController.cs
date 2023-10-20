using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.ViewModels;

namespace PetShopFinal.Controllers
{
    public class GalleryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public GalleryController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {

            //var organiclg = _dbContext.OrganicLG.ToList();
            var typeimage = _dbContext.TypeImages.Include(x => x.Types).ToList();
            var type = _dbContext.Typess.ToList();

            var galleryViewModel = new GalleryViewModel
            {
                //OrganicLG = organiclg,
                Types = type,
                TypeImage = typeimage,
            };

            return View(galleryViewModel);
        }
    }
}

