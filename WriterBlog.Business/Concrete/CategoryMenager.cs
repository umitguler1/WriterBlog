using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Concrete
{
    public class CategoryMenager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryMenager(ICategoryDal category, IMapper mapper)
        {
            _categoryDal = category;
            _mapper = mapper;
        }

        public async Task<bool> AddCategoryAsync(CategoryDto categoryDto)
        {
            Category category = DtoConvert(categoryDto);
            int reponse= await _categoryDal.AddAsync(category);
            return reponse == 0?false: true;
        }

        public async Task<bool> DeleteCategoryAsync(CategoryDto categoryDto)
        {
            Category category= DtoConvert(categoryDto);
            int response = await _categoryDal.DeleteAsync(category);
            return response == 0?false: true;
        }

        public async Task<List<CategoryDto>> GetAllCategoryAsync()
        {
            List<Category> categories = await _categoryDal.GetAllAsync();
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (Category category in categories)
            {
                CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);   
                categoryDtos.Add(categoryDto);
            }
            return categoryDtos;
           
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            Category category = await _categoryDal.GetAsync(x=>x.Id==id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> UpdateCategoryAsync(CategoryDto categoryDto)
        {
            Category category=  _mapper.Map<Category>(categoryDto);
            int response = await _categoryDal.UpdateAsync(category);
            return response > 0;
        }
        public Category DtoConvert(CategoryDto categoryDto)
        {
            return _mapper.Map<Category>(categoryDto);
        }
    }
}
