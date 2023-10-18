﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriterBlog.Entities.Concrete.Dtos
{
    public class AboutDto
    {
        public int Id { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string MapLocation { get; set; }
    }
}
