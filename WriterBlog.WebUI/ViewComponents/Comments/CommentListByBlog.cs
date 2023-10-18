using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.ViewComponents.Comments
{
	public class CommentListByBlog : ViewComponent
	{
		private readonly ICommentService _commentService;

		public CommentListByBlog(ICommentService commentService)
		{
			_commentService = commentService;
		}
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			List<CommentDto> comments = await _commentService.GetAllCommentAsync(id);
			return View(comments);
		}
	}
}
