using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
	public interface INewsLetterService
	{
		Task AddNewsLetter(NewsLetterDto newsLetterDto);
	}
}
