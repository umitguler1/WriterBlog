using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface IMessage2Service
    {
        Task<bool> AddMessage2Async(Message2Dto message2Dto);
        Task<bool> UpdateMessage2Async(Message2Dto message2Dto);
        Task<bool> DeleteMessage2Async(Message2Dto message2Dto);
        Task<Message2Dto> GetMessage2ByIdAsync(int id);
        Task<List<Message2Dto>> GetAllMessage2Async(int id);
        Task<List<Message2Dto>> GetInboxListByWriter(int id);
        Task<List<Message2Dto>> GetSendBoxListByWriter(int id);
    }
}
