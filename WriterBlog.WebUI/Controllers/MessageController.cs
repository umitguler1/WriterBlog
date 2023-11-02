using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessage2Service _message2Service;

        public MessageController(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public async Task<IActionResult> InBox()
        {
            List<Message2Dto> values = await _message2Service.GetInboxListByWriter(2);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetails(int id)
        {
            Message2Dto message2Dto = await _message2Service.GetMessage2ByIdAsync(id);
            return View(message2Dto);
        }
    }
}
