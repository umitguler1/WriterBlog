using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

		public BlogListDashbord(IBlogService blogService, UserManager<AppUser> userManager)
		{
			_blogService = blogService;
			_userManager = userManager;
		}
		
		public async Task<IViewComponentResult> InvokeAsync()
        {

			var valuess = await _userManager.FindByNameAsync(User.Identity.Name);
		
			var values = _blogService.GetBlogListByWriterAsyn(valuess.Id).Result.OrderByDescending(x => x.CreateDate).ToList(); 
            List<BlogDto> blogDtos = new List<BlogDto>();
            foreach (var blogDto in values)
            {
                if (blogDto.WriterId == valuess.Id)
                {
                    blogDtos.Add(blogDto);
                }
            }
            return View(blogDtos);
        }
    }
}
