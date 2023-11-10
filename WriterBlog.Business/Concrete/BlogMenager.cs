using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;
using WriterBlog.Entities.Concrete;
using System.Reflection.Metadata;

namespace WriterBlog.Business.Concrete
{
    public class BlogMenager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IMapper _mapper;

        public BlogMenager(IBlogDal blog, IMapper mapper)
        {
            _blogDal = blog;
            _mapper = mapper;
        }

        public async Task<bool> AddBlogAsync(BlogDto blogDto)
        {
            Blog blog = DtoConvert(blogDto);
            blog.IsDeleted = false;
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            int reponse = await _blogDal.AddAsync(blog);
            return reponse == 0 ? false : true;
        }

        public async Task<bool> DeleteBlogAsync(BlogDto blogDto)
        {
            Blog blog = DtoConvert(blogDto);
            int response = await _blogDal.DeleteAsync(blog);
            return response == 0 ? false : true;
        }

        public async Task<List<BlogDto>> GetAllBlogAsync()
        {
            List<Blog> blogs = await _blogDal.GetAllAsync();
            List<BlogDto> blogDtos = new List<BlogDto>();
            foreach (Blog blog in blogs)
            {
                BlogDto blogDto = _mapper.Map<BlogDto>(blog);
                blogDtos.Add(blogDto);
            }
            return blogDtos;

        }

        public async Task<BlogDto> GetBlogByIdAsync(int id)
        {
            Blog blog = await _blogDal.GetAsync(x => x.Id == id);
            return _mapper.Map<BlogDto>(blog);
        }

        public async Task<bool> UpdateBlogAsync(BlogDto blogDto)
        {
            Blog blog = _mapper.Map<Blog>(blogDto);
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            int response = await _blogDal.UpdateAsync(blog);
            return response > 0;
        }
        public Blog DtoConvert(BlogDto blogDto)
        {
            return _mapper.Map<Blog>(blogDto);
        }

		public async Task<List<BlogDto>> GetBlogWithCategoryAsyn()
		{
            List<Blog> blogs = await _blogDal.GetListWithCategoryAsyn();
			List<BlogDto> blogDtos = new List<BlogDto>();
			foreach (Blog blog in blogs)
			{
				BlogDto blogDto = _mapper.Map<BlogDto>(blog);
				blogDtos.Add(blogDto);
			}
			return blogDtos;
		}

		public async Task<List<BlogDto>> GetBlogListByWriterAsyn(int id)
		{
			List<Blog> blogs= await _blogDal.GetAllAsync(x=>x.WriterId==id);
			List<BlogDto> blogDtos = new List<BlogDto>();
			foreach (Blog blog in blogs)
			{
				BlogDto blogDto = _mapper.Map<BlogDto>(blog);
				blogDtos.Add(blogDto);
			}
			return blogDtos;
		}

		public async Task<List<BlogDto>> GetBlogLast3PostAsyn()
		{
			List<Blog> blogs = _blogDal.GetAllAsync().Result.Take(3).ToList();
			List<BlogDto> blogDtos = new List<BlogDto>();
			foreach (Blog blog in blogs)
			{
				BlogDto blogDto = _mapper.Map<BlogDto>(blog);
				blogDtos.Add(blogDto);
			}
			return blogDtos;
		}

        public async Task<List<BlogDto>> GetListWithCategory2Asyn(int id)
        {
            List<Blog> blogs = await _blogDal.GetListWithCategory2Asyn(id);
            List<BlogDto> blogDtos = new List<BlogDto>();
            foreach (Blog blog in blogs)
            {
                BlogDto blogDto = _mapper.Map<BlogDto>(blog);
                blogDtos.Add(blogDto);
            }
            return blogDtos;
        }
    }
}
