using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;

namespace PetShopFinal.ViewComponents
{
    public class FooterTopViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public FooterTopViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerTop = await _dbContext.FooterTops.FirstOrDefaultAsync();

            return View(footerTop);
        }
    }
}
