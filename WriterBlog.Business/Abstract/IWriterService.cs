using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface IWriterService
    {
        Task<bool> AddWriterAsync(WriterDto writerDto);
        Task<bool> UpdateWriterAsync(WriterDto writerDto);
        Task<bool> DeleteWriterAsync(WriterDto writerDto);
        Task<WriterDto> GetWriterByIdAsync(int id);
        Task<List<WriterDto>> GetAllWriterAsync();
    }
}
