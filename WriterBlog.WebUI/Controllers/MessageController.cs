using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
    [Authorize(Roles = "Writer,Admin,Moderator")]
    public class MessageController : Controller
    {
        private readonly IMessage2Service _message2Service;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessage2Service message2Service, UserManager<AppUser> userManager)
        {
            _message2Service = message2Service;
            _userManager = userManager;
        }
       
        public async Task<IActionResult> InBox()
        {
            var person = _userManager.FindByNameAsync(User.Identity.Name).Result;
            List<Message2Dto> values =  _message2Service.GetInboxListByWriter(person.Id).Result.OrderByDescending(x => x.Id).ToList();
            return View(values);
        }
        public async Task<IActionResult> SendBox()
        {
            var person = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Message2Dto> values = _message2Service.GetSendBoxListByWriter(person.Id).Result.OrderByDescending(x => x.Id).ToList();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> MessageDetails(int id)
        {
            Message2Dto message2Dto = await _message2Service.GetMessage2ByIdAsync(id);
            message2Dto.Read = true;
            _message2Service.UpdateMessage2Async(message2Dto);
            return View(message2Dto);
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            List<SelectListItem> receiverValues = (from x in  _userManager.Users.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Email,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
            ViewBag.rv = receiverValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message2Dto message2Dto)
        {
            var person = await _userManager.FindByNameAsync(User.Identity.Name);
            message2Dto.SenderId = person.Id;
            
            message2Dto.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _message2Service.AddMessage2Async(message2Dto);
            return RedirectToAction("InBox");
        }
        public async Task<IActionResult> Delete(int id) 
        {
            Message2Dto message2Dto = await _message2Service.GetMessage2ByIdAsync(id);
            _message2Service.DeleteMessage2Async(message2Dto);
            return RedirectToAction("inbox"); 
        }
    }
}
