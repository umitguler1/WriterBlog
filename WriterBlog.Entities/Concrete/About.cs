using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string MapLocation { get; set; }
        public bool IsDeleted { get; set; }
    }
}
