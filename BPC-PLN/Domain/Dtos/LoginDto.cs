using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Dtos
{
    public class LoginDto
    {
        
        [Required(ErrorMessage = "وارد کردن نام کاربری اجباری است")]
        public string Username { get; set; }
        [Required(ErrorMessage = " وارد کردن رمز اجباری است")]
        public string Password { get; set; }
        [Required(ErrorMessage = "انتخاب نوع ورود اجباری است")]
        public DbAccessType AccessType { get; set; } = DbAccessType.Main;

    }
    public enum DbAccessType
    {
        Main,
        Provider,
        Branch
    }

  
}
