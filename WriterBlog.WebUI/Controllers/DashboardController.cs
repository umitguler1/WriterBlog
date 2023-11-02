using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;

namespace WriterBlog.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
			Context context = new Context();
			var userName = User.Identity.Name;
			var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
			var writerid = context.Writers.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
			ViewBag.v1=context.Blogs.Count().ToString();
            ViewBag.v2=context.Blogs.Where(x=>x.WriterId==writerid).Count();
            ViewBag.v3=context.Categories.Count().ToString();
            return View();
        }
    }
}
