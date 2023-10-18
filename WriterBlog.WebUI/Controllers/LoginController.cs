using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IWriterService _writerService;

		public LoginController(IWriterService writerService)
		{
			_writerService = writerService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(WriterDto writerDto)
		{
			List<WriterDto> list = await _writerService.GetAllWriterAsync();
			WriterDto writerDto1 = list.FirstOrDefault(x => x.Email == writerDto.Email && x.Password == writerDto.Password);
			if (writerDto1 != null)
			{
				//HttpContext.Session.SetString("username", writerDto.Email);
				//var claims = new List<Claim>
				//{
				//	new Claim(ClaimTypes.Name,writerDto.Email)
				//};
				//var useridentity = new ClaimsIdentity(claims,"a");
				//ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				//await HttpContext.SignInAsync(principal);
				return RedirectToAction("BlogListByWriter", "Blog");
			}
			else
			{

				return View();

			}

		}
	}
}
