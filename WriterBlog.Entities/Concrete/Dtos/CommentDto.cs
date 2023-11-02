using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriterBlog.Entities.Concrete.Dtos
{
    public class CommentDto
    {
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreateDate { get; set; }
		public int BlogScore { get; set; }
		public bool IsDeleted { get; set; }
		public int BlogID { get; set; }

		public Blog Blog { get; set; }
	}
}
