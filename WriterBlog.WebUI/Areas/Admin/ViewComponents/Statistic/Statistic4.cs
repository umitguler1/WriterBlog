using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;

namespace WriterBlog.WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context context = new Context();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = context.Admins.Where(x => x.Id == 1).Select(x => x.Name).FirstOrDefault();
            ViewBag.v2 = context.Admins.Where(x => x.Id == 1).Select(x => x.ImageURl).FirstOrDefault();
            ViewBag.v3 = context.Admins.Where(x => x.Id == 1).Select(x => x.Description).FirstOrDefault();
            return View();
        }

    }
}
