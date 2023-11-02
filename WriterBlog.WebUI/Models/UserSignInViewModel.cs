using System.ComponentModel.DataAnnotations;

namespace WriterBlog.WebUI.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifre Girin")]

        public string Password { get; set; }
    }
}
