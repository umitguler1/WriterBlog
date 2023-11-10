using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Core.DataAccess.EntityFremawork;
using WriterBlog.Entities.Concrete;

namespace WinterBlog.DataAccess.Repositories
{
    public class CommentDal : RepositoryBase<Comment> , ICommentDal
    {
        public CommentDal(Context context) : base(context) 
        {
            
        }

        public async Task<List<Comment>> GetListWithBlogAsyn()
        {
            using (var c = new Context())
            {
                return  c.Comments.Include(x => x.Blog).ToList();
            }
        }
    }
}
