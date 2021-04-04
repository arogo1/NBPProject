namespace Account.Service.Models.Query
{
    public class SearchAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? Role { get; set; }
    }
}