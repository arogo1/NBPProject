﻿namespace Account.Service.Models.Request
{
    public class UpdateAccountRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}