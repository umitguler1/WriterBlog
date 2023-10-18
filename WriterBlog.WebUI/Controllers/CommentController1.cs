using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
	public class CommentController1 : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController1(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<PartialViewResult> PartialAddComment()
		{
			return  PartialView();
		}
		[HttpPost]
		public async Task<PartialViewResult> PartialAddComment(CommentDto commentDto)
		{
			commentDto.BlogID = 2;
			_commentService.AddCommentAsync(commentDto);
			return PartialView();
		}
		public async Task<PartialViewResult> CommentListByBlog(int id)
		{
			List<CommentDto> comments = await _commentService.GetAllCommentAsync(id);
			return PartialView(comments);
		}
	}
}
