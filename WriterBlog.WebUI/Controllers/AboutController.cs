using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;
		

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
			
		}

		public async Task<IActionResult> Index()
		{
			List<AboutDto> aboutDtos = await _aboutService.GetAllAboutAsync();
			return View(aboutDtos);
		}
		public async Task<PartialViewResult> SocialMediaAbout()
		{
			
			return PartialView();
		}
	}
}
