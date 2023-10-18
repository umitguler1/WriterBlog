using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete
{
    public class Comment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int BlogID { get; set; }

        public Blog Blog { get; set; }
    }
}
