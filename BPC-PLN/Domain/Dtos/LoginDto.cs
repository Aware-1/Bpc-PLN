using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Dtos
{
    [Table("BPC_006_BranchUsers")]
    public class LoginBranchDto
    {
        [Key]
        public int LogicalRef { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public string Username { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public string Password { get; set; }
    }


    [Table("tblUser")]
    public class LoginProviderDto
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public string Username { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public string Password { get; set; }
    }
}
