
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private readonly IMessage2Service _message2Service;
        private readonly UserManager<AppUser> _userManager;
        public AdminMessageController(IMessage2Service message2Service, UserManager<AppUser> userManager)
        {
            _message2Service = message2Service;
            _userManager = userManager;
        }


        public async Task<IActionResult> InBox()
        {

            var person = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Message2Dto> value = _message2Service.GetInboxListByWriter(person.Id).Result.OrderByDescending(x => x.CreateDate).ToList();
            return View(value);
        }
        public async Task<IActionResult> SendBox()
        {

            var person = await _userManager.FindByNameAsync(User.Identity.Name);
            var value =  _message2Service.GetSendBoxListByWriter(person.Id).Result.OrderByDescending(x => x.CreateDate).ToList();
            return View(value);
        }
        public async Task<IActionResult> ComposeMessage()
        {
            List<SelectListItem> receiverValues = (from x in _userManager.Users.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Email,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
            ViewBag.rva = receiverValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ComposeMessage(Message2Dto message2)
        {
            var person = await _userManager.FindByNameAsync(User.Identity.Name);
            message2.SenderId = person.Id;
            message2.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2.IsDeleted = false;
            _message2Service.AddMessage2Async(message2);
            return RedirectToAction("SendBox");
        }
        public async Task<IActionResult> Details(int id)
        {
            Message2Dto message2Dto = await _message2Service.GetMessage2ByIdAsync(id);
            message2Dto.Read = true;
            _message2Service.UpdateMessage2Async(message2Dto);
            return View(message2Dto);
        }
		public async Task<IActionResult> Delete(int id)
		{
			Message2Dto message2Dto = await _message2Service.GetMessage2ByIdAsync(id);
			_message2Service.DeleteMessage2Async(message2Dto);
			return RedirectToAction("inbox");
		}
	}
}
