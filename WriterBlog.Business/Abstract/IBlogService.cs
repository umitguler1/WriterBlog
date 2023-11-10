using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface IBlogService
    {
        Task<bool> AddBlogAsync(BlogDto blogDto);
        Task<bool> UpdateBlogAsync(BlogDto blogDto);
        Task<bool> DeleteBlogAsync(BlogDto blogDto);
        Task<BlogDto> GetBlogByIdAsync(int id);
        Task<List<BlogDto>> GetAllBlogAsync();
		Task<List<BlogDto>> GetBlogWithCategoryAsyn();
		Task<List<BlogDto>> GetListWithCategory2Asyn(int id);
		Task<List<BlogDto>> GetBlogLast3PostAsyn();
		Task<List<BlogDto>> GetBlogListByWriterAsyn(int id);
	}
}
