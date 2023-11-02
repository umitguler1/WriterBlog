using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WriterBlog.Business.Abstract;

namespace WriterBlog.WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        private readonly IBlogService _blogServices;
        private readonly IContactService _contactServices;
        private readonly ICommentService _commentServices;

        public Statistic1(IBlogService blogServices, IContactService contactServices, ICommentService commentServices)
        {
            _blogServices = blogServices;
            _contactServices = contactServices;
            _commentServices = commentServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sum = _blogServices.GetAllBlogAsync().Result.Count;
            ViewBag.v1 = sum;
            ViewBag.v2 = _contactServices.GetAllContactAsync().Result.Count;
            ViewBag.v3 = _commentServices.GetAllCommentNoIdAsync().Result.Count;

            //string api = "7637c74c4a3c1348b49af231c1eafbee";
            //string connection = "https://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=xml&appid=" + api;
            //XDocument document = XDocument.Load(connection);
            ViewBag.v4 = 25;
            return View();
        }

    }
}
