using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriterBlog.Entities.Concrete.Dtos
{
	public class LoginDto
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Lütfen Şifre Girin")]

		public string Password { get; set; }
	}
}
