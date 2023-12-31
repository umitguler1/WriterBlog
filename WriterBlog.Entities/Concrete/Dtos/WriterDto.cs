﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete.Dtos
{
    public class WriterDto : IDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Abaut { get; set; }
		public string Image { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public List<Blog> Blogs { get; set; }
		public virtual ICollection<Message2> WriterSender { get; set; }
		public virtual ICollection<Message2> WriterReceiver { get; set; }
	}
}
