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
	public class BlogDal : RepositoryBase<Blog>, IBlogDal
    {
        public BlogDal(Context context) : base(context)
        {

        }

		public async Task<List<Blog>> GetListWithCategoryAsyn()
		{
			using (var c=new Context())
			{
				return await c.Blogs.Include(x=>x.Category).ToListAsync();
			}
		}
	}
}
