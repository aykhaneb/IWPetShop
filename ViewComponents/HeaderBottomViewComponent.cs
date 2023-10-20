using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;

namespace PetShopFinal.ViewComponents
{
    public class HeaderBottomViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public HeaderBottomViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerbottom = await _dbContext.HeaderBottoms.FirstOrDefaultAsync();

            return View(headerbottom);
        }
    }
}
