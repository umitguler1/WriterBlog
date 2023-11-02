using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.Abstract;

namespace WriterBlog.WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        private readonly IWriterService _writerServices;
        Context context = new Context();

        public Statistic2(IWriterService writerServices)
        {
            _writerServices = writerServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.writer = context.Writers.OrderByDescending(x => x.Id).Select(x => x.Name).FirstOrDefault();
            return View();
        }

    }
}
