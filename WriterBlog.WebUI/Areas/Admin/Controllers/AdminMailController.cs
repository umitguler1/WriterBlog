using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMailController : Controller
	{
		private readonly IContactService _contactService;

		public AdminMailController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<IActionResult> Index()
		{
			List<ContactDto> contactDtos =  _contactService.GetAllContactAsync().Result.OrderByDescending(x=>x.CreateDate).ToList();
			return View(contactDtos);
		}
		public async Task<IActionResult> Details(int id)
		{
			ContactDto contactDto =await _contactService.GetContactByIdAsync(id);
			contactDto.Read = true;
			_contactService.UpdateContactAsync(contactDto);
			return View(contactDto);
		}
		public async Task<IActionResult> Delete(int id)
		{
            ContactDto contactDto = await _contactService.GetContactByIdAsync(id);
           bool res=await _contactService.DeleteContactAsync(contactDto);
			return res? RedirectToAction("Index"):RedirectToAction("Details",id);
		}
	}
}
