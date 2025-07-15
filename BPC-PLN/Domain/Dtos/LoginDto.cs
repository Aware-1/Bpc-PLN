using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Dtos
{//branch
    public class LoginBranchDto
    {
        
        public int LogicalRef { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public string Username { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public string Password { get; set; }
        [Required(ErrorMessage = "پرکردن این ورودی اجباری است")]
        public DbAccessType AccessType { get; set; } = DbAccessType.Main;

    }
    public enum DbAccessType
    {
        Main,
        Provider,
        Branch
    }


    //user
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
