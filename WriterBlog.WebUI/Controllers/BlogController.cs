
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WinterBlog.DataAccess.Repositories;
using WriterBlog.Business.Abstract;
using WriterBlog.Business.ValidationRules;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        BlogValidator validationRules = new BlogValidator();
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogDto> list = await _blogService.GetBlogWithCategoryAsyn();
            return View(list);
        }
        static int d;
		public async Task<IActionResult> Details(int id)
		{
       
            ViewBag.Id = id;

            d++;
			BlogDto blogDto = await _blogService.GetBlogByIdAsync(id);
			return View(blogDto);
       
		}
      
        public async Task<IActionResult> BlogListByWriter()
        {
            
           List<BlogDto> blogDtos = await _blogService.GetBlogListByWriterAsyn(1);
            return View(blogDtos);
        }
       
        [HttpGet]
        public async Task<IActionResult> BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in await _categoryService.GetAllCategoryAsync()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogAdd(BlogDto blogDto)
        {

            ValidationResult result =  validationRules.Validate(blogDto);
            if (result.IsValid)
            {
                blogDto.WriterId = 1;

             
                _blogService.AddBlogAsync(blogDto);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        public async Task<IActionResult> BlogRemove(int id)
        {
            BlogDto blogdto = await _blogService.GetBlogByIdAsync(id);
            _blogService.DeleteBlogAsync(blogdto);
            return RedirectToAction("BlogListByWriter");
        }
      
        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            List<SelectListItem> categoryValues = (from x in await _categoryService.GetAllCategoryAsync()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
            ViewBag.cvupdate = categoryValues;

            BlogDto blogDto = await _blogService.GetBlogByIdAsync(id);
            return View(blogDto);
        }
        [HttpPost]
		public async Task<IActionResult> UpdateBlog(BlogDto blogDto)
		{
            
           bool response = await _blogService.UpdateBlogAsync(blogDto);
            return response ? RedirectToAction("BlogListByWriter") : View(blogDto);

            
		}
	}
}
