using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminNaotificationController : Controller
	{
		private readonly INotificationService _notificationService;

		public AdminNaotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> AllNotification()
		{
			var values =  _notificationService.GetAllNotificationAsync().Result.OrderByDescending(x=>x.Id).ToList();
			return View(values);
		}
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _notificationService.GetNotificationByIdAsync(id);
			_notificationService.DeleteNotificationAsync(values);
            return RedirectToAction("AllNotification");
        }
		[HttpGet]
        public async Task<IActionResult> AddNotification()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> AddNotification(NotificationDto notificationDto)
        {
			bool res = await _notificationService.AddNotificationAsync(notificationDto);
            return res? RedirectToAction("AllNotification") : View(notificationDto);
        }
    }
}
