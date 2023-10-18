using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
	public class NewsLetterController : Controller
	{
		private readonly INewsLetterService _newsletterService;

		public NewsLetterController(INewsLetterService newsletterService)
		{
			_newsletterService = newsletterService;
		}

		[HttpGet]
		public async Task<PartialViewResult> SubscribeMailAsync()
		{
			return PartialView();
		}
		[HttpPost]
		public async Task<PartialViewResult> SubscribeMailAsync(NewsLetterDto newsLetterDto)
		{
			_newsletterService.AddNewsLetter(newsLetterDto);
			return PartialView();
		}
	}
}
