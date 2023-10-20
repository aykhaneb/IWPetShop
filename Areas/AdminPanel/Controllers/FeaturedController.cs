using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.Areas.AdminPanel.Data;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.Migrations;
using FilesFeatured = System.IO.File;

namespace PetShopFinal.Areas.AdminPanel.Controllers
{
    public class FeaturedController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public FeaturedController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var featuredProducts = await _dbContext.Featured.ToListAsync();

            return View(featuredProducts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DAL.Models.Featured featuredProduct)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!featuredProduct.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("photo", "You must choose photo");
            }

            var isExist = await _dbContext.Featured.AnyAsync(x => x.Title.ToLower().Equals(featuredProduct.Title.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("Name", "This product name already exist");

                return View();
            }

            else
            {
                var filename = $"{Guid.NewGuid()}-{featuredProduct.Photo.FileName}";

                var path = Path.Combine(Constants.ImagePath, filename);

                using (var fileStream = new FileStream(path, FileMode.CreateNew))
                {
                    await featuredProduct.Photo.CopyToAsync(fileStream);
                }

                featuredProduct.ImageUrl = filename;

                await _dbContext.Featured.AddAsync(featuredProduct);

                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var featuredProduct = await _dbContext.Featured.FindAsync(id);

            if (featuredProduct == null)
            {
                return NotFound();
            }
            return View(featuredProduct);
        }
    }
}
