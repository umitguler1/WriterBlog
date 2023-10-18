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
	public class NewsLetterDal : RepositoryBase<NewsLetter> , INewsLetterDal
	{
        public NewsLetterDal(Context context) : base(context) 
        {
            
        }
    }
}
