using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete
{
    public class Writer : IEntity
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abaut { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

     
        public bool IsDeleted { get; set; }
    }
}
