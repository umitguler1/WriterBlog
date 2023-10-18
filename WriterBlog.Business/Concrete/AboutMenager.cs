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
    public class AboutMenager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IMapper _mapper;

        public AboutMenager(IAboutDal about, IMapper mapper)
        {
            _aboutDal = about;
            _mapper = mapper;
        }

        public async Task<bool> AddAboutAsync(AboutDto aboutDto)
        {
            About about = DtoConvert(aboutDto);
            int reponse = await _aboutDal.AddAsync(about);
            return reponse == 0 ? false : true;
        }

        public async Task<bool> DeleteAboutAsync(AboutDto aboutDto)
        {
            About about = DtoConvert(aboutDto);
            int response = await _aboutDal.DeleteAsync(about);
            return response == 0 ? false : true;
        }

        public async Task<List<AboutDto>> GetAllAboutAsync()
        {
            List<About> abouts = await _aboutDal.GetAllAsync();
            List<AboutDto> aboutDtos = new List<AboutDto>();
            foreach (About about in abouts)
            {
                AboutDto aboutDto = _mapper.Map<AboutDto>(about);
                aboutDtos.Add(aboutDto);
            }
            return aboutDtos;

        }

        public async Task<AboutDto> GetAboutByIdAsync(int id)
        {
            About about = await _aboutDal.GetAsync(x => x.Id == id);
            return _mapper.Map<AboutDto>(about);
        }

        public async Task<bool> UpdateAboutAsync(AboutDto aboutDto)
        {
            About about = _mapper.Map<About>(aboutDto);
            int response = await _aboutDal.UpdateAsync(about);
            return response > 0;
        }
        public About DtoConvert(AboutDto aboutDto)
        {
            return _mapper.Map<About>(aboutDto);
        }
    }
}
