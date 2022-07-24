using CabInventoryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }

        public string? Role { get; set; } = "User";

     
    }
}
