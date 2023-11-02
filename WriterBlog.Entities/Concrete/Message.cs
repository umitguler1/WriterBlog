using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete
{
	public class Message : IEntity
	{
		public int Id { get; set; }
		public string Sender { get; set; }
		public string Receiver { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
	}
}
