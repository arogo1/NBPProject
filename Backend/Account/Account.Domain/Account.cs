﻿namespace Account.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
    }
}
