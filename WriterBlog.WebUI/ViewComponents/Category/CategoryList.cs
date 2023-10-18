using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Category
{
	public class CategoryList : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public CategoryList(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<CategoryDto> categoryDtos = await _categoryService.GetAllCategoryAsync();
			return View(categoryDtos);
		}
	}
}
