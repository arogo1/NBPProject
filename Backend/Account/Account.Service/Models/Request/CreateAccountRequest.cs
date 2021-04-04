using System.ComponentModel.DataAnnotations;
using Account.Service.Models.Enum;

namespace Account.Service.Models.Request
{
    public class CreateAccountRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}