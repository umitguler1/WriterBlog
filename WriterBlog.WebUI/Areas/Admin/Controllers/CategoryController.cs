using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WinterBlog.DataAccess.Repositories;
using WriterBlog.Business.Abstract;
using WriterBlog.Business.ValidationRules;
using WriterBlog.Entities.Concrete.Dtos;



namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int page = 1)
		{
            List<CategoryDto> categoryDtos =await _categoryService.GetAllCategoryAsync();
            return View(categoryDtos);
        }
        [HttpGet]
		public async Task<IActionResult> CategoryAdd()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CategoryAdd(CategoryDto categoryDto)
		{
			CategoryValidator cv = new CategoryValidator();
			ValidationResult result = cv.Validate(categoryDto);
			if (result.IsValid)
			{
				_categoryService.AddCategoryAsync(categoryDto);
				return RedirectToAction("index", "Category");
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
		[HttpGet]
		public async Task<IActionResult> CategoryUpdate(int id)
		{
			CategoryDto categoryDto = await _categoryService.GetCategoryByIdAsync(id);
			return View(categoryDto);
		}
        public async Task<IActionResult> CategoryUpdate(CategoryDto categoryDto)
        {
            bool res = await _categoryService.UpdateCategoryAsync(categoryDto);
            return res? RedirectToAction("index", "Category"): View(categoryDto);
        }
        public async Task<IActionResult> CategoryDelete(int id)
		{
			CategoryDto categoryDto =await _categoryService.GetCategoryByIdAsync(id);
			bool res = await _categoryService.DeleteCategoryAsync(categoryDto);
			return RedirectToAction("index", "Category");
        }

    }
}
