using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;

namespace PetShopFinal.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var header = await _dbContext.Headers.FirstOrDefaultAsync();

            return View(header);
        }
    }   
}
