using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;

namespace WriterBlog.WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public Statistic2(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
           AppUser appUser = _userManager.Users.OrderByDescending(x=>x.Id).FirstOrDefault();
            ViewBag.writer = appUser.NameSurname;
            return View();
        }

    }
}
