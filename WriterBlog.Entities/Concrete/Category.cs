using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
