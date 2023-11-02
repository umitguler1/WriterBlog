using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete
{
    public class AppRole : IdentityRole<int>, IEntity
    {
        public bool IsDeleted { get; set; }
    }
}
