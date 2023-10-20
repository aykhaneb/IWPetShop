using Microsoft.AspNetCore.Mvc;
using PetShopFinal.DAL;
using PetShopFinal.ViewModels;

namespace PetShopFinal.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly int _blogCount;

        public BlogController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
            _blogCount = _dbContext.Blogs.Count();
        }
        public IActionResult Index()
        {
            ViewBag.BlogCount = _blogCount;
            var blog = _dbContext.Blogs.Take(3).ToList();

            var blogViewModel = new BlogViewModel
            {
                Blog = blog,
            };

            return View(blogViewModel);
        }
        public IActionResult LoadBlogs(int skip) 
        {
            var blogs = _dbContext.Blogs.Skip(skip).Take(3).ToList();

            return PartialView("_BlogPartial", blogs);
        }
    }
}
