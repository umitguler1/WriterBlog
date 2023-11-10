using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Concrete
{
	public class AuthMenager : IAuthService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IMapper _mapper;

		public AuthMenager(IMapper mapper, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_mapper = mapper;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public Task<IdentityResult> AddRoleToUser(AppUser user)
		{
			throw new NotImplementedException();
		}

		public Task<string> CreateToken(LoginDto loginDto)
		{
			throw new NotImplementedException();
		}

		public async Task<SignInResult> Login(LoginDto loginDto)
		{
			AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);

			return user == null ? new SignInResult() : await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
		}

		public Task Logout()
		{
			throw new NotImplementedException();
		}

		public async Task<IdentityResult> Register(RegisterDto registerDto)
		{
			AppUser user = _mapper.Map<AppUser>(registerDto);
			
			

			IdentityResult result  = await _userManager.CreateAsync(user,registerDto.Password);
			
		
			return result;
		}
	}
}
