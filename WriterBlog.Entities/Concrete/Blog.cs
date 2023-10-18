﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete
{
    public class Blog : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public int WriterId { get; set; }

        public Category Category { get; set; }
        public Writer Writer { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
