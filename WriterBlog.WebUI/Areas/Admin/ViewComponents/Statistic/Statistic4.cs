using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Entities.Concrete;

namespace WriterBlog.WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
		private readonly UserManager<AppUser> _userManager;

		public Statistic4(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.v1 = values.NameSurname;
			ViewBag.v2 = values.ImageUrl;
            
            return View();
        }

    }
}
