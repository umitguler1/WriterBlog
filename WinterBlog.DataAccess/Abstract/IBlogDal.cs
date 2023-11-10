﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.DataAccess;
using WriterBlog.Entities.Concrete;

namespace WinterBlog.DataAccess.Abstract
{
    public interface IBlogDal : IRepositoryBase<Blog>
    {
        Task<List<Blog>> GetListWithCategoryAsyn();
        Task<List<Blog>> GetListWithCategory2Asyn(int id);
    }
}
