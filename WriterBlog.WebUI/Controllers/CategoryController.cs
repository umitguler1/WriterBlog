using Microsoft.AspNetCore.Mvc;

namespace WriterBlog.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
