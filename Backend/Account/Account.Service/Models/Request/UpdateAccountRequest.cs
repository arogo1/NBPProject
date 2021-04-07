using System.ComponentModel.DataAnnotations;

namespace Account.Service.Models.Request
{
    public class UpdateAccountRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}