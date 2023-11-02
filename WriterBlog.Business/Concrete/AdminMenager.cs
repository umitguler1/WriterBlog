using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WriterBlog.Entities.Concrete.Dtos;
using WriterBlog.Entities.Concrete;

namespace WriterBlog.Business.Concrete
{
    public class AdminMenager
    {
        private readonly IAdminDal _adminDal;
        private readonly IMapper _mapper;

        public AdminMenager(IAdminDal adminDal, IMapper mapper)
        {
            _adminDal = adminDal;
            _mapper = mapper;
        }

        public async Task<bool> AddAdminAsync(AdminDto adminDto)
        {
            Admin admin = DtoConvert(adminDto);
            int reponse = await _adminDal.AddAsync(admin);
            return reponse == 0 ? false : true;
        }

        public async Task<bool> DeleteAdminAsync(AdminDto adminDto)
        {
            Admin admin = DtoConvert(adminDto);
            int response = await _adminDal.DeleteAsync(admin);
            return response == 0 ? false : true;
        }

        public async Task<List<AdminDto>> GetAllAdminAsync()
        {
            List<Admin> admins = await _adminDal.GetAllAsync();
            List<AdminDto> adminDtos = new List<AdminDto>();
            foreach (Admin admin in admins)
            {
                AdminDto adminDto = _mapper.Map<AdminDto>(admin);
                adminDtos.Add(adminDto);
            }
            return adminDtos;

        }

        public async Task<AdminDto> GetAdminByIdAsync(int id)
        {
           Admin admin = await _adminDal.GetAsync(x => x.Id == id);
            return _mapper.Map<AdminDto>(admin);
        }

        public async Task<bool> UpdateAdminAsync(AdminDto adminDto)
        {
            Admin admin = _mapper.Map<Admin>(adminDto);
            int response = await _adminDal.UpdateAsync(admin);
            return response > 0;
        }
        public Admin DtoConvert(AdminDto adminDto)
        {
            return _mapper.Map<Admin>(adminDto);
        }
    }
}
