using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;

namespace PetShopFinal.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public FooterViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = await _dbContext.Footers.FirstOrDefaultAsync();

            return View(footer);
        }
    }
}
