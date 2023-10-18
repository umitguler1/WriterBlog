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
	public class NewsLetterManager : INewsLetterService
	{
		private readonly INewsLetterDal _newsLetterDal;
		private readonly Mapper _mapper;
		public NewsLetterManager(INewsLetterDal newsLetterDal, Mapper mapper)
		{
			_newsLetterDal = newsLetterDal;
			_mapper = mapper;
		}



		public async Task AddNewsLetter(NewsLetterDto newsLetterDto)
		{
			NewsLetter newsLetter =  _mapper.Map<NewsLetter>(newsLetterDto);
			_newsLetterDal.Equals(newsLetter);
		}
	}
}
