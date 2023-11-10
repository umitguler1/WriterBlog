using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		private readonly IBlogService _blogService;

		public BlogLast3Post(IBlogService blogService)
		{
			_blogService = blogService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<BlogDto> blogDtos = await _blogService.GetBlogLast3PostAsyn();
			return View(blogDtos);
		}
		
	}
}
