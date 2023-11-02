using Microsoft.AspNetCore.Mvc;

namespace WriterBlog.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<PartialViewResult> AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
