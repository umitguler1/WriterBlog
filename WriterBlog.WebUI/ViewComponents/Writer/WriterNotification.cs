using Microsoft.AspNetCore.Mvc;

namespace WriterBlog.WebUI.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }

    }
}
