using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.WebUI.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;
		private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public IActionResult Index()
		{
			return View();
		}
	
	
		[HttpGet]
		public async Task<PartialViewResult> PartialAddComment()
		{
			return PartialView();
		}
		static int id;
        //[Authorize(Roles = "Member,Writer,Admin,Moderator")]
        [HttpPost]
		public async Task<IActionResult> PartialAddComment(CommentDto commentDto)
		{
			try
			{
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                if (values is not null)
                {
                    id = int.Parse((TempData["BlogId"]).ToString());
                    commentDto.BlogID = id;
                    commentDto.BlogScore = 5;
                    _commentService.AddCommentAsync(commentDto);
                    return RedirectToAction("Details", "Blog", new { id });
                }
                else { return RedirectToAction("index", "Login"); }
            }
			catch (Exception)
			{

                return RedirectToAction("index", "Login");
            }
    
		}
		public async Task<PartialViewResult> CommentListByBlog(int id)
		{
			List<CommentDto> comments = await _commentService.GetAllCommentAsync(id);
			return PartialView(comments);
		}

	}
}
