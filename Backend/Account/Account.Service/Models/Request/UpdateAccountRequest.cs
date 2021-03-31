namespace Account.Service.Models.Request
{
    public class UpdateAccountRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}