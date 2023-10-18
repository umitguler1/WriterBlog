using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriterBlog.Entities.Concrete.Dtos
{
	public class NewsLetterDto
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public bool IsDeleted { get; set; }
	}
}
