using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface ICommentService
    {
        Task<bool> AddCommentAsync(CommentDto commentDto);
        Task<bool> UpdateCommentAsync(CommentDto commentDto);
        Task<bool> DeleteCommentAsync(CommentDto commentDto);
        Task<CommentDto> GetCommentByIdAsync(int id);
        Task<List<CommentDto>> GetAllCommentAsync(int id);
    }
}
