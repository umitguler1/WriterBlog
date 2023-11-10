using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;
using WinterBlog.DataAccess.Repositories;
using WriterBlog.Business.Abstract;
using WriterBlog.Business.ValidationRules;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{

	public class WriterController : Controller
	{
		private readonly IWriterService _writerService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IUserService _userService;


		public WriterController(IWriterService writerService, UserManager<AppUser> userManager, IUserService userService)
		{
			_writerService = writerService;
			_userManager = userManager;
			_userService = userService;
		}

		public async Task<IActionResult> Index()
		{
			var userMail = User.Identity.Name;
			ViewBag.V = userMail;
			Context c = new Context();
			var weritername = c.Writers.Where(x => x.Email == userMail).Select(x => x.Name).FirstOrDefault();
			ViewBag.V2 = weritername;
			return View();
		}
		public async Task<IActionResult> Test()
		{
			return View();
		}
		public async Task<PartialViewResult> WriterNawbarPartial()
		{
			return PartialView();
		}
		public async Task<PartialViewResult> WriterFooterPartial()
		{
			return PartialView();
		}
        [Authorize(Roles = "Writer,Admin,Moderator")]
        [HttpGet]
		public async Task<IActionResult> WriterEditProfile()
		{

			//Context context = new Context();
			//var userName = User.Identity.Name;
			//var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
			//var id=context.Users.Where(x=>x.Email==userMail).Select(x=>x.Id).FirstOrDefault();
			//var values = _userService.GetUserByIdAsync(id);
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> WriterEditProfile(AppUser appUser)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.Email = appUser.Email;
			values.ImageUrl = appUser.ImageUrl;
			values.NameSurname = appUser.NameSurname;
			values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, appUser.PasswordHash);
			IdentityResult result = await _userManager.UpdateAsync(values);
			return result.Succeeded ? RedirectToAction("Index", "Dashboard") : View(values);
			//WriterValidator wl = new WriterValidator();
			//ValidationResult result = wl.Validate(writerDto);
			//if (result.IsValid)
			//{
			//            bool res=await _writerService.UpdateWriterAsync(writerDto);
			//	return res ? RedirectToAction("Index", "Dashboard") :View(writerDto);
			//         }
			//else
			//{
			//	foreach (var item in result.Errors)
			//	{
			//		ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			//	}
			//}
			//return View(writerDto);

		}

	}
}