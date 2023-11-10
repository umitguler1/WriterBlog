using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IUserService _userService;


		public AdminProfileController(UserManager<AppUser> userManager, IUserService userService)
		{
			
			_userManager = userManager;
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> AdminEditProfile()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> AdminEditProfile(AppUser appUser)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.Email = appUser.Email;
			values.ImageUrl = appUser.ImageUrl;
			values.NameSurname = appUser.NameSurname;
			values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, appUser.PasswordHash);
			IdentityResult result = await _userManager.UpdateAsync(values);
			return result.Succeeded ? RedirectToAction("Index", "Widget", new { area = "Admin" }) : View(values);


		}
	}
}
