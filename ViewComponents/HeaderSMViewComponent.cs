using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL;

namespace PetShopFinal.ViewComponents
{
    public class HeaderSMViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public HeaderSMViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headersm = await _dbContext.HeaderSMs.FirstOrDefaultAsync();

            return View(headersm);
        }
    }
}
