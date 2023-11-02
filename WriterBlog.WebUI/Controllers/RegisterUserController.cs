using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;
using WriterBlog.WebUI.Models;

namespace WriterBlog.WebUI.Controllers
{
    public class RegisterUserController : Controller
    {
        private readonly IAuthService _authService;

		public RegisterUserController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _authService.Register(registerDto);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(registerDto);
        }
    }
}
