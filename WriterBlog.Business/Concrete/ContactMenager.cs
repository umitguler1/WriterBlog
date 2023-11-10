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
    public class ContactMenager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IMapper _mapper;

        public ContactMenager(IContactDal contact, IMapper mapper)
        {
            _contactDal = contact;
            _mapper = mapper;
        }

        public async Task<bool> AddContactAsync(ContactDto contactDto)
        {
            Contact contact = DtoConvert(contactDto);
            contact.IsDeleted = false;
            int reponse = await _contactDal.AddAsync(contact);
            return reponse == 0 ? false : true;
        }

        public async Task<bool> DeleteContactAsync(ContactDto contactDto)
        {
            Contact contact = DtoConvert(contactDto);
            int response = await _contactDal.DeleteAsync(contact);
            return response == 0 ? false : true;
        }

        public async Task<List<ContactDto>> GetAllContactAsync()
        {
            List<Contact> contacts = await _contactDal.GetAllAsync();
            List<ContactDto> contactDtos = new List<ContactDto>();
            foreach (Contact contact in contacts)
            {
                ContactDto contactDto = _mapper.Map<ContactDto>(contact);
                contactDtos.Add(contactDto);
            }
            return contactDtos;

        }

        public async Task<ContactDto> GetContactByIdAsync(int id)
        {
            Contact contact = await _contactDal.GetAsync(x => x.Id == id);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<bool> UpdateContactAsync(ContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            int response = await _contactDal.UpdateAsync(contact);
            return response > 0;
        }
        public Contact DtoConvert(ContactDto contactDto)
        {
            return _mapper.Map<Contact>(contactDto);
        }
    }
}
