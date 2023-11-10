using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;
using WriterBlog.WebUI.Models;
using WriterBlog.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

using WriterBlog.Business.Concrete;

namespace WriterBlog.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IWriterService _writerService;
		private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userMenager; 
        private readonly SignInManager<AppUser> _signInManager;

		public LoginController(IWriterService writerService, IAuthService authService, SignInManager<AppUser> signInManager, UserManager<AppUser> userMenager)
		{
			_writerService = writerService;
			_authService = authService;
			_signInManager = signInManager;
			_userMenager = userMenager;
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
					var values = await _userMenager.FindByNameAsync(loginDto.UserName);
					var userRoles = await _userMenager.GetRolesAsync(values);
                    string photo = values.ImageUrl;
                    ViewData["i"] = photo;
					bool user;
					bool admin;
					bool writer;
					foreach (var role in userRoles) {
                        admin= userRoles.Contains("Admin");
                        user= userRoles.Contains("Member");
                        writer= userRoles.Contains("Writer");
						
                        if (admin)
                        {
							return RedirectToAction("Index", "Widget",new {area="Admin"});
						}
                        else if (user)
                        {
							return RedirectToAction("Index", "Blog");
						}
                        else if (writer)
                        {
							return RedirectToAction("Index", "Dashboard");
						}
                    }
                
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
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }

        }
}
