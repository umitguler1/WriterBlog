
using DocumentFormat.OpenXml.Office2010.Excel;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WinterBlog.DataAccess.Concrete;
using WinterBlog.DataAccess.Repositories;
using WriterBlog.Business.Abstract;
using WriterBlog.Business.ValidationRules;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;
        BlogValidator validationRules = new BlogValidator();
        public BlogController(IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager, ICommentService commentService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userManager = userManager;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
          
            List<BlogDto> list =  _blogService.GetBlogWithCategoryAsyn().Result.OrderByDescending(x=>x.Id).ToList();
           
            return View(list);
        }
        static int d;
		public async Task<IActionResult> Details(int id)
		{
       
            ViewBag.Id = id;
            TempData["BlogId"] = id;

            d++;
            ViewBag.comment = _commentService.GetAllCommentAsync(id).Result.Count;
            BlogDto blogDto = await _blogService.GetBlogByIdAsync(id);
			return View(blogDto);
       
		}
        [Authorize(Roles = "Writer,Admin")]
        public async Task<IActionResult> BlogListByWriter()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            List<BlogDto> blogDtos =  _blogService.GetBlogListByWriterAsyn(values.Id).Result.OrderByDescending(x=>x.CreateDate).ToList();
            return View(blogDtos);
        }
        [Authorize(Roles = "Writer,Admin")]
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
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            ValidationResult result =  validationRules.Validate(blogDto);
            if (result.IsValid)
            {
                blogDto.WriterId = values.Id;

             
               bool s= await _blogService.AddBlogAsync(blogDto);
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
        [Authorize(Roles = "Writer,Admin")]
        public async Task<IActionResult> BlogRemove(int id)
        {
            BlogDto blogdto = await _blogService.GetBlogByIdAsync(id);
            _blogService.DeleteBlogAsync(blogdto);
            return RedirectToAction("BlogListByWriter");
        }
        [Authorize(Roles = "Writer,Admin")]
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
