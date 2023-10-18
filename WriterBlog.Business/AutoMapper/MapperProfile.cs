using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<Writer, WriterDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<NewsLetter, NewsLetterDto>().ReverseMap();
        }
    }
}
