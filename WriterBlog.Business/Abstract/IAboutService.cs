using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface IAboutService
    {
        Task<bool> AddAboutAsync(AboutDto aboutDto);
        Task<bool> UpdateAboutAsync(AboutDto aboutDto);
        Task<bool> DeleteAboutAsync(AboutDto aboutDto);
        Task<AboutDto> GetAboutByIdAsync(int id);
        Task<List<AboutDto>> GetAllAboutAsync();
    }
}
