using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;
using WriterBlog.Entities.Concrete;

namespace WriterBlog.Business.Concrete
{
    public class Message2Menager : IMessage2Service
    {
        private readonly IMessage2Dal _message2Dal;
        private readonly IMapper _mapper;

        public Message2Menager(IMapper mapper, IMessage2Dal message2Dal)
        {
            _mapper = mapper;
            _message2Dal = message2Dal;
        }

        public async Task<bool> AddMessage2Async(Message2Dto message2Dto)
        {
            Message2 message2 = DtoConvert(message2Dto);
            int reponse = await _message2Dal.AddAsync(message2);
            return reponse == 0 ? false : true;
        }

        public async Task<bool> DeleteMessage2Async(Message2Dto message2Dto)
        {
            Message2 message2 = DtoConvert(message2Dto);
            int response = await _message2Dal.DeleteAsync(message2);
            return response == 0 ? false : true;
        }

        public async Task<List<Message2Dto>> GetAllMessage2Async(int id)
        {
            List<Message2> message2s = await _message2Dal.GetAllAsync(x => x.ReceiverId == id);
            List<Message2Dto> message2Dtos = new List<Message2Dto>();
            foreach (Message2 item in message2s)
            {
                Message2Dto message2Dto = _mapper.Map<Message2Dto>(item);
                message2Dtos.Add(message2Dto);
            }
            return message2Dtos;

        }

        public async Task<Message2Dto> GetMessage2ByIdAsync(int id)
        {
            Message2 message2 = await _message2Dal.GetAsync(x => x.Id == id);
            return _mapper.Map<Message2Dto>(message2);
        }

        public async Task<bool> UpdateMessage2Async(Message2Dto message2Dto)
        {
            Message2 message2 = _mapper.Map<Message2>(message2Dto);
            int response = await _message2Dal.UpdateAsync(message2);
            return response > 0;
        }
        public Message2 DtoConvert(Message2Dto message2Dto)
        {
            return _mapper.Map<Message2>(message2Dto);
        }

        public async Task<List<Message2Dto>> GetInboxListByWriter(int id)
        {
            List<Message2> message2s = await _message2Dal.GetListWithMessageByWriter(id);
            List<Message2Dto> message2Dtos = new List<Message2Dto>();
            foreach (Message2 item in message2s)
            {
                Message2Dto message2Dto = _mapper.Map<Message2Dto>(item);
                message2Dtos.Add(message2Dto);
            }
            return message2Dtos;

        }
    }
}
