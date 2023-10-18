using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
    
    public class WriterController : Controller
	{
		public async Task<IActionResult> Index()
		{
			return View();
		}
		public async Task<IActionResult> Test()
		{
			return View();
		}
		public async Task<PartialViewResult> WriterNawbarPartial()
		{
			return PartialView();
		}
        public async Task<PartialViewResult> WriterFooterPartial()
        {
            return PartialView();
        }
    }
}
