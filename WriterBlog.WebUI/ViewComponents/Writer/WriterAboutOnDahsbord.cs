
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Writer
{
	
	public class WriterAboutOnDahsbord  : ViewComponent
	{
		private readonly IWriterService _writerService;
		private readonly UserManager<AppUser> _userManager;

		public WriterAboutOnDahsbord(IWriterService writerService, UserManager<AppUser> userManager)
		{
			_writerService = writerService;
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
			return View(values);
		}
	}
}
