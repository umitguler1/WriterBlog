using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
	public interface IMessageService
	{
		Task<bool> AddMessageAsync(MessageDto messageDto);
		Task<bool> UpdateMessageAsync(MessageDto messageDto);
		Task<bool> DeleteMessageAsync(MessageDto messageDto);
		Task<MessageDto> GetMessageByIdAsync(int id);
		Task<List<MessageDto>> GetAllMessageAsync(string mail);
	}
}
