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
	public class MessageMenager : IMessageService
	{
		private readonly IMessageDal _messageDal;
		private readonly IMapper _mapper;

		public MessageMenager(IMapper mapper, IMessageDal messageDal)
		{
			_mapper = mapper;
			_messageDal = messageDal;
		}

		public async Task<bool> AddMessageAsync(MessageDto messageDto)
		{
			Message message = DtoConvert(messageDto);
			int reponse = await _messageDal.AddAsync(message);
			return reponse == 0 ? false : true;
		}

		public async Task<bool> DeleteMessageAsync(MessageDto messageDto)
		{
			Message message = DtoConvert(messageDto);
			int response = await _messageDal.DeleteAsync(message);
			return response == 0 ? false : true;
		}

		public async Task<List<MessageDto>> GetAllMessageAsync(string mail)
		{
			List<Message> messages = await _messageDal.GetAllAsync(x=>x.Receiver==mail);
			List<MessageDto> messageDtos = new List<MessageDto>();
			foreach (Message item in messages)
			{
				MessageDto messageDto = _mapper.Map<MessageDto>(item);
				messageDtos.Add(messageDto);
			}
			return messageDtos;

		}

		public async Task<MessageDto> GetMessageByIdAsync(int id)
		{
			Message message = await _messageDal.GetAsync(x => x.Id == id);
			return _mapper.Map<MessageDto>(message);
		}

		public async Task<bool> UpdateMessageAsync(MessageDto messageDto)
		{
			Message message = _mapper.Map<Message>(messageDto);
			int response = await _messageDal.UpdateAsync(message);
			return response > 0;
		}
		public Message DtoConvert(MessageDto messageDto)
		{
			return _mapper.Map<Message>(messageDto);
		}
	}
}
