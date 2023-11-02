using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface IAdminService
    {
        Task<bool> AddAdminAsync(AdminDto adminDto);
        Task<bool> UpdateAdminAsync(AdminDto adminDto);
        Task<bool> DeleteAdminAsync(AdminDto adminDto);
        Task<AdminDto> GetAdminByIdAsync(int id);
        Task<List<AdminDto>> GetAllAdminAsync();
    }
}
