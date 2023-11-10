using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
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
				bool res =await _writerService.AddWriterAsync(writerDto);
				//Sentry ekleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
				//Resimleri binary olarak kaydedetmeyi yap aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
				//if (res)
				//{
				//	MailMessage mailMessage = new MailMessage();
				//	mailMessage.From=new MailAddress("");
				//	mailMessage.Subject = "Hoşgeldiniz.";
				//	SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
    //                {
    //                    UseDefaultCredentials = false,
    //                    DeliveryMethod = SmtpDeliveryMethod.Network,
    //                    Credentials = new NetworkCredential("userAddress", "userPassword"),
    //                    Port = 587,
    //                    EnableSsl = true,
    //                }; 
					
				//}
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
