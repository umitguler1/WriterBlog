using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessage2Service _message2Service;

		public WriterMessageNotification(IMessage2Service message2Service)
		{
			_message2Service = message2Service;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Message2Dto> values = await _message2Service.GetInboxListByWriter(2);
            return View(values);
        }

    }
}
