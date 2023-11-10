using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;
using WriterBlog.WebUI.Areas.Admin.Models;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogAdmnController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogAdmnController(IBlogService blogService)
        {
            _blogService = blogService;
            }

            public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ExportDynamicBlogList()
        {
            List<BlogDto> blogDtos = await _blogService.GetAllBlogAsync();
            List<BlogModel2> blogModels = new List<BlogModel2>();
            foreach (var item in blogDtos)
            {
                blogModels.Add(new BlogModel2()
                {
                    Id = item.Id,
                    BlogName = item.Title

                });
            }
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in blogModels)
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }

        }
        public async Task<IActionResult> BlogTitleListExcel()
        {
            return View();
        }


    }
}
