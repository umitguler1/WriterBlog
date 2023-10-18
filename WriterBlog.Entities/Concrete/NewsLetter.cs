using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete
{
	public class NewsLetter : IEntity
	{
		[Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
