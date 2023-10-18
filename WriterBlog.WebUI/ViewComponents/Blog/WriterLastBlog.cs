using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		private readonly IBlogService _blogService;

		public WriterLastBlog(IBlogService blogService)
		{
			_blogService = blogService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<BlogDto> blogDtos = await _blogService.GetBlogListByWriterAsyn(1);
			return View(blogDtos);
		}
	}
}
