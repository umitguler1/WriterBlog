using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Category
{
	public class CategoryListDashboard : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public CategoryListDashboard(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var categoryDtos = await _categoryService.GetAllCategoryAsync();
			return View(categoryDtos);
		}
	}
}
