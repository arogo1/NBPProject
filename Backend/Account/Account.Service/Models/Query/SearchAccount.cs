using Account.Service.Models.Enum;

namespace Account.Service.Models.Query
{
    public class SearchAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
    }
}
