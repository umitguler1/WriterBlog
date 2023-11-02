using Microsoft.AspNetCore.Mvc;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
