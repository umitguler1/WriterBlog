using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }
    }
}
