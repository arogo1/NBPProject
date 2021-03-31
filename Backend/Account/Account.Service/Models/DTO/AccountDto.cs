using System.ComponentModel.DataAnnotations;
using Account.Service.Models.Enum;

namespace Account.Service.Models.DTO
{
    public class AccountDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}