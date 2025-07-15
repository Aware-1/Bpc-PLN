using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.User
{
    [Table("tblUser")]
    public class LoginProvider
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public string Username { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public string Password { get; set; }
    }
}
