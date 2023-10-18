using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface IContactService 
    {
        Task<bool> AddContactAsync(ContactDto contactDto);
        Task<bool> UpdateContactAsync(ContactDto contactDto);
        Task<bool> DeleteContactAsync(ContactDto contactDto);
        Task<ContactDto> GetContactByIdAsync(int id);
        Task<List<ContactDto>> GetAllContactAsync();
    }
}
