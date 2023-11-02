using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
	public interface IAuthService
	{
		Task<IdentityResult> AddRoleToUser(AppUser user);
		Task<SignInResult> Login(LoginDto loginDto);
		Task<IdentityResult> Register(RegisterDto registerDto);
	
		Task<string> CreateToken(LoginDto loginDto);
		Task Logout();
	}
}
