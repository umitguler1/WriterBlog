using Microsoft.AspNetCore.Mvc;

namespace WriterBlog.WebUI.Controllers
{
	public class ErrorPageController : Controller
	{
		public async Task<IActionResult> Error1(int code)
		{
			return View();
		}
	}
}
