using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;

namespace WriterBlog.Business.Concrete
{
	public class UserMenager : IUserService
	{
		private readonly IUserDal _userDal;

		public UserMenager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public Task<AppUser> GetUserByIdAsync(int id)
		{
			return _userDal.GetAsync(x=>x.Id==id);
		}
	}
}
