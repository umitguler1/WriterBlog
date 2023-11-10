using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AccountsController(IAuthService authService) => _authService = authService;

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
			string token = _authService.CreateToken(loginDto).Result;
			return token is not null ? Ok(token) : NotFound("Başarısız giriş...");
		}
	}
}
