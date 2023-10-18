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
    public class WriterMenager : IWriterService
    {

        private readonly IWriterDal _writerDal;
        private readonly IMapper _mapper;

        public WriterMenager(IWriterDal writer, IMapper mapper)
        {
            _writerDal = writer;
            _mapper = mapper;
        }

        public async Task<bool> AddWriterAsync(WriterDto writerDto)
        {
            Writer writer = DtoConvert(writerDto);
            int reponse = await _writerDal.AddAsync(writer);
            return reponse == 0 ? false : true;
        }

        public async Task<bool> DeleteWriterAsync(WriterDto writerDto)
        {
            Writer writer = DtoConvert(writerDto);
            int response = await _writerDal.DeleteAsync(writer);
            return response == 0 ? false : true;
        }

        public async Task<List<WriterDto>> GetAllWriterAsync()
        {
            List<Writer> writers = await _writerDal.GetAllAsync();
            List<WriterDto> writerDtos = new List<WriterDto>();
            foreach (Writer writer in writers)
            {
                WriterDto writerDto = _mapper.Map<WriterDto>(writer);
                writerDtos.Add(writerDto);
            }
            return writerDtos;

        }

        public async Task<WriterDto> GetWriterByIdAsync(int id)
        {
            Writer writer = await _writerDal.GetAsync(x => x.Id == id);
            return _mapper.Map<WriterDto>(writer);
        }

        public async Task<bool> UpdateWriterAsync(WriterDto writerDto)
        {
            Writer writer = _mapper.Map<Writer>(writerDto);
            int response = await _writerDal.UpdateAsync(writer);
            return response > 0;
        }
        public Writer DtoConvert(WriterDto writerDto)
        {
            return _mapper.Map<Writer>(writerDto);
        }
    }
}
