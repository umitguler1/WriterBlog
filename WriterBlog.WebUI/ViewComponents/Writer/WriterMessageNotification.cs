using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.Abstract;

using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessage2Service _message2Service;
		private readonly UserManager<AppUser> _userManager;

		public WriterMessageNotification(IMessage2Service message2Service, UserManager<AppUser> userMenager)
		{
			_message2Service = message2Service;
			_userManager = userMenager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			List<Message2Dto> valuess =  _message2Service.GetInboxListByWriter(values.Id).Result.OrderByDescending(x => x.Id).ToList();
            return View(valuess);
        }

    }
}
