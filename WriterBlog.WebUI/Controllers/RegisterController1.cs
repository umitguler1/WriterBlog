using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Business.ValidationRules;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
	public class RegisterController1 : Controller
	{
		private readonly IWriterService _writerService;
		WriterValidator validationRules = new WriterValidator();

		public RegisterController1(IWriterService writerService)
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
			ValidationResult result=validationRules.Validate(writerDto);
			if (result.IsValid) 
			{
				writerDto.Abaut = "Deneme Test";
				_writerService.AddWriterAsync(writerDto);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			return View();
			
		}
	}
}
