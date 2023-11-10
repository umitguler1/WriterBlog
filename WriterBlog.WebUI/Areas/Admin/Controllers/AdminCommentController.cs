using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        private readonly ICommentService _commentService;

        public AdminCommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            List<CommentDto> commentDtos = await _commentService.GetCommentWithBlogAsyn();
            return View(commentDtos);
        }
		public async Task<IActionResult> Delete(int id)
        { 
            CommentDto commentDto =await _commentService.GetCommentByIdAsync(id);
            _commentService.DeleteCommentAsync(commentDto);
            return RedirectToAction("Index");   
        }

	}
}
