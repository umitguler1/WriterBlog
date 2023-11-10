using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminBlogController : Controller
    {
        private readonly IBlogService _blogServices;

        public AdminBlogController(IBlogService blogServices)
        {
            _blogServices = blogServices;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogDto> blogDtos= await _blogServices.GetAllBlogAsync();
            return View(blogDtos);
        }
    }
}
