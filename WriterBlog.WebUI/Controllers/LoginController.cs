using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;
using WriterBlog.WebUI.Models;

namespace WriterBlog.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IWriterService _writerService;
		private readonly IAuthService _authService;

		public LoginController(IWriterService writerService, IAuthService authService)
		{
			_writerService = writerService;
			_authService = authService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Login(loginDto);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }



        //      static int writerId;
        //      static string writerName;
        //      static string writerImage;
        //      [HttpPost]

        //public async Task<IActionResult> Index(WriterDto writerDto)
        //{
        //	List<WriterDto> list = await _writerService.GetAllWriterAsync();
        //	WriterDto writerDto1 = list.FirstOrDefault(x => x.Email == writerDto.Email && x.Password == writerDto.Password);
        //	if (writerDto1 != null)
        //	{
        //		writerId = writerDto1.Id;
        //		writerName = writerDto1.Name;
        //		writerImage = writerDto1.Image;
        //		TempData["WriterId"] = writerId;
        //		TempData["WriterId2"] = writerId;
        //		TempData["WriterName"] = writerName;
        //		TempData["WriterImage"] = writerImage;
        //		//HttpContext.Session.SetString("username", writerDto.Email);
        //		//var claims = new List<Claim>
        //		//{
        //		//	new Claim(ClaimTypes.Name,writerDto.Email)
        //		//};
        //		//var useridentity = new ClaimsIdentity(claims, "a");
        //		//ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //		//await HttpContext.SignInAsync(principal);
        //		return RedirectToAction("Index", "Dashboard");
        //	}
        //	else
        //	{

        //		return View();

        //	}

    
	}
}
