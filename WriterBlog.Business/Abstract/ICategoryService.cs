using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface ICategoryService
    {
        Task<bool> AddCategoryAsync(CategoryDto categoryDto);
        Task<bool> UpdateCategoryAsync(CategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(CategoryDto categoryDto);
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<List<CategoryDto>> GetAllCategoryAsync();
    }
}
