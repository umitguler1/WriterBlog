using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;

namespace WriterBlog.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public DashboardController(UserManager<AppUser> userManager, IBlogService blogService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _blogService = blogService;
            _categoryService = categoryService;
        }
        [Authorize(Roles = "Writer,Admin,Moderator")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1=(_blogService.GetAllBlogAsync()).Result.Count;
            ViewBag.v2=_blogService.GetBlogListByWriterAsyn(values.Id).Result.Count;
            ViewBag.v3=_categoryService.GetAllCategoryAsync().Result.Count;
            return View();
        }
    }
}
