using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.Areas.AdminPanel.Data;
using PetShopFinal.DAL;
using PetShopFinal.DAL.Models;
using Filess = System.IO.File;

namespace PetShopFinal.Areas.AdminPanel.Controllers
{
    public class OfferController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public OfferController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var offers = await _dbContext.Offer.ToListAsync();
            return View(offers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!offer.Image.ContentType.Contains("image"))
            {
                ModelState.AddModelError("photo", "You must choose photo");
            }

            var isExist = await _dbContext.Offer.AnyAsync(x => x.Title.ToLower().Equals(offer.Title.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("Name", "This product name already exist");

                return View();
            }


            var filename = $"{Guid.NewGuid()}-{offer.Image.FileName}";

            var path = Path.Combine(Constants.ImagePath, filename);

            using (var fileStream = new FileStream(path, FileMode.CreateNew))
            {
                await offer.Image.CopyToAsync(fileStream);
            }

            offer.ImageUrl = filename;

            await _dbContext.Offer.AddAsync(offer);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();

            var offer = await _dbContext.Offer.FindAsync(id);

            if (offer == null) return NotFound();

            var path = Path.Combine(Constants.ImagePath, offer.ImageUrl);

            if (Filess.Exists(path))
            {
                Filess.Delete(path);
            }

            _dbContext.Offer.Remove(offer);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var offer = await _dbContext.Offer.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }
            return View(offer);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var offer = await _dbContext.Offer.FindAsync(id);

            if (offer == null)
                return NotFound();

            return View(offer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Offer offer)
        {
            if (id == null)
                return NotFound();

            if (id != offer.Id)
                return BadRequest();

            var existingOffer = await _dbContext.Offer.FindAsync(id);

            if (existingOffer == null)
                return NotFound();

            // Validate the Offer model
            if (!ModelState.IsValid)
            {
                return View(offer);
            }

            var oldImagePath = Path.Combine(Constants.ImagePath, existingOffer.ImageUrl);

            var fileName = $"{Guid.NewGuid()}-{offer.Image.FileName}";

            if (Filess.Exists(oldImagePath))
            {
                Filess.Delete(oldImagePath);
            }

            existingOffer.ImageUrl = fileName;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
