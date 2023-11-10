using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Concrete
{
    public class CommentMenager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IMapper _mapper;

        public CommentMenager(ICommentDal comment, IMapper mapper)
        {
            _commentDal = comment;
            _mapper = mapper;
        }

        public async Task<bool> AddCommentAsync(CommentDto commentDto)
        {
            Comment comment = DtoConvert(commentDto);
            comment.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
			int reponse = await _commentDal.AddAsync(comment);
            return reponse == 0 ? false : true;
        }

        public async Task<bool> DeleteCommentAsync(CommentDto commentDto)
        {
            Comment comment = DtoConvert(commentDto);
            int response = await _commentDal.DeleteAsync(comment);
            return response == 0 ? false : true;
        }

        public async Task<List<CommentDto>> GetAllCommentAsync(int id)
        {
            List<Comment> comments = await _commentDal.GetAllAsync(x=>x.BlogID==id);
            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (Comment comment in comments)
            {
                CommentDto commentDto = _mapper.Map<CommentDto>(comment);
                commentDtos.Add(commentDto);
            }
            return commentDtos;

        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            Comment comment = await _commentDal.GetAsync(x => x.Id == id);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<bool> UpdateCommentAsync(CommentDto commentDto)
        {
            Comment comment = _mapper.Map<Comment>(commentDto);
            int response = await _commentDal.UpdateAsync(comment);
            return response > 0;
        }
        public Comment DtoConvert(CommentDto commentDto)
        {
            return _mapper.Map<Comment>(commentDto);
        }

        public async Task<List<CommentDto>> GetAllCommentNoIdAsync()
        {
            List<Comment> comments = await _commentDal.GetAllAsync();
            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (Comment comment in comments)
            {
                CommentDto commentDto = _mapper.Map<CommentDto>(comment);
                commentDtos.Add(commentDto);
            }
            return commentDtos;
        }

        public async Task<List<CommentDto>> GetCommentWithBlogAsyn()
        {
            List<Comment> comments = await _commentDal.GetListWithBlogAsyn();
            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (Comment comment in comments)
            {
                CommentDto commentDto = _mapper.Map<CommentDto>(comment);
                commentDtos.Add(commentDto);
            }
            return commentDtos;
        }
    }
}
