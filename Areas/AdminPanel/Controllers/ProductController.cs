using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.Areas.AdminPanel.Data;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using PetShopFinal.Migrations;
using Files = System.IO.File;

namespace PetShopFinal.Areas.AdminPanel.Controllers
{
    public class ProductController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.MainProductss.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MainProducts product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!product.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("photo", "You must choose photo");
            }

            var isExist = await _dbContext.MainProductss.AnyAsync(x => x.Name.ToLower().Equals(product.Name.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("Name", "This product name already exist");

                return View();
            }

            else
            {
                var filename = $"{Guid.NewGuid()}-{product.Photo.FileName}";

                var path = Path.Combine(Constants.ImagePath, filename);

                using (var fileStream = new FileStream(path, FileMode.CreateNew))
                {
                   await product.Photo.CopyToAsync(fileStream);
                }

                product.ImageUrl = filename;

                await _dbContext.MainProductss.AddAsync(product);

                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();

            var product =await _dbContext.MainProductss.FindAsync(id);

            if (product == null)  return NotFound();

                var path = Path.Combine(Constants.ImagePath, product.ImageUrl);

                if (Files.Exists(path))
                {
                    Files.Delete(path);
                }

            _dbContext.MainProductss.Remove(product);

            await _dbContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _dbContext.MainProductss.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
