using Microsoft.AspNetCore.Mvc;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
