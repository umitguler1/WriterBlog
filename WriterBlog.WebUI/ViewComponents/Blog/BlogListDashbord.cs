using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Blog
{
    public class BlogListDashbord : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogListDashbord(IBlogService blogService)
        {
            _blogService = blogService;
        }
		static int writerId;
		static int sayac;
		public async Task<IViewComponentResult> InvokeAsync()
        {
			Context context = new Context();
			var userName = User.Identity.Name;
			var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
			var writerId = context.Writers.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
			//if (sayac < 1)
			//{
			//	writerId = int.Parse(TempData["WriterId"].ToString());
			//	sayac += 2;
			//}
			var values =await _blogService.GetBlogListByWriterAsyn(writerId);
            List<BlogDto> blogDtos = new List<BlogDto>();
            foreach (var blogDto in values)
            {
                if (blogDto.WriterId == writerId)
                {
                    blogDtos.Add(blogDto);
                }
            }
            return View(blogDtos);
        }
    }
}
