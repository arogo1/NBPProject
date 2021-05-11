using System;
using System.ComponentModel.DataAnnotations;

namespace Account.Service.Models.Request
{
    public class LoginRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
